namespace Pigpot {
    export class PigpotClient {

        private folders: { [path: string]: Folder; } = {};


        folder(path: string): Folder {

            alert("mo!!!!!!!!!!!!!!!i");

            let repository = this.folders[path];
            if (!repository) {
                this.folders[path] = (repository = new Folder(path));
            }
            return repository;
        }

        

        //ping() {
        //    alert("pongssss!!!");

        //    let lookup: { [key: string]: any };
        //}




    }

    export class Folder {
        constructor(private path: string) {
        }
    }


}


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

