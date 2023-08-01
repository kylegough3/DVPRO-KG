$(document).ready(function () {
    $('.sidebar-nav .nav-link').click(function() {
        localStorage.removeItem('aNavLink');
    })
    $('header div a').click(function() {
        localStorage.removeItem('aNavLink');
        console.log('hey')
    })
    $('.sidebar-nav .nav-content a').click(function () {
        if ($(this).is('[id]')) {
            localStorage.setItem('aNavLink', $(this).attr('id'));
        } else {
            localStorage.setItem('aNavLink', '');
        }
    });
    let activeLink = localStorage.getItem('aNavLink');
    if (activeLink) {
        $('#' + activeLink).addClass('active');
    }
});