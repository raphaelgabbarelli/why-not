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

      var waterNormals;

			var parameters = {
				width: 2000,
				height: 2000,
				widthSegments: 250,
				heightSegments: 250,
				depth: 1500,
				param: 4,
				filterparam: 1
			};

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
  // scene.add( new THREE.AmbientLight( 0x222233 ) );

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



      scene.add( new THREE.AmbientLight( 0x444444 ) );

				var light = new THREE.DirectionalLight( 0xffffbb, 1 );
				light.position.set( - 1, 1, - 1 );
				scene.add( light );

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

  water.material.uniforms.time.value += 1.0 / 60.0;
				controls.update();
				water.render();
				renderer.render( scene, camera );

}

function renderScene() {

  renderer.render( scene, camera );

}

function render() {
  renderScene();
}
