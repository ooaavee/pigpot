var Pigpot;
(function (Pigpot) {
    class PigpotClient {
        constructor() {
            this.folders = {};
        }
        folder(path) {
            let repository = this.folders[path];
            if (!repository) {
                this.folders[path] = (repository = new Folder(path));
            }
            return repository;
        }
    }
    Pigpot.PigpotClient = PigpotClient;
    class Folder {
        constructor(path) {
            this.path = path;
        }
    }
    Pigpot.Folder = Folder;
})(Pigpot || (Pigpot = {}));
window["pingpot"] = new Pigpot.PigpotClient();
