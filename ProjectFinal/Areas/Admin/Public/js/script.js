$(document).ready(function(){
    
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
   
   $('.page_link').click(function(e){
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
   

    });

      
