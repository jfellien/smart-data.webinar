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
    
    console.log("get events for Id %s", id)
    
    eventStore
        .select()
        .from(esConfig.name)
        .where({id:id})
        .column("id")
        .column("type")
        .column("timestamp")
        .column("payload")
        .order("timestamp")
        .all()
        .then((events) => res.json(200, events));
}

exports.store = (req, res, next) => {
    
    var eventBag = {
        id : req.body.Id,
        type : req.body.Type,
        timestamp : req.body.Timestamp,
        payload : JSON.parse(req.body.Payload)
    }
    
    console.log("store event %s", JSON.stringify(eventBag));
    
    eventStore
        .insert()
        .into(config.eventStore.name)
        .set(eventBag)
        .one()
        .then((event)=> res.send(200, event));
}