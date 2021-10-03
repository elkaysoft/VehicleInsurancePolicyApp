
function GetVehicleMake(urlBase) {

    $('#drpVehicleMake').empty();
    $("#drpVehicleMake").append("<option selected='true' value='0' disabled>Choose Vehicle Make</option>");

    $.getJSON(urlBase, function (response) {
        console.log(response);
        if (response.data != null) {
            let obj = Object.entries(response.data);
            for (let [key, value] of obj) {
                $('#drpVehicleMake').append($('<option></option>')
                    .attr('value', value.id)
                    .text(value.vehicleMake));
            }
        }

    });
};


function getVehicleModelByMake(urlBase) {
    $('#drpVehicleMake').change(function (e) {
       var $selectedOption = $('#drpVehicleMake option:selected').text();

        var urlReasons = urlBase + '?maker=' + $selectedOption;

        $('#drpVehicleModel').empty();
        $('#drpVehicleModel').append('<option selected="true" disabled>Choose Model</option>')
        $.getJSON(urlReasons, function (data) {
            let obj = Object.entries(data.data);
            for (let [key, value] of obj) {
                $('#drpVehicleModel').append($('<option></option>')
                    .attr('value', value.id)
                    .text(value.vehicleModel));
            }
        });
    });
};

function GetInsurancePolicy(urlBase) {

    $('#drpBodyType').empty();
    $("#drpBodyType").append("<option selected='true' value='0' disabled>Choose Vehicle Make</option>");

    $.getJSON(urlBase, function (response) {
        console.log(response);
        if (response.data != null) {
            let obj = Object.entries(response.data);
            for (let [key, value] of obj) {
                $('#drpBodyType').append($('<option></option>')
                    .attr('value', value.amount)
                    .text(value.bodyType));
            }
        }

    });
};

$('#drpBodyType').change(function (e) {
    var $selectedOption = $('#drpBodyType option:selected').val();
    $('#spAmount').text($selectedOption);    
});


$('input').on('blur keyup', function () {
    if ($("#paymentForm").valid()) {
        $('#btnProceed').prop('disabled', false);
    } else {
        $('#btnProceed').prop('disabled', 'disabled');
    }
});

