var CustomJs = new function () {

    this.DeleteStudent = function (studentID) {
        $.ajax({
            type: "DELETE",
            url: '/api/Students/DeleteStudent?studentID=' + studentID,
        }).done(function (data) {
            window.location = "/"
        })
    };


}