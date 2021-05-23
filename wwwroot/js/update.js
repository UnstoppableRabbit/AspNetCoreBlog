$('.openmodal').click(function (e) {
    e.preventDefault();
    $('.modal').addClass('opened');
    $('.UserID').val($(this).find('.UID').text());
    $('.UserMail').val($(this).find('.UMail').text());
    $('.UserRole').val($(this).find('.URole').text());
    $('.UserNick').val($(this).find('.UNick').text());
});
$('.closemodal').click(function (e) {
    e.preventDefault();
    $('.modal').removeClass('opened');
});