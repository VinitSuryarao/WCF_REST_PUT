function getAllClients() {
    $.ajax({
        url: "Service/ClientService.svc/GetAllClients",
        type: "GET",
        dataType: "json",
        success: function (result) {
            clients = result;
            bindClientListToTable(clients);
        }
    });
}

function updateClient() {
    var id = $("#updateId").val();
    var uptclient = {
        "Id": $("#updateId").val(),
        "Code": $("#updateCode").val(),
        "Name": $("#updateName").val(),
        "Exchange": $("#updateExchange").val()
    };

    $.ajax({
        url: "Service/ClientService.svc/UpdateClient/" + id,
        type: "PUT",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(uptclient),
        success: function (result) {
            console.log(result);
            getAllClients();
        }
    });
}

