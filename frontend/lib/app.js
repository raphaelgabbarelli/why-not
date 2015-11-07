var socket = io();

if ( ! Detector.webgl ) {

  Detector.addGetWebGLMessage();
  document.getElementById( 'container' ).innerHTML = "";

}

socket.on("msg", function(msg) {
  pointLightL.position.x = msg.x;
  pointLightL.position.y = msg.y;
  pointLightL.position.z = msg.z;

  pointLightR.position.x = msg.x;
  pointLightR.position.y = msg.y;
  pointLightR.position.z = msg.z-1500;

  particlesL.position.x = msg.x;
  particlesL.position.y = msg.y;
  particlesL.position.z = msg.z;

  particlesR.position.x = msg.x;
  particlesR.position.y = msg.y;
  particlesR.position.z = msg.z-1500;
});

var container, stats;
var camera, scene, renderer;
var sphere;
var light;
var pointLightR;
var pointLightL;
var particleSystem;
var tick = 0;
var clock = new THREE.Clock(true);

// particlesL passed during each spawned
var particlesL = {
  position: new THREE.Vector3(),
  positionRandomness: .3,
  velocity: new THREE.Vector3(),
  velocityRandomness: .5,
  color: 0xff99ff,
  colorRandomness: .5,
  turbulence: .5,
  lifetime: 2,
  size: 2,
  sizeRandomness: 2
};
var particlesR = {
  position: new THREE.Vector3(),
  positionRandomness: .3,
  velocity: new THREE.Vector3(),
  velocityRandomness: .5,
  color: 0xff99ff,
  colorRandomness: .5,
  turbulence: .5,
  lifetime: 2,
  size: 2,
  sizeRandomness: 2
};

var spawnerparticlesL = {
  spawnRate: 1,
  horizontalSpeed: 1.5,
  verticalSpeed: 1.33,
  timeScale: 1
}


var parameters = {
  width: 2000,
  height: 2000,
  widthSegments: 250,
  heightSegments: 250,
  depth: 1500,
  param: 4,
  filterparam: 1
};

var waterNormals;

init();
animate();

function init() {
  initScene();
  initWater();
  initSkyBox();
  initBoat();
  initFireflies();
  initParticles();
}

function initScene () {
  container = document.createElement( 'div' );
  document.body.appendChild( container );

  renderer = new THREE.WebGLRenderer();
  renderer.setPixelRatio( window.devicePixelRatio );
  renderer.setSize( window.innerWidth, window.innerHeight );
  renderer.shadowMap.enabled = true;
	renderer.shadowMap.type = THREE.BasicShadowMap;
  container.appendChild( renderer.domElement );

  scene = new THREE.Scene();

  camera = new THREE.PerspectiveCamera( 45, window.innerWidth / window.innerHeight, 0.5, 3000000 );
  camera.position.set( 1000, 750, 1000 );

  controls = new THREE.OrbitControls( camera, renderer.domElement );
  controls.enablePan = false;
  controls.minDistance = 1000.0;
  controls.maxDistance = 5000.0;
  controls.maxPolarAngle = Math.PI * 0.495;
  controls.center.set( 0, 500, 0 );

  scene.add( new THREE.AmbientLight( 0x444444 ) );

  light = new THREE.DirectionalLight( 0xffffbb, 1 );
  light.position.set( - 1, 1, - 1 );
  scene.add( light );
}

function initWater () {
  waterNormals = new THREE.ImageUtils.loadTexture( 'img/waternormals.jpg' );
  waterNormals.wrapS = waterNormals.wrapT = THREE.RepeatWrapping;

  water = new THREE.Water( renderer, camera, scene, {
    textureWidth: 512,
    textureHeight: 512,
    waterNormals: waterNormals,
    alpha: 	1.0,
    sunDirection: light.position.clone().normalize(),
    sunColor: 0xffffff,
    waterColor: 0x001e0f,
    distortionScale: 50.0,
  } );


  mirrorMesh = new THREE.Mesh(
    new THREE.PlaneBufferGeometry( parameters.width * 500, parameters.height * 500 ),
    water.material
  );

  mirrorMesh.add( water );
  mirrorMesh.rotation.x = - Math.PI * 0.5;
  scene.add( mirrorMesh );
}

function initSkyBox () {
  // load skybox

  var cubeMap = new THREE.CubeTexture( [] );
  cubeMap.format = THREE.RGBFormat;

  var loader = new THREE.ImageLoader();
  loader.load( 'img/skyboxsun25degtest.png', function ( image ) {

    var getSide = function ( x, y ) {

      var size = 1024;

      var canvas = document.createElement( 'canvas' );
      canvas.width = size;
      canvas.height = size;

      var context = canvas.getContext( '2d' );
      context.drawImage( image, - x * size, - y * size );

      return canvas;

    };

    cubeMap.images[ 0 ] = getSide( 2, 1 ); // px
    cubeMap.images[ 1 ] = getSide( 0, 1 ); // nx
    cubeMap.images[ 2 ] = getSide( 1, 0 ); // py
    cubeMap.images[ 3 ] = getSide( 1, 2 ); // ny
    cubeMap.images[ 4 ] = getSide( 1, 1 ); // pz
    cubeMap.images[ 5 ] = getSide( 3, 1 ); // nz
    cubeMap.needsUpdate = true;

  } );

  var cubeShader = THREE.ShaderLib[ 'cube' ];
  cubeShader.uniforms[ 'tCube' ].value = cubeMap;

  var skyBoxMaterial = new THREE.ShaderMaterial( {
    fragmentShader: cubeShader.fragmentShader,
    vertexShader: cubeShader.vertexShader,
    uniforms: cubeShader.uniforms,
    depthWrite: false,
    side: THREE.BackSide
  } );

  var skyBox = new THREE.Mesh(
    new THREE.BoxGeometry( 1000000, 1000000, 1000000 ),
    skyBoxMaterial
  );

  scene.add( skyBox );
}

function initBoat () {
  var loader = new THREE.STLLoader();
    loader.load( './models/rowing_boat.stl', function ( geometry ) {

      var material = new THREE.MeshPhongMaterial( {
					color: 0x966F33,
					shininess: 10,
					specular: 0x111111,
					shading: THREE.SmoothShading
				} );
      var mesh = new THREE.Mesh( geometry, material );

      mesh.position.set( 0, -120, 0 );
      mesh.rotation.set( - Math.PI / 2, 0, 0 );
      mesh.scale.set( 20.1, 20.1, 20.1 );

      mesh.castShadow = true;
      mesh.receiveShadow = true;

      scene.add( mesh );

    } );
}

function initFireflies () {
  function createLight( color ) {
    var newLight = new THREE.PointLight( color, 1, 30 );
    newLight.castShadow = true;
    newLight.shadowCameraNear = 1;
    newLight.shadowCameraFar = 300000;
    // newLight.shadowCameraVisible = true;
    newLight.shadowMapWidth = 204;
    newLight.shadowMapHeight = 102;
    newLight.shadowBias = 0.1;
    newLight.shadowDarkness = 0.2;

    var geometry = new THREE.SphereGeometry( 20, 16, 16 );
    var material = new THREE.MeshBasicMaterial( { color: color } );
    var sphere = new THREE.Mesh( geometry, material );
    newLight.add( sphere );

    return newLight
  }
  pointLightL = createLight( 0xaa0000 );
  scene.add( pointLightL );

  pointLightR = createLight( 0x0000aa );
  scene.add( pointLightR );
}

function animate() {

  requestAnimationFrame( animate );
  render();


}

function initParticles () {
  particleSystem = new THREE.GPUParticleSystem({
    maxParticles: 2500
  });
  scene.add( particleSystem);


}

function render() {

  var time = performance.now() * 0.001;

  var delta = clock.getDelta() * spawnerparticlesL.timeScale;
  tick += delta;

  if (tick < 0) tick = 0;

  if (delta > 0) {
    particleSystem.spawnParticle(particlesL);
    particleSystem.spawnParticle(particlesR);
  }

  particleSystem.update(tick);


  water.material.uniforms.time.value += 1.0 / 60.0;
  controls.update();
  water.render();
  renderer.render( scene, camera );

}
