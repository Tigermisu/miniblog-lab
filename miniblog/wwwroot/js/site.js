// Write your JavaScript code.
$(function() {
    var $preview = $('#previewInput'),
        $sidenav = $('.sidenav');

    if ($preview.length > 0) {

        $preview.keyup(function () {
            var markdownText = $(this).val();

            updatePreview(markdownText);
        });

        updatePreview($preview.val());
    }

    if ($sidenav.length > 0) {
        $(window).resize(function () {
            $sidenav.css('width', parseInt($sidenav.parent().css('width')) - 30);
        });

        $(window).resize();
    }
});

function updatePreview(mdText) {
    $('#previewOutput').html(marked(mdText, {
        sanitize: true
    }));
}
