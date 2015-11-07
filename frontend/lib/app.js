var socket = io();

socket.on("msg", function(msg) {
  pointLight.position.x = msg.x;
  pointLight.position.y = msg.y;
  pointLight.position.z = msg.z;
})

if ( ! Detector.webgl ) Detector.addGetWebGLMessage();

var camera, scene, renderer, stats;
var pointLight, pointLight2;
var torusKnot;
var cubeMaterial;
var wallMaterial;
var ground;

init();
animate();

function init() {

  initScene();
  initMisc();

  document.body.appendChild( renderer.domElement );
  window.addEventListener( 'resize', onWindowResize, false );

}

function initScene() {

  camera = new THREE.PerspectiveCamera( 45, window.innerWidth / window.innerHeight, 1, 1000 );
  camera.position.set( 0, 10, 40 );

  scene = new THREE.Scene();
  scene.add( new THREE.AmbientLight( 0x222233 ) );

  // Lights

  function createLight( color ) {

    var pointLight = new THREE.PointLight( color, 1, 30 );
    pointLight.castShadow = true;
    pointLight.shadowCameraNear = 1;
    pointLight.shadowCameraFar = 30;
    // pointLight.shadowCameraVisible = true;
    pointLight.shadowMapWidth = 2048;
    pointLight.shadowMapHeight = 1024;
    pointLight.shadowBias = 0.01;
    pointLight.shadowDarkness = 0.5;

    var geometry = new THREE.SphereGeometry( 0.3, 32, 32 );
    var material = new THREE.MeshBasicMaterial( { color: color } );
    var sphere = new THREE.Mesh( geometry, material );
    pointLight.add( sphere );

    return pointLight

  }

  pointLight = createLight( 0xffffff );
  scene.add( pointLight );

  cubeMaterial = new THREE.MeshPhongMaterial( {
    color: 0xff0000,
    shininess: 50,
    specular: 0x222222
  } );

  wallMaterial = new THREE.MeshPhongMaterial( {
    color: 0xa0adaf,
    shininess: 10,
    specular: 0x111111,
    shading: THREE.SmoothShading
  } );

  var wallGeometry = new THREE.BoxGeometry( 20, 0.15, 20 );
  ground = new THREE.Mesh( wallGeometry, wallMaterial );
  ground.position.set( 0, -5, 0 );
  ground.scale.multiplyScalar( 3 );
  ground.receiveShadow = true;
  scene.add( ground );

  var ceiling = new THREE.Mesh( wallGeometry, wallMaterial );
  ceiling.position.set( 0, 24, 0 );
  ceiling.scale.multiplyScalar( 3 );
  ceiling.receiveShadow = true;
  scene.add( ceiling );

  var wall = new THREE.Mesh( wallGeometry, wallMaterial );
  wall.position.set( -24, 10, 0 );
  wall.rotation.z = Math.PI / 2;
  wall.scale.multiplyScalar( 3 );
  wall.receiveShadow = true;
  scene.add( wall );

  wall = new THREE.Mesh( wallGeometry, wallMaterial );
  wall.position.set( 24, 10, 0 );
  wall.rotation.z = Math.PI / 2;
  wall.scale.multiplyScalar( 3 );
  wall.receiveShadow = true;
  scene.add( wall );

  wall = new THREE.Mesh( wallGeometry, wallMaterial );
  wall.position.set( 0, 10, -24 );
  wall.rotation.y = Math.PI / 2;
  wall.rotation.z = Math.PI / 2;
  wall.scale.multiplyScalar( 3 );
  wall.receiveShadow = true;
  scene.add( wall );


  var loader = new THREE.STLLoader();
      loader.load( './models/rowing_boat.stl', function ( geometry ) {

        var material = new THREE.MeshPhongMaterial( { color: 0xA52A2A, specular: 0x111111, shininess: 200 } );
        var mesh = new THREE.Mesh( geometry, material );

        mesh.position.set( 10, 0, 0 );
        mesh.rotation.set( - Math.PI / 2, 0, 0 );
        mesh.scale.set( 0.1, 0.1, 0.1 );

        mesh.castShadow = true;
        mesh.receiveShadow = true;

        scene.add( mesh );

      } );


  /*
  wall = new THREE.Mesh( wallGeometry, wallMaterial );
  wall.scale.multiplyScalar( 3 );
  wall.castShadow = false;
  wall.receiveShadow = true;
  scene.add( wall );
  wall.position.set( 0, 10, 14 );
  wall.rotation.y = Math.PI / 2;
  wall.rotation.z = Math.PI / 2;
  */

}

function initMisc() {

  renderer = new THREE.WebGLRenderer();
  renderer.setSize( window.innerWidth, window.innerHeight );
  renderer.setClearColor( 0x000000 );
  renderer.shadowMap.enabled = true;
  renderer.shadowMap.type = THREE.BasicShadowMap;

  // Mouse control
  controls = new THREE.OrbitControls( camera, renderer.domElement );
  controls.target.set( 0, 10, 0 );
  controls.update();

  stats = new Stats();
  stats.domElement.style.position = 'absolute';
  stats.domElement.style.right = '0px';
  stats.domElement.style.top = '0px';
  document.body.appendChild( stats.domElement );

}

function onWindowResize() {

  camera.aspect = window.innerWidth / window.innerHeight;
  camera.updateProjectionMatrix();

  renderer.setSize( window.innerWidth, window.innerHeight );

}

function animate() {

  requestAnimationFrame( animate );
  render();
  stats.update();

}

function renderScene() {

  renderer.render( scene, camera );

}

function render() {
  renderScene();
}
