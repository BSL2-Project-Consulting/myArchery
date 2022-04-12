jQuery(document).ready(function () {
	jQuery('.titleWrapper').click(function () {
		var toggle = jQuery(this).next('div#descwrapper');
		jQuery(toggle).slideToggle("slow");
	});
	jQuery('.inactive').click(function () {
		jQuery(this).toggleClass('inactive active');
	});
});
