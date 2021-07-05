$(document).ready(function () {
    function loadMonth() {
        $('#month').append(`<option value='Jan'>JAN</option>`);
        /*$('#month').append(`<option value="Jan">JAN</option>`);
        $('#month').append(`<option value="Feb">FEB</option>`);
        $('#month').append(`<option value="Mar">MAR</option>`);
        $('#month').append(`<option value="Apr">APR</option>`);
        $('#month').append(`<option value="May">MAY</option>`);
        $('#month').append(`<option value="Jun">JUN</option>`);
        $('#month').append(`<option value="Jul">JUL</option>`);
        $('#month').append(`<option value="Aug">AUG</option>`);
        $('#month').append(`<option value="Sep">SEP</option>`);
        $('#month').append(`<option value="Oct">OCT</option>`);
        $('#month').append(`<option value="Nov">NOV</option>`);
        $('#month').append(`<option value="Dec">DEC</option>`);*/
    }
    function loadDay() {
        if ($('#month').val() == 'Jan' || $('#month').val() == 'Mar' || $('#month').val() == 'May' || $('#month').val() == 'Jul' || $('#month').val() == 'Aug' || $('#month').val() == 'Oct' || $('#month').val() == 'Dec') {
            for (var i = 1; i <= 31; i++) {
                $('#day').append(`<option value='`.i.`'>`.i.`</option>`);
            }
        }
        else if ($('#month').val() == 'Feb'){
            for (var i = 1; i <= 29; i++) {
                $('#day').append(`<option value='`.i.`'>`.i.`</option>`);
            }
        }
        else {
            for (var i = 1; i <= 30; i++) {
                $('#day').append(`<option value='`.i.`'>`.i.`</option>`);

            }
        }
    }
    function loadYear() {
        var currentTime = new Date();
        var year = currentTime.getFullYear();
        for (var i = 1900; i <= year; i++) {
            $('#year').append(`<option value='`.i.`'>`.i.`</option>`);

        }
    }
    function loadDates() {

        loadMonth();
        loadDay();
        loadYear();
    }

    loadMonth();
    //loadDates();

}