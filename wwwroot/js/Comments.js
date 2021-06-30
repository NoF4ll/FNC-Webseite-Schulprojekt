$().ready(() => {
    $.ajax({
        url: "/shop/GetAllComments",
        method: "GET",
        success: (dataFromServer) => {
            if (dataFromServer == "Error") {
                $(".comments").html("Data Error");
            }
            else {
                $(".comments").html(getCommentHTML(dataFromServer))
            }

        },
        error: () => {
            $(".comments").html("AJAX Error")
        }
    });
});

function getCommentHTML(comments) {
    let commentsHTML = ``;
    for (let i = 0; i < comments.length; i++) {
        commentsHTML += `
    <tr>
        <td>${comments[i].text}</td>
        <td><img src="..${comments[i].imagePath}" class="commentImage"/></td>
    </tr>
    <tr class="commentBottom">
        <td>Name : ${comments[i].creator}</td>
        <td>Bewertung : ${comments[i].rating} <svg height="25" width="23" class="star rating" data-rating="1">
    <polygon points="9.9, 1.1, 3.3, 21.78, 19.8, 8.58, 0, 8.58, 16.5, 21.78" style="fill-rule:nonzero;"/>
  </svg></td>
    </tr>`
    }

    return `<table class="commentTable">${commentsHTML}</table>`
}