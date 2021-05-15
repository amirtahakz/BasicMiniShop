function opennav() {

    document.getElementById('all-nav').style.display = "block";
}
function closenav() {
    document.getElementById('all-nav').style.display = "none";
}

function opendiv1() {
    document.getElementById('div1').style.display = "block";
    document.getElementById('div2').style.display = "none";
    document.getElementById('div3').style.display = "none";
    document.getElementById('div4').style.display = "none";
}
function opendiv2() {
    document.getElementById('div1').style.display = "none";
    document.getElementById('div2').style.display = "block";
    document.getElementById('div3').style.display = "none";
    document.getElementById('div4').style.display = "none";
}
function opendiv3() {
    document.getElementById('div1').style.display = "none";
    document.getElementById('div2').style.display = "none";
    document.getElementById('div3').style.display = "block";
    document.getElementById('div4').style.display = "none";
}
function opendiv4() {
    document.getElementById('div1').style.display = "none";
    document.getElementById('div2').style.display = "none";
    document.getElementById('div3').style.display = "none";
    document.getElementById('div4').style.display = "block";
}
document.getElementById('user').addEventListener("mouseover", mouseOver);
document.getElementById('user').addEventListener("mouseout", mouseOut);
document.getElementById('all-info-user').addEventListener("mouseout", mouseOut);
document.getElementById('all-info-user').addEventListener("mouseover", mouseOver);

function mouseOver() {
    document.getElementById('all-info-user').style.display = "block";
}

function mouseOut() {
    document.getElementById('all-info-user').style.display = "none";
}

function Category() {
    this.id = "";
    this.CategoryName = "";
}
function OpenCategorySubject(id) {

    $.ajax({
        url: '/cms/ReadByIdProduct',
        type: 'post',
        data: { id: id },
        success: function (data) {
            window.location.replace("https://localhost:44304/Category/Index")
        },
        error: function (errorThrown) {
            console.log(errorThrown);
        }
    });

}

function User() {
    this.ConfirmPassword = "";
    this.Password = "";
    this.NameFamily = "";
    this.Email = "";

}

function Register() {
    var u1 = new User();    
    u1.NameFamily = $("#NameFamily").val();
    u1.Email = $("#Email").val();
    u1.Password = $("#Password").val();
    u1.ConfirmPassword = $("#ConfirmPassword").val();   

    var form = document.getElementById("Registertion");
    if ($("#ConfirmPassword").val() != $("#Password").val()) {
        alert("رمز عبور خود را درست تایید کنید");  
    } else if (form.checkValidity() && $("#ConfirmPassword").val() == $("#Password").val()) {
        form.submit();
        $.ajax({
            url: '/Account/Register',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(u1),
            success: function (data) {
                alert(data);
            },
            error: function (errorThrown) {
                alert(errorThrown);
            }
        });
    }
}


function Login() {

    var u1 = new User();
    u1.Email = $("#EmailForLogin").val();
    u1.Password = $("#PasswordForLogin").val();

   if ($("#EmailForLogin").val() == "" || $("#PasswordForLogin").val() == "") {
        alert("لطفا همه فیلد هارا پر کنید");
   } else {

        $.ajax({
            url: '/Account/Login',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(u1),
            success: function (data) {
                if (data.redirectUrl) {
                    window.location.href = data.redirectUrl;
                } else if (data.redirectUrl2) {
                    window.location.href = data.redirectUrl2;
                } else {
                    alert("رمز عبور با نام کاربری مطابقت ندارد");
                }
            },
            error: function (errorThrown) {
                alert(errorThrown);
            }
        });
   }
}
function Category() {
    this.Subject = "";
}

function CreateNewCategory() {
    var c1 = new Category();
    c1.Subject = $("#ValueOfNewCategory").val();
    $.ajax({
        url: '/AdminDashboard/CreateNewCategory',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(c1),
        success: function (data) {
            alert("با موفقیت ذخیره شد");
            $("#ValueOfNewCategory").val("");
        },
        error: function (errorThrown) {
            alert(errorThrown);
        }
    });

}
function ShowSelectedCategory(Id) {
    $.ajax({
        url: '/Products/AllProduct',
        type: 'post',
        data: { id: Id },
        success: function (data) {
            $("#ShowData").html(data);
        }
    });
}
function Product() {
    this.Name = "";
    this.IdProduct = "";
    this.ImagePath = "";
    this.NumbersOfProduct = "";
    this.PriceProduct = "";

}

function AddToCart() {
    var p1 = new Product();
    p1.Name = $("#NameProduct").val();
    p1.IdProduct = $("#IdProduct").val();
    p1.ImageProduct = $("#ImagePath").val();
    p1.NumbersOfProduct = $("#NumbersOfProduct").val();
    p1.Price = $("#PriceProduct").val();
    $.ajax({
        url: '/Cart/AddToCart',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(p1),
        success: function () {
            alert("با موفقیت به سبد خرید اضافه شد");
        },
        error: function (errorThrown) {
            alert("مشکلی به وجود آمده");
        }
    });
}
function CheckLogin() {
    alert("لطفا به حساب کاربری خود وارد شوید");
}

function PaymentData() {
    this.UserId = "";
    //this.TotalPrice = "";
    //this.PaymentConfirmation = "";
}

function AddToPayment() {
    var pa1 = new PaymentData();
    pa1.UserId = $("#UserId").val();
    $.ajax({
        url: '/Cart/AddToPayment',
        type: 'post',
        contentType: 'application/json',
        processData: false,
        data: JSON.stringify(pa1),
        success: function (data) {
            alert("خرید شما با موفقیت انجام شد");
        },
        error: function (errorThrown) {
            alert(errorThrown);
        }
    });
}





