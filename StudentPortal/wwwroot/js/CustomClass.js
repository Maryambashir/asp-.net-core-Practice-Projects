var StudentClass = new function () {
    var studentData;
    this.DeleteStudent = function (studentID) {
        $.ajax({
            type: 'POST',  // http method
            url: '/api/Students/DeleteStudent',
            contentType: "application/json",
            data: JSON.stringify({ id: studentID }),  // data to submit
            success: function (response) {
                alert(response.message);
                window.location.reload();
            },
            error: function (failure) {
                alert(failure.message);
            },
        });
    };
    //function DeleteStudent(studentID) {
    //    $.ajax({
    //        type: 'POST',  // http method
    //        url: '/api/Students/DeleteStudent',
    //        contentType: "application/json",
    //        data: JSON.stringify({ id: studentID }),  // data to submit
    //        success: function (response) {
    //            alert(response.message);
    //            window.location.reload();
    //        },
    //        error: function (failure) {
    //            alert(failure.message);
    //        },
    //    });
    //};

    this.CreateStudent = function() {
        var studentData = getData();
        if (studentData != null) {
            $.ajax({
                type: 'POST',  // http method
                url: '/api/Students/CreateStudent',
                contentType: false,
                processData: false,
                data: studentData,  // data to submit
                success: function (response) {
                    alert(response.message);
                    console.log(response)
                    window.location.reload();
                },
                error: function (failure) {
                    alert(failure.message);
                },
            });
        }
        else {
            alert("Enter Form Values");
        }
        
    };
    function getData() {
        debugger;
        var Firstname = $('#FirstName').val();
        var Lastname = $('#LastName').val();
        var Email = $('#Email').val();
        var img = document.getElementById('StudentImg').files[0]
        if (Firstname == '' || Lastname == '' || Email == '') {
            return null;
        }
        else {
            var fd = new FormData();
            fd.append("files", img);
            fd.append("firstname", Firstname);
            fd.append("lastname", Lastname);
            fd.append("email", Email);
            return fd;
        }
    }

    this.CreateStudentNew = function () {
        debugger;
        getDataWithImage((studentData) => {
            debugger;
            if (studentData != null) {
                $.ajax({
                    type: 'POST',  // http method
                    url: '/api/Students/CreateStudentNew',
                    contentType: "application/json",
                    data: JSON.stringify(studentData),  // data to submit
                    success: function (response) {
                        alert(response.message);
                        console.log(response)
                        window.location.reload();
                    },
                    error: function (failure) {
                        alert(failure.message);
                    },
                });
            }
            else {
                alert("Enter Form Values");
            }
        });
    };

    function getDataWithImage(callback) {
        debugger;
        var Firstname = $('#FirstName').val();
        var Lastname = $('#LastName').val();
        var Email = $('#Email').val();
        var imgFile = document.getElementById('StudentImg').files[0]

        toBase64(imgFile, (result) => {
            debugger;
            imgBase64 = result;
            if (Firstname == '' || Lastname == '' || Email == '') {
                studentData = null
                callback(studentData)
            }
            else {
                studentData = { firstname: Firstname, lastname: Lastname, email: Email, image: imgBase64 };
                callback(studentData)
            }
        });
    }

    function toBase64(file, callback) {
        debugger;
        let reader = new FileReader();
        reader.readAsDataURL(file);

        reader.onload = function () {
            let parsedStr = reader.result
            debugger;
            if (parsedStr !== "") {
                callback(parsedStr)
            } 
        };
        reader.onerror = function (error) {
            console.log('Error: ', error);
        };
    };

}