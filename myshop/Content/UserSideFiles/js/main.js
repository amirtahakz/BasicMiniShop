/* =================================
------------------------------------
	Divisima | eCommerce Template
	Version: 1.0
 ------------------------------------
 ====================================*/


'use strict';


$(window).on('load', function() {
	/*------------------
		Preloder
	--------------------*/
	$(".loader").fadeOut();
	$("#preloder").delay(400).fadeOut("slow");

});

(function($) {
	/*------------------
		Navigation
	--------------------*/
	$('.main-menu').slicknav({
		prependTo:'.main-navbar .container',
		closedSymbol: '<i class="flaticon-right-arrow"></i>',
		openedSymbol: '<i class="flaticon-down-arrow"></i>'
	});


	/*------------------
		ScrollBar
	--------------------*/
	$(".cart-table-warp, .product-thumbs").niceScroll({
		cursorborder:"",
		cursorcolor:"#afafaf",
		boxzoom:false
	});


	/*------------------
		Category menu
	--------------------*/
	$('.category-menu > li').hover( function(e) {
		$(this).addClass('active');
		e.preventDefault();
	});
	$('.category-menu').mouseleave( function(e) {
		$('.category-menu li').removeClass('active');
		e.preventDefault();
	});


	/*------------------
		Background Set
	--------------------*/
	$('.set-bg').each(function() {
		var bg = $(this).data('setbg');
		$(this).css('background-image', 'url(' + bg + ')');
	});



	/*------------------
		Hero Slider
	--------------------*/
	var hero_s = $(".hero-slider");
    hero_s.owlCarousel({
        loop: true,
        margin: 0,
        nav: true,
        items: 1,
        dots: true,
        animateOut: 'fadeOut',
    	animateIn: 'fadeIn',
        navText: ['<i class="flaticon-left-arrow-1"></i>', '<i class="flaticon-right-arrow-1"></i>'],
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: false,
        onInitialized: function() {
        	var a = this.items().length;
            $("#snh-1").html("<span>1</span><span>" + a + "</span>");
        }
    }).on("changed.owl.carousel", function(a) {
        var b = --a.item.index, a = a.item.count;
    	$("#snh-1").html("<span> "+ (1 > b ? b + a : b > a ? b - a : b) + "</span><span>" + a + "</span>");

    });

	hero_s.append('<div class="slider-nav-warp"><div class="slider-nav"></div></div>');
	$(".hero-slider .owl-nav, .hero-slider .owl-dots").appendTo('.slider-nav');



	/*------------------
		Brands Slider
	--------------------*/
	$('.product-slider').owlCarousel({
		loop: true,
		nav: true,
		dots: false,
		margin : 30,
		autoplay: true,
		navText: ['<i class="flaticon-left-arrow-1"></i>', '<i class="flaticon-right-arrow-1"></i>'],
		responsive : {
			0 : {
				items: 1,
			},
			480 : {
				items: 2,
			},
			768 : {
				items: 3,
			},
			1200 : {
				items: 4,
			}
		}
	});


	/*------------------
		Popular Services
	--------------------*/
	$('.popular-services-slider').owlCarousel({
		loop: true,
		dots: false,
		margin : 40,
		autoplay: true,
		nav:true,
		navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
		responsive : {
			0 : {
				items: 1,
			},
			768 : {
				items: 2,
			},
			991: {
				items: 3
			}
		}
	});


	/*------------------
		Accordions
	--------------------*/
	$('.panel-link').on('click', function (e) {
		$('.panel-link').removeClass('active');
		var $this = $(this);
		if (!$this.hasClass('active')) {
			$this.addClass('active');
		}
		e.preventDefault();
	});


	/*-------------------
		Range Slider
	--------------------- */
	var rangeSlider = $(".price-range"),
		minamount = $("#minamount"),
		maxamount = $("#maxamount"),
		minPrice = rangeSlider.data('min'),
		maxPrice = rangeSlider.data('max');
	rangeSlider.slider({
		range: true,
		min: minPrice,
		max: maxPrice,
		values: [minPrice, maxPrice],
		slide: function (event, ui) {
			minamount.val(  ui.values[0]+'تومان');
			maxamount.val( ui.values[1]+'تومان');
		}
	});
	minamount.val( rangeSlider.slider("values", 0)+'تومان' );
	maxamount.val( rangeSlider.slider("values", 1)+'تومان' );


	/*-------------------
		Quantity change
	--------------------- */
    var proQty = $('.pro-qty');
	proQty.prepend('<span class="dec qtybtn">-</span>');
	proQty.append('<span class="inc qtybtn">+</span>');
	proQty.on('click', '.qtybtn', function () {
		var $button = $(this);
		var oldValue = $button.parent().find('input').val();
		if ($button.hasClass('inc')) {
			var newVal = parseFloat(oldValue) + 1;
		} else {
			// Don't allow decrementing below zero
			if (oldValue > 0) {
				var newVal = parseFloat(oldValue) - 1;
			} else {
				newVal = 0;
			}
		}
		$button.parent().find('input').val(newVal);
	});



	/*------------------
		Single Product
	--------------------*/
	$('.product-thumbs-track > .pt').on('click', function(){
		$('.product-thumbs-track .pt').removeClass('active');
		$(this).addClass('active');
		var imgurl = $(this).data('imgbigurl');
		var bigImg = $('.product-big-img').attr('src');
		if(imgurl != bigImg) {
			$('.product-big-img').attr({src: imgurl});
			$('.zoomImg').attr({src: imgurl});
		}
	});


	$('.product-pic-zoom').zoom();



})(jQuery);




$(".wishlist-btn").on("click",function(e){
	e.preventDefault();
  $(".far").toggleClass("fa")
})
// -------scrollTop-------


$(document).ready(function(){ 
    $(window).scroll(function(){ 
        if ($(this).scrollTop() > 100) { 
            $('#scroll').fadeIn(); 
        } else { 
            $('#scroll').fadeOut(); 
        } 
    }); 
    $('#scroll').click(function(){ 
        $("html, body").animate({ scrollTop: 0 }, 600); 
        return false; 
    }); 
});
// ---swiper---
var swiper = new Swiper('.swiper-containerInterest', {
	direction: 'horizontal',
    pagination: '.cd-slider',
    nextButton: '.swiper-next',
    prevButton: '.swiper-prev',
	slidesPerView: 1,
	grabCursor: true,
    paginationClickable: true,
    spaceBetween: 20,
    loop: true,
    speed: 400,
    effect: 'slide',
    keyboardControl: true,
	hashnav: true,
	pagination: {
		   el: '.swiper-pagination',
		   clickable: true,
		 },
    useCSS3Transforms: false,
	  breakpoints: {
        // when window width is <= 499px
        0: {
            slidesPerView: 1,
            spaceBetweenSlides: 30
        },
        600: {
            slidesPerView: 2,
            spaceBetweenSlides: 40
        },
   
        1000: {
            slidesPerView: 4,
            spaceBetweenSlides: 20
        }
    }
  });



  
        // ---timer---

        var timeInSecs;
var ticker;

function startTimer(secs) {
timeInSecs = parseInt(secs);
ticker = setInterval("tick()", 1000); 
}

function tick( ) {
var secs = timeInSecs;
if (secs > 0) {
timeInSecs--; 
}
else {
clearInterval(ticker);
startTimer(5*60); // 4 minutes in seconds
}

var days= Math.floor(secs/86400); 
secs %= 86400;
var hours= Math.floor(secs/3600);
secs %= 3600;
var mins = Math.floor(secs/60);
secs %= 60;
var pretty = ( (days < 10 ) ? "0" : "" ) + days + ":" + ( (hours < 10 ) ? "0" : "" ) + hours + ":" + ( (mins < 10) ? "0" : "" ) + mins + ":" + ( (secs < 10) ? "0" : "" ) + secs;
//**********************************************************************/
var elem1 = document.getElementById("baneertimer");
if(elem1){
elem1.innerHTML = pretty;
}

var elem2 = document.getElementById("timer-offer1");
if(elem2){
elem2.innerHTML = pretty;
}
var elem3 = document.getElementById("timer-offer2");
if(elem3){
elem3.innerHTML = pretty;
}
var elem4 = document.getElementById("timer-offer4");
if(elem4){
    elem4.innerHTML = pretty;
}
//**********************************************************************/ 
}

startTimer(600*60); // 4 minutes in seconds

// --------------end timer----



// ---delete product---
$("#delete").on("click",function(){
	$(".product-cart").remove();
})


// ---------------
// -----swiper 3---
var swiper = new Swiper('.swiper-containerBlog', {
	direction: 'horizontal',
    pagination: '.cd-slider',
    nextButton: '.swiper-next',
    prevButton: '.swiper-prev',
	slidesPerView: 1,
	grabCursor: true,
    paginationClickable: true,
    spaceBetween: 20,
    loop: true,
    speed: 400,
    effect: 'slide',
    keyboardControl: true,
	hashnav: true,
	pagination: {
		   el: '.swiper-pagination',
		   clickable: true,
		 },
    useCSS3Transforms: false,
	  breakpoints: {
        // when window width is <= 499px
        0: {
            slidesPerView: 1,
            spaceBetweenSlides: 30
        },
        600: {
            slidesPerView: 2,
            spaceBetweenSlides: 40
        },
   
        1000: {
            slidesPerView: 3,
            spaceBetweenSlides: 40
        }
    }
  });

// ---end swiper----
var swiper = new Swiper('.swiper-containerInterestIndex', {
	slidesPerView: 4,
	centeredSlides: true,
	spaceBetween: 30,
	loop:true,
	grabCursor: true,
	pagination: {
	  el: '.swiper-pagination',
	  clickable: true,
	},
	  breakpoints: {
        // when window width is <= 499px
        0: {
            slidesPerView: 1,
            spaceBetweenSlides: 30
        },
        600: {
            slidesPerView: 2,
            spaceBetweenSlides: 40
        },
   
        1000: {
            slidesPerView: 3,
            spaceBetweenSlides: 40
        }
    }

  });


//   -----swiper in intro index2---
var swiper = new Swiper('.swiper-introIndex2', {
	slidesPerView: 1,
	spaceBetween: 30,
	loop: true,
	pagination: {
	  el: '.swiper-pagination',
	  clickable: true,
	},

	autoplay: 
    {
      delay: 3000,
    },
	keyboard: 
	{
		enabled: true,
		onlyInViewport: false,
	},
	navigation: {
	  nextEl: '.swiper-button-next',
	  prevEl: '.swiper-button-prev',
	},
  });





  var swiper = new Swiper('.swiper-containerInterestIndex2', {

	direction: 'horizontal',
    pagination: '.cd-slider',
    nextButton: '.swiper-next',
    prevButton: '.swiper-prev',
	slidesPerView: 1,
	grabCursor: true,
    paginationClickable: true,
    spaceBetween: 20,
    loop: true,
    speed: 400,
    effect: 'slide',
    keyboardControl: true,
	hashnav: true,
	pagination: {
		   el: '.swiper-pagination',
		   clickable: true,
		 },
    useCSS3Transforms: false,
	  breakpoints: {
        // when window width is <= 499px
        0: {
            slidesPerView: 1,
            spaceBetweenSlides: 30
        },
        600: {
            slidesPerView: 2,
            spaceBetweenSlides: 40
        },
   
        1000: {
            slidesPerView: 4,
            spaceBetweenSlides: 40
        }
    }

  });



//   ---number en to farsi---

