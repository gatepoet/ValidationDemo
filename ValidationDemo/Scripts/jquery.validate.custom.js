(function ($) {
	$.validator.addMethod("uppercase", function (value, element) {
		return value === value.toUpperCase();
	}, "Only uppercase letters are allowed");
	$.validator.unobtrusive.adapters.addBool("uppercase");

	$.validator.addMethod("notequalto", function (value, element, params) {
		var otherProp = $('#' + params);
		return value != otherProp.val();
	})
	$.validator.unobtrusive.adapters.addSingleVal("notequalto", "otherproperty");

})(jQuery);