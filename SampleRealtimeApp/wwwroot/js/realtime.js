
var connection = new signalR.HubConnectionBuilder()
                            .withUrl('/product')
                            .build();
let btnSave = document.getElementById('btnSave');
btnSave.disabled = true;

connection.on('receiveProduct', function (name, description, status, actionType) {
    if (actionType == 'create') {
        try {
            let tr = document.createElement('tr');
            let nameTD = document.createElement('td');
            let descriptionTD = document.createElement('td');
            let statusTD = document.createElement('td');
            nameTD.textContent = name;
            descriptionTD.textContent = description;
            statusTD.textContent = status;
            tr.appendChild(nameTD);
            tr.appendChild(descriptionTD);
            tr.appendChild(statusTD);
            tr.appendChild(document.createElement('td'));
            document.querySelector('#tblProducts tbody').appendChild(tr);
        } catch (err) {

            return console.error(err.toString());
        }
    }
});

connection.start().then(function () {
    btnSave.disabled = false;

}).catch(function (err) {
   return console.error(err.toString());
})

btnSave.addEventListener('click', function (e) {
    let name = document.getElementById('txtName').value;
    let description = document.getElementById('txtDescription').value;
    let status = document.getElementById('ddStatus').value;
    connection.invoke('sendProduct', name, description, status, 'create')
        .catch(function (err) {
            return console.error(err.toString());
        });
    e.preventDefault();
})