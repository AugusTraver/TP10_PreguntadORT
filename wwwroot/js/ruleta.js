// Ruleta de 5 sectores
var degree = 1800; // rotación base
var clicks = 0;

$(document).ready(function(){
  $('#spin').click(function(){
    clicks++;
    var newDegree = degree * clicks;
    var extraDegree = Math.floor(Math.random() * 360) + 1;
    var totalDegree = newDegree + extraDegree;

    $('#inner-wheel').css({
      'transform' : 'rotate(' + totalDegree + 'deg)'
    });

    // animación de tilt
    $('#spin').addClass('spin');
    setTimeout(function(){ $('#spin').removeClass('spin'); }, 100);
  });
});
