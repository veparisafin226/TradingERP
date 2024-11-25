
$(document).ready(function () {
    var typeVal = $("#RgmType").val();
    
    if (typeVal == "Liz") {
        $("#RgmLiz").attr('required', 'required');
        $("#RgmLiz").attr('data-val', 'true');
        $("#RgmLiz").attr('data-val-required', 'Please select Liz');
        $("#RgmDealer").removeAttr('required');
        $("#RgmDealer").removeAttr('data-val');
        $("#RgmDealer").removeAttr('data-val-required');
        $("#dealerDiv").hide();
        $("#lizDiv").show();
        $("#RateDiv").hide();
        $("#TotalDiv").show();
    }
    else {
        $("#RgmDealer").attr('required', 'required');
        $("#RgmDealer").attr('data-val', 'true');
        $("#RgmDealer").attr('data-val-required', 'Please select Dealer');
        $("#RgmLiz").removeAttr('required');
        $("#RgmLiz").removeAttr('data-val');
        $("#RgmLiz").removeAttr('data-val-required');
        $("#dealerDiv").show();
        $("#lizDiv").hide();
        $("#RateDiv").show();
        $("#TotalDiv").show();
    }

    $("#btnCreate").click(function (e) {
        
        const form = $("#frmRegister")[0];
        if (form.checkValidity()) {
            $("#frmMsg").removeClass("alert alert-danger");
            $("#frmMsg").text("");
            form.submit();
        }
        else {
            $("#frmMsg").addClass("alert alert-danger");
            $("#frmMsg").text("Please fill out all required fields correctly.");
            e.preventDefault();
        }
        
    });
    //$('#frmRegister').on('submit', function (e) {
    //    alert("submit")
    //    e.preventDefault(); // Prevent form submission
    //    if (this.checkValidity()) {
    //        alert("Form is valid!");
    //        // Proceed with form submission or any other logic
    //        this.submit();
    //    } else {
    //        alert("Form is invalid.");
    //    }
    //});
    $("#RgmType").change(function () {
        
        $("#RgmRate1").val("0");
        $("#RgmTotal1").val("0");
        var typeVal = $("#RgmType").val();
        
        if (typeVal == "Liz") {
            $("#RgmLiz").attr('required', 'required');
            $("#RgmLiz").attr('data-val', 'true');
            $("#RgmLiz").attr('data-val-required', 'Please select Liz');
            $("#RgmDealer").removeAttr('required');
            $("#RgmDealer").removeAttr('data-val');
            $("#RgmDealer").removeAttr('data-val-required');
            $("#lizDiv").show();
            $("#dealerDiv").hide();
            $("#RateDiv").hide();
            $("#TotalDiv").show();
        }
        else {
            $("#RgmDealer").attr('required', 'required');
            $("#RgmDealer").attr('data-val', 'true');
            $("#RgmDealer").attr('data-val-required', 'Please select Dealer');
            $("#RgmLiz").removeAttr('required');
            $("#RgmLiz").removeAttr('data-val');
            $("#RgmLiz").removeAttr('data-val-required');
            $("#lizDiv").hide();
            $("#dealerDiv").show();
            $("#RateDiv").show();
            $("#TotalDiv").show();
        }
    });
   
    $("#RgmQty").blur(function () {
       
        var qty = $("#RgmQty").val();
        var rate = $("#RgmRate").val();
        var rate1 = $("#RgmRate1").val();
        var typeVal = $("#RgmType").val();
        if (qty == undefined || qty == "" || rate == undefined || rate == "") {
            $("#RgmTotal").val("0");
            $("#RgmTotal1").val("0");
        }
        else {
            try {
                var total = parseFloat(qty) * parseFloat(rate);
                total = total.toFixed(2);
                $("#RgmTotal").val(total);
                if (typeVal == "Dealer") {
                    var total1 = parseFloat(qty) * parseFloat(rate1);
                    total1 = total1.toFixed(2);
                    $("#RgmTotal1").val(total1);
                }
            }
            catch (e) {
                $("#RgmTotal").val("0");
                $("#RgmTotal1").val("0");
            }
        }
    });

    $("#RgmRate").blur(function () {
        
        var qty = $("#RgmQty").val();
        var rate = $("#RgmRate").val();
        if (qty == undefined || qty == "" || rate == undefined || rate == "") {
            $("#RgmTotal").val("0");
        }
        else {
            try {
                var total = parseFloat(qty) * parseFloat(rate);
                total = total.toFixed(2);
                $("#RgmTotal").val(total);
            }
            catch (e) {
                $("#RgmTotal").val("0");
            }
        }
    });

    $("#RgmRate1").blur(function () {
        
        var typeVal = $("#RgmType").val();
        if (typeVal == "Dealer") {
            var qty = $("#RgmQty").val();
            var rate = $("#RgmRate1").val();
            if (qty == undefined || qty == "" || rate == undefined || rate == "") {
                $("#RgmTotal1").val("0");
            }
            else {
                try {
                    var total = parseFloat(qty) * parseFloat(rate);
                    total = total.toFixed(2);
                    $("#RgmTotal1").val(total);
                }
                catch (e) {
                    $("#RgmTotal1").val("0");
                }
            }
        }
    });

    

});


  

