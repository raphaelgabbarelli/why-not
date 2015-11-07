var socket = io();

var sendEvent = _.throttle(function (e) {
  var newData = {
    x: e.rotationRate.alpha,
    y: e.rotationRate.beta,
    z: e.rotationRate.gamma
  };

  document.getElementById("accelerationX").innerHTML = e.accelerationIncludingGravity.x;
  document.getElementById("accelerationY").innerHTML = e.accelerationIncludingGravity.y;
  document.getElementById("accelerationZ").innerHTML = e.accelerationIncludingGravity.z;
  document.getElementById("rotationAlpha").innerHTML = e.rotationRate.alpha;
  document.getElementById("rotationBeta").innerHTML = e.rotationRate.beta;
  document.getElementById("rotationGamma").innerHTML = e.rotationRate.gamma;

  socket.emit("controller2server", newData);
}, 100);

window.addEventListener("devicemotion", sendEvent, false);
