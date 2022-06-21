//#region - Local Variables
var selected = {};
var inprogValues = {};
var errorMessage = [];
//#endregion

//#region - UI Events
function onClickOkBtn(e) {
    var selectedOrderInfo = selected.orderInfo;
    errorMessage = validate(selectedOrderInfo);
    if (errorMessage.length == 0) {
        if (selectedOrderInfo && selectedOrderInfo.Status != 2) {
            if (!(selectedOrderInfo.Status == 1 && !$("#isCompletedChkBox").prop('checked'))) {
                moveStatus();
            }
        }
        $("#myModal").modal("hide");
    } else {
        showError(errorMessage[0]);
    }
}

function handleFileInput(e) {
    var files = e.target.files;
    if (files && files.item)
        inprogValues.fileToUpload = files.item(0);
}

function onClickSave() {
    $.ajax({
        type: "POST",
        url: "/Dashboard/Save",
        success: function (r) { success(r); },
        data: JSON.stringify(dataModel.Distributors),
        contentType: "application/json; charset=utf-8",
    });
}

function success(data) {
    if (data && data == "success") {
        alert("Saved Succesfully");
    }
}
//#endregion

//#region - Methods

function validate(selectedOrderInfo) {
    errorMessage = [];
    if (selectedOrderInfo.Status == 0 && $("#inprogressTextVal").val() == "")
        errorMessage.push("Fill the required fields !");
    return errorMessage;
}

function showError(errorMessage) {
    $(".modal-error").text(errorMessage).removeClass("hidden");

}

function clearError() {
    $(".modal-error").text("").addClass("hidden");;
}

function showPopup(e, distributorId, orderInfoId) {
    clearError();
    selected = getSelectedInfo(distributorId, orderInfoId);
    if (selected.orderInfo && selected.orderInfo.Status !== 2) {
        selected.distributor = distributor;
        selected.target = e.target;

        var type = "InProgress";
        var title = "Move to InProgress";
        if (selected.orderInfo.Status == 1) {
            type = "Complete";
            title = "Move to Complete";
        }
        $("#moveToStatusTitle").text(title);

        $.get("/Dashboard/ShowpopUp/", { type: type },
            function (data) {
                $('.modal-body').html(data);
            });
        $("#myModal").modal("show");
    }
}

function getSelectedInfo(distributorId, orderInfoId) {
    if (dataModel && dataModel.Distributors) {
        distributor = dataModel.Distributors.find(item => item.Id == distributorId);
        var orderInfo = distributor && distributor.Orders.find(item => item.Id == orderInfoId);
        return {
            distributor: distributor, orderInfo: orderInfo
        };
    }
    return {};
}

function moveStatus() {
    if (selected.orderInfo && selected.target) {
        var selectedOrderInfo = selected.orderInfo;
        switch (selectedOrderInfo.Status) {
            case 0:
                selectedOrderInfo.Status = 1;
                $(selected.target).removeClass("open").addClass("inprogress");
                return true;
            case 1:
                selectedOrderInfo.Status = 2;
                $(selected.target).removeClass("inprogress").addClass("completed");
                return true;;
        }
    }
    return false;
}

function clearHelperValues() {
    selected = {};
    inprogValues = {};
    errorMessage = [];
    clearError();
    $("#isCompletedChkBox").prop('checked', false);
}

//#endregion

