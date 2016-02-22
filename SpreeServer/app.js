var config = require("./server-config");
var restify = require("restify");
var events = require("./events-repository");

// Setup Server
var server = restify.createServer();

server.use(restify.queryParser());
server.use(restify.bodyParser());
server.use(restify.authorizationParser());
server.pre(restify.pre.sanitizePath());

//Setup Routes
server.get("/events-for/:id", events.get);
server.post("/event", events.store);

// Start Server
server.listen(config.web.port, config.web.host,  () => {
    console.log("Service is running");
});