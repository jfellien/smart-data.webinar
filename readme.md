#CQRS mit OrientDB

Dieses Beispiel zeigt exemplarisch, wie eine CQRS Applikation, erstellt in C#, über einen REST Client seine Daten in einer OrientDB speichert und liest.


## Installation
### Node.js App
Node.js istalliert man am besten über den Installer, den man auf der Webseite von [Node.js](https://nodejs.org/) herunter laden kann. Wie genau das funktioniert entnimmt man den Anleitungen, die es zu Hauf online gibt. 

### OrientDB

Das Paket kann man auf der Webseite von [OrientDB](http://orientdb.com/download/) herunter geladen werden. Anschließend entpackt man das ZIP-File in einen beliebeigen Ordner.

Zur Installation des Servers ruft man unter Windows die server.bat und unter den *ix Systemen die server.sh auf. Das ist auch gleichzeitig das Script, welchen den Server in Zukunft startet.

Bei der Erstinstallation wird man aufgefordert, das root Passwort ein zu richten. Entweder man gibt ein eigenes ein oder lässt sich eins automatisch generieren. Das Passwort wird in der orientdb-server-config.xml gespeichert. 

Für die weiteren Aktionen muss der Server gestartet sein.

#### EventStore
Die einfachste Art eine neue Datenbank in OrientDB anzulegen geht über das Web Frontend. Im Browser seiner Wahl, ich habe die besten Erfahrungen mit Chrome gemacht, ruft man die URL **http://localhost:2480** auf.

**New DB** anklicken, als *Server User* `root` und als *Server Password* das aus der orientdb-server-config.xml verwenden. Unter **Advanced Settings** den *Database Type* auf `document`setzen. Abschließend **Create Database** klicken und die Datenbank ist angelegt.

Das **Schema** des EventStores ist denkbar einfach. Doch bevor es richtig los geht,  braucht es eine kleine Vorbereitung. Zum Speichern der Events als Typen muss dieser in das Schema aufgenommen werden. Über **New Class** wird dies gemacht. Der *Name* dieses neuen Typen sollte `Event` sein. Dieser Typ hat kein weiteres Schema. 
Anschließend wird ein weiteres Schema angelegt, auch wieder über **New Class**, mit dem Namen `EventBag`.

	Feld		| Typ			| Linked Class
	-------------------------------------------
	Id 			| STRING		|
	Payload		| EMBEDDED		| Event
	Timestamp	| DateTime		|
	Type		| STRING		|

Die Properties eines Typen legt man in der Schema Übersicht an, nach dem man auf den Typen geklickt hat.

#### ReadModel
Nun, wo der EventStore angelegt ist, muss man sich abmelden von der aktuellen Datenbank und eine neue, wie oben beschrieben, kann angelegt werden. Nun wird jedoch der Typ `graph` verwendet.

In dieser Datenbank werden sämtliche Typen angelegt, die in Zukunft als ReadModel gebraucht werden. Für das vorliegende Beispiel reicht der Typ `Produkt`mit dem folgenden Schema:


	Feld		| Typ			
	---------------------------
	Id 			| STRING		
	Name		| STRING		
	Preis		| DECIMAL		
	Kategorie	| STRING		

Final sollten zwei drei Datensätze, sprich Produkte, angelegt werden. In der Schema Übersicht klickt man auf den Typnamen und kann nun mit **New Record** einzelne Datensätze hinzufügen. Jeder neue Datensatz wird über **Actions** angelegt.

---

Damit sind die grundlegenden Daten in der Datenbank und man kann sich mit der Applikation austoben.