/*!
    * Start Bootstrap - Freelancer v6.0.4 (https://startbootstrap.com/themes/freelancer)
    * Copyright 2013-2020 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-freelancer/blob/master/LICENSE)
    */
(function ($) {
    "use strict"; // Start of use strict

    $("#sendMessageButton").click(function (e) {
        e.preventDefault();
        var button = $("#sendMessageButton");
        button.prop("disabled", true); // Disable submit button until AJAX call is complete to prevent duplicate messages                    

        var values = {
            name: $("#name").val(),
            email: $("#email").val(),
            phoneNumber: $("#phone").val(),
            body: $("#message").val()            
        }

        $.ajax({
            url: "/Home/SendEmail",
            type: "POST",
            data: values,            
        }).done(function (data) {
            // Success message
            $("#success").html("<div class='alert alert-success'>");
            $("#success > .alert-success")
                .html(
                    "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;"
                )
                .append("</button>");
            $("#success > .alert-success").append(
                "<strong>" + data + "</strong>"
            );
            $("#success > .alert-success").append("</div>");  
        }).fail(function (data) {
            // Fail message
            let messageError;

            if (data.responseText != null) {
                messageError = data.responseText;
            }
            else if (data != null) {
                messageError = data;
            }
            else {
                messageError = "Desculpa " + firstName + ", parece que no momento não consigo enviar o e-mail, tente outro contato!";
            }

            $("#success").html("<div class='alert alert-danger'>");
            $("#success > .alert-danger")
                .html(
                    "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;"
                )
                .append("</button>");
            $("#success > .alert-danger").append(
                $("<strong>").text(messageError)
            );
            $("#success > .alert-danger").append("</div>");
        }).always(function () {
            $("#contactForm").trigger("reset");

            setTimeout(function () {
                $this.prop("disabled", false); // Re-enable submit button when AJAX call is complete
            }, 1000);
        });        
    });

    // Smooth scrolling using jQuery easing
    $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: (target.offset().top - 71)
                }, 1000, "easeInOutExpo");
                return false;
            }
        }
    });

    // Scroll to top button appear
    $(document).scroll(function () {
        var scrollDistance = $(this).scrollTop();
        if (scrollDistance > 100) {
            $('.scroll-to-top').fadeIn();
        } else {
            $('.scroll-to-top').fadeOut();
        }
    });

    // Closes responsive menu when a scroll trigger link is clicked
    $('.js-scroll-trigger').click(function () {
        $('.navbar-collapse').collapse('hide');
    });

    // Activate scrollspy to add active class to navbar items on scroll
    $('body').scrollspy({
        target: '#mainNav',
        offset: 80
    });

    // Collapse Navbar
    var navbarCollapse = function () {
        if ($("#mainNav").offset().top > 100) {
            $("#mainNav").addClass("navbar-shrink");
        } else {
            $("#mainNav").removeClass("navbar-shrink");
        }
    };
    // Collapse now if page is not at top
    navbarCollapse();
    // Collapse the navbar when page is scrolled
    $(window).scroll(navbarCollapse);

    // Floating label headings for the contact form
    $(function () {
        $("body").on("input propertychange", ".floating-label-form-group", function (e) {
            $(this).toggleClass("floating-label-form-group-with-value", !!$(e.target).val());
        }).on("focus", ".floating-label-form-group", function () {
            $(this).addClass("floating-label-form-group-with-focus");
        }).on("blur", ".floating-label-form-group", function () {
            $(this).removeClass("floating-label-form-group-with-focus");
        });
    });

})(jQuery); // End of use strict
