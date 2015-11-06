var express = require('express');
var app = require('express')();
var http = require('http').Server(app);

app.get('/', function(req, res){
  res.sendFile(__dirname + '/index.html');
});

app.use('/lib', express.static('lib'));
// app.get('/lib/*', function(req, res){
//   console.log(req);
//   console.log(res);
//   res.sendFile(__dirname + '/index.html');
// });

http.listen(3000, function(){
  console.log('listening on *:3000');
});
