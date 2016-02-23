var config = require("./server-config");
var orientDb = require("orientjs");

var dbServer = config.dbServer;
var readModel = config.readModelStore;


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
        name : readModel.dbName,
        username : readModel.username,
        password : readModel.password
    }
);


exports.getProdukte = (req, res, next) => {
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