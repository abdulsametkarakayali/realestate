/**
 * Fixing the missing Array.indexOf method in IE8 or other
 * @see http://stackoverflow.com/questions/3629183/why-doesnt-indexof-work-on-an-array-ie8
 */
if (!Array.prototype.indexOf)
{
  Array.prototype.indexOf = function(elt /*, from*/)
  {
    var len = this.length >>> 0;

    var from = Number(arguments[1]) || 0;
    from = (from < 0)
         ? Math.ceil(from)
         : Math.floor(from);
    if (from < 0)
      from += len;

    for (; from < len; from++)
    {
      if (from in this &&
          this[from] === elt)
        return from;
    }
    return -1;
  };
}

String.prototype.ucfirst = function() {
	return this.charAt(0).toUpperCase() + this.slice(1);
}

/**
 * Don't Act on Absent Elements - Best: Add a doOnce plugin.
 * @param func
 * @returns {jQuery.fn}
 * @see https://learn.jquery.com/performance/dont-act-on-absent-elements/
 */
jQuery.fn.doOnce = function(func) {
	this.length && func.apply(this);
	return this;
};

$(function(){
	/**
	 * Activation du sticky sur le bloc contact proprietaire detail simplifie
	 */
	if ($('.sticky-content').length) {
		$(".sticky-content").sticky({
			topSpacing:20
		});
	}
	
	/**
	 * Activation du système de menu déroulant jQuery Dropotron pour le sous-menu Mon espace
	 */
	if ($(".header-toolbox").length){
		$(".header-toolbox > div > ul").dropotron({
			menuClass: "header-toolbox-dropdown",
			expandMode: "hover"
		});
	}

	/**
	 * Autocomplete FB pour la géolocalisation (sur la home et dans la recherche)
	 * Le remplissage automatique n'est déclenché que s'il y a une valeur présente dans l'input
	 */

	var fbac_geo_el = $('#geo_objets_ids.autocomplete');
	var fbac_geo_init = function (el, data)
	{
		data = data || [];
		var options = {
			hintText: "Région, code postal, département, ville, pays...",
			noResultsText: "Aucune ville ne correspond",
			searchingText: "Recherche...",
			placeholder: "Lieu(x)",
			prePopulate: data,
			preventDuplicates: true,
			theme: 'facebook',
			searchDelay: 50
		};
		if (el.hasClass('colocataire') || el.hasClass('exemple-de-vente'))
		{
			options.tokenLimit = 1;
		}
		if (el.parent('div').attr('id') == 'geo_objets_edit')
		{
			options.onAdd = function ()
			{
				el.closest('form').submit();
			};
		}
		el.tokenInput('/index/ac-geo2', options);
	};

	if (fbac_geo_el.length > 0)
	{
		if (fbac_geo_el.val())
		{
			$.getJSON('/index/ac-geo-init?ids=' + fbac_geo_el.val(), function (data)
			{
				fbac_geo_init(fbac_geo_el, data);
			});
		}
		else
		{
			fbac_geo_init(fbac_geo_el);
		}
	}

	/**
	 * Autocomplete FB pour les métros (sur la home et dans la recherche)
	 * Le remplissage automatique n'est déclenché que s'il y a une valeur présente dans l'input
	 */

	var fbac_transport_el = $('#transport_objets_ids.autocomplete') ;
	var fbac_transport_init = function(el, data) {
		data = data || [] ;
		var options = {
			hintText         : "Indiquez une ligne ou une station de métro (Île-de-France seulement)",
			noResultsText    : "Aucune ligne ou station de métro ne correspond",
			searchingText    : "Recherche...",
			prePopulate      : data,
			preventDuplicates: true,
			theme            : 'facebook'
		} ;
		if (el.parent('div').attr('id') == 'transport_objets_edit') {
			options.onAdd = function() {
				el.closest('form').submit() ;
			} ;
		}
		el.tokenInput('/index/ac-transport', options) ;
	} ;
	if (fbac_transport_el.length > 0) {
		if (fbac_transport_el.val()) {
			$.getJSON('/index/ac-transport-init?ids='+fbac_transport_el.val(), function(data) {
				fbac_transport_init(fbac_transport_el, data) ;
			}) ;
		} else {
			fbac_transport_init(fbac_transport_el) ;
		}
	}

	/*************************************************************************
	 *** Utilisé sur plusieurs pages sur le site
	 *************************************************************************/
	
	/**
	 * Fermeture du bandeau CNIL (ancienne css)
	 */
	$('.cookie-banner').doOnce(function() {
		$('.close-button').on('click', function(c) {
			$('.cookie-banner').fadeOut('slow', function(c) {
				$('.cookie-banner').remove();
			});
		});
	});
	
	/**
	 * Placeholder Fix pour IE8
	 */
	$("input, textarea").placeholder();

	/*************************************************************************
	 *** Points Annonces
	 *************************************************************************/

	$('#map_canvas').doOnce(function ()
	{
		var latlng = [$('#map_canvas').data('map-lat'), $('#map_canvas').data('map-lng')];

		var map = new L.Mappy.Map("map_canvas", {
			clientId: "pap",
			center: latlng,
			zoom: 10,
			logoControl: {
				position: "topright",
				dir: "/vendor/api-ajax-mappy-5.2.0-37/dist/images/"
			},
			scrollWheelZoom: false,
			layersControl: {
				publicTransport: false,
				traffic: false,
				viewMode: false,
				trafficLegend: false
			}
		});

		L.marker(latlng, { icon: L.icon({
			iconUrl: '/images/icones/pinmarker-red.png',
			iconSize: [16, 24],
			popupAnchor: [0, -12]}) }).addTo(map);
	});

	// diagnostic
	if ($('#map_markers').length) {
		$data = $('#map_markers').metadata() ;

		// Carte
		var map = createMap(false, parseFloat($data.lat), parseFloat($data.lng), 'map_markers', parseInt($data.zoom)) ;
		map.enableScrollWheelZoom() ;

		// Couche de marqueurs
		var markerLayer = new Mappy.api.map.layer.MarkerLayer(40) ;
		map.addLayer(markerLayer) ;

		// Marqueurs
		var markerImage = new Mappy.api.ui.Icon(Mappy.api.ui.Icon.DEFAULT) ;
		markerImage.image = '/images/icones/pinmarker-red.png' ;
		markerImage.size  = (21, 31) ;
		$.each($data.markers, function(k, v) {
			var markerCoord = new Mappy.api.geo.Coordinates(parseFloat(v.lng), parseFloat(v.lat)) ;
			var marker = new Mappy.api.map.Marker(markerCoord, markerImage) ;
			markerLayer.addMarker(marker) ;
			marker.addListener('click', function() {
				markerLayer.closeAllPopup() ; 
				marker.openPopUp(v.tooltip) ; 
			}) ;
		}) ;

	}

	/*************************************************************************
	 *** Contenu
	 *************************************************************************/

	/** Sticky **/
	/**
	 * Affiche le sticky alerte si le site a assez de place et en fonction de la position du scroll dans la fenetre.
	 */
	var stickyNav = function() {
		// Ne s'affiche pas si la fenetre du navigateur est trop petite
		if ($(window).width() >= 1128) {
			var left = $('.main-container').offset().left - $('#sticky-alerte').width() - 15;

			if ($(window).scrollTop() >= formRechercheTop && $(window).scrollTop() <= footerTop - footerHeight) {
				$('#sticky-alerte').css({position: 'fixed', left: left + 'px', top: '50px', 'z-index': 20}).fadeIn().removeClass('hidden');
			}
			else {
				$('#sticky-alerte').css({'z-index': -1}).fadeOut();
			}
		}
		else {
			$('#sticky-alerte').css({'z-index': -1}).fadeOut();
		}
	}

	if ($('#sticky-alerte').length > 0 && $('.formulaire-recherche').length > 0)
	{
		var formRechercheTop = $('.formulaire-recherche').offset().top;
		var footerTop = $('footer').offset().top;
		var footerHeight = $('footer').height() + 50;

		// Init
		stickyNav();

		// Scroll window
		$(window).scroll(function() {
			stickyNav();
		});

		// Resize window
		$(window).resize(function() {
			stickyNav();
		});
	}
	// Fin - Sticky alerte

	// Creation alerte
	$('#formulaire-plus-criteres').doOnce(function () {

		$('#alerte-oui, #alerte-non').on('click', function (e) {
			$('#formulaire-plus-criteres-email').toggle(($(this).attr('id') === 'alerte-oui'));
		});

		var form_alerte = $(this);

		form_alerte.on('click.alerte', '.submit-button', function (e) {
			if ($('#alerte-non').is(':checked'))
			{
				return true;
			}

			var div_msg_erreurs = $('#formulaire-plus-criteres-erreurs');
			var div_loading = form_alerte.find('.loading-actif');
			var submit_button = form_alerte.find('.submit-button');

			div_msg_erreurs.find('.togglable').each(function () {
				$(this).hide();
			});

			submit_button.hide();
			div_loading.show();

			$.ajax({
				url: form_alerte.data('url'),
				type: form_alerte.attr('method'),
				data: form_alerte.serialize(),
				dataType: 'json',
				timeout: 10000,
				creation_annonce: false,
				success: function(json) {
					//console.log(json);
					if (json.reponse === 'ko') {
						div_msg_erreurs.find('.togglable').each(function () {
							$(this).toggle(!($.inArray($(this).data('erreur'), json.erreurs)));
							if ($(this).data('erreur') == 'max-annonce' && !($.inArray('max-annonce', json.erreurs))) {
								var gaq = $(this).data('gaq');
								ga('send','event',gaq.category,gaq.action,gaq.label);
							}
						});
					}
					this.creation_annonce = json.creation;
				},
				error: function(flux, status) {
					div_loading.hide();
					submit_button.show();
					form_alerte.submit();
				},
				complete: function(flux, status) {
					if (status === 'success' && this.creation_annonce === true) {
						form_alerte.submit();
					}
					div_loading.hide();
					submit_button.show();
				}
			});
			e.preventDefault();
			return false;
		});
	});
	// Fin - creation alerte

	/*****************************************************************************
	 *** Popin Création alerte e-mail
	 *****************************************************************************/
	$("#popin-creation-alerte-email").doOnce(function () {
		var popin_creation_alerte_email = $(this).dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 550,
			close: function (e, ui) {
				if (e.srcElement != undefined && popin_creation_alerte_email.data('actif') == '1') {
					var gaq = popin_creation_alerte_email.data('gaq');
					ga('send','event',gaq.category,"Refuser Creation Alerte",gaq.label);
				}
			}
		});

		if (popin_creation_alerte_email.data('actif') == '1') {
			popin_creation_alerte_email.dialog('open');
			var gaq = popin_creation_alerte_email.data('gaq');
			ga('send','event',gaq.category,gaq.action,gaq.label);
		}

		$('a.link-creation-alerte-email').on('click', function (e) {
			e.preventDefault();
			popin_creation_alerte_email.find('#popin-creation-alerte-email-origine').val($(this).data('origine'));
			popin_creation_alerte_email.dialog('open');
			return false;
		});

		popin_creation_alerte_email.on('click', 'input.btn-valider', function (e) {
			e.preventDefault();
			var form_alerte = popin_creation_alerte_email.find('form');
			var div_msg_erreurs = popin_creation_alerte_email.find('#popin-creation-alerte-email-erreur');
			var div_loading = popin_creation_alerte_email.find('.loading-actif');
			var submit_button = popin_creation_alerte_email.find('.btn-valider');

			div_msg_erreurs.find('.togglable').each(function () {
				$(this).hide();
			});

			submit_button.hide();
			div_loading.show();

			$.ajax({
				url: form_alerte.attr('action'),
				type: form_alerte.attr('method'),
				data: form_alerte.serialize(),
				dataType: 'json',
				timeout: 10000,
				creation_annonce: false,
				success: function(json) {
					//console.log(json);
					if (json.reponse === 'ko') {
						div_msg_erreurs.find('.togglable').each(function () {
							$(this).toggle(!($.inArray($(this).data('erreur'), json.erreurs)));
						});
					}
					this.creation_annonce = json.creation;
				},
				error: function(flux, status) {
					div_loading.hide();
					submit_button.show();
				},
				complete: function(flux, status) {
					div_loading.hide();
					submit_button.show();
					if (status === 'success' && this.creation_annonce === true) {
						popin_creation_alerte_email.dialog('close');
					}
				}
			});
			return false;
		});
	});

	/** Enquête **/

	$('#enquete_ville').autocomplete({
		source: '/index/ac-geo',
		minLength: 2
	}) ;

	/** Produits **/

	$("#jcarousel-produits").each(function() {
		$(this).jcarousel({start:$(this).metadata().jcarousel_start, scroll:$(this).metadata().jcarousel_scroll}) ;
	}) ;

	/*************************************************************************
	 *** Divers
	 *************************************************************************/

	/** on cache les éléments de class 'hide' **/
	$('.hide').hide() ;

	/** Toggle simple des éléments **/
	$('.toggler').click(function(){
		$('#'+ $(this).metadata().toggled_id).slideToggle() ;
		return false ;
	}) ;

	/** popup **/
	$('.popup').click(function(){
		window.open('', $(this).attr('target'), "height = " + $(this).metadata().popup_height + " ,width=" + $(this).metadata().popup_width + " ,scrollbars= " + $(this).metadata().popup_scrollbars) ; 
	}) ;

	/** Text area counter **/
	var count = function($textarea){
		$label = $('#label_' + $textarea.attr('id')+'_counter') ;
		maxlength = $textarea.metadata().textarea_counter_max ;
		curlength = $textarea.val().length ;
		remaining = Math.max(maxlength - curlength, 0) ;
		$('.remaining', $label).text(remaining) ;
		$('.curlength', $label).text(curlength) ;
		$label
			.toggleClass('ok', maxlength >= curlength)
			.toggleClass('ko', maxlength <  curlength)
			;
	}
	// Ajout du compteur
	$('.textarea_counter').each(function(){

		$label     = $('<p id="label_' + $(this).attr('id')+'_counter"' +'>') ;
		$container = $('<div>').addClass('counter').attr('id', $(this).attr('id')+'_counter') ;
		$(this).wrap($container) ;
		$label.insertAfter($(this)) ;
		texte = "<span class='light'>Reste : <span class='remaining'></span> caract&egrave;res (<span class='curlength'></span> / <span class='maxlength'>" + $(this).metadata().textarea_counter_max + "</span>)" ;
		// texte = texte + " - Nous n'acceptons pas les abréviations.</span>" ; 

		// init
		$label.html(texte) ;
		count($(this)) ;

		// events
		var interval ; 
		$(this).bind({
			focus: function() {
				$textarea = $(this) ;
				interval = setInterval(function(){
					count($textarea) ;
					}
				, 333) ;
			},
			blur: function() {
				clearInterval(interval) ;
			}
		});
	}) ;

	/*************************************************************************
	 *** Espace annonceur
	 *************************************************************************/

	/**
	 * Gestion compteur texte annonce.
	 */
	$("#annonceur_compteur").doOnce(function() {
		var max = $(this).data('max');
		var text_area = $('#texte');
		var text_affiche = $('#annonceur_compteur_affiche');
		if (text_area.val().length) {
			text_affiche.html(text_area.val().length + ' / ' + max + ' caractères');
		}
		else {
			text_affiche.html(max + ' / ' + max + ' caractères');
		}
		text_area.on('keyup', function () {
			text_affiche.html(max - text_area.val().length + ' / ' + max + ' caractères');
		});
	});

	/**
	 * Gestion de l'affichage du prix au m² dans le détail d'annonce
	 */
	$('#prix-m2').click(function() {
		$.getJSON(
			'check-prix-m2',
			{prix_m2: $(this).is(':checked') ? 1 : 0, annonce_id: $('#annonce_id').val()}
		) ;
	});

	/**
	 * Gestion de sélection des checkbox du choix d'options du formulaire du passage d'annonce
	 */
	$(".options-list-box input, .option-item input").click(function() {
		return false;
	});
	$(".options-list-box, .option-item").click(function() {
		if ($(this).hasClass("option-item"))
		{
			var class_active = 'option-item-active';
		}
		else
		{
			var class_active = 'options-list-box-active';
		}
		$(this).find('input:checkbox')[0].checked = !$(this).find('input:checkbox')[0].checked;
		if ($(this).find('input:checkbox')[0].checked)
		{
			$(this).addClass(class_active);

		} else {
			$(this).removeClass(class_active);
		}
	});

	/**
	 * Gestion affichage du formulaire de modification annonce sur la prolongation d'annonce
	 */
	$("#edit-annonce-wrapper").doOnce(function() {
		$('#edit-annonce-wrapper').bind('slide', function ()
		{
			if ($('input[id="modifier-annonce-oui"]:checked').val()) {
				$('#edit-annonce-wrapper').slideDown('slow');
			}
			else
			{
				$('#edit-annonce-wrapper').slideUp('fast');
			}
		});

		if ($('input[id="modifier-annonce-oui"]:checked').val())
		{
			$("#edit-annonce-wrapper").show();
		}
		else
		{
			$("#edit-annonce-wrapper").hide();
		}
		$('input[name="modifier-annonce"]').click(function() {
			$("#edit-annonce-wrapper").trigger('slide');
		});
	});


	/**
	 * Affichage des erreurs sur le formulaire de prolongation.
	 * Si il existe des div.alert-box, alors on retire la classe hidden dans le conteneur #suite-prolongation.
	 * Sinon, cela signifie que l'on est en debut de saisie de formulaire, donc on met la classe hidden.
	 * Cet hidden permet :
	 * - de n'afficher que les forfaits parutions, en debut de saisie de prolongation.
	 * - cet hidden n'est pas mis en php, car, cela pose des problemes avec le redimensionenemtn de la box classe énergie. Vu avec Julien
	 */
	
	$('div.alert-box').doOnce(function() {
		$('#suite-prolongation').removeClass('hidden');
		if ($("#edit-annonce-wrapper div.alert-box").length )
		{
			$('input[id="modifier-annonce-oui"]').prop('checked', true);
			$("#edit-annonce-wrapper").trigger('slide');
		}
	});
	
	$(".error-box:visible, .alert-box:visible").doOnce(function() {
		var scrollTop = $(this).offset().top - 50;
		$("html, body").animate({
			scrollTop: scrollTop
		}, 1500);
	});

	if ($('div#recapitulatif').length)
	{
		$('#block-phrase-accroche').bind('refresh', function () {
			$val = $('#option-a-la-une input[name^="a_la_une"]:checkbox:checked');
			if ($val[0])
			{
				$("#block-phrase-accroche").removeClass('hidden') ;
				$('input[id="modifier-annonce-oui"]').prop('checked', true);
				$("#edit-annonce-wrapper").trigger('slide');
			}
			else
			{
				$("#block-phrase-accroche").addClass('hidden') ;
			}
		});

		$('#recapitulatif').bind('refresh', function () {
			var tmp = {};
			var fields = $(".options-list-box input:checkbox:checked, .option-item input:checkbox:checked").serializeArray();

			tmp.session =  $("#recapitulatif").attr('session');
			tmp.codepromo = $("#recapitulatif").attr('codepromo');
			tmp.evenement =  $("#recapitulatif").hasClass('ajax');
			$.each(fields, function (i, field){
				tmp[field['name']] = field['value'];
			});
			if ($("#parution-form").length)
			{
				var parution = $('input[name^="parution"]:checked');
				if (parution.val())
				{
					tmp['parution'] = parution.val();
				}
				else if ($('#parution-form').attr('parution').length)
				{
					var parution = $('#parution-form').attr('parution');
					tmp['parution'] = parution;
				}
			}

			$('#recapitulatif').load('get-recapitulatif', tmp);
		});

		$('#recapitulatif').trigger('refresh') ;
		$('#block-phrase-accroche').trigger('refresh') ;


		// Affiche le block de la phrase d'accroche
		$("#option-a-la-une").click(function() {
			$('#block-phrase-accroche').trigger('refresh') ;
		});

		$('.options-list-box, .option-item').click( function(){
			$('#recapitulatif').trigger('refresh') ;
		});
	}


	/**
	 * Gestion de la dialog pour saisir le code promo
	 */
	if ($('#parution-form').length) {

		$('#codepromo-dialog').dialog({
			modal: true,
			autoOpen: false
		});

		$('#parution-form').bind('refresh', function () {
			$('#parution-form').load('get-parutions', {
				'session': $("#parution-form").attr('session'),
				'produit': $("#parution-form").attr('produit'),
				'parution': $("#parution-form").attr('parution'),
				'codepromo': $("input[name^='codepromo']").val(),
				'typebien': $("#parution-form").attr('typebien'),
				'geo_commune': $("#geo_commune").val()
			}, function() {
				// Ne pas afficher le conseil au début
				$('.parution-recommandation-box').hide();
				// Déclencher l'affichage si la géolocalisation est renseignée
				if ($('#geo_commune').val()) {
					$('.parution-recommandation-box').trigger('show');
				}
			});
		});

		//Si on a le bien dès le depart, on rafraichit le bloc des tarifs,
		// utilisé notament pour le renouvellement ou l'on connait deja le type de bien.
		
		if ($('#parution-form').attr('typebien').length)
		{
			$('#parution-form').trigger('refresh') ;
		}


		$('#codepromo-handler').click(function() {
			$('#codepromo-dialog').dialog('open');
			return false;
		});

		$('#codepromo-dialog #codepromo-submit').click(function(ev) {
			// Supprimer le message d'avertissement

			$('#codepromo-dialog .warning').remove();

			$.ajax({
				url: '/annonceur/passer/check-code-promo',
				data: $('#codepromo-dialog form').serialize(),
				async: false,
				success: function(res) {
					// Si la validation a échoué
					if (!res.success) {

						// Empêche l'action de validation du formulaire
						ev.preventDefault();

						// Affiche le message d'avertissement
						$('#codepromo-dialog form').before(''
							+ '<div class="ui-widget warning">'
							+ '	<div style="padding: 0 .7em;" class="ui-state-error ui-corner-all">'
							+ '		<p><span style="float: left; margin-top:0.3em;margin-right: .3em;" class="ui-icon ui-icon-alert"></span>'
							+ '		<strong>Attention :</strong> '+res.message+'</p>'
							+ '	</div>'
							+ '</div>');
					}
					else
					{
						ev.preventDefault();
						$('#codepromo-dialog').dialog('close');
						$('#parution-form').trigger('refresh') ;
					}

				}
			});
		});


	/**
	 * Gestion de sélection des boutons radio du tableau de prix du formulaire du passage d'annonce
	 */
		$('body').on('click', '.table-price-box', function() {

			$(this).find('input:radio')[0].checked = true;
			$('.table-price-box-active').toggleClass('table-price-box-active');
			$(this).toggleClass('table-price-box-active');
		});

		$('body').on('click', '.table-price-item', function() {
			$(this).find('input:radio')[0].checked = true;
			$('.table-price-item-active').toggleClass('table-price-item-active');
			$(this).toggleClass('table-price-item-active');
			$('#recapitulatif').trigger('refresh') ;

			if ($('#parution-form input:radio[name^="parution"]:checked')[0])
			{
				$('#suite-prolongation').removeClass('hidden');
				$(".single-select").multiselect({
					header: false,
					multiple: false,
					selectedList: 1,
					noneSelectedText: "Pas de s&eacute;lection",
					height: "auto"
				});
				$('html, body').animate({
					scrollTop: ($('#suite-prolongation').offset().top - 50)
				}, 1500);
			}
		});


		// Montrer l'info-box
		$('body').on('show', '.parution-recommandation-box', function(ev) {
			if ($('#geo_pays').val() != '25') {
				return;
			}
			// Recommandation, si aucun forfait n'est déjà coché
			$.getJSON('get-recommandation', {produit: $('#produit').val(), geo_objet_id: $('#geo_commune').val()}, function(json) {
				if (json == null)
					return;
				// Afficher le conseil si le forfait n'est pas un forfait 2 mois  pour les ventes, ni un forfait 1 semaine pour les locations
				if (json.forfait != '2-mois' && json.forfait != '1-semaine')
				{
					$('.parution-recommandation-box').find('.parution-info-box-moyenne').html(json.html_moyenne);
					$('.parution-recommandation-box').find('.parution-info-box-forfait').html(json.html_forfait);
					$('.parution-recommandation-box').find('.parution-info-box-ville').html(json.html_contexte+' :');
					$('.parution-recommandation-box').show();
					// Sélectionner une valeur
					if ($('#parution-form input:radio:checked').length == 0) {
						$('.table-price-box:has(#radio-'+json.forfait+')').trigger('click');
					}
				}
			});
		});
		
	}

	// passage d'annonce

	var communeList = [
		{
			id: 19895,
			slug: "blanquefort-33290",
			title: "Blanquefort (33290)",
			lat: 44.910198,
			lng: -0.637806,
			_links: {
				self: {
					href: "http://ws.pap.fr/gis/places/19895"
				}
			}
		},
		{
			id: 19920,
			slug: "le-pian-medoc-33290",
			title: "Le Pian-Médoc (33290)",
			lat: 44.9575,
			lng: -0.668323,
			_links: {
				self: {
					href: "http://ws.pap.fr/gis/places/19920"
				}
			}
		},
		{
			id: 19926,
			slug: "ludon-medoc-33290",
			title: "Ludon-Médoc (33290)",
			lat: 44.982201,
			lng: -0.603999,
			_links: {
				self: {
					href: "http://ws.pap.fr/gis/places/19926"
				}
			}
		},
		{
			id: 19932,
			slug: "parempuyre-33290",
			title: "Parempuyre (33290)",
			lat: 44.948898,
			lng: -0.604154,
			_links: {
				self: {
					href: "http://ws.pap.fr/gis/places/19932"
				}
			}
		}
	];

	$("#geolocalisation_form").doOnce(function() {
		var _geo_form = $(this);
		var pays = $('#geo_pays');
		var zone_france = $('#geo_zone_france');
		var code_postal = $('#geo_code_postal');
		var commune = $('#geo_commune');
		var adresse = $('#geo_adresse');
		var voir_carte = $('#geo_voir_carte');
		var map_avertissement = $('#geo_map_avertissement');
		var map_print = $('#geo_map_print');
		var lat = $('#geo_lat');
		var lng = $('#geo_lng');
		var zoom = $('#geo_zoom');
		var diffuser_adresse = $('#geo_diffuser_adresse');
		var erreurs = $('#geo_erreurs');

		var map = {
			mappy: false,
			marker: L.marker([48.8405899, 2.3681628],
				{
					icon: L.icon(
						{
							iconUrl: '/images/picto-geoloc-exacte.png',
							iconSize: [30, 36],
							iconAnchor: [15, 36],
							popupAnchor: [0, -40]
						}),
					draggable: true
				}),
			marker_added: false,
			change_adresse: false,

			initMap: function () {
				// permet l'accès en https
				L.Mappy.enableHttps();
				this.mappy = new L.Mappy.Map("geo_map", {
					clientId: 'pap',
					center: [46.2157467, 2.2088258],
					zoom: 2,
					zoomControl: true,
					layersControl: false,
					scrollWheelZoom: false,
					tileLayerOptions: {
						minZoom: 2,
						maxZoom: 12,
						detectRetina: true
					},
					logoControl: {
						position: "topright",
						dir: "/vendor/api-ajax-mappy-5.2.0-37/dist/images/"
					}
				});

				L.DomEvent.addListener(this.mappy, 'zoomend', function() {
					zoom.val(map.mappy.getZoom());
				});

				L.DomEvent.addListener(this.marker, "dragend", function() {
					var coords = map.marker.getLatLng();
					lat.val(coords.lat);
					lng.val(coords.lng);
				});
			},

			geocodeMap: function () {
				if (!this.change_adresse && lat.val() && lng.val() && zoom.val()) {
					this._changeCoords([lat.val(), lng.val()], zoom.val());
				}
				else {
					L.Mappy.Services.geocode(
						adresse.val() + " " + code_postal.val() + " " + commune.find('option:selected').text(),
						function (results) {
							if (results.length > 0) {
								map._changeCoords(results[0].Point.coordinates.split(",").reverse(), 9);
							}
							else {
								$.each(erreurs.find('p.toggleable'), function (k, v) {
									$(v).toggle(($(v).hasClass('error-geocode')));
								});
							}
						},
						function () {
							$.each(erreurs.find('p.toggleable'), function (k, v) {
								$(v).toggle(($(v).hasClass('error-geocode')));
							});
						}
					);
				}
			},

			_changeCoords: function (pCoords, pZoom) {
				this.marker.setLatLng(pCoords);
				this.marker.update();
				if (this.marker_added == false) {
					this.marker_added = true;
					this.marker.addTo(this.mappy).bindPopup("<div style=\"text-align:center\">Déplacez le point pour placer<br>votre logement au bon endroit</div>").openPopup();
				}
				this.mappy.setView(pCoords, pZoom, {reset: true});
				lat.val(pCoords[0]);
				lng.val(pCoords[1]);
				zoom.val(pZoom);
				this.change_adresse = false;
			}
		};

		pays.on('change', function() {
			zone_france.toggle($(this).val() == '25');
			if ($(this).val() != '25') {
				code_postal.val('');
				commune.empty().attr('disabled', 'disabled');
				adresse.val('').attr('disabled', 'disabled');
				lat.val('');
				lng.val('');
				zoom.val('');
			}
		});


		code_postal.on('propertychange input', function() {
			if ($(this).val().length == 5) {
				$.ajax({
					url: _geo_form.data('url').replace('{{cp}}', $(this).val()),
					type: 'get',
					data: {
						'recherche[cible]': 'pap-annonce'
					},
					dataType: 'json',
					async: true,
					cache: true,
					success: function (data) {
						//console.log(data);
						$.each(erreurs.find('p.toggleable'), function () {$(this).hide()});
						if (data.nb_items > 0) {
							commune.empty().removeAttr('disabled');
							adresse.removeAttr('disabled');
							$.each(data._embedded.place, function(i, value) {
								//console.log(value);
								commune.append($('<option></option>').val(value.id).html(value.title));
							});
							if (commune.data('geoid') != '') {
								commune.val(commune.data('geoid'));
								commune.data('geoid', '');
							}
							// Déclencher le rafraîchissement des forfaits
							$('#parution-form').trigger('refresh');
							var dept_cherche = code_postal.val().substr(0,2);
							if (dept_cherche=='75'||dept_cherche=='77'||dept_cherche=='78'||dept_cherche=='91'||dept_cherche=='92'||dept_cherche=='93'||dept_cherche=='94'||dept_cherche=='95')
							{
									window.optimizely.push(['setDimensionValue', 4259620556, 'idf']);

							}
							else
							{

									window.optimizely.push(['setDimensionValue', 4259620556, 'regions']);

							}
						}
						else {
							$.each(erreurs.find('p.toggleable'), function (k, v) {
								$(v).toggle(($(v).hasClass('error')));
							});
						}
					},
					error: function (x, status, msg) {
						$.each(erreurs.find('p.toggleable'), function (k, v) {
							$(v).toggle(($(v).hasClass(status)));
						});
					}
				});
			}
			else {
				commune.empty().attr('disabled', 'disabled');
				adresse.val('').attr('disabled', 'disabled');
				//voir_carte.hide();
				map_print.hide();
			}
		});
		
		$('#geo_pays,#geo_code_postal,#geo_commune').on('change', function() {
			// Déclencher le rafraîchissement des forfaits
			$('#parution-form').trigger('refresh');
		});
		
		if (commune.data('geoid') != '') {
			code_postal.trigger('input');
		}

		// Si adresse, on affiche le lien voir la carte
		adresse.doOnce(function () {
			$(this).on('focusout keypress', function(e) {
				if ($(this).val().length > 0) {
					//voir_carte.show();
					if (e.type === 'keypress') {
						map.change_adresse = true;
					}
				}
				else {
					//voir_carte.hide();
					lat.val('');
					lng.val('');
					zoom.val('');
					map_print.hide();
				}
			}).trigger('focusout');
		});

		// Quand on clique sur voir la carte
		voir_carte.doOnce(function () {
			$(this).on('click', function(e) {
				e.preventDefault();
				if (adresse.val().length) {
					map_print.show();
					if (map.mappy === false) {
						map.initMap();
					}
					map.geocodeMap();
				}
				else {
					map_avertissement.show().delay(2000).fadeOut(1000);
				}
			});
		});

		if (lat.val() && lng.val() && zoom.val()) {
			voir_carte.trigger('click');
		}

		diffuser_adresse.doOnce(function () {
			$(this).on('click', function (e) {
				lat.val('');
				lng.val('');
				zoom.val('');
				map_print.hide();
				var gaq = $(this).data('gaq');
				ga('send','event',gaq.category,gaq.action,gaq.label);
				e.preventDefault();
			});
		});
	});
	// fin passage d'annonce

	/**
	 * Divers au passage d'annonce
	 */
	
	// Compteur de texte
	$('.maxlength-handle').each(function() {
		var $handle = $(this) ;
		var $display = $('<span class="maxlength-display">') ;
		$handle.after($display) ;
		$display.bind('update', function() {
			var cur = $handle.val().length ;
			var max = parseInt($handle.attr('maxlength')) ;
			var rem = max - cur ;
			$display.text(rem + " caractères restant") ;
			$handle.toggleClass('maxlength-reached', rem <= 0) ;
			$display.toggleClass('maxlength-reached', rem <= 0) ;
		}) ;
		$handle.bind('keyup change', function() {
			$display.trigger('update') ;
		}) ;
		$display.trigger('update') ;
	}) ;

	$('.prol-maxlength-handle').each(function() {
		var $handle = $(this) ;
		var $display = $("<i>");
		$handle.after($("<div class='align-right'>").append($("<small>").append($display)) ) ;
		$display.bind('update', function() {
			var cur = $handle.val().length ;
			var max = parseInt($handle.attr('maxlength')) ;
			var rem = max - cur ;
			$display.text( rem + " caractères restant" ) ;
			$handle.toggleClass('maxlength-reached', rem <= 0) ;
			$display.toggleClass('maxlength-reached', rem <= 0) ;
		}) ;
		$handle.bind('keyup change', function() {
			$display.trigger('update') ;
		}) ;
		$display.trigger('update') ;
	}) ;

	// Valeurs qui dépendent des charges comprises
	$('input:radio[name=charges_comprises]').click(function() {
		$('.charges_comprises').each(function() {
			$(this).toggle($('input:radio[name=charges_comprises]:checked').val() == 'non') ;
		}) ;
	}) ;
	$('input:radio[name=charges_comprises]:checked').trigger('click');
	
	// Valeurs qui dépendent du type de bien
	$('#typebien').change(function() {

		$('.typebien').each(function() {
			$(this).toggle($(this).hasClass('typebien-'+$('#typebien').val())) ;

		}) ;

		$("#info-location-locaux-commerciaux").addClass("hidden") ;
		if ( $.inArray($("select[name^='typebien']").val(),['bureaux','local-commercial', 'local-d-activite','garage-parking','terrain','divers','surface-a-amenager'] )> -1)
		{
			$("label[id^='label-surface']").text('Surface : ');
			if ( $.inArray($("select[name^='typebien']").val(),['bureaux','local-commercial', 'local-d-activite'] )> -1)
			{
				$("label[id^='label-loyer']").text('Loyer TTC : ');
			}
			else
			{
				$("label[id^='label-loyer']").text('Loyer : ');
			}

			if ( $("select[name^='typebien']").val() == 'local-commercial' && $("#parution-form").attr('produit') == 'location')
			{
				$("#info-location-locaux-commerciaux").removeClass("hidden") ;
			}
		}
		else
		{
			$("label[id^='label-surface']").text('Surface habitable : ');
			$("label[id^='label-loyer']").text('Loyer : ');
		}

		//Si on change le type de bien, on rafraichit le bloc des tarifs
		$("#parution-form").attr('typebien', $("select[name^='typebien']").val());
		$('#parution-form').trigger('refresh') ;

	}) ;
	$('#typebien').trigger('change') ;

	// Valeurs qui dépendent de la civilité
	$('#client_civilite').change(function() {
		$('.civilite').each(function() {
			$(this).toggle($(this).hasClass('civilite-'+$('#client_civilite').val())) ;
		}) ;
	}) ;
	$('#client_civilite').trigger('change') ;

	/**
	 * Enregistrement des coordonnées à la volée
	 */
	
	$('#contact_email,.telephones').blur(function() {
		var list_telephone = [];
		$('.telephones').each(function () {
			if ($(this).val()) {
				list_telephone.push($(this).val());
			}
		});
		$.get('set-contacts', {session: $('#session').val(), email: $('#contact_email').val(),"telephones[]": list_telephone}, function() {
			if ($('#contact_email').val() || list_telephone) {
				ga('send','event','PASSAGE ANNONCE','Coordonnees Annonce','Enregistrer Coordonnees');
				window.optimizely.push(["trackEvent","coordonnees-enregistrement"]);
			}
		});
	});
	
	/**
	 * Page "Mes contacts"
	 */
	
	if ($('.abuse-popin').length > 0) {
		
		$('.abuse-popin').dialog({
			modal: true,
			autoOpen: false,
			resizable: false,
			width: 500,
			open: function() {
				// Fermer la dialog box quand on clique sur l'overlay
				self = $(this);
				$('.ui-widget-overlay').click(function() {
					self.dialog('close');
				});
			}
		});
		
		$('.abuse-handler').click(function() {
			var $dialog = $($(this).attr('href'));
			$dialog.find('input[name="id"]').val($(this).closest('.contact-item').data('id'));
			$dialog.removeClass('popin-sent popin-error');
			$dialog.dialog('open');
			return false;
		});
		
		$('.abuse-popin form').submit(function() {
			var $dialog = $(this).closest('.popin');
			var id = $(this).find('input[name="id"]').val();
			var action = $(this).find('input[name="action"]').val();
			$dialog.removeClass('popin-error');
			$.post($(this).attr('action'), $(this).serialize(), function(data) {
				if (data.success) {
					$('#contact_item_'+id).toggleClass('abuse-reported', action == 'report');
					$dialog.addClass('popin-sent');
				} else {
					$dialog.addClass('popin-error');
				}
			});
			return false;
		});
		
		$('.abuse-popin .popin-close').click(function () {
			$(this).closest('.popin').dialog('close');
		});
		
	}

	/*************************************************************************
	 *** Page Gestion des photos
	 *** ATTENTION: Script semble incompatible avec jquery-1.11.1 pour le plugin
	 *** https://blueimp.github.io/jQuery-File-Upload/basic.html
	 *************************************************************************/
	$('#gestion_photos').doOnce(function ()
	{
		var browser = {
			name: '',
			version: '',
			init: function ()
			{
				var isOpera = !!window.opera || navigator.userAgent.indexOf(' OPR/') >= 0;
				// Opera 8.0+ (UA detection to detect Blink/v8-powered Opera)
				var isFirefox = typeof InstallTrigger !== 'undefined';// Firefox 1.0+
				var isSafari = Object.prototype.toString.call(window.HTMLElement).indexOf('Constructor') > 0;
				// At least Safari 3+: "[object HTMLElementConstructor]"
				var isChrome = !!window.chrome && !isOpera;// Chrome 1+
				var isIE = /*@cc_on!@*/false || !!document.documentMode; // >= IE6

				//Navigateur
				this.name =
					isOpera ? 'opera' :
						isFirefox ? 'firefox' :
							isSafari ? 'safari' :
								isChrome ? 'chrome' :
									isIE ? 'ie' :
										'autre';
				//Version
				switch (this.name)
				{
					case 'ie' :
						//Version <= 10
						this.version = (function ()
						{
							if (new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})").exec(navigator.userAgent) != null)
							{
								return parseFloat(RegExp.$1);
							}
							else
							{
								return false;
							}
						})();

						if (!this.version)
						{
							//Version 11
							this.version = (!!window.MSStream) ? 11 : '-';
						}
						break;
					default :
						this.version = '-';
						break;
				}
			}
		};
		browser.init();

		//Variables DOM
		var $gestion_photos = $('#gestion_photos');
		var $file_upload_button = $(".fileupload-button");
		var $popin_edit_target = $("#popup_photo_edit");
		var $bloc_first_photo = $('body #bloc-first-photo');
		var $message_box = $('#message');
		var $bloc_progress_bar = $('#bloc-progress-bar') ;
		var $bloc_photos_online = $('body #bloc-photos-online');
		var $blocs = $("body #gestion_photos");
		var $bloc_photos_invalides = $('#bloc-photos-invalides');

		var $file_upload = $('.file_upload');
		var $compteur_photo_online = $('#bloc-photos-online .compteur-photo');
		var $new_photo = $('.new-photo');

		//Variables données
		var config = {
			taillePhoto:16000000,
			fichiersAcceptes: /(\.|\/)(jpe?g)$/i ,
			delaiAffichages:5000,
			environnement:$gestion_photos.data("gestion-photos").environnement,
			annonceReference:$gestion_photos.data("gestion-photos").annonceReference,
			referenceDirectory: $gestion_photos.data("gestion-photos").annonceReference.substring(0, 3),
			annonceId:$gestion_photos.data("gestion-photos").annonceId,
			journal:$gestion_photos.data("gestion-photos").journal,
			photosInternetMax:parseInt($gestion_photos.data("gestion-photos").photosInternet),
			nbPhotos:parseInt($gestion_photos.data("gestion-photos").nbPhotos),
			nbPhotosInvalides:parseInt($gestion_photos.data("gestion-photos").nbPhotosInvalides),
			isTransfertIframe:(browser.name = 'ie' && browser.version <= 10)
		};



		/**
		 * Popin pour les liens de la bar menu (Vos photos, Envoyer par courrier, Envoyer par mail)
		 */
		$('p.envoi-mail a').fancybox({
			padding: 10,
			margin: 0,
			type: 'inline',
			closeEffect: 'none'
		});

		var gestionPhotos = {
			success: 'succes-default',
			succes_delete: 'succes-delete',
			success_uploads: 'succes-uploads',
			erreur_dl: "error-download",
			erreur_default: "error-default",
			erreur_poids: "error-poids",
			erreur_jpg: "error-jpg",
			erreur_max: 'error-nb-max',
			erreur_ajax: 'error-ajax',
			server :  'http://upload.pap' + config.environnement,
			getCssMessage: function (action, result)
			{
				switch (action + ',' + result)
				{
					case 'inserts,0' :
						return this.success_uploads;
					case 'insert,0':
						return this.success;
					case 'insert,1':
					case 'rotate,1':
					case 'crop,1':
					case 'update,1':
					case 'update,2':
					case 'delete,1':
					case 'delete_invalide,1':
					case 'order,1':
						return this.erreur_default;
					case 'insert,2':
						return this.erreur_dl;
					case 'insert,File is too large':
					case 'insert,3':
					case 'update,3':
						return this.erreur_poids;
					case 'insert,File type not allowed':
					case 'insert,4':
					case 'update,4':
						return this.erreur_jpg;
					case 'insert,5':
						return this.erreur_max;
					case 'rotate,0':
					case 'crop,0':
					case 'update,0':
					case 'delete_invalide,0':
					case 'order,0':
						return '';
					case 'delete,0':
						return this.succes_delete;
					default:
						return this.erreur_default;
				}
			},
			getSrcImage: function (hash, thumb)
			{
				if (thumb)
				{
					return this.server + '/photos/' + config.referenceDirectory + '/' + hash + '.thumb.jpg';
				}
				return this.server + '/photos/' + config.referenceDirectory + '/' + hash + '.jpg';
			},
			setOrdre: function (order_serial)
			{
				/**
				 * Ordre des photos
				 */
				$.ajax({
					url: '/ajax/photo-update.php?action=order',
					dataType: "json",
					data: {
						reference: config.annonceReference,
						order_serial: $.param({phot: order_serial})
					},
					success: function (response)
					{
						if (response.resultat != 0)
						{
							$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('order', 0));
						}
					},
					error: function (jqXHR, textStatus, errorThrown)
					{
						$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('order', 1));
					}
				});
			},
			setDelete: function ($element, nom_unique)
			{
				/**
				 * Suppresion d'une photo
				 */

				var resultat = 0; // pour ie9
				$.ajax({
					url: '/ajax/photo-update.php?action=delete',
					dataType: "json",
					data: {
						reference: config.annonceReference,
						pho_nom_unique: nom_unique
					},
					success: function (data)
					{
						resultat = data.resultat;
						if (data.resultat == 0)
						{
							if ($element.offsetParent().attr("id") == 'bloc-photos-invalides')
							{
								config.nbPhotosInvalides--;
							}
							else
							{
								config.nbPhotos--;
							}

							$("#pho_" + nom_unique).remove();
							$blocs.trigger('refresh') ;
						}
						$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('delete', data.resultat));
					},
					error: function (jqXHR, textStatus, errorThrown)
					{
						resultat = 1;
						$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('delete', ajax_error));
					}
				});
				//Si on supprime a partir de la boite de dialogue, on ferme la boite de dialogue
				if (resultat == 0 && $('.fancybox-opened').length)
				{
					parent.$.fancybox.close();
				}

			},
			setRotate: function (angle)
			{
				/**
				 * Rotation des photo selon l'angle envoyé
				 */
				$.ajax({
					url: this.server + '/rotate.json.php?callback=?',
					dataType: "json",
					data: {
						annonces_id: config.annonceId,
						hash: $popin_edit_target.attr("data-nom"),
						angle: angle
					},
					success: function (response_new_img)
					{
						if (response_new_img.result_cdr == 0)
						{
							$.ajax({
								url: '/ajax/photo-update.php?action=rotate',
								dataType: "json",
								data: {
									reference: config.annonceReference,
									pho_nom_unique: response_new_img.hash,
									pho_nom_unique_old: $popin_edit_target.attr("data-nom"),
									pho_largeur: $popin_edit_target.attr("data-width"),
									pho_hauteur: $popin_edit_target.attr("data-height"),
									pho_journal: config.journal
								},
								success: function (data)
								{
									if (data.resultat == 0)
									{
										//Change les valeurs data et src de la nouvelle photo dans la liste
										$("#" + $popin_edit_target.attr("data-id-element")).attr({
											'data-nom': response_new_img.hash,
											'data-width': response_new_img.width,
											'data-height': response_new_img.height
										}).find('.src-photo').attr('src', gestionPhotos.getSrcImage(response_new_img.hash, false));

										//Change les valeurs data et src de la nouvelle photo dans la popin
										$popin_edit_target.attr({
											'data-nom': response_new_img.hash,
											'data-width': response_new_img.width,
											'data-height': response_new_img.height
										}).find('.photo_edit_target').attr('src', gestionPhotos.getSrcImage(response_new_img.hash, false));
									}
									else
									{
										$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('rotate', data.message));
									}
								},
								error: function (jqXHR, textStatus, errorThrown)
								{
									$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('rotate', data.message));
								}
							});
						}
						else
						{
							$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('rotate', response_new_img.result_cdr));
						}
					},
					error: function (jqXHR, textStatus, errorThrown)
					{
						$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('rotate', textStatus));
					}
				});
			},
			initUpload: function ()
			{
				/**
				 * Upload les images et si elles sont valides, ajout.
				 */
				var nb_files_uploaded = 0;
				$.ajaxSetup({cache: false});
				$file_upload.fileupload({
						acceptFileTypes: config.fichiersAcceptes,
						type: 'POST',
						maxFileSize: config.taillePhoto, // 16 MB
						dataType: 'json',
						formData: {annonces_id: config.annonceId},
						formAcceptCharset: 'utf-8',
						forceIframeTransport: config.isTransfertIframe ? true : false,
						sequentialUploads: true,
						replaceFileInput: false,
						url: config.isTransfertIframe ? this.server + '/upload-iframe-json.php' : this.server + '/upload-jquery-json.php',
						redirect: config.isTransfertIframe ? 'http://www.pap' + config.environnement + '/vendor/jQuery-File-Upload-9.8.1/cors/result.html?%s' : '',
						// Callback de début de tout upload
						start: function (e)
						{
							//permet de savoir le nombre de fichier uploadés à la fin , pour afficher un message different.
							nb_files_uploaded = 0;
							//Affichage de la barre de progression
							$bloc_progress_bar.show();
						},
						// Callback à chaque envoi de photos
						send: function (e, data)
						{
							config.nbPhotos++;
							if (config.nbPhotos > config.photosInternetMax)
							{
								config.nbPhotos = config.photosInternetMax;
								$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('insert', 5));
								return false;
							}
						},
						// Callback pour chaque upload
						done: function (e, data)
						{
							nb_files_uploaded++; //Incrémente le nombre de fichier uploadé
							//Pour chaque upload on met a jout la bdd
							$.each(data.result.files, function (index, file)
							{
								if (file.result_cdr != 0)
								{
									$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('insert', file.result_cdr));
									return;
								}

								//Enregistre la photo dans la bdd
								$.ajax({
									url: '/ajax/photo-update.php?action=insert',
									dataType: 'json',
									data: {
										reference: config.annonceReference,
										pho_nom_unique: file.hash,
										pho_largeur: file.width,
										pho_hauteur: file.height,
										pho_journal: config.journal
									},
									success: function (response)
									{
										//Actualisation de la liste de photos
										$new_photo.trigger("add_photo", file);
										//Actualisation des blocs
										if (response.resultat != 0)
										{
											$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('insert', response.message));
										}
										$blocs.trigger("refresh");
									},
									error: function (jqXHR, textStatus, errorThrown)
									{
										$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('insert', ajax_error));
									}
								});


							});
						},
						// Callback en cas d'erreur avant envoi
						fail: function (e, data)
						{
							if (config.nbPhotos == config.photosInternetMax)
							{
								$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('insert', 5));
							}
							else
							{
								$message_box.trigger("affiche_message", gestionPhotos.getCssMessage('insert', "ici"));
							}
							//Retire la barre de progression
							$bloc_progress_bar.trigger('cache') ;

							//Actualisation des blocs
							$blocs.trigger("refresh");
						},
						// Callback de la barre de progression
						progressall: function (e, data)
						{
							var progress = parseInt(data.loaded / data.total * 100, 10);
							$bloc_progress_bar.find('.progress-text').text(progress);
							$('#progress .bar').css('width', progress + '%');

							//Uploads terminés
							if (data.loaded == data.total)
							{
								//Retire la barre de progression
								$bloc_progress_bar.trigger('cache') ;
								$message_box.trigger("affiche_message", gestionPhotos.getCssMessage( (nb_files_uploaded > 0) ? 'inserts' : 'insert', 0));
							}
						}
					}
					// Callback pour chaque upload, test du fichier
				).bind('fileuploadprocessalways', function (e, data){
						var index = data.index,
							file = data.files[index];
						if (file.error)
						{
							$("#message").trigger("affiche_message", gestionPhotos.getCssMessage('insert', file.error));
							$bloc_progress_bar.trigger('cache') ;
						}
					});
			}
		};


		/**
		 * Evenement pour cacher la barre de progression
		 */
		$bloc_progress_bar.on('cache', function (){
			//On cache le bloc de la barre de progression
			$(this).fadeOut(700).queue(function ()
			{
				$(this).hide().dequeue();
			});
		});


		/**
		 * Evenement pour rafraichir les 3 blocs principaux: bloc pas de photo, bloc photo invalide, bloc photo online
		 */
		$blocs.on("refresh", function ()
		{
			$file_upload.val(''); //Supprime la valeur des input files à verifier pour ie
			$compteur_photo_online.text(config.nbPhotos);

			$bloc_first_photo.toggle( (config.nbPhotos == 0 && config.nbPhotosInvalides == 0) == true);
			$file_upload_button.toggle( (config.nbPhotos == 0 && config.nbPhotosInvalides == 0) == false);

			$bloc_photos_online.toggle((config.nbPhotos > 0) == true);
			$bloc_photos_invalides.toggle((config.nbPhotosInvalides > 0) == true) ;
		});


		/**
		 * Evenement lors de l'affichage d'un message
		 */
		$message_box.on('affiche_message', function (e, slug_class)
		{
			$(this).addClass('hidden').find(".error,.succes").hide();
			if (!slug_class)
				return;

			$(this).removeClass('hidden').find("." + slug_class).show().delay(config.delaiAffichages).fadeOut(600).queue(function ()
			{
				$(this).hide().dequeue();
			});
		});


		/**
		 * Evenement lors de l'ajout de photos
		 */
		$new_photo.on('add_photo', function (e, file)
		{
			var $copie = $(this).clone();

			$copie.attr({
				'id': 'pho_' + file.hash,
				'data-nom': file.hash,
				'data-width': file.width,
				'data-height': file.height
			})
				.find('.src-photo').attr('src', gestionPhotos.getSrcImage(file.hash)).end()
				.removeClass('new-photo hidden').addClass('clearfix box-photo');
			$copie.insertBefore($(this));
		});

		/**
		 * Popin pour toutes les images de la liste.
		 */
		$('a.photo-fancybox').livequery( function ()
		{
			var $photo_file = $(this).parents("div.box-photo");
			$(this).fancybox({
				autoSize: false,
				fitToView: false,
				beforeLoad: function ()
				{
					var photo_nom = $photo_file.attr('data-nom');
					this.width = 800;
					this.height = 650;
					$popin_edit_target.attr({
						'data-nom' : photo_nom,
						'data-width': $photo_file.attr('data-width'),
						'data-height': $photo_file.attr('data-height'),
						'data-first': $(this).find('div.premiere-photo-box').length,
						'data-id-element':$photo_file.attr("id")
					}).find('.photo_edit_target').attr('src', gestionPhotos.getSrcImage(photo_nom, false));

					//Desactive les boutons de la popin lorsque c'est dans la liste des photos refusées
					$("#action-rotation, #action-supprimer").toggle(($photo_file.offsetParent().is('#bloc-photos-invalides')) == false);
				}
			});
		});

		/**
		 * Changement d'ordre des phtoos
		 */
		$('body #bloc-photos-online').on('click', '.picto-remonter, .picto-descendre', function (e){
			var $item = $(this).parents("div.box-photo");
			var order_serial = [];
			var is_click_down = $(this).hasClass("picto-descendre");
			var $item_mobile = is_click_down ? $item.next() : $item.prev();
			if ($item_mobile.length == 0)
			{
				return;
			}

			$item_mobile.fadeTo("fast",0.07).css('z-index', 999).css('position', 'relative').animate({top: is_click_down ? '-' + $item.height() : $item.height()}, 250);
			$item.fadeTo("fast",0.07).css('z-index', 1000).css('position', 'relative').animate({top: is_click_down ? $item_mobile.height() : '-' + $item_mobile.height()}, 300, function ()
			{
				$item_mobile.css('z-index', '').css('top', '').css('position', '');
				$item.css('z-index', '').css('top', '').css('position', '');
				if (is_click_down)
				{
					$item.insertAfter($item_mobile);
				}
				else
				{
					$item.insertBefore($item_mobile);
				}
				$item.fadeTo("slow",1);
				$item_mobile.fadeTo("slow",1);
				$.each($("div[id^='pho_']"), function ()
				{
					order_serial.push($(this).data('nom'));
				});
				gestionPhotos.setOrdre(order_serial);
			});
			e.preventDefault();
		});

		/**
		 * Rotation
		 */
		$("#action-rotation").click(function (e)
		{
			gestionPhotos.setRotate(90);
			e.preventDefault();
		});

		/**
		 * Suppression photo valide/invalides
		 * on pointe sur le body pour pouvoir retrouver les .actions-supprimer ajoutés dynamiquement
		 */
		$('body').on('click', '.action-supprimer', function (e)
		{
			if (!confirm("La photo va être supprimée. Continuer ?"))
			{
				e.preventDefault();
				return;
			}
			gestionPhotos.setDelete($(this), ($(this).parents("div.box-photo").data("nom")) ? $(this).parents("div.box-photo").data("nom") : $("body #popup_photo_edit").data('nom'));
			e.preventDefault();
		});

		/**
		 * Initialisation des blocs, des inputs et de l'ordre
		 */
		$blocs.trigger('refresh') ;
		gestionPhotos.initUpload();

	});

	/*************************************************************************
	 *** MailCheck
	 *************************************************************************/

	var domains = ['gmail.com', 'yahoo.fr', 'hotmail.com', 'hotmail.fr', 'free.fr', 'wanadoo.fr', 'orange.fr', 'pap.fr', 'laposte.net', 'live.fr', 'yahoo.com', 'neuf.fr', 'sfr.fr', 'voila.fr', 'aol.com', 'club-internet.fr', 'noos.fr', 'msn.com', 'aliceadsl.fr', 'bureaux-commerces.com', 'bbox.fr', 'numericable.fr', 'cegetel.net', 'ymail.com', 'dbmail.com', 'libertysurf.fr', 'bnpparibas.com', 'me.com', '9online.fr', 'netcourrier.com', 'mac.com', 'bouygues-immobilier.com', 'yahoo.co.uk', 'sgcib.com', 'yahoo.it', 'orange-ftgroup.com', 'numericable.com', 'yahoo.es', 'gmx.fr', 'libero.it', 'googlemail.com', 'socgen.com', 'club.fr', 'marketing-lab.com', 'sanofi-aventis.com', 'live.com', 'aol.fr', 'infonie.fr', 'hsbc.fr', 'fr.ibm.com', 'worldonline.fr', 'sncf.fr', 'renault.com', 'ketb.com', 'mail.ru', 'orange.com', 'ge.com', 'nexity.fr', 'hotmail.it', 'vinci-immobilier.com', 'rocketmail.com', 'gmx.net', 'freesurf.fr', 'mgcpub.com', 'skynet.be', 'freesbee.fr', 'mpsa.com', 'web.de', 'gmx.de', 'ca-cib.com', 'gmx.com', 'edhec.com', 'bluewin.ch', 'hotmail.co.uk', 'online.fr', 'natixis.com', 'tf1.fr', 'paris.fr', 'bouwfonds-marignan.com', 'generali.fr', 'edf.fr', 'cic.fr', 'total.com', 'caissedesdepots.fr', 'icade.fr', 'bouyguestelecom.fr', 'yahoo.de', 'accenture.com', 'interieur.gouv.fr', 'essec.edu', 'francetv.fr', 'carrefour.com', 'saint-gobain.com', 'yahoo.ca', 'medicis-patrimoine.com', 'cogedim.com', 'sanofi.com', 'mageos.com', 'mail.pf', 'gadz.org', 'e-h.fr', 'senat.fr', 'haussmania.com', 'm4x.org', 'unesco.org', 'pole-emploi.fr', 'cea.fr', 'radiofrance.com', 'sfr.com', 'mailing.pap.fr', 'paris.notaires.fr', 'airfrance.fr', 'cetelem.fr', 'axa-im.com', 'badri.fr', 'umusic.com', 'canal-plus.com', 'finances.gouv.fr', 'groupe-arcade.com', 'caramail.com', 'luxe.loreal.com', 'axa.fr', 'franco-suisse.fr', 'ogic.fr', 'prisma-presse.com', 'fr.thalesgroup.com', 'rothschild.com', 'accor.com', 'danone.com', 'dpp.loreal.com', 'de-pardieu.com', 'axa.com', 'pitchpromotion.fr', 'menara.ma', 'eurosport.com', 'immotalk.com', 'upmc.fr', 'wp.pl', 'sodearif.com', 'devoteam.com', 'oecd.org', 'essca.eu', 'oddo.fr', 'adp.fr', 'dell.com', 'amundi.com', 'u-psud.fr', 'student.ecp.fr', 'transport.alstom.com', 'nrj.fr', '9business.fr', 'laposte.fr', 'skema.edu', 'developpement-durable.gouv.fr', 'alcatel-lucent.com', 'tiscali.it', 'microsoft.com', 'sungard.com', 'esc-montpellier.com', 'valeo.com', 'caceis.com', 'sage.com', 'cisco.com', 'marmara.com', 'vinci-construction.fr', 'pagesjaunes.fr', 'lefigaro.fr', 'inserm.fr', 'yahoo.gr', 'mail.com', 'modulonet.fr', 'btinternet.com', 't-online.de', 'deloitte.fr', 'baml.com', 'hp.com', 'essec.fr', 'dgfip.finances.gouv.fr', 'accuracy.com', 'easycare.fr', 'magic.fr', 'festival-russe.fr', 'linklaters.com', 'justice.fr', 'capgemini.com', 'culture.gouv.fr', 'labanquepostale.fr', 'sciences-po.org', 'yandex.ru', 'spartel.fr', 'homelikehome.com', 'eiffage.com', 'ca-cf.fr', 'centraliens.net', 'barclays.fr', 'nordnet.fr', 'fr.loreal.com', 'interconstruction.fr', 'bpce.fr', 'bouygues-construction.com', 'lycos.com', 'gmx.ch', 'qq.com', 'mailhec.com', 'mondadori.fr', 'fr.pwc.com', 'rd.loreal.com', 'immobilierelutece.fr', 'psychosomatique.eu', 'lncsa.com', 'constructa.fr', 'imagina.mc', 'cnamts.fr', 'yahoo.com.cn', 'umbriafelix.it', 'omd.com', 'maureletprom.fr', 'france3.fr', 'banque-france.fr', 'rockfon.fr', 'evolis.fr', 'atosorigin.com', 'winston.com', 'tin.it', 'fr.nestle.com', 'em-lyon.com', 'bcg.com', 'novartis.com', 'no-log.org', 'arval.fr', 'naievolis.fr', 'bpimmo.com', 'cpoconsulting.com', 'bt.com', 'yopmail.com', 'oracle.com', 'cityzen.fr', 'telenet.be', 'groupegambetta.fr', 'mbrico.com', 'yahoo.com.br', 'nsn.com', 'cnam.fr', 'cgv-immo.fr', 'yahoo.co.jp', 'lcl.fr', 'essilor.fr', '360media.fr', 'lagardere-active.com', 'jpmorgan.com', 'iliad.fr', 'hi-media.com', 'arcelormittal.com', 'airliquide.com', 'hachette-livre-intl.com', 'ddb.fr', 'betc.eurorscg.fr', 'allianz.fr', 'ti.com', 'numeo.fr', 'gdfsuez.com', 'electre.com', 'axway.com', 'aprionis.fr', 'ap-hm.fr', 'prosodie.com', 'power.alstom.com', 'ms.com', 'isit-paris.eu', 'areva.com', 'unilever.com', 'sos-racisme.org', 'lyxor.com', 'ratp.fr', 'o2.pl', 'lvmh.fr', 'eurocopter.com', 'samusocial-75.fr', 'generale-de-protection.fr', 'franprix.fr', '3ds.com', 'cmcics.com', 'ag2r.com', 'fiat.com', 'conseil-etat.fr', 'cabinet-thesis.fr', 'blotimmobilier.fr', 'barcap.com', 'att.net', 'rte-france.com', 'pasteur.fr', 'otenet.gr', 'netmakers.fr', 'lncsa.fr', 'leguern.net', 'gemalto.com', 'ibssc.com', 'groupe-bpi.com', 'fr.ey.com', 'france-terre.fr', 'yahoo.ie', 'pagepersonnel.fr', 'resmed.fr', 'jbaproduction.com', 'alm.fr', 'alice.it', 'credit-suisse.com', 'sat.aphp.fr', 'mazars.fr', 'jen-mood.com', 'ign.fr', 'dalkia.com', 'techdata.fr', 'richard-sons.com', 'credit-agricole-sa.fr', 'vkleck.org', 'lexisnexis.fr', 'hermes.com', 'eurorscg.fr', 'email.cz', 'waika9.com', 'notoriouscommunication.com', 'lazard.fr', 'fullsix.com', 'thomsonreuters.com', 'infinim.fr', 'eslnetwork.com', 'curie.fr', 'comcast.net', 'xerox.com', 'univ-savoie.fr', 'sopragroup.com', 'lemonde.fr', 'inwind.it', 'fiducial.net', 'bull.net', 'afd.fr', '24ip.com', 'virgilio.it', 'thalesgroup.com', 'jeantet.fr', 'egp.aphp.fr', 'db.com', 'netscape.net', 'fr.bosch.com', 'cofely-gdfsuez.com', 'altareacogedim.com', 'triege.ch', 'lexpress.fr', 'gmx.it', 'econocom.com', 'bms.com', 'sidexa.fr', 'morganstanley.com', 'ina.fr', 'illy.fr', 'hachette-livre.fr', 'e-epitech.com', 'disney.com', 'ces.fr', 'artcurial.com', 'ansaldo-sts.fr', 'showroomprive.com', 'nozbone.com', 'france2.fr', 'colim.fr', 'cegetel.rss.fr', 'cargill.com', 'blancmarine.asso.fr', 'peugeot.com', 'jeumontelectric.com', 'immoadomicile.com', 'gs.com', 'fnac.net', 'esitpa.fr', 'creathema.fr', 'cafec.com', 'allenovery.com', 'wyckaert.info', 'parisdescartes.fr', 'adequation-marketing.com', 'svp.com', 'rff.fr', 'estellegoldfarb.com', 'dila.gouv.fr', 'cubaa.eu', 'caratge.com', 'rbccm.com', 'imelavi.fr', 'hhprintmanagement.com', 'dauphine.fr', 'clinique-bellevue.com', 'cabinets.finances.gouv.fr', 'bowiewonderworld.com', 'tvbase.net', 'oat.fr', 'm6.fr', 'lexmark.fr', 'eurokapi.fr', 'ensmp.fr', 'diplomatie.gouv.fr'];
	$('.mailcheck').blur(function(){
		var input = $(this);
		input.mailcheck({
			domains : domains,
			suggested : function(element, suggestion){
				input.next('div').remove();
				$('<div class="aide-email erreur"/>').insertAfter(input).append('Vouliez-vous écrire <a href="#">'+suggestion.full+'</a>').find('a').click(function(e){
					e.preventDefault();
					input.val($(this).text());
					input.trigger('blur');
				}); 
			},
			empty : function(element){
				input.next('div').remove();
			}
		})
	}) ;

	/*************************************************************************
	 *** Rubrique diagnostics
	 *************************************************************************/

	$(".tooltips .tip-handler").hover(function () {
		$(this).next('.tip').toggle() ;
	}) ;
	
	if ($('iframe#auto-height').length > 0) {
		$('iframe#auto-height').iframeHeight({
			minimumHeight: 400,
			defaultHeight: 1000
//			heightOffset: 150
		}) ;
	}

	/*************************************************************************
	 *** Guides & Contrats
	 *************************************************************************/

	$('#guides-et-contrats a.fancybox').each(function(i,data) {
		$(this).fancybox() ;
	}) ;

	/*************************************************************************
	 *** Recherche
	 *************************************************************************/

 	/**
	 * Texte de chaussette guide ville placé sous le titre H1 et positionné en JS dans la sidebar.
	 * Utilise deux wrappers <div id="seo-guide-ville-src"> et <div id="seo-guide-ville-dst">.
 	 */

	$('#seo-guide-ville-src').removeClass('hidden').appendTo('#seo-guide-ville-dst');

	var seoPopinGuideVille = $('#seo-guide-ville-src .guide-ville .details-seo-guide-ville').dialog({
		autoOpen: false,
		modal: true,
		resizable: false,
		draggable: false,
		width: 750,
		buttons: {
			"Fermer": function () {
				$(this).dialog('close');
			}
		},
		open: function() {
			// Fermer la dialog box quand on clique sur l'overlay
			self = $(this);
			$('.ui-widget-overlay').click(function() {
				self.dialog('close');
			})
		}
	});

	$('<a href="#">&nbsp;</a>').prependTo(seoPopinGuideVille) ;

	$('.guide-ville .header .suite').click(function() {
		seoPopinGuideVille.css({'max-height': $(window).height()-300, 'overflow-y': 'auto'});
		seoPopinGuideVille.parent().css({position:"fixed"});
		seoPopinGuideVille.dialog('open');
		return false;
	});

	// FIN Seo chaussette guide ville

	/**
	 * Tout le bloc de description de l'annonce est cliquable
	 */
	$('.search-results-list-container .annonce .description p').click(function() {
		var gaq = $(this).data('gaq');
		ga('send','event',gaq.category,gaq.action,gaq.label);
		window.location = $(this).parent().find('a.button').attr('href') ;
	}) ;
	// Fin

	/**
	 * recherche par carte
	 */
	$("#recherche-map").doOnce(function ()
	{
		var map = new L.Mappy.Map("recherche-map", {
			clientId: "pap",
			center: [48.8566667, 2.3509871],
			zoom: 5,
			logoControl: {
				position: "topright",
				dir: "/vendor/api-ajax-mappy-5.2.0-37/dist/images/"
			},
			scrollWheelZoom: false,
			layersControl: {
				publicTransport: true,
				traffic: false,
				viewMode: false,
				trafficLegend: false
			}
		});

		var markers = [];
		var zones = [];
		var geo_objets = [];

		// marqueur simple
		var myMarkerImage = L.icon({
			iconUrl: '/images/marker-mappy.png',
			iconSize: [20, 20],
			popupAnchor: [0, -10]
		});

		// marqueur déjà consulté
		var myMarkerImageVu = L.icon({
			iconUrl: '/images/marker-dejavu-mappy.png',
			iconSize: [20, 20],
			popupAnchor: [0, -10]
		});

		// marqueur a la une
		var myMarkerImageALaUne = L.icon({
			iconUrl: '/images/marker-alaune-mappy.png',
			iconSize: [20, 20],
			popupAnchor: [0, -10]
		});

		$.ajax({
			type: 'POST',
			url: '/recherche/liste/ajax-liste-annonces',
			dataType: 'json',
			data: {
				q: $(this).attr('data-route')
			},
			success: function (data)
			{
				var nbMarker = 0;
				var cookValue = getCookie('recherche_carte[dejavu]');

				//  on boucle sur toutes les annonces
				for (i = 0; i < data._embedded.annonce.length; i++)
				{
					var annonceObj = data._embedded.annonce[i];
					var annonceId = annonceObj.id;

					// si l'annonce est géolocalisée
					if (annonceObj.marker)
					{
						var latlng = [annonceObj.marker.lat, annonceObj.marker.lng];
						var texte = createTexte(annonceObj, true);

						// choix du marqueur affiché
						// marqueur par défaut
						var imgObj = myMarkerImage;
						// cas du marqueur à la une
						if (annonceObj.a_la_une == 1)
						{
							var imgObj = myMarkerImageALaUne;
						}
						// cas du marqueue déjà vu
						if (cookValue.search(annonceId + '-') >= 0)
						{
							var imgObj = myMarkerImageVu;
						}

						// création et ajout du marqueur sur la carte
						markers.push(L.marker(latlng, { icon: imgObj }).bindPopup(texte, { minWidth: 330 }));

						// on compte le nombre d'annonce géolocalisées
						nbMarker++;
					}
					// cas des annonces non géolocalisées
					else
					{
						var placeObj = annonceObj._embedded.place[0];
						// tableau des geo_objets à afficher
						if (geo_objets.indexOf(placeObj.id) < 0)
						{
							geo_objets.push(placeObj.id);
						}
						var texte_tmp = createTexte(annonceObj, false);

						zones[placeObj.id] = {
							'id': placeObj.id,
							'lat': placeObj.lat,
							'lng': placeObj.lng,
							'title': placeObj.title,
							'nb_annonces': ((zones[placeObj.id]) ? zones[placeObj.id].nb_annonces + 1 : 1),
							'texte': ((zones[placeObj.id]) ? zones[placeObj.id].texte : '') + texte_tmp
						};
					}
				}

				// affichage des marqueurs des annonces non géolocalisées
				for (var k = 0; k < geo_objets.length; k++)
				{
					var obj = geo_objets[k];
					var latlng = [zones[obj].lat, zones[obj].lng];
					var texte = "<span class='no-geoloc-status'>Annonces non-géolocalisées</span>" +
						"<h2 class='no-geoloc-location'>" + zones[obj].title + "</h2>" +
						" <div class='no-geoloc-annonces'>" + zones[obj].texte + '</div>';

					// marqueur zone
					var myMarkerImageZone = L.divIcon({
						className: 'marker-zone-mappy',
						iconSize: [30, 30],
						popupAnchor: [0, -15]
					});

					// permet d'afficher le nombre d'annonce sur le marqueur
					myMarkerImageZone.options.html = zones[obj].nb_annonces;

					// création et ajout du marqueur sur la carte
					markers.push(L.marker(latlng, { icon: myMarkerImageZone }).bindPopup(texte));
				}

				// ajout des marqueur sur le layer
				var markerLayer = L.featureGroup(markers).addTo(map);
				markerLayer.on('click', showMarker);


				// centre la carte en fonction des marqueurs affichés
				if (data._embedded.annonce.length == 1)
				{
					map.fitBounds(markerLayer.getBounds(), {maxZoom: 5});
				}
				else
				{
					map.fitBounds(markerLayer.getBounds());
				}

				// mets à jour le nombre d'annonce géolocalisé
				$('.display-options').append('<p>' + nbMarker + ' annonce' + (nbMarker > 1 ? 's' :'') + ' géolocalisée' + (nbMarker > 1 ? 's' :'') + ' sur ' + data._embedded.annonce.length + '</p>');
			}
		});

		function showMarker ()
		{
			$('.vignette img').resizecrop({
				width:102,
				height:102
			});

			$('div.details-text').doOnce(function ()
			{
				$(this).each(function () {
					var popup_annonce_id = $(this).attr('data-popup-id');
					if (_PJS && popup_annonce_id != '-')
					{
						eStat_id.serial('240040202756');
						eStat_id.master('09142');
						eStat_id.action('V');
						eStat_id.typ_prod('recherche');
						eStat_id.mrq_prod('liste');
						eStat_id.ref_prod(popup_annonce_id);
						eStat_id.nbr('1');
						eStat_id.ca_engdr('0');
						eStat_tag.post('ma');
					}
				});
			});

			$('#popup').doOnce(function ()
			{
				var popup_annonce_id = $(this).attr('data-popup-id');
				if (_PJS && popup_annonce_id != '-')
				{
					eStat_id.serial('240040202756');
					eStat_id.master('09142');
					eStat_id.action('V');
					eStat_id.typ_prod('recherche');
					eStat_id.mrq_prod('liste');
					eStat_id.ref_prod(popup_annonce_id);
					eStat_id.nbr('1');
					eStat_id.ca_engdr('0');
					eStat_tag.post('ma');
				}
			});
		}

		/**
		 * Retourne le détail d'annonce formaté pour la popin dans la carte en fonction de si elle est géolocalisée ou non
		 * @param annonceObj
		 * @param is_geoloc
		 * @returns {string}
		 */
		function createTexte(annonceObj, is_geoloc)
		{
			// cas des annonces géolocalisées
			if (is_geoloc)
			{
				var titre = annonceObj.produit.ucfirst();
				if (annonceObj.typebien)
				{
					titre += ' ' + annonceObj.typebien;
				}
				if (annonceObj.surface)
				{
					titre += ' ' + annonceObj.surface + '&nbsp;m²';
				}
				if (annonceObj._embedded.place[0].title)
				{
					titre += ' ' + annonceObj._embedded.place[0].title;
				}

				var texte = '<ul class="blocs-annonce blocs-annonce-mappy">' +
					'<li class="bloc-annonce clearfix" data-popup-id="' + annonceObj.id + '" id="popup">' +
					'<a href="' + annonceObj._links.desktop.href + '-carte" class="title-annonce">' + titre + '</a>';
					if (annonceObj.texte_accroche)
					{
						texte += '<div class="coup-de-coeur">' + annonceObj.texte_accroche.substr(0, 30) + '...</div>';
					}
					texte += '<div class="clearfix">' +
					'<div class="vignette">' +
					'<span style="width: 102px; height: 102px; overflow: hidden; display: inline-block; vertical-align: middle; position: relative;"><img src="' + annonceObj._embedded.photo[0]._links.self.href + '" alt="" style="display: block; height: 102px; left: -25.5px; top: 0px; position: relative;"></span>' +
					'<span class="prix-annonce">' + number_format(annonceObj.prix, 0, ',', '.') + ' <span class="euro">&euro;</span></span>' +
					'</div>' +
					'<div class="description-annonce">' +
					'<ul class="clearfix">';

					if (annonceObj.nb_pieces)
					{
						texte += '<li>Pièce' + ((annonceObj.nb_pieces > 1) ? 's' : '') + '<span>' + annonceObj.nb_pieces + '</span></li>';
					}
					if (annonceObj.nb_chambres_max)
					{
						texte += '<li>Chambre' + ((annonceObj.nb_chambres_max > 1) ? 's' : '') + '<span>' + annonceObj.nb_chambres_max + '</span></li>';
					}
					if (annonceObj.surface)
					{
						texte += '<li class="last">Surface<span>' + annonceObj.surface + ' <span class="metre-carre">m<sup>2</sup></span></span></li>';
					}

				texte += '</ul>' +
					'<a href="' + annonceObj._links.desktop.href + '-carte" class="btn-details">Détails</a>' +
				'</div>' +
				'</div>' +
				'</li>' +
				'</ul>';
			}
			// cas des annonces non-géolocalisées
			else
			{
				var texte = '<div class="bloc-annonce-no-geoloc">' +
						'<div class="details-text" data-popup-id="' + annonceObj.id  + '">' +
							'<div class="type-bien-prix">' + annonceObj.typebien.ucfirst() + ' : ' + '<span class="prix">' + number_format(annonceObj.prix, 0, ',', '.') + ' &euro;</span></div>' ;
							if (annonceObj.nb_chambres_max)
							{
								texte += annonceObj.nb_chambres_max + ' chambre' + ((annonceObj.nb_chambres_max > 1) ? 's' : '') + ' ';
							}
							if (annonceObj.nb_pieces)
							{
								texte += annonceObj.nb_pieces + ' pièce' + ((annonceObj.nb_pieces > 1) ? 's' : '') + ' ';
							}
							if (annonceObj.surface)
							{
								texte += annonceObj.surface + ' <span class="metre-carre">m<sup>2</sup>';
							}
							texte += '</span>' +
						'</div>'+
						'<div class="btn-details-container">' +
							'<a href="' + annonceObj._links.desktop.href + '-carte" class="title-annonce">Détails</a>' +
						'</div><br />' +
					'</div>';
			}

			return texte;
		}

			});

	/*****************************************************************************
	 *** Mensualité
	 *****************************************************************************/

	/**
	 * Popin de calcul de la mensualité
	 */
	$('#popin-mensualite').dialog({
		autoOpen: false,
		modal: true,
		resizable: false,
		width: 650,
		open: function() {
			// Fermer la dialog box quand on clique sur l'overlay
			self = $(this);
			$('.ui-widget-overlay').click(function() {
				self.dialog('close');
			})
		}
	});

	mensualite_prerempli = function(is_detail, prix, prix_notaire) {
		// on vide la mensualité
		$('#mensualites-resultats').html('');

		if (prix == prix_notaire)
			$('.prix-notaire').hide() ;
			
		// mise à jour du prix
		$('.prix-bien').children('span').html(number_format(prix, 0, ',', '.') + '&nbsp;&euro;');
		$('.prix-notaire').children('span').html(number_format(prix_notaire, 0, ',', '.') + '&nbsp;&euro;');
		$('#prix').val(prix_notaire);

		// apport personnel
		// on un cookie
		if (getCookie('calcul_mensualite[apport_personnel]').length > 0)
		{
			var apport_personnel = getCookie('calcul_mensualite[apport_personnel]');
			if (apport_personnel > prix_notaire)
			{
				apport_personnel = prix_notaire;
			}
			$('#apport-perso').val(apport_personnel);
		}
		// on a pas de cookie
		else
		{
			var apport_personnel = Math.round(prix_notaire * 0.3) ;
			$('#apport-perso').attr('placeholder', apport_personnel);
		}

		// montant emprunt
		var montant_emprunt = prix_notaire - apport_personnel;
		$('#montant-emprunt').val(montant_emprunt);

		// taux pret
		// on un cookie
		if (getCookie('calcul_mensualite[taux]').length > 0)
		{
			var taux_pret = getCookie('calcul_mensualite[taux]');
		}
		// on a pas de cookie
		else
		{
			var taux_pret = 3.3;
			// $('#taux-interet').attr('placeholder', taux_pret);
		}
		$('#taux-interet').val(taux_pret);

		// taux assurance
		// on un cookie
		if (getCookie('calcul_mensualite[taux_assurance]').length > 0)
		{
			var taux_assurance = getCookie('calcul_mensualite[taux_assurance]');
		}
		// on a pas de cookie
		else
		{
			var taux_assurance = 0.1;
			// $('#taux-assurance').attr('placeholder', taux_assurance);
		}
		$('#taux-assurance').val(taux_assurance);

		return false;
	};


	if ($('.simulation-financement-container').length > 0)
	{
		mensualite_prerempli(true, $('.mensualite-dialog').metadata().prix_bien, $('.mensualite-dialog').metadata().prix_notaire);
	}
	else
	{
		$('.search-results-list .mensualite-dialog').click(
			function () {
				mensualite_prerempli(false, $(this).metadata().prix_bien, $(this).metadata().prix_notaire);

				// tracking page virtuelle
				ga('send','pageview','/recherche/fonctionnalites/calculer-votre-mensualite');

				$('#popin-mensualite').dialog('open');
				$('#form-mensualite .btn-calculer').click();
				return false;
			}
		);
	}

	mensualite_submit = function(){

		if ($('.simulation-financement-container').length > 0) {
			if (mensualite_submit.noCountClick === false) {
				ga('send','event','DETAIL VENTE','Calculer Mensualite','Content');
			}
			mensualite_submit.noCountClick = false;
		}
		else {
			ga('send','event','LISTE VENTE','Calculer Mensualite','Popin');
		}

		var form_id = $(this).parents("form")[0].id;
		var annonces = [];
		$('.mensualite-dialog').each(function() {
			annonces.push({prix: $(this).metadata().prix_notaire, annonce_id: $(this).metadata().annonce_id});
		});

		$.ajax({
			url:  '/ajax/ajax-mensualite.php',
			type :'POST',
			dataType: 'json',
			data: {
				annonces: annonces,
				montant_emprunt : $('#' + form_id + ' input[name^="montant_emprunt"]').val(),
				apport_personnel : $('#' + form_id + ' input[name^="apport_personnel"]').val(),
				prix : $('#' + form_id + ' #prix').val(),
				taux_pret : $('#' + form_id + ' input[name^="taux_pret"]').val(),
				taux_assurance : $('#' + form_id + ' input[name^="taux_assurance"]').val(),
				submit: 1
			},
			success: function(result) {

				if (result.erreurs)
				{
					var arr = result.erreurs;

					for (var i = 0; i < arr.length; i++)
					{
						var field = $('#' + form_id + ' input[name^="' + arr[i].type + '"]');
						field.addClass('error');

						if (field.siblings('.txt-error').length == 0)
						{
							field.after('<span class="txt-error">' + arr[i].message + '</span>');
						}
					}
				}
				else
				{
					$('#form-mensualite input').each(function ()
					{
						if ($(this).hasClass('error'))
						{
							$(this).removeClass('error');
						}

						if ($(this).siblings('.txt-error').length > 0)
						{
							$(this).siblings('.txt-error').remove();
							$(this).children('span').html('');
						}
					});
				}
				if (result.htmlcontent)
				{
					if (result.htmlcontent.length > 0)
					{
						var tableau = result.htmlcontent;
						var table = $('<table></table>');
						table.append('<thead><tr><td>Durée</td><td>Mensualité</td><td>Coût de l\'emprunt</td></tr></thead><tbody>');
						for (i = 0; i < tableau.length; i++)
						{
							table.append('<tr><td>' + tableau[i].duree + ' ans</td><td>' + number_format(tableau[i].montant, 2, ',', '.') + '&nbsp;&euro; / mois</td><td>' + number_format(tableau[i].cout, 0, ',', '.') + '&nbsp;&euro;</td></tr>');
						}
						table.append('</tbody>');
						if ($('.comparaison-mensualites').length > 0)
						{
							$('.comparaison-mensualites').html(table);
						}
						else if ($('.popin-comparaison-mensualites').length > 0)
						{
							$('.popin-comparaison-mensualites').html(table);
						}
					}
				}
				if (result.mensualite)
				{
					var hrml_mensualite = '<div class="resultats">' + number_format(result.mensualite, 2, ',', '.') + '<span>&nbsp;&euro; / mois</span></div>';
					if ($('.comparaison-mensualites').length > 0)
					{
						hrml_mensualite += '<a href="#" class="btn-comparaison-mensualites">Comparer les mensualités</a>';
					}
					$('#mensualites-resultats').html(hrml_mensualite);
					$('a.btn-comparaison-mensualites').click(function() {
						$('.comparaison-mensualites').slideToggle('400');
						return false;
					});
				}
				if (result.new_mensualite)
				{
					var arr = result.new_mensualite;

					for (var i = 0; i < arr.length; i++)
					{
						$('.mensualite-dialog').each(function() {
							if ($(this).metadata().annonce_id == arr[i].annonce_id)
							{
								if (arr[i].new_mensualite == 0)
								{
									$(this).children('span').html('');
								}
								else
								{

									$(this).children('span').html('<span>à partir de ' + arr[i].new_mensualite + ' / mois</span><sup>*</sup>');
								}
							}
						});

					}

				}
			}
		}) ;

		return false;
	};

	// calcul automatique du montant emprunté
	$('#form-mensualite #apport-perso').keyup(function() {
		var montant_emprunt = $('#prix').val() - $('#apport-perso').val();
		if (montant_emprunt > 0)
		{
			$('#form-mensualite #montant-emprunt').val(montant_emprunt);
		}
	});

	/**
	 * Formulaire mensualité dans le détail annonce
	 */
	mensualite_submit.noCountClick = false;
	$('#form-mensualite .btn-calculer').click(mensualite_submit);
	// Si page detail alors lance l'event on click pour simuler le premier calcul et remplir la page.
	if ($('.simulation-financement-container').length > 0)
	{
		mensualite_submit.noCountClick = true;
		$('#form-mensualite .btn-calculer').click();
	}

	/*****************************************************************************
	 *** Popin Contact propriétaire - liste annonce
	 *****************************************************************************/
	
	$("a.btn-liste-contact-email-popin").doOnce(function () {
		var popin = $($(this).attr('href'));
		var form = popin.find('form');
		var popin_confirmation = $(popin.data('popinConfirmation'));

		popin.dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 650,
			dialogClass: "popin-blue",
			open: function () {
				// Fermer la dialog box quand on clique sur l'overlay
				self = $(this);
				$('.ui-widget-overlay').click(function () {
					self.dialog('close');
				})
			}
		});

		this.click(function (e) {
			var annonce_id = $(this).data('annonceId');
			popin.find('.togglable').each(function () {
				$(this).toggle(!($.inArray(annonce_id, $(this).data('annoncesIds')) == -1));
			});
			$('#popin-contact-proprietaire-emain-annonce-id').val(annonce_id);
			popin.data('gaq', $(this).data('gaqSend')).dialog("open");
			popin_confirmation.data('simulation', $(this).data('simulation'));
			form.find('span.txt-error').hide();
			form.find('.error').removeClass('error');
			e.preventDefault();
			return false;
		});

		/**
		 * Popin pour confirmation envoi mail contact annonceur.
		 * Si 'div#popin-contact-proprietaire-email-confirmation' est présent afficher la popin.
		 */
		popin_confirmation.dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 650,
			close: 'Fermer',
			position: {my: 'center', at: 'center', of: window},
			buttons: {
				'Fermer': function () {
					$(this).dialog('close');
				}
			},
			open: function () {
				$(this).find('div.details-annonce-container').toggle(popin_confirmation.data('simulation'));
				// Fermer la dialog box quand on clique sur l'overlay
				self = $(this);
				$('.ui-widget-overlay').click(function () {
					self.dialog('close');
				})
			}
		});

		/**
		 * Traitement du contact annonceur
		 */
		$('#popin-contact-proprietaire-emain-bouton').on('click', 'input.btn-envoyer-message', function (e) {
			// on remplace le bouton par le loader
			var div_bouton = $(this);
			var div_loading = $('#popin-contact-proprietaire-email-loading');
			var form_creation_alerte = $('#recherche-liste-formulaire-creation-alerte');

			div_bouton.hide();
			div_loading.show();

			$.ajax({
				url: form.attr('action'),
				type: form.attr('method'),
				data: form.serialize(),
				success: function (json) {
					form.find('span.txt-error').hide();
					form.find('.error').removeClass('error');

					// si il n'y a pas d'erreur
					if (json.success)
					{
						var gaq = popin.data('gaq');
						ga('send','event',gaq.category,gaq.action,gaq.label);
						popin.dialog("close");
						popin_confirmation.dialog("open");

						var i_email = $('#popin-contact-proprietaire-email-email');
						var i_alerte_email = form.find('input[name^="alerte_email"]:checked').length;
						if (i_alerte_email == 1) {
							form_creation_alerte.find('#creation-alerte-email').val(i_email.val());
							$.ajax({
								url: form_creation_alerte.attr('action'),
								type: form_creation_alerte.attr('method'),
								data: form_creation_alerte.serialize(),
								success: function (json_alerte) {}
							});
						}
							window.optimizely.push(["trackEvent", "contact-email"]);;

						   window.optimizely.push(["trackEvent", "contact-email-liste"]);

					}
					else
					{
						$.each(json.message, function (k, v) {
							$('#popin-contact-proprietaire-email-' + k).addClass('error').next().show().html(v);
						});
					}

					// on affiche le bouton et on masque le loading
					div_bouton.show();
					div_loading.hide();
				}
			});
			e.preventDefault();
			return false;
		});
		// fin du traitement du contact annonceur
	});

	/*****************************************************************************
	 *** Popin Contact propriétaire
	 *****************************************************************************/
	$("a.btn-contact-email-popin").doOnce(function() {
		var popin = $("#popin-contact-proprietaire-email");
		popin.dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 650,
			dialogClass: "popin-blue",
			open: function() {
				// Fermer la dialog box quand on clique sur l'overlay
				self = $(this);
				$('.ui-widget-overlay').click(function() {
					self.dialog('close');
				})
			}
		});

		this.click(function() {
			popin.dialog("open");
			return false;
		});


		/**
		 * Popin pour confirmation envoi mail contact annonceur.
		 * Si 'div#popin-form-contact' est présent afficher la popin.
		 */
		var popin_confirmation = $("#popin-form-contact");
		popin_confirmation.dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 650,
			close: 'Fermer',
			position: {my: 'center', at: 'center', of: window},
			buttons: {
				'Fermer': function() {
					$(this).dialog('close');
				}
			},
			open: function() {
				// Fermer la dialog box quand on clique sur l'overlay
				self = $(this);
				$('.ui-widget-overlay').click(function() {
					self.dialog('close');
				})
			}
		});

		/**
		 * Traitement du contact annonceur
		 */
		$('#btn-envoyer-message').click(function(e) {
			// on remplace le bouton par le loader
			div_bouton = $('#btn');
			div_loading = $('#loading');
			div_bouton.hide();
			div_loading.show();

			var form = $('#form-contact-annonceur');
			$.ajax({
				url: '/recherche/detail/ajax-contact-annonceur',
				type: 'POST',
				data: form.serialize(),
				success: function(json) {
					i_nom = $('#nom-popin');
					i_email = $('#email-popin');
					i_message = $('#message-popin');
					i_tel = $('#tel-popin');

					// on supprime toutes les classes error des champs
					i_nom.removeClass('error');
					i_email.removeClass('error');
					i_message.removeClass('error');
					i_tel.removeClass('error');

					$('span').remove('.txt-error');

					// si il n'y a pas d'erreur
					if (json.success)
					{
						var gaq = form.data('gaq');
						ga('send','event',gaq.category,gaq.action,gaq.label);
						popin.dialog("close");
						popin_confirmation.dialog("open");
					}
					else
					{
						var error = json.message;
						if (error.nom)
						{
							i_nom.addClass('error');
							if (!i_nom.closest('div').find('.txt-error').length)
							{
								i_nom.closest('div').append('<span class="txt-error">' + error.nom + '</span>');
							}
						}
						if (error.email)
						{
							i_email.addClass('error');
							if (!i_email.closest('div').find('.txt-error').length)
							{
								i_email.closest('div').append('<span class="txt-error">' + error.email + '</span>');
							}
						}
						if (error.message)
						{
							i_message.addClass('error');
							if (!i_message.closest('div').find('.txt-error').length)
							{
								i_message.closest('div').append('<span class="txt-error">' + error.message + '</span>');
							}
						}
						if (error.telephone)
						{
							i_tel.addClass('error');
							if (!i_tel.closest('div').find('.txt-error').length)
							{
								i_tel.closest('div').append('<span class="txt-error">' + error.telephone + '</span>');
							}
						}
					}

					// on affiche le bouton et on masque le loading
					div_bouton.show();
					div_loading.hide();
				}
			});
			e.preventDefault();
		});
		// fin du traitement du contact annonceur
	});

	$("#popin-signaler-prix-opener").doOnce(function() {
		var popin = $("#popin-signaler-prix");
		popin.dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 550,
			open: function() {
				// Fermer la dialog box quand on clique sur l'overlay
				self = $(this);
				$('.ui-widget-overlay').click(function() {
					self.dialog('close');
				})
			}
		});

		this.click(function() {
			popin.dialog("open");
			return false;
		});


		/**
		 * Popin pour confirmation envoi mail contact annonceur.
		 * Si 'div#popin-form-contact' est présent afficher la popin.
		 */
		var popin_confirmation = $("#popin-form-contact");
		popin_confirmation.dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 650,
			close: 'Fermer',
			position: {my: 'center', at: 'center', of: window},
			buttons: {
				'Fermer': function() {
					$(this).dialog('close');
				}
			},
			open: function() {
				// Fermer la dialog box quand on clique sur l'overlay
				self = $(this);
				$('.ui-widget-overlay').click(function() {
					self.dialog('close');
				})
			}
		});

		/**
		 * Traitement du contact annonceur
		 */
		$('#btn-envoyer-signaler-prix').click(function(e) {
			// on remplace le bouton par le loader
			div_bouton = $('#btn');
			div_loading = $('#loading');
			div_bouton.hide();
			div_loading.show();

			var form = $('#form-contact-signaler-prix');

			// on renseigne le message en fonction du prix sélectionné
			var baisse_prix_value = '';
			if ($('#signaler-prix').val() != 'nc')
			{
				var tmp = $('#signaler-prix').val().split('-');
				if (tmp[1] && tmp[2])
				{
					baisse_prix_value = " de l'ordre de -" + tmp[1] + " (soit un prix de vente d'environ " + number_format(tmp[2], 0, ',', '.') + " &euro;) ";
				}
			}
			$('#message-signaler-prix').val("Bonjour,\r\n J'ai vu votre annonce sur PAP.fr et votre bien m'intéresse.\r\n Seriez-vous ouvert à une négociation " + baisse_prix_value + "? Merci de me contacter pour en discuter si c'est envisageable.");

			$.ajax({
				url: '/recherche/detail/ajax-contact-annonceur',
				type: 'POST',
				data: form.serialize(),
				success: function(json) {
					i_email = $('#email-signaler-prix');

					// on supprime toutes les classes error des champs
					i_email.removeClass('error');

					$('span').remove('.txt-error');

					// si il n'y a pas d'erreur
					if (json.success)
					{
						var gaq = form.data('gaq');
						ga('send','event',gaq.category,gaq.action,gaq.label);
						popin.dialog("close");
						popin_confirmation.dialog("open");
					}
					else
					{
						var error = json.message;
						if (error.email)
						{
							i_email.addClass('error');
							if (!i_email.closest('div').find('.txt-error').length)
							{
								i_email.closest('div').append('<span class="txt-error">' + error.email + '</span>');
							}
						}
					}

					// on affiche le bouton et on masque le loading
					div_bouton.show();
					div_loading.hide();
				}
			});
			e.preventDefault();
		});
		// fin du traitement du contact annonceur
	});

	/**
	 * Contact annonceur pour détail simple
	 */
	$('#form-contact-annonceur-simple, #form-contact-annonceur-simple-centre').doOnce(function()
	{
		var form_contact_annonceur = $(this);
		var popin_confirmation = $("#popin-confirmation-bien-a-vendre");
		popin_confirmation.dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 550,
			position: {my: 'center', at: 'center', of: window},
			close: function (e)
			{
				createCookie('contacter_annonceur[bien-a-vendre]', '1', 365);
			}
		});
		var form = $(this);
		$('input.btn-envoyer-message').click(function(e)
		{
			var form = $(this).closest('form');
			var li = $(this).closest('li');
			var div_bouton = form.find('input.btn-envoyer-message');
			var div_loading = li.find('div.loading-message');
			var div_envoye = li.find('div.contact-succes');
			var div_error = li.find('div.contact-error');
			var form_creation_alerte = $('#recherche-detail-formulaire-creation-alerte');
			var cookie_value_option_a_la_vente = getCookie('contacter_annonceur[option_a_la_vente]');
			div_bouton.hide();
			div_loading.show();
			div_envoye.hide();
			div_error.hide();
			$.ajax({
				url: '/recherche/detail/ajax-contact-annonceur',
				type: 'POST',
				data: form.serialize(),
				success: function(json)
				{
					i_nom = form.find('input[name^="nom"]');
					i_email = form.find('input[name^="email"]');
					i_message = form.find('input[name^="message"]');
					i_tel = form.find('input[name^="tel"]');
					i_alerte_email = form.find('input[name^="alerte_email"]:checked').length;
					i_id = form.find('input[name^="id"]') ;
					if (json.success)
					{
						var gaq = form.data('gaq');
						ga('send','event',gaq.category,gaq.action,gaq.label);
						div_envoye.show();
						if (i_alerte_email == 1)
						{
							form_creation_alerte.find('#creation-alerte-email').val(i_email.val());
							$.ajax({
								url: form_creation_alerte.attr('action'),
								type: form_creation_alerte.attr('method'),
								data: form_creation_alerte.serialize(),
								success: function (json_alerte) {}
							});
						}
						if (getCookie('contacter_annonceur[bien-a-vendre]').length == 0)
						{
							$('#popin-confirmation-bien-a-vendre-oui, #popin-confirmation-bien-a-vendre-non').on('click', function(e)
							{
								var self = $(this);
								var data_serialized = form.serialize()
									+ '&recevoir_offre=' + ($(this).attr('id') == 'popin-confirmation-bien-a-vendre-oui' ? '1' : '')
									+ '&origine=' + ($(this).attr('id') == 'popin-confirmation-bien-a-vendre-oui' ? 'detail' : '');;
								$.ajax({
									url: $('#popin-confirmation-bien-a-vendre-form').attr('action'),
									type: $('#popin-confirmation-bien-a-vendre-form').attr('method'),
									data: data_serialized,
									complete: function ()
									{
										popin_confirmation.dialog('close');
									}
								});
								e.preventDefault();
							});
							popin_confirmation.dialog('open');
						}
						if (form.attr('id') == 'form-contact-annonceur-simple')
						{


								window.optimizely.push(["trackEvent", "contact-email"]);
								window.optimizely.push(["trackEvent", "contact-email-detail"]);
								window.optimizely.push(["trackEvent", "contact-email-detail-sidebar"]);

						}
						else
						{


								window.optimizely.push(["trackEvent", "contact-email"]);
								window.optimizely.push(["trackEvent", "contact-email-detail"]);
								window.optimizely.push(["trackEvent", "contact-email-detail-content"]);;

						}
						if ($('#contact-proprietaire-alavente-centre').length)
						{
							$('#contact-proprietaire-alavente-centre').show();
							$('#contact-proprietaire-alavente-sidebar').show();
							if (cookie_value_option_a_la_vente.search(i_id.val() + '-') == -1) {
								cookie_value_option_a_la_vente = i_id.val() + '-' + cookie_value_option_a_la_vente;
							}
							createCookie('contacter_annonceur[option_a_la_vente]', cookie_value_option_a_la_vente, 365);
						}


					}
					else
					{
						var error = json.message;
						if (error.nom)
						{
							div_error.append(error.nom + "<br>");
						}
						if (error.email)
						{
							div_error.append(error.email + "<br>");
						}
						if (error.message)
						{
							div_error.append(error.message + "<br>");
						}
						if (error.telephone)
						{
							div_error.append(error.telephone + "<br>");
						}
						div_error.show();
					}
					div_bouton.show();
					div_loading.hide();
				}
			});
			e.preventDefault();
		});
		// fin du traitement du contact annonceur simplé
	});


	/*****************************************************************************
	 *** Popin Contact sms
	 *****************************************************************************/
	$("a.btn-contact-sms").doOnce(function() {
		var popin = $("#popin-contact-proprietaire-sms");
		popin.dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 650,
			dialogClass: "popin-blue",
			open: function() {
				// Fermer la dialog box quand on clique sur l'overlay
				self = $(this);
				$('#sms-nom-popin').blur();
				$('.ui-widget-overlay').click(function() {
					self.dialog('close');
				})
			}
		});

		this.click(function() {
			popin.dialog("open");
			return false;
		});


		/**
		 * Popin pour confirmation envoi mail contact annonceur.
		 * Si 'div#popin-form-contact' est présent afficher la popin.
		 */
		var popin_confirmation = $("#popin-form-contact");
		popin_confirmation.dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 650,
			close: 'Fermer',
			position: {my: 'center', at: 'center', of: window},
			buttons: {
				'Fermer': function() {
					$(this).dialog('close');
				}
			},
			open: function() {
				// Fermer la dialog box quand on clique sur l'overlay
				self = $(this);
				$('.ui-widget-overlay').click(function() {
					self.dialog('close');
				})
			}
		});

		/**
		 * Traitement du contact sms
		 */
		$('#btn-envoyer-sms').click(function(e) {
			// on remplace le bouton par le loader
			div_bouton = $('#sms-btn');
			div_loading = $('#sms-loading');
			div_bouton.hide();
			div_loading.show();

			var form = $('#form-contact-sms');
			$.ajax({
				url: '/recherche/detail/ajax-contact-sms',
				type: 'POST',
				data: form.serialize(),
				success: function(json) {

					i_nom = $('#sms-nom-popin');
					i_email = $('#sms-email-popin');
					i_tel = $('#sms-tel-popin');
					i_title = $('#sms-title');

					// on supprime toutes les classes error des champs
					i_nom.removeClass('error');
					i_email.removeClass('error');
					i_tel.removeClass('error');

					$('span').remove('.txt-error');

					// si il n'y a pas d'erreur
					if (json.success)
					{
						var gaq = form.data('gaq');
						ga('send','event',gaq.category,gaq.action,gaq.label);
						popin.dialog("close");
						popin_confirmation.dialog("open");
					}
					else
					{
						var error = json.message;

						if (error.quota)
						{
							if (!i_title.closest('div').find('.txt-error').length)
							{
								i_title.after('<p class="text-send txt-error">' + error.quota + '</p>');
							}
						}

						if (error.nom)
						{
							i_nom.addClass('error');
							if (!i_nom.closest('div').find('.txt-error').length)
							{
								i_nom.closest('div').append('<span class="txt-error">' + error.nom + '</span>');
							}
						}
						if (error.email)
						{
							i_email.addClass('error');
							if (!i_email.closest('div').find('.txt-error').length)
							{
								i_email.closest('div').append('<span class="txt-error">' + error.email + '</span>');
							}
						}
						if (error.telephone)
						{
							i_tel.addClass('error');
							if (!i_tel.closest('div').find('.txt-error').length)
							{
								i_tel.closest('div').append('<span class="txt-error">' + error.telephone + '</span>');
							}
						}
					}

					// on affiche le bouton et on masque le loading
					div_bouton.show();
					div_loading.hide();
				}
			});
			e.preventDefault();
		});
		// fin du traitement du contact sms

	});

	/*****************************************************************************
	 *** Popin Envoi a un ami
	 *****************************************************************************/
	var popin_envoi_a_un_ami = $('#popin-envoi-a-un-ami').dialog({
		autoOpen: false,
		modal: true,
		resizable: false,
		width: 650
	});

	$('a.btn-envoyer-a-un-ami').click(function() {
		popin_envoi_a_un_ami.load('/ajax/ajax-popin-envoi-ami.php?annonce_id=' + $(this).metadata().annonce_id).dialog('open');
		return false;
	});

	// Voir ajax /ajax/ajax-popin-envoi-ami.php
	envoi_ami_submit = function() {
		$.ajax({
			type: "POST",
			url: "/ajax/ajax-popin-envoi-ami.php",
			dataType: 'html',
			data: {
				prenom: $('#prenomnom').val(),
				email: $('#emailexpediteur').val(),
				destinataire: $('#emaildestinataire').val(),
				commentaires: $('#commentaires').val(),
				annonce_id: $('#annonce_id').val(),
				optin: $('#optin').is(':checked') ? 1 : 0,
				submit: $('#submit').val()
			},
			success: function(data) {
				popin_envoi_a_un_ami.html(data);
			}
		});
		return false;
	};

	/*************************************************************************
	 *** Anciennement pap-new.js
	 *************************************************************************/

	if ($('.type-bien').length) {
		$(".type-bien").multiselect({
			selectedList: 2,
			header: false,
			minWidth: 100,
			noneSelectedText: "Type de bien",
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedText: function (numChecked, numTotal, checkedItems)
			{
				var value = "";
				if (numChecked > 0)
				{
					var o = this.options;
					var $inputs = this.inputs;
					var $checked = $inputs.filter(':checked');
					var result = $checked.map(function ()
					{
						return $(this).next().text();
					}).get().join(', ');
					result = result.split(',');
					if (result.length > o.selectedList)
					{
						var i = 0;
						for (val in result)
						{
							i++;
							value += result[val] + ', ';
							if (i >= o.selectedList)
							{
								value += "...";
								break;
							}
						}
					}
					else
					{
						value = $checked.map(function ()
						{
							return $(this).next().text();
						}).get().join(', ');
					}
				}
				return value;
				//return numChecked + ' of ' + numTotal + ' checked';
			},

			classes: "multiselect-localisation ui-widget ui-corner-all"
		});
	}

	if ($("#nb_chambres").length) {
		$("#nb_chambres").multiselect({
			noneSelectedText: "None selected",
			multiple: false,
			header: false,
			minWidth: 140,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1,
			height: "auto"
		});
	}

	if ($('select#nb_pieces').length) {
		$("select#nb_pieces").multiselect({
			noneSelectedText: "None selected",
			multiple: false,
			header: false,
			minWidth: 120,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1,
			height: "auto"
		});
	}

	if ($("#nb_resultats_par_page, #tri").length) {
		$("#nb_resultats_par_page, #tri").multiselect({
			noneSelectedText: "None selected",
			multiple: false,
			header: false,
			minWidth: 100,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1,
			height: "auto"
		});
	}

	if ($("#duree_pret, #popin_duree_pret").length) {
		$("#duree_pret, #popin_duree_pret").multiselect({
			noneSelectedText: "Durée du prêt",
			multiple: false,
			header: false,
			minWidth: 100,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1
		});
	}

	if ($(".objet-contact").length) {
		$(".objet-contact").multiselect({
			noneSelectedText: "Objet",
			multiple: false,
			header: false,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1,
			height: "auto"
		});
	}

	if ($(".m2-recherche #produit").length) {
		$(".m2-recherche #produit").multiselect({
			height: 'auto',
			multiple: false,
			header: false,
			minWidth: 100,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1
		});
	}

	if ($(".categorie-reclamation").length) {
		$(".categorie-reclamation").multiselect({
			noneSelectedText: "None selected",
			multiple: false,
			header: false,
			minWidth: 510,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1,
			height: "auto"
		});
	}

	if ($('.frequence-notif-email').length) {
		$('.frequence-notif-email').multiselect({
			noneSelectedText: "None selected",
			multiple: false,
			header: false,
			minWidth: 250,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1,
			height: "auto"
		});
	}

	if ($('.choix-action-annonce').length) {
		$('.choix-action-annonce').multiselect({
			noneSelectedText: "None selected",
			multiple: false,
			header: false,
			minWidth: 200,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1,
			height: "auto"
		});
	}
	if ($('.objet-du-message').length) {
		$('.objet-du-message').multiselect({
			noneSelectedText: "None selected",
			multiple: false,
			header: false,
			minWidth: 200,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1,
			height: "auto"
		});
	}

	$('#login-form').click(function (ev)
	{
		section_form = document.getElementById('login-formulaire');
		if (section_form.style.display == "none")
		{
			section_form.style.display = "block";
		}
		else
		{
			section_form.style.display = "none";
		}
		return false;
	});

	$("a#video-presentation").click(function ()
	{
		$.fancybox({
			'padding': 0,
			'autoScale': false,
			'transitionIn': 'none',
			'transitionOut': 'none',
			'title': this.title,
			'width': 680,
			'height': 495,
			'href': this.href.replace(new RegExp("watch\\?v=", "i"), 'v/'),
			'type': 'swf',
			'swf': {
				'wmode': 'transparent',
				'allowfullscreen': 'true'
			}
		});

		return false;
	});

	$("a[id^=video-temoin]").click(function ()
	{
		$.fancybox({
			'padding': 0,
			'autoScale': false,
			'transitionIn': 'none',
			'transitionOut': 'none',
			'title': this.title,
			'width': 680,
			'height': 495,
			'href': this.href.replace(new RegExp("watch\\?v=", "i"), 'v/'),
			'type': 'swf',
			'swf': {
				'wmode': 'transparent',
				'allowfullscreen': 'true'
			}
		});

		return false;
	});

	/**
	 * Moteur de recherche, affichage par toggle des criteres additionnels
	 */
	$('a.btn-more-filters').click(function() {
		$('.more-filters-form').slideToggle('400');
		if ($(this).css('background-position') == '0px 0px'
			|| $(this).css('background-position') == '0px -20px') {
			$(this).css('background-position', '0px -60px');
		}
		else if ($(this).css('background-position') == '0px -40px'
			|| $(this).css('background-position') == '0px -60px') {
			$(this).css('background-position', '0px -20px');
		}
		return false;
	});

	$('a.btn-more-filters').hover(
		function() {
			if ($(this).css('background-position') == '0px 0px') {
				$(this).css('background-position', '0px -20px');
			}
			if ($(this).css('background-position') == '0px -40px') {
				$(this).css('background-position', '0px -60px');
			}
	},
		function() {
			if ($(this).css('background-position') == '0px -20px') {
				$(this).css('background-position', '0px 0px');
			}
			if ($(this).css('background-position') == '0px -60px') {
				$(this).css('background-position', '0px -40px');
			}
	});
	// Fin toggle des criteres additionnels

	/*************************************************************************
	 *** Page détail
	 *************************************************************************/

	/**
	 * Affiche le numero de telephone contact annonceur.
	 * Lors d'un clic, l'affichage est comptabilisé et le numéro reste affiché sur une période donnée.
	 */
	var telAnnonceur = function() {
		$('a.btn-telephone, a.btn-afficher-telephone').find('.hide-tel').hide();

		$('a.btn-telephone, a.btn-afficher-telephone').click(function() {

			var annonceId = $(this).data('annonce-id');
			var cookValue = getCookie('contacter_annonceur[showtel]');

			// Si le numero est caché, track nb click
			if ($(this).find('.hide-tel').length == 1) {
				$.ajax({
					type: 'GET',
					url: '/ajax/track-tel.php',
					data: {id: annonceId}
				});
			}

			$('a.btn-telephone, a.btn-afficher-telephone').each(function(key, value) {
				$(this).find('.label-tel').remove();
				$(this).find('.hide-tel').removeClass('hide-tel').show().css("display", "inline-block");
				$(this).addClass('bloc-telephone');
			});

			// Ajoute l'annonce id dans le cookie si non present
			if (cookValue.search(annonceId + '-') == -1) {
				cookValue = annonceId + '-' + cookValue;
			}

			createCookie('contacter_annonceur[showtel]', cookValue, 30);
			return false;
		});
	};
	telAnnonceur();
	// Fin affiche numero de telephone contact annonceur

	// message prérempli dans le contact annonceur
	if ($(".object-contact").length)
	{
		$(".object-contact").bind("click", function ()
		{
			var visite = $('#objet-visite-popin').is(':checked');
			var photos = $('#objet-photos-popin').is(':checked');
			var infos = $('#objet-infos-popin').is(':checked');
			var telephone = $('#tel-popin').val();
			var message = '';

			if (visite && !photos && !infos)
			{
				message = "Bonjour, votre bien m'intéresse, je souhaite pouvoir le visiter. Pouvez-vous me recontacter par e-mail ou par téléphone afin de convenir d'un rendez-vous ? Cordialement.";
			}
			if (!visite && photos && !infos)
			{
				message = "Bonjour, pouvez-vous m'envoyer des photos supplémentaires par e-mail ? Cordialement.";
			}
			if (!visite && !photos && infos)
			{
				message = "Bonjour, votre bien m'intéresse, pouvez-vous m'envoyer plus d'informations (type de chauffage, individuel ou collectif...) par e-mail ? Cordialement.";
			}
			if (visite && photos && !infos)
			{
				message = "Bonjour, votre bien m'intéresse, je souhaite pouvoir le visiter. Pouvez-vous me recontacter par e-mail ou par téléphone afin de convenir d'un rendez-vous ? En attendant, pouvez-vous m'envoyer des photos supplémentaires par e-mail ? Cordialement.";
			}
			if (visite && !photos && infos)
			{
				message = "Bonjour, votre bien m'intéresse, je souhaite pouvoir le visiter. Pouvez-vous me recontacter par e-mail ou par téléphone afin de convenir d'un rendez-vous ? En attendant, pouvez-vous m'envoyer plus d'informations (type de chauffage, individuel ou collectif...) par e-mail ? Cordialement.";
			}
			if (!visite && photos && infos)
			{
				message = "Bonjour, votre bien m'intéresse. Pouvez-vous m'envoyer plus d'informations (type de chauffage, individuel ou collectif...) et plus de photos par e-mail ? Cordialement.";
			}
			if (visite && photos && infos)
			{
				message = "Bonjour, votre bien m'intéresse, je souhaite pouvoir le visiter. Pouvez-vous me recontacter par e-mail ou par téléphone afin de convenir d'un rendez-vous ? En attendant, pouvez-vous m'envoyer plus d'informations (type de chauffage, individuel ou collectif...) et plus de photos par e-mail ? Cordialement.";
			}

			$('#message-popin').val(message);
		});
	}
	// Fin message prérempli dans le contact annonceur


	/**
	 * Simulation financement, affichage tableau comparatif
	 */
	if ($('a.btn-comparaison-mensualites').length) {
		$('a.btn-comparaison-mensualites').live('click', function() {
			$('.comparaison-mensualites').slideToggle('400');
			return false;
		});
	}
	// Fin affichage tableau comparatif

	/**
	 * Apparition du bloc Alerte Email lors du scroll de la page
	 * Désactivé après re conecption du nouveau bloc.
	 */
	alerteemail = $(".alerte-email").fadeTo(0, 0);

	$(window).scroll(function(d,h) {
		alerteemail.each(function(i) {
			a = $(this).offset().top + $(this).height();
			b = $(window).scrollTop() + $(window).height();
			if (a < b) $(this).fadeTo(500,1);
			});
	});
	// Fin effet apparition scroll

	/**
	 * Showcase Image slideshow de la page details annonce
	 */
	if ($("#showcase").length) {
		$("#showcase").awShowcase(
		{
			content_width: 750,
			content_height: 440,
			fit_to_parent: false,
			auto: false,
			interval: 3000,
			continuous: false,
			loading: true,
			tooltip_width: 200,
			tooltip_icon_width: 32,
			tooltip_icon_height: 32,
			tooltip_offsetx: 18,
			tooltip_offsety: 0,
			arrows: true,
			buttons: true,
			btn_numbers: true,
			keybord_keys: false,
			mousetrace: false, /* Trace x and y coordinates for the mouse */
			pauseonover: true,
			stoponclick: true,
			transition: 'hslide', /* hslide/vslide/fade */
			transition_delay: 300,
			transition_speed: 500,
			show_caption: 'onload', /* onload/onhover/show */
			thumbnails: true,
			thumbnails_position: 'outside-last', /* outside-last/outside-first/inside-last/inside-first */
			thumbnails_direction: 'horizontal', /* vertical/horizontal */
			thumbnails_slidex: 0, /* 0 = auto / 1 = slide one thumbnail / 2 = slide two thumbnails / etc. */
			dynamic_height: false, /* For dynamic height to work in webkit you need to set the width and height of images in the source. Usually works to only set the dimension of the first slide in the showcase. */
			speed_change: false, /* Set to true to prevent users from swithing more then one slide at once. */
			viewline: false /* If set to true content_width, thumbnails, transition and dynamic_height will be disabled. As for dynamic height you need to set the width and height of images in the source. */
		});
	}
	
	/**
	 * Showcase Image slideshow du bloc Annonces similaires de la page details annonce
	 */
	if ($("#showcase2").length) {
		$("#showcase2").awShowcase(
		{
			content_width: 610,
			content_height: 215,
			fit_to_parent: false,
			auto: true,
			interval: 10000,
			continuous: true,
			loading: true,
			tooltip_width: 200,
			tooltip_icon_width: 32,
			tooltip_icon_height: 32,
			tooltip_offsetx: 18,
			tooltip_offsety: 0,
			arrows: true,
			buttons: false,
			btn_numbers: false,
			keybord_keys: false,
			mousetrace: false, /* Trace x and y coordinates for the mouse */
			pauseonover: true,
			stoponclick: true,
			transition: 'hslide', /* hslide/vslide/fade */
			transition_delay: 0,
			transition_speed: 500,
			show_caption: 'onload', /* onload/onhover/show */
			thumbnails: false,
			thumbnails_position: 'outside-last', /* outside-last/outside-first/inside-last/inside-first */
			thumbnails_direction: 'horizontal', /* vertical/horizontal */
			thumbnails_slidex: 0, /* 0 = auto / 1 = slide one thumbnail / 2 = slide two thumbnails / etc. */
			dynamic_height: false, /* For dynamic height to work in webkit you need to set the width and height of images in the source. Usually works to only set the dimension of the first slide in the showcase. */
			speed_change: false, /* Set to true to prevent users from swithing more then one slide at once. */
			viewline: false /* If set to true content_width, thumbnails, transition and dynamic_height will be disabled. As for dynamic height you need to set the width and height of images in the source. */
		});
	}

	/**
	 * ResizeCrop, croppage des vignettes d'annonces
	 */

	if ($('.search-results-list .vignette-annonce img').length) {
		$('.search-results-list .vignette-annonce img').resizecrop({
			width: 212,
			height: 158
		});
	}
	if ($('.a-la-une .vignette-alaune').length) {
		$('.a-la-une .vignette-alaune').resizecrop({
			width: 208,
			height: 154
		});
	}

	if ($('.sidebar .annonces-a-la-une .vignette img').length) {
		$('.sidebar .annonces-a-la-une .vignette img').resizecrop({
			width: 102,
			height: 102
		});
	}

	if ($('.annonces-similaires .vignette-annonce img').length) {
		$('.annonces-similaires .vignette-annonce img').resizecrop({
			width: 182,
			height: 128
		});
	}

	/**
	 * Gestion du panier
	 * Liens page de resultat, page detail, page favoris
	 */

	// Permet d'actualiser le pictos lorsque le bouton précédent est cliqué vers la liste d'annonce
	if (window.location.pathname.substring(0, 9) == '/annonce/' && $('body').hasClass('search-results-page'))
	{
		$.ajax({
			url: '/ajax/panier-get.php',
			cache: false,
			type: 'GET',
			dataType: 'json',
			success: function(data) {
				if (data && data.success === undefined) {
					$('a.favoris').removeClass('favoris-selected').each(function(index) {
						if ($.inArray($(this).data('annonce-id').toString(), data) > -1) {
							$(this).addClass('favoris-selected');
						}
					});
				}
			}
		});
	}

	/**
	 * Ajax set favoris.
	 *
	 * @param link Objet sur lien favoris
	 * @param addPanier 0 ou 1 pour ajouter ou retirer le favoris
	 * @param reload_on_success bool true recharge page, false non
	 */
	function favoris_set(link, addPanier, reload_on_success) {
		$.ajax({
			url: '/ajax/panier-set.php',
			type: 'POST',
			data: {
				'panier': addPanier,
				'annonces_id': link.data('annonce-id')
			},
			success: function(json) {
				if (json.success == true) {
					if (link.hasClass('favoris-detail')) { // Page détail
						$('a.favoris').each(function() {
							$(this).toggleClass('favoris-selected');
							if ($(this).hasClass('favoris-selected')) {
								$(this).find('span.favoris-ajouter').attr('class', 'favoris-supprimer').html('Supprimer de vos favoris');
							}
							else {
								$(this).find('span.favoris-supprimer').attr('class', 'favoris-ajouter').html('Ajouter à<br /> vos favoris');
							}
							if ($(this).hasClass('tooltip2')) {
								$(this).tooltipster('content', $(this).text());
							}
						});
					}
					else { // Page liste
						link.toggleClass('favoris-selected');
						if (link.hasClass('favoris-selected')) {
							link.tooltipster('content', 'Supprimer de vos favoris');
						}
						else {
							link.tooltipster('content', 'Ajouter à vos favoris');
						}
					}
				}
			},
			complete: function(flux, status) {
				if (reload_on_success) {
					window.location.reload();
				}
			}
		});
	}

	// Active les favoris sur les liens de classe 'favoris'
	$('a.favoris').doOnce(function() {
		this.on('click', function(e) {
			var link = $(this);
			var addPanier = link.hasClass('favoris-selected') ? 0 : 1;
			if (link.attr('href') !== '#') {
				return true; // Utilise le lien si non connecté
			}
			favoris_set(link, addPanier, false);
			e.preventDefault();
			return false;
		});
	});
	// FIN -- Gestion du panier

	/**
	 * Activer Tooltipster
	 */
	$('.tooltip').doOnce(function() {
		this.tooltipster();
	});

	$('.tooltip2').doOnce(function() {
		this.tooltipster({theme: 'tooltipster2'});
	});

	$('.error-tooltip').doOnce(function() {
		this.tooltipster({position: 'right', theme: 'tooltipster-error'});
	});
	// FIN -- Tooltipster

	/**
	 * Petite astuce pour cacher les conteneurs de pub qui n'ont pas de pub associé
	 * et donc affiche un fichier empty.gif
	 */
	$("div.pub:has(img[src$='empty.gif'])").addClass('hidden') ;

	/**
	 * Afficher la carte Mappy
	 */
	
	if ($('#popin-map-annonce').length > 0) {
		
		$('#popin-map-annonce').dialog({
			modal: true,
			autoOpen: false,
			resizable: false,
			height: 600,
			width: 800,
			open: function() {
				// Fermer la dialog box quand on clique sur l'overlay
				self = $(this);
				$('.ui-widget-overlay').click(function() {
					self.dialog('close');
				});
			}
		});
		
		$('#map-annonce').on('init', function() {
			
			// Création de la carte
			var $map = new L.Mappy.Map('map-annonce', {
					clientId: 'pap',
					center: [
						parseFloat($('#map-annonce').data('mapLat')),
						parseFloat($('#map-annonce').data('mapLng'))
					],
					zoom: parseInt($('#map-annonce').data('mapZoom')),
					layersControl: {
						publicTransport: true,
						traffic: false,
						viewMode: false,
						trafficLegend: false
					},
					logoControl: {
						position: "topright",
						dir: "/vendor/leaflet-mappy-5.2.0/dist/images/"
					}
				});
			
			// Impossible de cliquer sur le lien Mappy SW-538
			$('.leaflet-control-attribution').on('click', 'a', function () {
				window.open($(this).attr('href'), $(this).attr('target'));
			});
			
			// Afficher le disque de proximité
			if ($('#map-annonce').hasClass('map-annonce-adresse')) {
				var layer = L.layerGroup().addTo($map);
				var shape = L.circle($map.getCenter(), 300, {
						weight: 2,
						color: "#ffffff",
						opacity: 0.5,
						fillColor: "#005ea8",
						fillOpacity: 0.2
					}).addTo(layer);
			}
			
			// Enregistrer l'initialisation
			$('#map-annonce').data('isInitialized', 1);
			
		});
		
		// Gestion de l'ouverture
		$('#handler-map-annonce').click(function() {
			$('#popin-map-annonce').dialog('open');
			if (!$('#map-annonce').data('isInitialized')) {
				$('#map-annonce').trigger('init');
			}
			return false;
		});
		
	}
	
	/*****************************************************************************
	 * Page generic
	 *****************************************************************************/

	/**
	 * Code generique pour l'ouverture en accordeon avec un lien avant le bloc
	 */
	$('a.open-toggle-before, a.open-toggle-after').doOnce(function() {
		this.on('click', function(e) {
			var tmp_titre = $(this).data('openToggleTitre');
			$(this).data('openToggleTitre', $(this).html())
			$(this).html(tmp_titre);
			if ($(this).hasClass('open-toggle-before')) {
				$(this).next().slideToggle();
			}
			else {
				$(this).prev().slideToggle();
			}
			e.preventDefault();
		})
	});

	/**
	 * Code generique pour la fermeture par un bouton dans le bloc apparaissant.
	 */
	$('span.close-toggle').doOnce(function() {
		this.on('click', function(e) {
			$(this).parent().slideToggle();
			e.preventDefault();
		});
	});

	/**
	 * Section evaluation
	 */
	var geo_el = $('#geo_objets.autocomplete');

	if (geo_el.length > 0)
	{
		evaluationInitialize();

		var geo_init = function (el, data) {
			data = data || [];
			var options = {
				hintText: "Indiquez une ville...",
				noResultsText: "Aucune ville ne correspond",
				searchingText: "Recherche...",
				prePopulate: data,
				preventDuplicates: true,
				theme: 'facebook',
				searchDelay: 50,
				tokenLimit: "1"
			};

			el.tokenInput('/index/ac-geo-prixm2', options);
		};

		if (geo_el.val()) {
			$.getJSON('/index/ac-geo-init?ids=' + geo_el.val(), function (data) {
				geo_init(geo_el, data);
			});
		}
		else {
			geo_init(geo_el);
		}
	}

	function evaluationInitialize()
	{
		var latlng = false;
		var lat = document.getElementById('ville_lat').value;
		var lng = document.getElementById('ville_lng').value;

		if (lat && lng)
		{
			latlng = [lat, lng];
		}

		if (latlng)
		{
			var center = latlng;
			var zoom = 8;
			var affiche = true;
		}
		else
		{
			var center = [47, 1.5];
			var zoom = 3;
			var affiche = false;
		}

		var map = new L.Mappy.Map("map-eval", {
			clientId: "pap",
			center: center,
			zoom: zoom,
			logoControl: {
				position: "topright",
				dir: "/vendor/api-ajax-mappy-5.2.0-37/dist/images/"
			},
			scrollWheelZoom: false,
			layersControl: {
				publicTransport: false,
				traffic: false,
				viewMode: false,
				trafficLegend: false
			}
		});

		if (affiche) {
			$.get("/kml/kml-" + document.getElementById('produitselect').value + ".xml", function (data) {
				var json = $.xml2json(data);
				parseXml(json.Document);
				useTheData(json.Document);
			});

			var markers = [];

			// parcourre les points et place les markers
			function parseXml(doc) {
				for (var i = 0; i < doc.Placemark.length; i++) {
					coord = doc.Placemark[i].Point.coordinates.split(',');

					markers[i] = L.marker([coord[1], coord[0]], { icon: L.icon({
						iconUrl: '/images/icones/prixm2.png',
						iconSize: [32, 32],
						popupAnchor: [0, -16]}) }).addTo(map).bindPopup("<div class='popupmap'><div class='titrepopupmap'>" + doc.Placemark[i].name + '</div>' + doc.Placemark[i].description + "</div>");
				}
			}

			// ouvre la popup sinon place un marker sans prix
			function useTheData(doc) {
				// Geodata handling goes here, using JSON properties of the doc object
				var finded = false;

				for (var i = 0; i < doc.Placemark.length; i++) {
					coord = doc.Placemark[i].Point.coordinates.split(',');

					if ((Math.round(parseFloat(coord[0]) * 1000) / 1000) == (Math.round(parseFloat(lng) * 1000) / 1000)
						&& (Math.round(parseFloat(coord[1]) * 1000) / 1000) == (Math.round(parseFloat(lat) * 1000) / 1000)) {
						markers[i].fire('click');
						finded = true;
					}
				}

				if (finded == false) {
					// on créé un marker à cet endroit
					var markernone = L.marker(latlng, { icon: L.icon({
						iconUrl: '/images/icones/goutte.png',
						iconSize: [24, 33],
						popupAnchor: [0, -16]}) }).addTo(map).bindPopup("<div class='popupmap'>Aucun prix pour cette ville</div>");
					markernone.fire('click');
				}
			};
		}
	}

	/**
	 * Exemple de vente
	 */
	$('#recherche-exemple-prix').doOnce(function() {

		$("#tri").live("change keyup", function () {
			$("#tri-form").submit();
		});

		var div_excerpt = $('div.excerpt');
		div_excerpt.each(function () {
			var first_content = $(this).find('span').hide().html();
			var excerpt = first_content.slice(0, 250).concat('...');
			$(this).find('p.descriptif').prepend('<span class="excerpt">' + excerpt + '</span>');
		});
		div_excerpt.on('click', 'a.reveal', function(e) {
			e.preventDefault();
			$(this).siblings('span').toggle();
			if ($(this).text() == 'Lire la suite') {
				$(this).text('Réduire');
			}
			else {
				$(this).text('Lire la suite');
			}
		});

		var multiselectOptions = {
			noneSelectedText: "None selected",
			multiple: false,
			header: false,
			minWidth: 160,
			show: ["slide", {direction: "up"}, 200],
			hide: ["slide", {direction: "up"}, 200],
			selectedList: 1,
			height: "auto"
		};

		var type_bien_exemples_prix = $("#type-bien-exemples-prix");
		type_bien_exemples_prix.init = function () {
			if (type_bien_exemples_prix.val() == 'appartement')
			{
				$('#nb-pieces-exemples-prix').multiselect(multiselectOptions);
				$('#superficie-exemples-prix').multiselect(multiselectOptions);
				$('#superficie-maison-exemples-prix').multiselect('destroy').hide();
			}
			else if (type_bien_exemples_prix.val() == 'maison')
			{
				$('#nb-pieces-exemples-prix').multiselect('destroy').hide();
				$('#superficie-exemples-prix').multiselect('destroy').hide();
				$('#superficie-maison-exemples-prix').multiselect(multiselectOptions);
			}
			else
			{
				$('#nb-pieces-exemples-prix').multiselect('destroy').hide();
				$('#superficie-exemples-prix').multiselect('destroy').hide();
				$('#superficie-maison-exemples-prix').multiselect('destroy').hide();
			}
		};
		type_bien_exemples_prix.init();
		type_bien_exemples_prix.multiselect(multiselectOptions).on('change', type_bien_exemples_prix.init);
	});

	/**
	 * Tool print
	 */
	$('a.tool-print-fiche').doOnce(function() {
		this.on('click', function() {
			$('section.topbar-fixed-wrapper').hide();
			window.print();
			return false;
		});
	});

	/*************************************************************************
	 *** Landing page évaluation
	 *************************************************************************/

	/* Activation de la popin de connexion à l'espace évaluation */
	if ($("#dialog-box-connection").length){
		$("#dialog-box-connection").dialog({
			autoOpen: false,
			modal: true,
			resizable: false,
			width: 450
		});
	}
	if ($("#dialog-box-opener-connection").length){
		$("#dialog-box-opener-connection").click(function() {
			$( "#dialog-box-connection" ).dialog( "open" );
			return false;
		});
	}


});

/*****************************************************************************
 *** Gérer les cookies
 *****************************************************************************/

/**
 * Creer un cookie
 *
 * @param name Cle du cookie
 * @param value Valeur du cookie
 * @param days Nb de jours avant expiration
 */
function createCookie(name, value, days)
{
	if (days) {
		var date = new Date();
		date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
		var expires = '; expires=' + date.toGMTString();
	}
	else {
		var expires = '';
	}
	document.cookie = name + '=' + value + expires + '; path=/';
}

/**
 * Lire un cookie
 *
 * @param cname Cle du cookie
 * @returns {string} Value
 */
function getCookie(cname)
{
	var name = cname + "=";
	var ca = document.cookie.split(';');
	for (var i = 0; i < ca.length; i++)
	{
		var c = ca[i].replace(/^\s+|\s+$/g, '');
		if (c.indexOf(name) == 0) {
			return c.substring(name.length, c.length);
		}
	}
	return "";
}

function number_format(number, decimals, dec_point, thousands_sep)
{
	number = (number + '').replace(/[^0-9+\-Ee.]/g, '');
	var n = !isFinite(+number) ? 0 : +number,
		prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
		sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
		dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
		s = '',
		toFixedFix = function (n, prec)
		{
			var k = Math.pow(10, prec);
			return '' + (Math.round(n * k) / k)
				.toFixed(prec);
		};
	// Fix for IE parseFloat(0.55).toFixed(0) = 0;
	s = (prec ? toFixedFix(n, prec) : '' + Math.round(n))
		.split('.');
	if (s[0].length > 3)
	{
		s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
	}
	if ((s[1] || '')
		.length < prec)
	{
		s[1] = s[1] || '';
		s[1] += new Array(prec - s[1].length + 1)
			.join('0');
	}
	return s.join(dec);
}
