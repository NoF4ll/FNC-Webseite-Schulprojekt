//tableUsers
$(document).ready(() => {
   
    alert("hallo");
        $.ajax({

        
            url: "/AJAX/getAllUsers",
       
        method: "GET",
        
        success: (dataFromServer) => {
            if (dataFromServer == "NoUsers") {
                $("#tableUsers").text("Keine User Vorhanden")
            }
            else if (dataFromServer == "Error") {
                $("#tableUsers").text("Fehler")
            }
            else {
                $("#tableUsers").html(createTableUsers(dataFromServer));


            }

        },
        error: () => {
            $("#tableUsers").text("Es trat ein Fehler auf die Artikeldaten konnten nicht geladen werden!")
        }

    });

});


function createTableUsers(users) {
    let s = `<table>
        <thead>
            <tr>
                <td colspan="2">Users</td>
            </tr>
        </thead>
        <tbody>
            
        `
    for (let i = 0; i < users.length; i++) {
        s += `
            <tr>
                <td>${users[i].username}</td >
                <td>${users[i].password}</td>
               
            </tr>`;
    }
    s += `
</tbody>
    </table >`
    return s;
}


