(function ($) {
    $.fn.inputFilter = function (inputFilter) {
        return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            } else {
                this.value = "";
            }
        });
    };
}(jQuery));



$("[datatype='currency']").inputFilter(function (value) {
    return /^-?\d*[.,]?\d{0,2}$/.test(value);
});

$("[datatype='uint']").inputFilter(function (value) {
    return /^\d*$/.test(value);
});

$("#intTextBox").inputFilter(function (value) {
    return /^-?\d*$/.test(value);
});

$("#intLimitTextBox").inputFilter(function (value) {
    return /^\d*$/.test(value) && (value === "" || parseInt(value) <= 500);
});
$("#floatTextBox").inputFilter(function (value) {
    return /^-?\d*[.,]?\d*$/.test(value);
});

$("#latinTextBox").inputFilter(function (value) {
    return /^[a-z]*$/i.test(value);
});
$("#hexTextBox").inputFilter(function (value) {
    return /^[0-9a-f]*$/i.test(value);
});