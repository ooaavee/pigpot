var Pigpot;
(function (Pigpot) {
    var PigpotClient = /** @class */ (function () {
        function PigpotClient() {
            this.folders = {};
            //ping() {
            //    alert("pongssss!!!");
            //    let lookup: { [key: string]: any };
            //}
        }
        PigpotClient.prototype.folder = function (path) {
            alert("mo!!!!!!!!!!!!!!!i");
            var repository = this.folders[path];
            if (!repository) {
                this.folders[path] = (repository = new Folder(path));
            }
            return repository;
        };
        return PigpotClient;
    }());
    Pigpot.PigpotClient = PigpotClient;
    var Folder = /** @class */ (function () {
        function Folder(path) {
            this.path = path;
        }
        return Folder;
    }());
    Pigpot.Folder = Folder;
})(Pigpot || (Pigpot = {}));
window["pingpot"] = new Pigpot.PigpotClient();
//////////import { Promise } from "es6-promise";
////////namespace Pigpot
////////{
////////    export class PigpotClient {
////////        xxx(): Promise<any> {
////////            var b = true;
////////            return new Promise(
////////                function (resolve, reject) {
////////                    if (b) {
////////                        var phone = {
////////                            brand: 'Samsung',
////////                            color: 'black'
////////                        };
////////                        resolve(phone); // fulfilled
////////                    } else {
////////                        var reason = new Error('mom is not happy');
////////                        reject(reason); // reject
////////                    }
////////                }
////////            );;
////////        }
////////        ping() {
////////            alert("pongssss");
////////        }
////////        test() {
////////            var b = true;
////////var willIGetNewPhone = new Promise(
////////    (resolve, reject) => {
////////        if (b) {
////////            var phone = {
////////                brand: 'Samsung',
////////                color: 'black'
////////            };
////////            resolve(phone); // fulfilled
////////        } else {
////////            var reason = new Error('mom is not happy');
////////            reject(reason); // reject
////////        }
////////    }
////////);
////////            var willIGetNewPhone2 = new Promise(
////////                function (resolve, reject) {
////////                    if (b) {
////////                        var phone = {
////////                            brand: 'Samsung',
////////                            color: 'black'
////////                        };
////////                        resolve(phone); // fulfilled
////////                    } else {
////////                        var reason = new Error('mom is not happy');
////////                        reject(reason); // reject
////////                    }
////////                }
////////            );
////////        }
////////    }
////////}
////////window["repository"] = new Pigpot.PigpotClient();
//////////import { Promise } from 'es6-promise'
//////////var b: boolean = true;
//////////var willIGetNewPhone = new Promise(
//////////    function (resolve, reject) {
//////////        if (b) {
//////////            var phone = {
//////////                brand: 'Samsung',
//////////                color: 'black'
//////////            };
//////////            resolve(phone); // fulfilled
//////////        } else {
//////////            var reason = new Error('mom is not happy');
//////////            reject(reason); // reject
//////////        }
//////////    }
//////////);
