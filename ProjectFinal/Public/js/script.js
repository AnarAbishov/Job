$(document).ready(function () {
    new WOW().init();

    var show_per_page = 6;
    var number_of_items = $('#paginate .tr').length;

    var navigation_html = '<a class="previous_link" href=""><<</a>' + '&nbsp';
    var current_link = 1;
    for (var i = 0; i < number_of_items; i = i + show_per_page) {
        navigation_html += '<a class="page_link" href="" data-start="' + i + '" data-end="' + (i + show_per_page) + '">' + (current_link) + '</a>' + '&nbsp';
        current_link++;
    }
    navigation_html += '<a class="next_link" href="">>></a>';
    $('#page_navigation').html(navigation_html);
    rowDisplay(0, show_per_page);

    function rowDisplay(startIndex, endIndex) {
        $('#paginate .tr').hide().slice(startIndex, endIndex).show();
    }

    $('.page_link').click(function (e) {
        e.preventDefault();
        $('.active').removeClass('active');
        $(this).addClass('active');
        var IndexData = $(this).data();
        rowDisplay(IndexData.start, IndexData.end);
    }).first().addClass('active');

    $('.previous_link, .next_link').click(function (e) {
        e.preventDefault();
        var traverse = $(this).is('.previous_link') ? 'prev' : 'next';
        $('.page_link.active')[traverse]('.page_link').click();
    });



    $(".form-control").on("keyup", function (event) {
        checkTextAreaMaxLength(this, event);
    });


    function checkTextAreaMaxLength(textBox, e) {

        var maxLength = parseInt($(textBox).data("length"));


        if (!checkSpecialKeys(e)) {
            if (textBox.value.length > maxLength - 1) textBox.value = textBox.value.substring(0, maxLength);
        }
        $(".char-count-Elave_melumat").html(maxLength - textBox.value.length);

        return true;
    }



    function checkSpecialKeys(e) {
        if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
            return false;
        else
            return true;
    }

    $(".form-control1").on("keyup", function (event) {
        checkTextAreaMaxLength1(this, event);
    });


    function checkTextAreaMaxLength1(textBox, e) {

        var maxLength1 = parseInt($(textBox).data("length"));


        if (!checkSpecialKeys1(e)) {
            if (textBox.value.length > maxLength1 - 1) textBox.value = textBox.value.substring(0, maxLength1);
        }
        $(".char-count-Namizede_telebler").html(maxLength1 - textBox.value.length);

        return true;
    }

    function checkSpecialKeys1(e) {
        if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
            return false;
        else
            return true;
    }





    $(".form-control2").on("keyup", function (event) {
        checkTextAreaMaxLength2(this, event);
    });


    function checkTextAreaMaxLength2(textBox, e) {

        var maxLength2 = parseInt($(textBox).data("length"));


        if (!checkSpecialKeys2(e)) {
            if (textBox.value.length > maxLength2 - 1) textBox.value = textBox.value.substring(0, maxLength2);
        }
        $(".char-count-Ish_barede_melumat").html(maxLength2 - textBox.value.length);

        return true;
    }



    function checkSpecialKeys2(e) {
        if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
            return false;
        else
            return true;
    }


    $(function () {
        $('#myTab li:last-child a').tab('show')
    })

    $("select[name=KategoriyaId]").change(function () {
        var KategoriyaId = $(this).val();
        modelsUrl = "http://localhost:51808/cv_yarat/GetVezifeJson/" + KategoriyaId;
        $("select[name=VezifeId]").empty();

        $.ajax({
            url: modelsUrl,
            type: "get",
            datatype: "html",
            success: function (response) {
                for (var i = 0; i < response.length; i++) {
                    $("select[name=VezifeId]").append("<option value='" + response[i].Id + "'>" + response[i].Ad + "</option>");
                }
            }

        })

    })

});