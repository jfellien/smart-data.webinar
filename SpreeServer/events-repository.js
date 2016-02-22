var config = require("./server-config");
var orientDb = require("orientjs");

var dbServer = config.dbServer;
var esConfig = config.eventStore;

var server = orientDb(
    {
        host: dbServer.host,
        port: dbServer.port,
        username: dbServer.username,
        password: dbServer.password
    }
);

var eventStore = server.use(
    {
        name : esConfig.dbName,
        username : esConfig.username,
        password : esConfig.password
    }
);

exports.get = (req, res, next) => {
    
    var id = req.params["id"];
    
    eventStore
        .select()
        .from(esConfig.name)
        .where({id:id})
        .column("payload")
        .all()
        .then((events) => res.send(events));
}

exports.store = (req, res, next) => {
    
}