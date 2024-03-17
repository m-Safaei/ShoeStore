    /*=====================
     20. Color Picker
     ==========================*/
    var color_picker1 = document.getElementById("ColorPicker1").value;
    document.getElementById("ColorPicker1").onchange = function () {
        color_picker1 = this.value;
        document.body.style.setProperty('--theme-color', color_picker1);
    };

    /*------------------------------
    21. RTL & Dark Light
    -------------------------------*/
    var events = $("body");
    events.on("click", ".ltr-btn", function () {
        $(this).toggleClass('ltr');
        $('body').removeClass('rtl');
        if ($('.ltr-btn').hasClass('ltr')) {
            $('.ltr-btn').text('RTL');
            $('body').addClass('ltr');
        } else {
            $('.ltr-btn').text('ltr');
        }
        return false;
    });



    $(".setting_buttons li").click(function () {
        $(this).addClass('active').siblings().removeClass('active');
    });
    $(".color-box li").click(function () {
        $(this).addClass('active').siblings().removeClass('active');
    });

    function openSetting() {
        document.getElementById("setting_box").classList.add('open-setting');
        document.getElementById("setting-icon").classList.add('open-icon');
    }

    function closeSetting() {
        document.getElementById("setting_box").classList.remove('open-setting');
        document.getElementById("setting-icon").classList.remove('open-icon');
    }