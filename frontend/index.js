var express = require('express');
var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var _ = require('lodash');

app.get('/', function(req, res){
  res.sendFile(__dirname + '/index.html');
});

app.use('/lib', express.static('lib'));
app.use('/models', express.static('models'));
app.use('/img', express.static('img'));
app.use('/controller.html', express.static('controller.html'));
app.use('/display.html', express.static('display.html'));

io.on('connection', function(socket){
  console.log('User connected');

  socket.on('disconnect', function(){
    console.log('User disconnected');
  });

  socket.on("controller2server", function (data) {
    console.log('Passing through data ', data);
    socket.broadcast.emit("server2display", {
      channel: socket.channel,
      message: data
    });
  });
});

http.listen(3000, function(){
  console.log('listening on *:3000');
});
