$(function () {
	$(document).ready(function () {
		// date picker
		if ($('.dpYears').length > 0) {
			$('.dpYears').datepicker({
				autoclose  : true,
				startDate  : '-10y',
				endDate    : '+5y',
				viewMode   : "months",
				minViewMode: "months",
				format     : 'mm/yyyy'
			});
		}

		// add new budget - select amount
		if ($('.budget-form').length > 0) {
			EditableTable.group();

			//valid data fields
			var max_year = new Date().getFullYear() + 5;
			$('.budget-form').validate({
				rules: {
					inputYear : {
						required: true,
						number  : true,
						min     : 1900,
						max     : max_year
					},
					dropPeriod: "required"
				}
			});

			var objMoneyType = $('.budget-money');
			var frmAmount = $('.input-amount');

			objMoneyType.change(function () {
				switch ($(this).val()) {
					case '1':
						// display total amount to input the money
						frmAmount.removeClass('hidden');
						frmAmount.find('input[type=text]').focus();

						// change input icon
						$('.budget-form tbody tr').each(function () {
							$(this).find('input[type=text]').attr('placeholder', '%');
						});
						break;
					default:
						frmAmount.addClass('hidden');
						$('.budget-form tbody tr').each(function () {
							$(this).find('input[type=text]').attr('placeholder', '$');
						});
				}
			});

			// check value when inputting the money
			$('.budget-form .edittable-datalist tbody tr input[type=text]').on(
				'focus', function () {
					if (objMoneyType.val() == 1) { // the end user selected input type is percent
						var objAmount = frmAmount.find('input[type=text]');
						var amount = $.trim(objAmount.val());
						if (amount.length > 0) {
							if (!$.isNumeric(amount) || amount <= 0) {
								$('.msg-input-amount').text('Invalid your amount');
							}
							else {
								$('.msg-input-amount').text('').hide();
							}
						}
						else {
							$('.msg-input-amount').text('Please enter your amount').show();
						}
					}
				},
				'change', function () { // check to calc total
					var tmpAmount = 0;
				}
			);
		}
		else if ($('.advance-form').length > 0) { // add new advance
			EditableTable.group();
			//valid data fields
			$('.advance-form').validate({
				rules: {
					dropPeriod: "required"
				}
			});
		}
		else if ($('.actual-salesforce-form').length > 0) { // add new advance
			EditableTable.group();
			//valid data fields
			$('.actual-salesforce-form').validate({
				rules: {
					dropPeriod: "required",
					dropPayment: "required"
				}
			});
		}
		else { // init default table type
			if ($('.editable-table').length > 0) {
				EditableTable.init();
			}
		}
	});
});

(function () {
	"use strict";

	// custom scrollbar
	$("html").niceScroll({
		styler    : "fb", cursorcolor: "#65cea7", cursorwidth: '6', cursorborderradius: '0px',
		background: '#424f63', spacebarenabled: false, cursorborder: '0', zindex: '1000'
	});

	$(".left-side").niceScroll({
		styler    : "fb", cursorcolor: "#65cea7", cursorwidth: '3', cursorborderradius: '0px',
		background: '#424f63', spacebarenabled: false, cursorborder: '0'
	});


	$(".left-side").getNiceScroll();
	if ($('body').hasClass('left-side-collapsed')) {
		$(".left-side").getNiceScroll().hide();
	}

	// Toggle Left Menu
	jQuery('.menu-list > a').click(function () {
		var parent = jQuery(this).parent();
		var sub = parent.find('> ul');

		if (!jQuery('body').hasClass('left-side-collapsed')) {
			if (sub.is(':visible')) {
				sub.slideUp(200, function () {
					parent.removeClass('nav-active');
					jQuery('.main-content').css({height: ''});
					mainContentHeightAdjust();
				});
			}
			else {
				visibleSubMenuClose();
				parent.addClass('nav-active');
				sub.slideDown(200, function () {
					mainContentHeightAdjust();
				});
			}
		}
		return false;
	});

	function visibleSubMenuClose() {
		jQuery('.menu-list').each(function () {
			var t = jQuery(this);
			if (t.hasClass('nav-active')) {
				t.find('> ul').slideUp(200, function () {
					t.removeClass('nav-active');
				});
			}
		});
	}

	function mainContentHeightAdjust() {
		// Adjust main content height
		var docHeight = jQuery(document).height();
		if (docHeight > jQuery('.main-content').height())
			jQuery('.main-content').height(docHeight);
	}

	//  class add mouse hover
	jQuery('.custom-nav > li').hover(function () {
		jQuery(this).addClass('nav-hover');
	}, function () {
		jQuery(this).removeClass('nav-hover');
	});


	// Menu Toggle
	jQuery('.toggle-btn').click(function () {
		$(".left-side").getNiceScroll().hide();

		if ($('body').hasClass('left-side-collapsed')) {
			$(".left-side").getNiceScroll().hide();
		}
		var body = jQuery('body');
		var bodyposition = body.css('position');

		if (bodyposition != 'relative') {

			if (!body.hasClass('left-side-collapsed')) {
				body.addClass('left-side-collapsed');
				jQuery('.custom-nav ul').attr('style', '');

				jQuery(this).addClass('menu-collapsed');

			}
			else {
				body.removeClass('left-side-collapsed chat-view');
				jQuery('.custom-nav li.active ul').css({display: 'block'});

				jQuery(this).removeClass('menu-collapsed');

			}
		}
		else {

			if (body.hasClass('left-side-show'))
				body.removeClass('left-side-show');
			else
				body.addClass('left-side-show');

			mainContentHeightAdjust();
		}

	});


	searchform_reposition();

	jQuery(window).resize(function () {
		if (jQuery('body').css('position') == 'relative') {

			jQuery('body').removeClass('left-side-collapsed');

		}
		else {

			jQuery('body').css({left: '', marginRight: ''});
		}

		searchform_reposition();

	});

	function searchform_reposition() {
		if (jQuery('.searchform').css('position') == 'relative') {
			jQuery('.searchform').insertBefore('.left-side-inner .logged-user');
		}
		else {
			jQuery('.searchform').insertBefore('.menu-right');
		}
	}

	// panel collapsible
	$('.panel .tools .fa').click(function () {
		var el = $(this).parents(".panel").children(".panel-body");
		if ($(this).hasClass("fa-chevron-down")) {
			$(this).removeClass("fa-chevron-down").addClass("fa-chevron-up");
			el.slideUp(200);
		}
		else {
			$(this).removeClass("fa-chevron-up").addClass("fa-chevron-down");
			el.slideDown(200);
		}
	});

	$('.todo-check label').click(function () {
		$(this).parents('li').children('.todo-title').toggleClass('line-through');
	});

	$(document).on('click', '.todo-remove', function () {
		$(this).closest("li").remove();
		return false;
	});

	$("#sortable-todo").sortable();


	// panel close
	$('.panel .tools .fa-times').click(function () {
		$(this).parents(".panel").parent().remove();
	});


	// tool tips
	$('.tooltips').tooltip();

	// popovers
	$('.popovers').popover();
})(jQuery);