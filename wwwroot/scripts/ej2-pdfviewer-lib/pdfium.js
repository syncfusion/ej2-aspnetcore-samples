var PDFiumModule = (() => {
    var _scriptDir = typeof document !== 'undefined' && document.currentScript ? document.currentScript.src : undefined;
    if (typeof __filename !== 'undefined')
        _scriptDir = _scriptDir || __filename;
    return (function (PDFiumModule = {}) {
        var Module = typeof PDFiumModule != "undefined" ? PDFiumModule : {};
        var moduleOverrides = Object.assign({}, Module);
        var arguments_ = [];
        var thisProgram = "./this.program";
        var quit_ = (status, toThrow) => {
            throw toThrow
        };
        var ENVIRONMENT_IS_WEB = typeof window == "object";
        var ENVIRONMENT_IS_WORKER = typeof importScripts == "function";
        var ENVIRONMENT_IS_NODE = typeof process == "object" && typeof process.versions == "object" && typeof process.versions.node == "string";
        var scriptDirectory = "";

        function locateFile(path) {
            if (Module["locateFile"]) {
                return Module["locateFile"](path, scriptDirectory)
            }
            return scriptDirectory + path
        }
        var read_, readAsync, readBinary, setWindowTitle;
        if (ENVIRONMENT_IS_NODE) {
            var fs = require("fs");
            var nodePath = require("path");
            if (ENVIRONMENT_IS_WORKER) {
                scriptDirectory = nodePath.dirname(scriptDirectory) + "/"
            } else {
                scriptDirectory = __dirname + "/"
            }
            read_ = (filename, binary) => {
                filename = isFileURI(filename) ? new URL(filename) : nodePath.normalize(filename);
                return fs.readFileSync(filename, binary ? undefined : "utf8")
            };
            readBinary = filename => {
                var ret = read_(filename, true);
                if (!ret.buffer) {
                    ret = new Uint8Array(ret)
                }
                return ret
            };
            readAsync = (filename, onload, onerror) => {
                filename = isFileURI(filename) ? new URL(filename) : nodePath.normalize(filename);
                fs.readFile(filename, function (err, data) {
                    if (err) onerror(err);
                    else onload(data.buffer)
                })
            };
            if (process.argv.length > 1) {
                thisProgram = process.argv[1].replace(/\\/g, "/")
            }
            arguments_ = process.argv.slice(2);
            if (typeof module != "undefined") {
                module["exports"] = Module
            }
            process.on("uncaughtException", function (ex) {
                if (ex !== "unwind" && !(ex instanceof ExitStatus) && !(ex.context instanceof ExitStatus)) {
                    throw ex
                }
            });
            var nodeMajor = process.versions.node.split(".")[0];
            if (nodeMajor < 15) {
                process.on("unhandledRejection", function (reason) {
                    throw reason
                })
            }
            quit_ = (status, toThrow) => {
                process.exitCode = status;
                throw toThrow
            };
            Module["inspect"] = function () {
                return "[Emscripten Module object]"
            }
        } else if (ENVIRONMENT_IS_WEB || ENVIRONMENT_IS_WORKER) {
            if (ENVIRONMENT_IS_WORKER) {
                scriptDirectory = self.location.href
            } else if (typeof document != "undefined" && document.currentScript) {
                scriptDirectory = document.currentScript.src
            }
            if (scriptDirectory.indexOf("blob:") !== 0) {
                scriptDirectory = scriptDirectory.substr(0, scriptDirectory.replace(/[?#].*/, "").lastIndexOf("/") + 1)
            } else {
                scriptDirectory = ""
            } {
                read_ = url => {
                    var xhr = new XMLHttpRequest;
                    xhr.open("GET", url, false);
                    xhr.send(null);
                    return xhr.responseText
                };
                if (ENVIRONMENT_IS_WORKER) {
                    readBinary = url => {
                        var xhr = new XMLHttpRequest;
                        xhr.open("GET", url, false);
                        xhr.responseType = "arraybuffer";
                        xhr.send(null);
                        return new Uint8Array(xhr.response)
                    }
                }
                readAsync = (url, onload, onerror) => {
                    var xhr = new XMLHttpRequest;
                    xhr.open("GET", url, true);
                    xhr.responseType = "arraybuffer";
                    xhr.onload = () => {
                        if (xhr.status == 200 || xhr.status == 0 && xhr.response) {
                            onload(xhr.response);
                            return
                        }
                        onerror()
                    };
                    xhr.onerror = onerror;
                    xhr.send(null)
                }
            }
            setWindowTitle = title => document.title = title
        } else {}
        var out = Module["print"] || console.log.bind(console);
        var err = Module["printErr"] || console.warn.bind(console);
        Object.assign(Module, moduleOverrides);
        moduleOverrides = null;
        if (Module["arguments"]) arguments_ = Module["arguments"];
        if (Module["thisProgram"]) thisProgram = Module["thisProgram"];
        if (Module["quit"]) quit_ = Module["quit"];
        var wasmBinary;
        if (Module["wasmBinary"]) wasmBinary = Module["wasmBinary"];
        var noExitRuntime = Module["noExitRuntime"] || true;
        if (typeof WebAssembly != "object") {
            abort("no native wasm support detected")
        }
        var wasmMemory;
        var ABORT = false;
        var EXITSTATUS;

        function assert(condition, text) {
            if (!condition) {
                abort(text)
            }
        }
        var UTF8Decoder = typeof TextDecoder != "undefined" ? new TextDecoder("utf8") : undefined;

        function UTF8ArrayToString(heapOrArray, idx, maxBytesToRead) {
            var endIdx = idx + maxBytesToRead;
            var endPtr = idx;
            while (heapOrArray[endPtr] && !(endPtr >= endIdx)) ++endPtr;
            if (endPtr - idx > 16 && heapOrArray.buffer && UTF8Decoder) {
                return UTF8Decoder.decode(heapOrArray.subarray(idx, endPtr))
            }
            var str = "";
            while (idx < endPtr) {
                var u0 = heapOrArray[idx++];
                if (!(u0 & 128)) {
                    str += String.fromCharCode(u0);
                    continue
                }
                var u1 = heapOrArray[idx++] & 63;
                if ((u0 & 224) == 192) {
                    str += String.fromCharCode((u0 & 31) << 6 | u1);
                    continue
                }
                var u2 = heapOrArray[idx++] & 63;
                if ((u0 & 240) == 224) {
                    u0 = (u0 & 15) << 12 | u1 << 6 | u2
                } else {
                    u0 = (u0 & 7) << 18 | u1 << 12 | u2 << 6 | heapOrArray[idx++] & 63
                }
                if (u0 < 65536) {
                    str += String.fromCharCode(u0)
                } else {
                    var ch = u0 - 65536;
                    str += String.fromCharCode(55296 | ch >> 10, 56320 | ch & 1023)
                }
            }
            return str
        }

        function UTF8ToString(ptr, maxBytesToRead) {
            return ptr ? UTF8ArrayToString(HEAPU8, ptr, maxBytesToRead) : ""
        }

        function stringToUTF8Array(str, heap, outIdx, maxBytesToWrite) {
            if (!(maxBytesToWrite > 0)) return 0;
            var startIdx = outIdx;
            var endIdx = outIdx + maxBytesToWrite - 1;
            for (var i = 0; i < str.length; ++i) {
                var u = str.charCodeAt(i);
                if (u >= 55296 && u <= 57343) {
                    var u1 = str.charCodeAt(++i);
                    u = 65536 + ((u & 1023) << 10) | u1 & 1023
                }
                if (u <= 127) {
                    if (outIdx >= endIdx) break;
                    heap[outIdx++] = u
                } else if (u <= 2047) {
                    if (outIdx + 1 >= endIdx) break;
                    heap[outIdx++] = 192 | u >> 6;
                    heap[outIdx++] = 128 | u & 63
                } else if (u <= 65535) {
                    if (outIdx + 2 >= endIdx) break;
                    heap[outIdx++] = 224 | u >> 12;
                    heap[outIdx++] = 128 | u >> 6 & 63;
                    heap[outIdx++] = 128 | u & 63
                } else {
                    if (outIdx + 3 >= endIdx) break;
                    heap[outIdx++] = 240 | u >> 18;
                    heap[outIdx++] = 128 | u >> 12 & 63;
                    heap[outIdx++] = 128 | u >> 6 & 63;
                    heap[outIdx++] = 128 | u & 63
                }
            }
            heap[outIdx] = 0;
            return outIdx - startIdx
        }

        function stringToUTF8(str, outPtr, maxBytesToWrite) {
            return stringToUTF8Array(str, HEAPU8, outPtr, maxBytesToWrite)
        }

        function lengthBytesUTF8(str) {
            var len = 0;
            for (var i = 0; i < str.length; ++i) {
                var c = str.charCodeAt(i);
                if (c <= 127) {
                    len++
                } else if (c <= 2047) {
                    len += 2
                } else if (c >= 55296 && c <= 57343) {
                    len += 4;
                    ++i
                } else {
                    len += 3
                }
            }
            return len
        }
        var HEAP8, HEAPU8, HEAP16, HEAPU16, HEAP32, HEAPU32, HEAPF32, HEAPF64;

        function updateMemoryViews() {
            var b = wasmMemory.buffer;
            Module["HEAP8"] = HEAP8 = new Int8Array(b);
            Module["HEAP16"] = HEAP16 = new Int16Array(b);
            Module["HEAP32"] = HEAP32 = new Int32Array(b);
            Module["HEAPU8"] = HEAPU8 = new Uint8Array(b);
            Module["HEAPU16"] = HEAPU16 = new Uint16Array(b);
            Module["HEAPU32"] = HEAPU32 = new Uint32Array(b);
            Module["HEAPF32"] = HEAPF32 = new Float32Array(b);
            Module["HEAPF64"] = HEAPF64 = new Float64Array(b)
        }
        var wasmTable;
        var __ATPRERUN__ = [];
        var __ATINIT__ = [];
        var __ATPOSTRUN__ = [];
        var runtimeInitialized = false;
        var runtimeKeepaliveCounter = 0;

        function keepRuntimeAlive() {
            return noExitRuntime || runtimeKeepaliveCounter > 0
        }

        function preRun() {
            if (Module["preRun"]) {
                if (typeof Module["preRun"] == "function") Module["preRun"] = [Module["preRun"]];
                while (Module["preRun"].length) {
                    addOnPreRun(Module["preRun"].shift())
                }
            }
            callRuntimeCallbacks(__ATPRERUN__)
        }

        function initRuntime() {
            runtimeInitialized = true;
            if (!Module["noFSInit"] && !FS.init.initialized) FS.init();
            FS.ignorePermissions = false;
            TTY.init();
            callRuntimeCallbacks(__ATINIT__)
        }

        function postRun() {
            if (Module["postRun"]) {
                if (typeof Module["postRun"] == "function") Module["postRun"] = [Module["postRun"]];
                while (Module["postRun"].length) {
                    addOnPostRun(Module["postRun"].shift())
                }
            }
            callRuntimeCallbacks(__ATPOSTRUN__)
        }

        function addOnPreRun(cb) {
            __ATPRERUN__.unshift(cb)
        }

        function addOnInit(cb) {
            __ATINIT__.unshift(cb)
        }

        function addOnPostRun(cb) {
            __ATPOSTRUN__.unshift(cb)
        }
        var runDependencies = 0;
        var runDependencyWatcher = null;
        var dependenciesFulfilled = null;

        function getUniqueRunDependency(id) {
            return id
        }

        function addRunDependency(id) {
            runDependencies++;
            if (Module["monitorRunDependencies"]) {
                Module["monitorRunDependencies"](runDependencies)
            }
        }

        function removeRunDependency(id) {
            runDependencies--;
            if (Module["monitorRunDependencies"]) {
                Module["monitorRunDependencies"](runDependencies)
            }
            if (runDependencies == 0) {
                if (runDependencyWatcher !== null) {
                    clearInterval(runDependencyWatcher);
                    runDependencyWatcher = null
                }
                if (dependenciesFulfilled) {
                    var callback = dependenciesFulfilled;
                    dependenciesFulfilled = null;
                    callback()
                }
            }
        }

        function abort(what) {
            if (Module["onAbort"]) {
                Module["onAbort"](what)
            }
            what = "Aborted(" + what + ")";
            err(what);
            ABORT = true;
            EXITSTATUS = 1;
            what += ". Build with -sASSERTIONS for more info.";
            var e = new WebAssembly.RuntimeError(what);
            throw e
        }
        var dataURIPrefix = "data:application/octet-stream;base64,";

        function isDataURI(filename) {
            return filename.startsWith(dataURIPrefix)
        }

        function isFileURI(filename) {
            return filename.startsWith("file://")
        }
        var wasmBinaryFile;
        if (PDFiumModule.url) {
            wasmBinaryFile = PDFiumModule.url + '/pdfium.wasm';
        }
        else {
            wasmBinaryFile = 'pdfium.wasm';
        }
        if (!isDataURI(wasmBinaryFile)) {
            wasmBinaryFile = locateFile(wasmBinaryFile)
        }

        function getBinary(file) {
            try {
                if (file == wasmBinaryFile && wasmBinary) {
                    return new Uint8Array(wasmBinary)
                }
                if (readBinary) {
                    return readBinary(file)
                }
                throw "both async and sync fetching of the wasm failed"
            } catch (err) {
                abort(err)
            }
        }

        function getBinaryPromise(binaryFile) {
            if (!wasmBinary && (ENVIRONMENT_IS_WEB || ENVIRONMENT_IS_WORKER)) {
                if (typeof fetch == "function" && !isFileURI(binaryFile)) {
                    return fetch(binaryFile, {
                        credentials: "same-origin"
                    }).then(function (response) {
                        if (!response["ok"]) {
                            throw "failed to load wasm binary file at '" + binaryFile + "'"
                        }
                        return response["arrayBuffer"]()
                    }).catch(function () {
                        return getBinary(binaryFile)
                    })
                } else {
                    if (readAsync) {
                        return new Promise(function (resolve, reject) {
                            readAsync(binaryFile, function (response) {
                                resolve(new Uint8Array(response))
                            }, reject)
                        })
                    }
                }
            }
            return Promise.resolve().then(function () {
                return getBinary(binaryFile)
            })
        }

        function instantiateArrayBuffer(binaryFile, imports, receiver) {
            return getBinaryPromise(binaryFile).then(function (binary) {
                return WebAssembly.instantiate(binary, imports)
            }).then(function (instance) {
                return instance
            }).then(receiver, function (reason) {
                err("failed to asynchronously prepare wasm: " + reason);
                abort(reason)
            })
        }

        function instantiateAsync(binary, binaryFile, imports, callback) {
            if (!binary && typeof WebAssembly.instantiateStreaming == "function" && !isDataURI(binaryFile) && !isFileURI(binaryFile) && !ENVIRONMENT_IS_NODE && typeof fetch == "function") {
                return fetch(binaryFile, {
                    credentials: "same-origin"
                }).then(function (response) {
                    var result = WebAssembly.instantiateStreaming(response, imports);
                    return result.then(callback, function (reason) {
                        err("wasm streaming compile failed: " + reason);
                        err("falling back to ArrayBuffer instantiation");
                        return instantiateArrayBuffer(binaryFile, imports, callback)
                    })
                })
            } else {
                return instantiateArrayBuffer(binaryFile, imports, callback)
            }
        }

        function createWasm() {
            var info = {
                "env": wasmImports,
                "wasi_snapshot_preview1": wasmImports
            };

            function receiveInstance(instance, module) {
                var exports = instance.exports;
                Module["asm"] = exports;
                wasmMemory = Module["asm"]["memory"];
                updateMemoryViews();
                wasmTable = Module["asm"]["__indirect_function_table"];
                addOnInit(Module["asm"]["__wasm_call_ctors"]);
                removeRunDependency("wasm-instantiate");
                return exports
            }
            addRunDependency("wasm-instantiate");

            function receiveInstantiationResult(result) {
                receiveInstance(result["instance"])
            }
            if (Module["instantiateWasm"]) {
                try {
                    return Module["instantiateWasm"](info, receiveInstance)
                } catch (e) {
                    err("Module.instantiateWasm callback failed with error: " + e);
                    return false
                }
            }
            instantiateAsync(wasmBinary, wasmBinaryFile, info, receiveInstantiationResult);
            return {}
        }
        var tempDouble;
        var tempI64;

        function ExitStatus(status) {
            this.name = "ExitStatus";
            this.message = "Program terminated with exit(" + status + ")";
            this.status = status
        }

        function callRuntimeCallbacks(callbacks) {
            while (callbacks.length > 0) {
                callbacks.shift()(Module)
            }
        }
        var wasmTableMirror = [];

        function getWasmTableEntry(funcPtr) {
            var func = wasmTableMirror[funcPtr];
            if (!func) {
                if (funcPtr >= wasmTableMirror.length) wasmTableMirror.length = funcPtr + 1;
                wasmTableMirror[funcPtr] = func = wasmTable.get(funcPtr)
            }
            return func
        }

        function ___call_sighandler(fp, sig) {
            getWasmTableEntry(fp)(sig)
        }

        function setErrNo(value) {
            HEAP32[___errno_location() >> 2] = value;
            return value
        }
        var PATH = {
            isAbs: path => path.charAt(0) === "/",
            splitPath: filename => {
                var splitPathRe = /^(\/?|)([\s\S]*?)((?:\.{1,2}|[^\/]+?|)(\.[^.\/]*|))(?:[\/]*)$/;
                return splitPathRe.exec(filename).slice(1)
            },
            normalizeArray: (parts, allowAboveRoot) => {
                var up = 0;
                for (var i = parts.length - 1; i >= 0; i--) {
                    var last = parts[i];
                    if (last === ".") {
                        parts.splice(i, 1)
                    } else if (last === "..") {
                        parts.splice(i, 1);
                        up++
                    } else if (up) {
                        parts.splice(i, 1);
                        up--
                    }
                }
                if (allowAboveRoot) {
                    for (; up; up--) {
                        parts.unshift("..")
                    }
                }
                return parts
            },
            normalize: path => {
                var isAbsolute = PATH.isAbs(path),
                    trailingSlash = path.substr(-1) === "/";
                path = PATH.normalizeArray(path.split("/").filter(p => !!p), !isAbsolute).join("/");
                if (!path && !isAbsolute) {
                    path = "."
                }
                if (path && trailingSlash) {
                    path += "/"
                }
                return (isAbsolute ? "/" : "") + path
            },
            dirname: path => {
                var result = PATH.splitPath(path),
                    root = result[0],
                    dir = result[1];
                if (!root && !dir) {
                    return "."
                }
                if (dir) {
                    dir = dir.substr(0, dir.length - 1)
                }
                return root + dir
            },
            basename: path => {
                if (path === "/") return "/";
                path = PATH.normalize(path);
                path = path.replace(/\/$/, "");
                var lastSlash = path.lastIndexOf("/");
                if (lastSlash === -1) return path;
                return path.substr(lastSlash + 1)
            },
            join: function () {
                var paths = Array.prototype.slice.call(arguments);
                return PATH.normalize(paths.join("/"))
            },
            join2: (l, r) => {
                return PATH.normalize(l + "/" + r)
            }
        };

        function getRandomDevice() {
            if (typeof crypto == "object" && typeof crypto["getRandomValues"] == "function") {
                var randomBuffer = new Uint8Array(1);
                return () => {
                    crypto.getRandomValues(randomBuffer);
                    return randomBuffer[0]
                }
            } else if (ENVIRONMENT_IS_NODE) {
                try {
                    var crypto_module = require("crypto");
                    return () => crypto_module["randomBytes"](1)[0]
                } catch (e) {}
            }
            return () => abort("randomDevice")
        }
        var PATH_FS = {
            resolve: function () {
                var resolvedPath = "",
                    resolvedAbsolute = false;
                for (var i = arguments.length - 1; i >= -1 && !resolvedAbsolute; i--) {
                    var path = i >= 0 ? arguments[i] : FS.cwd();
                    if (typeof path != "string") {
                        throw new TypeError("Arguments to path.resolve must be strings")
                    } else if (!path) {
                        return ""
                    }
                    resolvedPath = path + "/" + resolvedPath;
                    resolvedAbsolute = PATH.isAbs(path)
                }
                resolvedPath = PATH.normalizeArray(resolvedPath.split("/").filter(p => !!p), !resolvedAbsolute).join("/");
                return (resolvedAbsolute ? "/" : "") + resolvedPath || "."
            },
            relative: (from, to) => {
                from = PATH_FS.resolve(from).substr(1);
                to = PATH_FS.resolve(to).substr(1);

                function trim(arr) {
                    var start = 0;
                    for (; start < arr.length; start++) {
                        if (arr[start] !== "") break
                    }
                    var end = arr.length - 1;
                    for (; end >= 0; end--) {
                        if (arr[end] !== "") break
                    }
                    if (start > end) return [];
                    return arr.slice(start, end - start + 1)
                }
                var fromParts = trim(from.split("/"));
                var toParts = trim(to.split("/"));
                var length = Math.min(fromParts.length, toParts.length);
                var samePartsLength = length;
                for (var i = 0; i < length; i++) {
                    if (fromParts[i] !== toParts[i]) {
                        samePartsLength = i;
                        break
                    }
                }
                var outputParts = [];
                for (var i = samePartsLength; i < fromParts.length; i++) {
                    outputParts.push("..")
                }
                outputParts = outputParts.concat(toParts.slice(samePartsLength));
                return outputParts.join("/")
            }
        };

        function intArrayFromString(stringy, dontAddNull, length) {
            var len = length > 0 ? length : lengthBytesUTF8(stringy) + 1;
            var u8array = new Array(len);
            var numBytesWritten = stringToUTF8Array(stringy, u8array, 0, u8array.length);
            if (dontAddNull) u8array.length = numBytesWritten;
            return u8array
        }
        var TTY = {
            ttys: [],
            init: function () {},
            shutdown: function () {},
            register: function (dev, ops) {
                TTY.ttys[dev] = {
                    input: [],
                    output: [],
                    ops: ops
                };
                FS.registerDevice(dev, TTY.stream_ops)
            },
            stream_ops: {
                open: function (stream) {
                    var tty = TTY.ttys[stream.node.rdev];
                    if (!tty) {
                        throw new FS.ErrnoError(43)
                    }
                    stream.tty = tty;
                    stream.seekable = false
                },
                close: function (stream) {
                    stream.tty.ops.fsync(stream.tty)
                },
                fsync: function (stream) {
                    stream.tty.ops.fsync(stream.tty)
                },
                read: function (stream, buffer, offset, length, pos) {
                    if (!stream.tty || !stream.tty.ops.get_char) {
                        throw new FS.ErrnoError(60)
                    }
                    var bytesRead = 0;
                    for (var i = 0; i < length; i++) {
                        var result;
                        try {
                            result = stream.tty.ops.get_char(stream.tty)
                        } catch (e) {
                            throw new FS.ErrnoError(29)
                        }
                        if (result === undefined && bytesRead === 0) {
                            throw new FS.ErrnoError(6)
                        }
                        if (result === null || result === undefined) break;
                        bytesRead++;
                        buffer[offset + i] = result
                    }
                    if (bytesRead) {
                        stream.node.timestamp = Date.now()
                    }
                    return bytesRead
                },
                write: function (stream, buffer, offset, length, pos) {
                    if (!stream.tty || !stream.tty.ops.put_char) {
                        throw new FS.ErrnoError(60)
                    }
                    try {
                        for (var i = 0; i < length; i++) {
                            stream.tty.ops.put_char(stream.tty, buffer[offset + i])
                        }
                    } catch (e) {
                        throw new FS.ErrnoError(29)
                    }
                    if (length) {
                        stream.node.timestamp = Date.now()
                    }
                    return i
                }
            },
            default_tty_ops: {
                get_char: function (tty) {
                    if (!tty.input.length) {
                        var result = null;
                        if (ENVIRONMENT_IS_NODE) {
                            var BUFSIZE = 256;
                            var buf = Buffer.alloc(BUFSIZE);
                            var bytesRead = 0;
                            try {
                                bytesRead = fs.readSync(process.stdin.fd, buf, 0, BUFSIZE, -1)
                            } catch (e) {
                                if (e.toString().includes("EOF")) bytesRead = 0;
                                else throw e
                            }
                            if (bytesRead > 0) {
                                result = buf.slice(0, bytesRead).toString("utf-8")
                            } else {
                                result = null
                            }
                        } else if (typeof window != "undefined" && typeof window.prompt == "function") {
                            result = window.prompt("Input: ");
                            if (result !== null) {
                                result += "\n"
                            }
                        } else if (typeof readline == "function") {
                            result = readline();
                            if (result !== null) {
                                result += "\n"
                            }
                        }
                        if (!result) {
                            return null
                        }
                        tty.input = intArrayFromString(result, true)
                    }
                    return tty.input.shift()
                },
                put_char: function (tty, val) {
                    if (val === null || val === 10) {
                        out(UTF8ArrayToString(tty.output, 0));
                        tty.output = []
                    } else {
                        if (val != 0) tty.output.push(val)
                    }
                },
                fsync: function (tty) {
                    if (tty.output && tty.output.length > 0) {
                        out(UTF8ArrayToString(tty.output, 0));
                        tty.output = []
                    }
                }
            },
            default_tty1_ops: {
                put_char: function (tty, val) {
                    if (val === null || val === 10) {
                        err(UTF8ArrayToString(tty.output, 0));
                        tty.output = []
                    } else {
                        if (val != 0) tty.output.push(val)
                    }
                },
                fsync: function (tty) {
                    if (tty.output && tty.output.length > 0) {
                        err(UTF8ArrayToString(tty.output, 0));
                        tty.output = []
                    }
                }
            }
        };

        function zeroMemory(address, size) {
            HEAPU8.fill(0, address, address + size);
            return address
        }

        function alignMemory(size, alignment) {
            return Math.ceil(size / alignment) * alignment
        }

        function mmapAlloc(size) {
            size = alignMemory(size, 65536);
            var ptr = _emscripten_builtin_memalign(65536, size);
            if (!ptr) return 0;
            return zeroMemory(ptr, size)
        }
        var MEMFS = {
            ops_table: null,
            mount: function (mount) {
                return MEMFS.createNode(null, "/", 16384 | 511, 0)
            },
            createNode: function (parent, name, mode, dev) {
                if (FS.isBlkdev(mode) || FS.isFIFO(mode)) {
                    throw new FS.ErrnoError(63)
                }
                if (!MEMFS.ops_table) {
                    MEMFS.ops_table = {
                        dir: {
                            node: {
                                getattr: MEMFS.node_ops.getattr,
                                setattr: MEMFS.node_ops.setattr,
                                lookup: MEMFS.node_ops.lookup,
                                mknod: MEMFS.node_ops.mknod,
                                rename: MEMFS.node_ops.rename,
                                unlink: MEMFS.node_ops.unlink,
                                rmdir: MEMFS.node_ops.rmdir,
                                readdir: MEMFS.node_ops.readdir,
                                symlink: MEMFS.node_ops.symlink
                            },
                            stream: {
                                llseek: MEMFS.stream_ops.llseek
                            }
                        },
                        file: {
                            node: {
                                getattr: MEMFS.node_ops.getattr,
                                setattr: MEMFS.node_ops.setattr
                            },
                            stream: {
                                llseek: MEMFS.stream_ops.llseek,
                                read: MEMFS.stream_ops.read,
                                write: MEMFS.stream_ops.write,
                                allocate: MEMFS.stream_ops.allocate,
                                mmap: MEMFS.stream_ops.mmap,
                                msync: MEMFS.stream_ops.msync
                            }
                        },
                        link: {
                            node: {
                                getattr: MEMFS.node_ops.getattr,
                                setattr: MEMFS.node_ops.setattr,
                                readlink: MEMFS.node_ops.readlink
                            },
                            stream: {}
                        },
                        chrdev: {
                            node: {
                                getattr: MEMFS.node_ops.getattr,
                                setattr: MEMFS.node_ops.setattr
                            },
                            stream: FS.chrdev_stream_ops
                        }
                    }
                }
                var node = FS.createNode(parent, name, mode, dev);
                if (FS.isDir(node.mode)) {
                    node.node_ops = MEMFS.ops_table.dir.node;
                    node.stream_ops = MEMFS.ops_table.dir.stream;
                    node.contents = {}
                } else if (FS.isFile(node.mode)) {
                    node.node_ops = MEMFS.ops_table.file.node;
                    node.stream_ops = MEMFS.ops_table.file.stream;
                    node.usedBytes = 0;
                    node.contents = null
                } else if (FS.isLink(node.mode)) {
                    node.node_ops = MEMFS.ops_table.link.node;
                    node.stream_ops = MEMFS.ops_table.link.stream
                } else if (FS.isChrdev(node.mode)) {
                    node.node_ops = MEMFS.ops_table.chrdev.node;
                    node.stream_ops = MEMFS.ops_table.chrdev.stream
                }
                node.timestamp = Date.now();
                if (parent) {
                    parent.contents[name] = node;
                    parent.timestamp = node.timestamp
                }
                return node
            },
            getFileDataAsTypedArray: function (node) {
                if (!node.contents) return new Uint8Array(0);
                if (node.contents.subarray) return node.contents.subarray(0, node.usedBytes);
                return new Uint8Array(node.contents)
            },
            expandFileStorage: function (node, newCapacity) {
                var prevCapacity = node.contents ? node.contents.length : 0;
                if (prevCapacity >= newCapacity) return;
                var CAPACITY_DOUBLING_MAX = 1024 * 1024;
                newCapacity = Math.max(newCapacity, prevCapacity * (prevCapacity < CAPACITY_DOUBLING_MAX ? 2 : 1.125) >>> 0);
                if (prevCapacity != 0) newCapacity = Math.max(newCapacity, 256);
                var oldContents = node.contents;
                node.contents = new Uint8Array(newCapacity);
                if (node.usedBytes > 0) node.contents.set(oldContents.subarray(0, node.usedBytes), 0)
            },
            resizeFileStorage: function (node, newSize) {
                if (node.usedBytes == newSize) return;
                if (newSize == 0) {
                    node.contents = null;
                    node.usedBytes = 0
                } else {
                    var oldContents = node.contents;
                    node.contents = new Uint8Array(newSize);
                    if (oldContents) {
                        node.contents.set(oldContents.subarray(0, Math.min(newSize, node.usedBytes)))
                    }
                    node.usedBytes = newSize
                }
            },
            node_ops: {
                getattr: function (node) {
                    var attr = {};
                    attr.dev = FS.isChrdev(node.mode) ? node.id : 1;
                    attr.ino = node.id;
                    attr.mode = node.mode;
                    attr.nlink = 1;
                    attr.uid = 0;
                    attr.gid = 0;
                    attr.rdev = node.rdev;
                    if (FS.isDir(node.mode)) {
                        attr.size = 4096
                    } else if (FS.isFile(node.mode)) {
                        attr.size = node.usedBytes
                    } else if (FS.isLink(node.mode)) {
                        attr.size = node.link.length
                    } else {
                        attr.size = 0
                    }
                    attr.atime = new Date(node.timestamp);
                    attr.mtime = new Date(node.timestamp);
                    attr.ctime = new Date(node.timestamp);
                    attr.blksize = 4096;
                    attr.blocks = Math.ceil(attr.size / attr.blksize);
                    return attr
                },
                setattr: function (node, attr) {
                    if (attr.mode !== undefined) {
                        node.mode = attr.mode
                    }
                    if (attr.timestamp !== undefined) {
                        node.timestamp = attr.timestamp
                    }
                    if (attr.size !== undefined) {
                        MEMFS.resizeFileStorage(node, attr.size)
                    }
                },
                lookup: function (parent, name) {
                    throw FS.genericErrors[44]
                },
                mknod: function (parent, name, mode, dev) {
                    return MEMFS.createNode(parent, name, mode, dev)
                },
                rename: function (old_node, new_dir, new_name) {
                    if (FS.isDir(old_node.mode)) {
                        var new_node;
                        try {
                            new_node = FS.lookupNode(new_dir, new_name)
                        } catch (e) {}
                        if (new_node) {
                            for (var i in new_node.contents) {
                                throw new FS.ErrnoError(55)
                            }
                        }
                    }
                    delete old_node.parent.contents[old_node.name];
                    old_node.parent.timestamp = Date.now();
                    old_node.name = new_name;
                    new_dir.contents[new_name] = old_node;
                    new_dir.timestamp = old_node.parent.timestamp;
                    old_node.parent = new_dir
                },
                unlink: function (parent, name) {
                    delete parent.contents[name];
                    parent.timestamp = Date.now()
                },
                rmdir: function (parent, name) {
                    var node = FS.lookupNode(parent, name);
                    for (var i in node.contents) {
                        throw new FS.ErrnoError(55)
                    }
                    delete parent.contents[name];
                    parent.timestamp = Date.now()
                },
                readdir: function (node) {
                    var entries = [".", ".."];
                    for (var key in node.contents) {
                        if (!node.contents.hasOwnProperty(key)) {
                            continue
                        }
                        entries.push(key)
                    }
                    return entries
                },
                symlink: function (parent, newname, oldpath) {
                    var node = MEMFS.createNode(parent, newname, 511 | 40960, 0);
                    node.link = oldpath;
                    return node
                },
                readlink: function (node) {
                    if (!FS.isLink(node.mode)) {
                        throw new FS.ErrnoError(28)
                    }
                    return node.link
                }
            },
            stream_ops: {
                read: function (stream, buffer, offset, length, position) {
                    var contents = stream.node.contents;
                    if (position >= stream.node.usedBytes) return 0;
                    var size = Math.min(stream.node.usedBytes - position, length);
                    if (size > 8 && contents.subarray) {
                        buffer.set(contents.subarray(position, position + size), offset)
                    } else {
                        for (var i = 0; i < size; i++) buffer[offset + i] = contents[position + i]
                    }
                    return size
                },
                write: function (stream, buffer, offset, length, position, canOwn) {
                    if (buffer.buffer === HEAP8.buffer) {
                        canOwn = false
                    }
                    if (!length) return 0;
                    var node = stream.node;
                    node.timestamp = Date.now();
                    if (buffer.subarray && (!node.contents || node.contents.subarray)) {
                        if (canOwn) {
                            node.contents = buffer.subarray(offset, offset + length);
                            node.usedBytes = length;
                            return length
                        } else if (node.usedBytes === 0 && position === 0) {
                            node.contents = buffer.slice(offset, offset + length);
                            node.usedBytes = length;
                            return length
                        } else if (position + length <= node.usedBytes) {
                            node.contents.set(buffer.subarray(offset, offset + length), position);
                            return length
                        }
                    }
                    MEMFS.expandFileStorage(node, position + length);
                    if (node.contents.subarray && buffer.subarray) {
                        node.contents.set(buffer.subarray(offset, offset + length), position)
                    } else {
                        for (var i = 0; i < length; i++) {
                            node.contents[position + i] = buffer[offset + i]
                        }
                    }
                    node.usedBytes = Math.max(node.usedBytes, position + length);
                    return length
                },
                llseek: function (stream, offset, whence) {
                    var position = offset;
                    if (whence === 1) {
                        position += stream.position
                    } else if (whence === 2) {
                        if (FS.isFile(stream.node.mode)) {
                            position += stream.node.usedBytes
                        }
                    }
                    if (position < 0) {
                        throw new FS.ErrnoError(28)
                    }
                    return position
                },
                allocate: function (stream, offset, length) {
                    MEMFS.expandFileStorage(stream.node, offset + length);
                    stream.node.usedBytes = Math.max(stream.node.usedBytes, offset + length)
                },
                mmap: function (stream, length, position, prot, flags) {
                    if (!FS.isFile(stream.node.mode)) {
                        throw new FS.ErrnoError(43)
                    }
                    var ptr;
                    var allocated;
                    var contents = stream.node.contents;
                    if (!(flags & 2) && contents.buffer === HEAP8.buffer) {
                        allocated = false;
                        ptr = contents.byteOffset
                    } else {
                        if (position > 0 || position + length < contents.length) {
                            if (contents.subarray) {
                                contents = contents.subarray(position, position + length)
                            } else {
                                contents = Array.prototype.slice.call(contents, position, position + length)
                            }
                        }
                        allocated = true;
                        ptr = mmapAlloc(length);
                        if (!ptr) {
                            throw new FS.ErrnoError(48)
                        }
                        HEAP8.set(contents, ptr)
                    }
                    return {
                        ptr: ptr,
                        allocated: allocated
                    }
                },
                msync: function (stream, buffer, offset, length, mmapFlags) {
                    MEMFS.stream_ops.write(stream, buffer, 0, length, offset, false);
                    return 0
                }
            }
        };

        function asyncLoad(url, onload, onerror, noRunDep) {
            var dep = !noRunDep ? getUniqueRunDependency("al " + url) : "";
            readAsync(url, arrayBuffer => {
                assert(arrayBuffer, 'Loading data file "' + url + '" failed (no arrayBuffer).');
                onload(new Uint8Array(arrayBuffer));
                if (dep) removeRunDependency(dep)
            }, event => {
                if (onerror) {
                    onerror()
                } else {
                    throw 'Loading data file "' + url + '" failed.'
                }
            });
            if (dep) addRunDependency(dep)
        }
        var FS = {
            root: null,
            mounts: [],
            devices: {},
            streams: [],
            nextInode: 1,
            nameTable: null,
            currentPath: "/",
            initialized: false,
            ignorePermissions: true,
            ErrnoError: null,
            genericErrors: {},
            filesystems: null,
            syncFSRequests: 0,
            lookupPath: (path, opts = {}) => {
                path = PATH_FS.resolve(path);
                if (!path) return {
                    path: "",
                    node: null
                };
                var defaults = {
                    follow_mount: true,
                    recurse_count: 0
                };
                opts = Object.assign(defaults, opts);
                if (opts.recurse_count > 8) {
                    throw new FS.ErrnoError(32)
                }
                var parts = path.split("/").filter(p => !!p);
                var current = FS.root;
                var current_path = "/";
                for (var i = 0; i < parts.length; i++) {
                    var islast = i === parts.length - 1;
                    if (islast && opts.parent) {
                        break
                    }
                    current = FS.lookupNode(current, parts[i]);
                    current_path = PATH.join2(current_path, parts[i]);
                    if (FS.isMountpoint(current)) {
                        if (!islast || islast && opts.follow_mount) {
                            current = current.mounted.root
                        }
                    }
                    if (!islast || opts.follow) {
                        var count = 0;
                        while (FS.isLink(current.mode)) {
                            var link = FS.readlink(current_path);
                            current_path = PATH_FS.resolve(PATH.dirname(current_path), link);
                            var lookup = FS.lookupPath(current_path, {
                                recurse_count: opts.recurse_count + 1
                            });
                            current = lookup.node;
                            if (count++ > 40) {
                                throw new FS.ErrnoError(32)
                            }
                        }
                    }
                }
                return {
                    path: current_path,
                    node: current
                }
            },
            getPath: node => {
                var path;
                while (true) {
                    if (FS.isRoot(node)) {
                        var mount = node.mount.mountpoint;
                        if (!path) return mount;
                        return mount[mount.length - 1] !== "/" ? mount + "/" + path : mount + path
                    }
                    path = path ? node.name + "/" + path : node.name;
                    node = node.parent
                }
            },
            hashName: (parentid, name) => {
                var hash = 0;
                for (var i = 0; i < name.length; i++) {
                    hash = (hash << 5) - hash + name.charCodeAt(i) | 0
                }
                return (parentid + hash >>> 0) % FS.nameTable.length
            },
            hashAddNode: node => {
                var hash = FS.hashName(node.parent.id, node.name);
                node.name_next = FS.nameTable[hash];
                FS.nameTable[hash] = node
            },
            hashRemoveNode: node => {
                var hash = FS.hashName(node.parent.id, node.name);
                if (FS.nameTable[hash] === node) {
                    FS.nameTable[hash] = node.name_next
                } else {
                    var current = FS.nameTable[hash];
                    while (current) {
                        if (current.name_next === node) {
                            current.name_next = node.name_next;
                            break
                        }
                        current = current.name_next
                    }
                }
            },
            lookupNode: (parent, name) => {
                var errCode = FS.mayLookup(parent);
                if (errCode) {
                    throw new FS.ErrnoError(errCode, parent)
                }
                var hash = FS.hashName(parent.id, name);
                for (var node = FS.nameTable[hash]; node; node = node.name_next) {
                    var nodeName = node.name;
                    if (node.parent.id === parent.id && nodeName === name) {
                        return node
                    }
                }
                return FS.lookup(parent, name)
            },
            createNode: (parent, name, mode, rdev) => {
                var node = new FS.FSNode(parent, name, mode, rdev);
                FS.hashAddNode(node);
                return node
            },
            destroyNode: node => {
                FS.hashRemoveNode(node)
            },
            isRoot: node => {
                return node === node.parent
            },
            isMountpoint: node => {
                return !!node.mounted
            },
            isFile: mode => {
                return (mode & 61440) === 32768
            },
            isDir: mode => {
                return (mode & 61440) === 16384
            },
            isLink: mode => {
                return (mode & 61440) === 40960
            },
            isChrdev: mode => {
                return (mode & 61440) === 8192
            },
            isBlkdev: mode => {
                return (mode & 61440) === 24576
            },
            isFIFO: mode => {
                return (mode & 61440) === 4096
            },
            isSocket: mode => {
                return (mode & 49152) === 49152
            },
            flagModes: {
                "r": 0,
                "r+": 2,
                "w": 577,
                "w+": 578,
                "a": 1089,
                "a+": 1090
            },
            modeStringToFlags: str => {
                var flags = FS.flagModes[str];
                if (typeof flags == "undefined") {
                    throw new Error("Unknown file open mode: " + str)
                }
                return flags
            },
            flagsToPermissionString: flag => {
                var perms = ["r", "w", "rw"][flag & 3];
                if (flag & 512) {
                    perms += "w"
                }
                return perms
            },
            nodePermissions: (node, perms) => {
                if (FS.ignorePermissions) {
                    return 0
                }
                if (perms.includes("r") && !(node.mode & 292)) {
                    return 2
                } else if (perms.includes("w") && !(node.mode & 146)) {
                    return 2
                } else if (perms.includes("x") && !(node.mode & 73)) {
                    return 2
                }
                return 0
            },
            mayLookup: dir => {
                var errCode = FS.nodePermissions(dir, "x");
                if (errCode) return errCode;
                if (!dir.node_ops.lookup) return 2;
                return 0
            },
            mayCreate: (dir, name) => {
                try {
                    var node = FS.lookupNode(dir, name);
                    return 20
                } catch (e) {}
                return FS.nodePermissions(dir, "wx")
            },
            mayDelete: (dir, name, isdir) => {
                var node;
                try {
                    node = FS.lookupNode(dir, name)
                } catch (e) {
                    return e.errno
                }
                var errCode = FS.nodePermissions(dir, "wx");
                if (errCode) {
                    return errCode
                }
                if (isdir) {
                    if (!FS.isDir(node.mode)) {
                        return 54
                    }
                    if (FS.isRoot(node) || FS.getPath(node) === FS.cwd()) {
                        return 10
                    }
                } else {
                    if (FS.isDir(node.mode)) {
                        return 31
                    }
                }
                return 0
            },
            mayOpen: (node, flags) => {
                if (!node) {
                    return 44
                }
                if (FS.isLink(node.mode)) {
                    return 32
                } else if (FS.isDir(node.mode)) {
                    if (FS.flagsToPermissionString(flags) !== "r" || flags & 512) {
                        return 31
                    }
                }
                return FS.nodePermissions(node, FS.flagsToPermissionString(flags))
            },
            MAX_OPEN_FDS: 4096,
            nextfd: (fd_start = 0, fd_end = FS.MAX_OPEN_FDS) => {
                for (var fd = fd_start; fd <= fd_end; fd++) {
                    if (!FS.streams[fd]) {
                        return fd
                    }
                }
                throw new FS.ErrnoError(33)
            },
            getStream: fd => FS.streams[fd],
            createStream: (stream, fd_start, fd_end) => {
                if (!FS.FSStream) {
                    FS.FSStream = function () {
                        this.shared = {}
                    };
                    FS.FSStream.prototype = {};
                    Object.defineProperties(FS.FSStream.prototype, {
                        object: {
                            get: function () {
                                return this.node
                            },
                            set: function (val) {
                                this.node = val
                            }
                        },
                        isRead: {
                            get: function () {
                                return (this.flags & 2097155) !== 1
                            }
                        },
                        isWrite: {
                            get: function () {
                                return (this.flags & 2097155) !== 0
                            }
                        },
                        isAppend: {
                            get: function () {
                                return this.flags & 1024
                            }
                        },
                        flags: {
                            get: function () {
                                return this.shared.flags
                            },
                            set: function (val) {
                                this.shared.flags = val
                            }
                        },
                        position: {
                            get: function () {
                                return this.shared.position
                            },
                            set: function (val) {
                                this.shared.position = val
                            }
                        }
                    })
                }
                stream = Object.assign(new FS.FSStream, stream);
                var fd = FS.nextfd(fd_start, fd_end);
                stream.fd = fd;
                FS.streams[fd] = stream;
                return stream
            },
            closeStream: fd => {
                FS.streams[fd] = null
            },
            chrdev_stream_ops: {
                open: stream => {
                    var device = FS.getDevice(stream.node.rdev);
                    stream.stream_ops = device.stream_ops;
                    if (stream.stream_ops.open) {
                        stream.stream_ops.open(stream)
                    }
                },
                llseek: () => {
                    throw new FS.ErrnoError(70)
                }
            },
            major: dev => dev >> 8,
            minor: dev => dev & 255,
            makedev: (ma, mi) => ma << 8 | mi,
            registerDevice: (dev, ops) => {
                FS.devices[dev] = {
                    stream_ops: ops
                }
            },
            getDevice: dev => FS.devices[dev],
            getMounts: mount => {
                var mounts = [];
                var check = [mount];
                while (check.length) {
                    var m = check.pop();
                    mounts.push(m);
                    check.push.apply(check, m.mounts)
                }
                return mounts
            },
            syncfs: (populate, callback) => {
                if (typeof populate == "function") {
                    callback = populate;
                    populate = false
                }
                FS.syncFSRequests++;
                if (FS.syncFSRequests > 1) {
                    err("warning: " + FS.syncFSRequests + " FS.syncfs operations in flight at once, probably just doing extra work")
                }
                var mounts = FS.getMounts(FS.root.mount);
                var completed = 0;

                function doCallback(errCode) {
                    FS.syncFSRequests--;
                    return callback(errCode)
                }

                function done(errCode) {
                    if (errCode) {
                        if (!done.errored) {
                            done.errored = true;
                            return doCallback(errCode)
                        }
                        return
                    }
                    if (++completed >= mounts.length) {
                        doCallback(null)
                    }
                }
                mounts.forEach(mount => {
                    if (!mount.type.syncfs) {
                        return done(null)
                    }
                    mount.type.syncfs(mount, populate, done)
                })
            },
            mount: (type, opts, mountpoint) => {
                var root = mountpoint === "/";
                var pseudo = !mountpoint;
                var node;
                if (root && FS.root) {
                    throw new FS.ErrnoError(10)
                } else if (!root && !pseudo) {
                    var lookup = FS.lookupPath(mountpoint, {
                        follow_mount: false
                    });
                    mountpoint = lookup.path;
                    node = lookup.node;
                    if (FS.isMountpoint(node)) {
                        throw new FS.ErrnoError(10)
                    }
                    if (!FS.isDir(node.mode)) {
                        throw new FS.ErrnoError(54)
                    }
                }
                var mount = {
                    type: type,
                    opts: opts,
                    mountpoint: mountpoint,
                    mounts: []
                };
                var mountRoot = type.mount(mount);
                mountRoot.mount = mount;
                mount.root = mountRoot;
                if (root) {
                    FS.root = mountRoot
                } else if (node) {
                    node.mounted = mount;
                    if (node.mount) {
                        node.mount.mounts.push(mount)
                    }
                }
                return mountRoot
            },
            unmount: mountpoint => {
                var lookup = FS.lookupPath(mountpoint, {
                    follow_mount: false
                });
                if (!FS.isMountpoint(lookup.node)) {
                    throw new FS.ErrnoError(28)
                }
                var node = lookup.node;
                var mount = node.mounted;
                var mounts = FS.getMounts(mount);
                Object.keys(FS.nameTable).forEach(hash => {
                    var current = FS.nameTable[hash];
                    while (current) {
                        var next = current.name_next;
                        if (mounts.includes(current.mount)) {
                            FS.destroyNode(current)
                        }
                        current = next
                    }
                });
                node.mounted = null;
                var idx = node.mount.mounts.indexOf(mount);
                node.mount.mounts.splice(idx, 1)
            },
            lookup: (parent, name) => {
                return parent.node_ops.lookup(parent, name)
            },
            mknod: (path, mode, dev) => {
                var lookup = FS.lookupPath(path, {
                    parent: true
                });
                var parent = lookup.node;
                var name = PATH.basename(path);
                if (!name || name === "." || name === "..") {
                    throw new FS.ErrnoError(28)
                }
                var errCode = FS.mayCreate(parent, name);
                if (errCode) {
                    throw new FS.ErrnoError(errCode)
                }
                if (!parent.node_ops.mknod) {
                    throw new FS.ErrnoError(63)
                }
                return parent.node_ops.mknod(parent, name, mode, dev)
            },
            create: (path, mode) => {
                mode = mode !== undefined ? mode : 438;
                mode &= 4095;
                mode |= 32768;
                return FS.mknod(path, mode, 0)
            },
            mkdir: (path, mode) => {
                mode = mode !== undefined ? mode : 511;
                mode &= 511 | 512;
                mode |= 16384;
                return FS.mknod(path, mode, 0)
            },
            mkdirTree: (path, mode) => {
                var dirs = path.split("/");
                var d = "";
                for (var i = 0; i < dirs.length; ++i) {
                    if (!dirs[i]) continue;
                    d += "/" + dirs[i];
                    try {
                        FS.mkdir(d, mode)
                    } catch (e) {
                        if (e.errno != 20) throw e
                    }
                }
            },
            mkdev: (path, mode, dev) => {
                if (typeof dev == "undefined") {
                    dev = mode;
                    mode = 438
                }
                mode |= 8192;
                return FS.mknod(path, mode, dev)
            },
            symlink: (oldpath, newpath) => {
                if (!PATH_FS.resolve(oldpath)) {
                    throw new FS.ErrnoError(44)
                }
                var lookup = FS.lookupPath(newpath, {
                    parent: true
                });
                var parent = lookup.node;
                if (!parent) {
                    throw new FS.ErrnoError(44)
                }
                var newname = PATH.basename(newpath);
                var errCode = FS.mayCreate(parent, newname);
                if (errCode) {
                    throw new FS.ErrnoError(errCode)
                }
                if (!parent.node_ops.symlink) {
                    throw new FS.ErrnoError(63)
                }
                return parent.node_ops.symlink(parent, newname, oldpath)
            },
            rename: (old_path, new_path) => {
                var old_dirname = PATH.dirname(old_path);
                var new_dirname = PATH.dirname(new_path);
                var old_name = PATH.basename(old_path);
                var new_name = PATH.basename(new_path);
                var lookup, old_dir, new_dir;
                lookup = FS.lookupPath(old_path, {
                    parent: true
                });
                old_dir = lookup.node;
                lookup = FS.lookupPath(new_path, {
                    parent: true
                });
                new_dir = lookup.node;
                if (!old_dir || !new_dir) throw new FS.ErrnoError(44);
                if (old_dir.mount !== new_dir.mount) {
                    throw new FS.ErrnoError(75)
                }
                var old_node = FS.lookupNode(old_dir, old_name);
                var relative = PATH_FS.relative(old_path, new_dirname);
                if (relative.charAt(0) !== ".") {
                    throw new FS.ErrnoError(28)
                }
                relative = PATH_FS.relative(new_path, old_dirname);
                if (relative.charAt(0) !== ".") {
                    throw new FS.ErrnoError(55)
                }
                var new_node;
                try {
                    new_node = FS.lookupNode(new_dir, new_name)
                } catch (e) {}
                if (old_node === new_node) {
                    return
                }
                var isdir = FS.isDir(old_node.mode);
                var errCode = FS.mayDelete(old_dir, old_name, isdir);
                if (errCode) {
                    throw new FS.ErrnoError(errCode)
                }
                errCode = new_node ? FS.mayDelete(new_dir, new_name, isdir) : FS.mayCreate(new_dir, new_name);
                if (errCode) {
                    throw new FS.ErrnoError(errCode)
                }
                if (!old_dir.node_ops.rename) {
                    throw new FS.ErrnoError(63)
                }
                if (FS.isMountpoint(old_node) || new_node && FS.isMountpoint(new_node)) {
                    throw new FS.ErrnoError(10)
                }
                if (new_dir !== old_dir) {
                    errCode = FS.nodePermissions(old_dir, "w");
                    if (errCode) {
                        throw new FS.ErrnoError(errCode)
                    }
                }
                FS.hashRemoveNode(old_node);
                try {
                    old_dir.node_ops.rename(old_node, new_dir, new_name)
                } catch (e) {
                    throw e
                } finally {
                    FS.hashAddNode(old_node)
                }
            },
            rmdir: path => {
                var lookup = FS.lookupPath(path, {
                    parent: true
                });
                var parent = lookup.node;
                var name = PATH.basename(path);
                var node = FS.lookupNode(parent, name);
                var errCode = FS.mayDelete(parent, name, true);
                if (errCode) {
                    throw new FS.ErrnoError(errCode)
                }
                if (!parent.node_ops.rmdir) {
                    throw new FS.ErrnoError(63)
                }
                if (FS.isMountpoint(node)) {
                    throw new FS.ErrnoError(10)
                }
                parent.node_ops.rmdir(parent, name);
                FS.destroyNode(node)
            },
            readdir: path => {
                var lookup = FS.lookupPath(path, {
                    follow: true
                });
                var node = lookup.node;
                if (!node.node_ops.readdir) {
                    throw new FS.ErrnoError(54)
                }
                return node.node_ops.readdir(node)
            },
            unlink: path => {
                var lookup = FS.lookupPath(path, {
                    parent: true
                });
                var parent = lookup.node;
                if (!parent) {
                    throw new FS.ErrnoError(44)
                }
                var name = PATH.basename(path);
                var node = FS.lookupNode(parent, name);
                var errCode = FS.mayDelete(parent, name, false);
                if (errCode) {
                    throw new FS.ErrnoError(errCode)
                }
                if (!parent.node_ops.unlink) {
                    throw new FS.ErrnoError(63)
                }
                if (FS.isMountpoint(node)) {
                    throw new FS.ErrnoError(10)
                }
                parent.node_ops.unlink(parent, name);
                FS.destroyNode(node)
            },
            readlink: path => {
                var lookup = FS.lookupPath(path);
                var link = lookup.node;
                if (!link) {
                    throw new FS.ErrnoError(44)
                }
                if (!link.node_ops.readlink) {
                    throw new FS.ErrnoError(28)
                }
                return PATH_FS.resolve(FS.getPath(link.parent), link.node_ops.readlink(link))
            },
            stat: (path, dontFollow) => {
                var lookup = FS.lookupPath(path, {
                    follow: !dontFollow
                });
                var node = lookup.node;
                if (!node) {
                    throw new FS.ErrnoError(44)
                }
                if (!node.node_ops.getattr) {
                    throw new FS.ErrnoError(63)
                }
                return node.node_ops.getattr(node)
            },
            lstat: path => {
                return FS.stat(path, true)
            },
            chmod: (path, mode, dontFollow) => {
                var node;
                if (typeof path == "string") {
                    var lookup = FS.lookupPath(path, {
                        follow: !dontFollow
                    });
                    node = lookup.node
                } else {
                    node = path
                }
                if (!node.node_ops.setattr) {
                    throw new FS.ErrnoError(63)
                }
                node.node_ops.setattr(node, {
                    mode: mode & 4095 | node.mode & ~4095,
                    timestamp: Date.now()
                })
            },
            lchmod: (path, mode) => {
                FS.chmod(path, mode, true)
            },
            fchmod: (fd, mode) => {
                var stream = FS.getStream(fd);
                if (!stream) {
                    throw new FS.ErrnoError(8)
                }
                FS.chmod(stream.node, mode)
            },
            chown: (path, uid, gid, dontFollow) => {
                var node;
                if (typeof path == "string") {
                    var lookup = FS.lookupPath(path, {
                        follow: !dontFollow
                    });
                    node = lookup.node
                } else {
                    node = path
                }
                if (!node.node_ops.setattr) {
                    throw new FS.ErrnoError(63)
                }
                node.node_ops.setattr(node, {
                    timestamp: Date.now()
                })
            },
            lchown: (path, uid, gid) => {
                FS.chown(path, uid, gid, true)
            },
            fchown: (fd, uid, gid) => {
                var stream = FS.getStream(fd);
                if (!stream) {
                    throw new FS.ErrnoError(8)
                }
                FS.chown(stream.node, uid, gid)
            },
            truncate: (path, len) => {
                if (len < 0) {
                    throw new FS.ErrnoError(28)
                }
                var node;
                if (typeof path == "string") {
                    var lookup = FS.lookupPath(path, {
                        follow: true
                    });
                    node = lookup.node
                } else {
                    node = path
                }
                if (!node.node_ops.setattr) {
                    throw new FS.ErrnoError(63)
                }
                if (FS.isDir(node.mode)) {
                    throw new FS.ErrnoError(31)
                }
                if (!FS.isFile(node.mode)) {
                    throw new FS.ErrnoError(28)
                }
                var errCode = FS.nodePermissions(node, "w");
                if (errCode) {
                    throw new FS.ErrnoError(errCode)
                }
                node.node_ops.setattr(node, {
                    size: len,
                    timestamp: Date.now()
                })
            },
            ftruncate: (fd, len) => {
                var stream = FS.getStream(fd);
                if (!stream) {
                    throw new FS.ErrnoError(8)
                }
                if ((stream.flags & 2097155) === 0) {
                    throw new FS.ErrnoError(28)
                }
                FS.truncate(stream.node, len)
            },
            utime: (path, atime, mtime) => {
                var lookup = FS.lookupPath(path, {
                    follow: true
                });
                var node = lookup.node;
                node.node_ops.setattr(node, {
                    timestamp: Math.max(atime, mtime)
                })
            },
            open: (path, flags, mode) => {
                if (path === "") {
                    throw new FS.ErrnoError(44)
                }
                flags = typeof flags == "string" ? FS.modeStringToFlags(flags) : flags;
                mode = typeof mode == "undefined" ? 438 : mode;
                if (flags & 64) {
                    mode = mode & 4095 | 32768
                } else {
                    mode = 0
                }
                var node;
                if (typeof path == "object") {
                    node = path
                } else {
                    path = PATH.normalize(path);
                    try {
                        var lookup = FS.lookupPath(path, {
                            follow: !(flags & 131072)
                        });
                        node = lookup.node
                    } catch (e) {}
                }
                var created = false;
                if (flags & 64) {
                    if (node) {
                        if (flags & 128) {
                            throw new FS.ErrnoError(20)
                        }
                    } else {
                        node = FS.mknod(path, mode, 0);
                        created = true
                    }
                }
                if (!node) {
                    throw new FS.ErrnoError(44)
                }
                if (FS.isChrdev(node.mode)) {
                    flags &= ~512
                }
                if (flags & 65536 && !FS.isDir(node.mode)) {
                    throw new FS.ErrnoError(54)
                }
                if (!created) {
                    var errCode = FS.mayOpen(node, flags);
                    if (errCode) {
                        throw new FS.ErrnoError(errCode)
                    }
                }
                if (flags & 512 && !created) {
                    FS.truncate(node, 0)
                }
                flags &= ~(128 | 512 | 131072);
                var stream = FS.createStream({
                    node: node,
                    path: FS.getPath(node),
                    flags: flags,
                    seekable: true,
                    position: 0,
                    stream_ops: node.stream_ops,
                    ungotten: [],
                    error: false
                });
                if (stream.stream_ops.open) {
                    stream.stream_ops.open(stream)
                }
                if (Module["logReadFiles"] && !(flags & 1)) {
                    if (!FS.readFiles) FS.readFiles = {};
                    if (!(path in FS.readFiles)) {
                        FS.readFiles[path] = 1
                    }
                }
                return stream
            },
            close: stream => {
                if (FS.isClosed(stream)) {
                    throw new FS.ErrnoError(8)
                }
                if (stream.getdents) stream.getdents = null;
                try {
                    if (stream.stream_ops.close) {
                        stream.stream_ops.close(stream)
                    }
                } catch (e) {
                    throw e
                } finally {
                    FS.closeStream(stream.fd)
                }
                stream.fd = null
            },
            isClosed: stream => {
                return stream.fd === null
            },
            llseek: (stream, offset, whence) => {
                if (FS.isClosed(stream)) {
                    throw new FS.ErrnoError(8)
                }
                if (!stream.seekable || !stream.stream_ops.llseek) {
                    throw new FS.ErrnoError(70)
                }
                if (whence != 0 && whence != 1 && whence != 2) {
                    throw new FS.ErrnoError(28)
                }
                stream.position = stream.stream_ops.llseek(stream, offset, whence);
                stream.ungotten = [];
                return stream.position
            },
            read: (stream, buffer, offset, length, position) => {
                if (length < 0 || position < 0) {
                    throw new FS.ErrnoError(28)
                }
                if (FS.isClosed(stream)) {
                    throw new FS.ErrnoError(8)
                }
                if ((stream.flags & 2097155) === 1) {
                    throw new FS.ErrnoError(8)
                }
                if (FS.isDir(stream.node.mode)) {
                    throw new FS.ErrnoError(31)
                }
                if (!stream.stream_ops.read) {
                    throw new FS.ErrnoError(28)
                }
                var seeking = typeof position != "undefined";
                if (!seeking) {
                    position = stream.position
                } else if (!stream.seekable) {
                    throw new FS.ErrnoError(70)
                }
                var bytesRead = stream.stream_ops.read(stream, buffer, offset, length, position);
                if (!seeking) stream.position += bytesRead;
                return bytesRead
            },
            write: (stream, buffer, offset, length, position, canOwn) => {
                if (length < 0 || position < 0) {
                    throw new FS.ErrnoError(28)
                }
                if (FS.isClosed(stream)) {
                    throw new FS.ErrnoError(8)
                }
                if ((stream.flags & 2097155) === 0) {
                    throw new FS.ErrnoError(8)
                }
                if (FS.isDir(stream.node.mode)) {
                    throw new FS.ErrnoError(31)
                }
                if (!stream.stream_ops.write) {
                    throw new FS.ErrnoError(28)
                }
                if (stream.seekable && stream.flags & 1024) {
                    FS.llseek(stream, 0, 2)
                }
                var seeking = typeof position != "undefined";
                if (!seeking) {
                    position = stream.position
                } else if (!stream.seekable) {
                    throw new FS.ErrnoError(70)
                }
                var bytesWritten = stream.stream_ops.write(stream, buffer, offset, length, position, canOwn);
                if (!seeking) stream.position += bytesWritten;
                return bytesWritten
            },
            allocate: (stream, offset, length) => {
                if (FS.isClosed(stream)) {
                    throw new FS.ErrnoError(8)
                }
                if (offset < 0 || length <= 0) {
                    throw new FS.ErrnoError(28)
                }
                if ((stream.flags & 2097155) === 0) {
                    throw new FS.ErrnoError(8)
                }
                if (!FS.isFile(stream.node.mode) && !FS.isDir(stream.node.mode)) {
                    throw new FS.ErrnoError(43)
                }
                if (!stream.stream_ops.allocate) {
                    throw new FS.ErrnoError(138)
                }
                stream.stream_ops.allocate(stream, offset, length)
            },
            mmap: (stream, length, position, prot, flags) => {
                if ((prot & 2) !== 0 && (flags & 2) === 0 && (stream.flags & 2097155) !== 2) {
                    throw new FS.ErrnoError(2)
                }
                if ((stream.flags & 2097155) === 1) {
                    throw new FS.ErrnoError(2)
                }
                if (!stream.stream_ops.mmap) {
                    throw new FS.ErrnoError(43)
                }
                return stream.stream_ops.mmap(stream, length, position, prot, flags)
            },
            msync: (stream, buffer, offset, length, mmapFlags) => {
                if (!stream.stream_ops.msync) {
                    return 0
                }
                return stream.stream_ops.msync(stream, buffer, offset, length, mmapFlags)
            },
            munmap: stream => 0,
            ioctl: (stream, cmd, arg) => {
                if (!stream.stream_ops.ioctl) {
                    throw new FS.ErrnoError(59)
                }
                return stream.stream_ops.ioctl(stream, cmd, arg)
            },
            readFile: (path, opts = {}) => {
                opts.flags = opts.flags || 0;
                opts.encoding = opts.encoding || "binary";
                if (opts.encoding !== "utf8" && opts.encoding !== "binary") {
                    throw new Error('Invalid encoding type "' + opts.encoding + '"')
                }
                var ret;
                var stream = FS.open(path, opts.flags);
                var stat = FS.stat(path);
                var length = stat.size;
                var buf = new Uint8Array(length);
                FS.read(stream, buf, 0, length, 0);
                if (opts.encoding === "utf8") {
                    ret = UTF8ArrayToString(buf, 0)
                } else if (opts.encoding === "binary") {
                    ret = buf
                }
                FS.close(stream);
                return ret
            },
            writeFile: (path, data, opts = {}) => {
                opts.flags = opts.flags || 577;
                var stream = FS.open(path, opts.flags, opts.mode);
                if (typeof data == "string") {
                    var buf = new Uint8Array(lengthBytesUTF8(data) + 1);
                    var actualNumBytes = stringToUTF8Array(data, buf, 0, buf.length);
                    FS.write(stream, buf, 0, actualNumBytes, undefined, opts.canOwn)
                } else if (ArrayBuffer.isView(data)) {
                    FS.write(stream, data, 0, data.byteLength, undefined, opts.canOwn)
                } else {
                    throw new Error("Unsupported data type")
                }
                FS.close(stream)
            },
            cwd: () => FS.currentPath,
            chdir: path => {
                var lookup = FS.lookupPath(path, {
                    follow: true
                });
                if (lookup.node === null) {
                    throw new FS.ErrnoError(44)
                }
                if (!FS.isDir(lookup.node.mode)) {
                    throw new FS.ErrnoError(54)
                }
                var errCode = FS.nodePermissions(lookup.node, "x");
                if (errCode) {
                    throw new FS.ErrnoError(errCode)
                }
                FS.currentPath = lookup.path
            },
            createDefaultDirectories: () => {
                FS.mkdir("/tmp");
                FS.mkdir("/home");
                FS.mkdir("/home/web_user")
            },
            createDefaultDevices: () => {
                FS.mkdir("/dev");
                FS.registerDevice(FS.makedev(1, 3), {
                    read: () => 0,
                    write: (stream, buffer, offset, length, pos) => length
                });
                FS.mkdev("/dev/null", FS.makedev(1, 3));
                TTY.register(FS.makedev(5, 0), TTY.default_tty_ops);
                TTY.register(FS.makedev(6, 0), TTY.default_tty1_ops);
                FS.mkdev("/dev/tty", FS.makedev(5, 0));
                FS.mkdev("/dev/tty1", FS.makedev(6, 0));
                var random_device = getRandomDevice();
                FS.createDevice("/dev", "random", random_device);
                FS.createDevice("/dev", "urandom", random_device);
                FS.mkdir("/dev/shm");
                FS.mkdir("/dev/shm/tmp")
            },
            createSpecialDirectories: () => {
                FS.mkdir("/proc");
                var proc_self = FS.mkdir("/proc/self");
                FS.mkdir("/proc/self/fd");
                FS.mount({
                    mount: () => {
                        var node = FS.createNode(proc_self, "fd", 16384 | 511, 73);
                        node.node_ops = {
                            lookup: (parent, name) => {
                                var fd = +name;
                                var stream = FS.getStream(fd);
                                if (!stream) throw new FS.ErrnoError(8);
                                var ret = {
                                    parent: null,
                                    mount: {
                                        mountpoint: "fake"
                                    },
                                    node_ops: {
                                        readlink: () => stream.path
                                    }
                                };
                                ret.parent = ret;
                                return ret
                            }
                        };
                        return node
                    }
                }, {}, "/proc/self/fd")
            },
            createStandardStreams: () => {
                if (Module["stdin"]) {
                    FS.createDevice("/dev", "stdin", Module["stdin"])
                } else {
                    FS.symlink("/dev/tty", "/dev/stdin")
                }
                if (Module["stdout"]) {
                    FS.createDevice("/dev", "stdout", null, Module["stdout"])
                } else {
                    FS.symlink("/dev/tty", "/dev/stdout")
                }
                if (Module["stderr"]) {
                    FS.createDevice("/dev", "stderr", null, Module["stderr"])
                } else {
                    FS.symlink("/dev/tty1", "/dev/stderr")
                }
                var stdin = FS.open("/dev/stdin", 0);
                var stdout = FS.open("/dev/stdout", 1);
                var stderr = FS.open("/dev/stderr", 1)
            },
            ensureErrnoError: () => {
                if (FS.ErrnoError) return;
                FS.ErrnoError = function ErrnoError(errno, node) {
                    this.name = "ErrnoError";
                    this.node = node;
                    this.setErrno = function (errno) {
                        this.errno = errno
                    };
                    this.setErrno(errno);
                    this.message = "FS error"
                };
                FS.ErrnoError.prototype = new Error;
                FS.ErrnoError.prototype.constructor = FS.ErrnoError;
                [44].forEach(code => {
                    FS.genericErrors[code] = new FS.ErrnoError(code);
                    FS.genericErrors[code].stack = "<generic error, no stack>"
                })
            },
            staticInit: () => {
                FS.ensureErrnoError();
                FS.nameTable = new Array(4096);
                FS.mount(MEMFS, {}, "/");
                FS.createDefaultDirectories();
                FS.createDefaultDevices();
                FS.createSpecialDirectories();
                FS.filesystems = {
                    "MEMFS": MEMFS
                }
            },
            init: (input, output, error) => {
                FS.init.initialized = true;
                FS.ensureErrnoError();
                Module["stdin"] = input || Module["stdin"];
                Module["stdout"] = output || Module["stdout"];
                Module["stderr"] = error || Module["stderr"];
                FS.createStandardStreams()
            },
            quit: () => {
                FS.init.initialized = false;
                for (var i = 0; i < FS.streams.length; i++) {
                    var stream = FS.streams[i];
                    if (!stream) {
                        continue
                    }
                    FS.close(stream)
                }
            },
            getMode: (canRead, canWrite) => {
                var mode = 0;
                if (canRead) mode |= 292 | 73;
                if (canWrite) mode |= 146;
                return mode
            },
            findObject: (path, dontResolveLastLink) => {
                var ret = FS.analyzePath(path, dontResolveLastLink);
                if (!ret.exists) {
                    return null
                }
                return ret.object
            },
            analyzePath: (path, dontResolveLastLink) => {
                try {
                    var lookup = FS.lookupPath(path, {
                        follow: !dontResolveLastLink
                    });
                    path = lookup.path
                } catch (e) {}
                var ret = {
                    isRoot: false,
                    exists: false,
                    error: 0,
                    name: null,
                    path: null,
                    object: null,
                    parentExists: false,
                    parentPath: null,
                    parentObject: null
                };
                try {
                    var lookup = FS.lookupPath(path, {
                        parent: true
                    });
                    ret.parentExists = true;
                    ret.parentPath = lookup.path;
                    ret.parentObject = lookup.node;
                    ret.name = PATH.basename(path);
                    lookup = FS.lookupPath(path, {
                        follow: !dontResolveLastLink
                    });
                    ret.exists = true;
                    ret.path = lookup.path;
                    ret.object = lookup.node;
                    ret.name = lookup.node.name;
                    ret.isRoot = lookup.path === "/"
                } catch (e) {
                    ret.error = e.errno
                }
                return ret
            },
            createPath: (parent, path, canRead, canWrite) => {
                parent = typeof parent == "string" ? parent : FS.getPath(parent);
                var parts = path.split("/").reverse();
                while (parts.length) {
                    var part = parts.pop();
                    if (!part) continue;
                    var current = PATH.join2(parent, part);
                    try {
                        FS.mkdir(current)
                    } catch (e) {}
                    parent = current
                }
                return current
            },
            createFile: (parent, name, properties, canRead, canWrite) => {
                var path = PATH.join2(typeof parent == "string" ? parent : FS.getPath(parent), name);
                var mode = FS.getMode(canRead, canWrite);
                return FS.create(path, mode)
            },
            createDataFile: (parent, name, data, canRead, canWrite, canOwn) => {
                var path = name;
                if (parent) {
                    parent = typeof parent == "string" ? parent : FS.getPath(parent);
                    path = name ? PATH.join2(parent, name) : parent
                }
                var mode = FS.getMode(canRead, canWrite);
                var node = FS.create(path, mode);
                if (data) {
                    if (typeof data == "string") {
                        var arr = new Array(data.length);
                        for (var i = 0, len = data.length; i < len; ++i) arr[i] = data.charCodeAt(i);
                        data = arr
                    }
                    FS.chmod(node, mode | 146);
                    var stream = FS.open(node, 577);
                    FS.write(stream, data, 0, data.length, 0, canOwn);
                    FS.close(stream);
                    FS.chmod(node, mode)
                }
                return node
            },
            createDevice: (parent, name, input, output) => {
                var path = PATH.join2(typeof parent == "string" ? parent : FS.getPath(parent), name);
                var mode = FS.getMode(!!input, !!output);
                if (!FS.createDevice.major) FS.createDevice.major = 64;
                var dev = FS.makedev(FS.createDevice.major++, 0);
                FS.registerDevice(dev, {
                    open: stream => {
                        stream.seekable = false
                    },
                    close: stream => {
                        if (output && output.buffer && output.buffer.length) {
                            output(10)
                        }
                    },
                    read: (stream, buffer, offset, length, pos) => {
                        var bytesRead = 0;
                        for (var i = 0; i < length; i++) {
                            var result;
                            try {
                                result = input()
                            } catch (e) {
                                throw new FS.ErrnoError(29)
                            }
                            if (result === undefined && bytesRead === 0) {
                                throw new FS.ErrnoError(6)
                            }
                            if (result === null || result === undefined) break;
                            bytesRead++;
                            buffer[offset + i] = result
                        }
                        if (bytesRead) {
                            stream.node.timestamp = Date.now()
                        }
                        return bytesRead
                    },
                    write: (stream, buffer, offset, length, pos) => {
                        for (var i = 0; i < length; i++) {
                            try {
                                output(buffer[offset + i])
                            } catch (e) {
                                throw new FS.ErrnoError(29)
                            }
                        }
                        if (length) {
                            stream.node.timestamp = Date.now()
                        }
                        return i
                    }
                });
                return FS.mkdev(path, mode, dev)
            },
            forceLoadFile: obj => {
                if (obj.isDevice || obj.isFolder || obj.link || obj.contents) return true;
                if (typeof XMLHttpRequest != "undefined") {
                    throw new Error("Lazy loading should have been performed (contents set) in createLazyFile, but it was not. Lazy loading only works in web workers. Use --embed-file or --preload-file in emcc on the main thread.")
                } else if (read_) {
                    try {
                        obj.contents = intArrayFromString(read_(obj.url), true);
                        obj.usedBytes = obj.contents.length
                    } catch (e) {
                        throw new FS.ErrnoError(29)
                    }
                } else {
                    throw new Error("Cannot load without read() or XMLHttpRequest.")
                }
            },
            createLazyFile: (parent, name, url, canRead, canWrite) => {
                function LazyUint8Array() {
                    this.lengthKnown = false;
                    this.chunks = []
                }
                LazyUint8Array.prototype.get = function LazyUint8Array_get(idx) {
                    if (idx > this.length - 1 || idx < 0) {
                        return undefined
                    }
                    var chunkOffset = idx % this.chunkSize;
                    var chunkNum = idx / this.chunkSize | 0;
                    return this.getter(chunkNum)[chunkOffset]
                };
                LazyUint8Array.prototype.setDataGetter = function LazyUint8Array_setDataGetter(getter) {
                    this.getter = getter
                };
                LazyUint8Array.prototype.cacheLength = function LazyUint8Array_cacheLength() {
                    var xhr = new XMLHttpRequest;
                    xhr.open("HEAD", url, false);
                    xhr.send(null);
                    if (!(xhr.status >= 200 && xhr.status < 300 || xhr.status === 304)) throw new Error("Couldn't load " + url + ". Status: " + xhr.status);
                    var datalength = Number(xhr.getResponseHeader("Content-length"));
                    var header;
                    var hasByteServing = (header = xhr.getResponseHeader("Accept-Ranges")) && header === "bytes";
                    var usesGzip = (header = xhr.getResponseHeader("Content-Encoding")) && header === "gzip";
                    var chunkSize = 1024 * 1024;
                    if (!hasByteServing) chunkSize = datalength;
                    var doXHR = (from, to) => {
                        if (from > to) throw new Error("invalid range (" + from + ", " + to + ") or no bytes requested!");
                        if (to > datalength - 1) throw new Error("only " + datalength + " bytes available! programmer error!");
                        var xhr = new XMLHttpRequest;
                        xhr.open("GET", url, false);
                        if (datalength !== chunkSize) xhr.setRequestHeader("Range", "bytes=" + from + "-" + to);
                        xhr.responseType = "arraybuffer";
                        if (xhr.overrideMimeType) {
                            xhr.overrideMimeType("text/plain; charset=x-user-defined")
                        }
                        xhr.send(null);
                        if (!(xhr.status >= 200 && xhr.status < 300 || xhr.status === 304)) throw new Error("Couldn't load " + url + ". Status: " + xhr.status);
                        if (xhr.response !== undefined) {
                            return new Uint8Array(xhr.response || [])
                        }
                        return intArrayFromString(xhr.responseText || "", true)
                    };
                    var lazyArray = this;
                    lazyArray.setDataGetter(chunkNum => {
                        var start = chunkNum * chunkSize;
                        var end = (chunkNum + 1) * chunkSize - 1;
                        end = Math.min(end, datalength - 1);
                        if (typeof lazyArray.chunks[chunkNum] == "undefined") {
                            lazyArray.chunks[chunkNum] = doXHR(start, end)
                        }
                        if (typeof lazyArray.chunks[chunkNum] == "undefined") throw new Error("doXHR failed!");
                        return lazyArray.chunks[chunkNum]
                    });
                    if (usesGzip || !datalength) {
                        chunkSize = datalength = 1;
                        datalength = this.getter(0).length;
                        chunkSize = datalength;
                        out("LazyFiles on gzip forces download of the whole file when length is accessed")
                    }
                    this._length = datalength;
                    this._chunkSize = chunkSize;
                    this.lengthKnown = true
                };
                if (typeof XMLHttpRequest != "undefined") {
                    if (!ENVIRONMENT_IS_WORKER) throw "Cannot do synchronous binary XHRs outside webworkers in modern browsers. Use --embed-file or --preload-file in emcc";
                    var lazyArray = new LazyUint8Array;
                    Object.defineProperties(lazyArray, {
                        length: {
                            get: function () {
                                if (!this.lengthKnown) {
                                    this.cacheLength()
                                }
                                return this._length
                            }
                        },
                        chunkSize: {
                            get: function () {
                                if (!this.lengthKnown) {
                                    this.cacheLength()
                                }
                                return this._chunkSize
                            }
                        }
                    });
                    var properties = {
                        isDevice: false,
                        contents: lazyArray
                    }
                } else {
                    var properties = {
                        isDevice: false,
                        url: url
                    }
                }
                var node = FS.createFile(parent, name, properties, canRead, canWrite);
                if (properties.contents) {
                    node.contents = properties.contents
                } else if (properties.url) {
                    node.contents = null;
                    node.url = properties.url
                }
                Object.defineProperties(node, {
                    usedBytes: {
                        get: function () {
                            return this.contents.length
                        }
                    }
                });
                var stream_ops = {};
                var keys = Object.keys(node.stream_ops);
                keys.forEach(key => {
                    var fn = node.stream_ops[key];
                    stream_ops[key] = function forceLoadLazyFile() {
                        FS.forceLoadFile(node);
                        return fn.apply(null, arguments)
                    }
                });

                function writeChunks(stream, buffer, offset, length, position) {
                    var contents = stream.node.contents;
                    if (position >= contents.length) return 0;
                    var size = Math.min(contents.length - position, length);
                    if (contents.slice) {
                        for (var i = 0; i < size; i++) {
                            buffer[offset + i] = contents[position + i]
                        }
                    } else {
                        for (var i = 0; i < size; i++) {
                            buffer[offset + i] = contents.get(position + i)
                        }
                    }
                    return size
                }
                stream_ops.read = (stream, buffer, offset, length, position) => {
                    FS.forceLoadFile(node);
                    return writeChunks(stream, buffer, offset, length, position)
                };
                stream_ops.mmap = (stream, length, position, prot, flags) => {
                    FS.forceLoadFile(node);
                    var ptr = mmapAlloc(length);
                    if (!ptr) {
                        throw new FS.ErrnoError(48)
                    }
                    writeChunks(stream, HEAP8, ptr, length, position);
                    return {
                        ptr: ptr,
                        allocated: true
                    }
                };
                node.stream_ops = stream_ops;
                return node
            },
            createPreloadedFile: (parent, name, url, canRead, canWrite, onload, onerror, dontCreateFile, canOwn, preFinish) => {
                var fullname = name ? PATH_FS.resolve(PATH.join2(parent, name)) : parent;
                var dep = getUniqueRunDependency("cp " + fullname);

                function processData(byteArray) {
                    function finish(byteArray) {
                        if (preFinish) preFinish();
                        if (!dontCreateFile) {
                            FS.createDataFile(parent, name, byteArray, canRead, canWrite, canOwn)
                        }
                        if (onload) onload();
                        removeRunDependency(dep)
                    }
                    if (Browser.handledByPreloadPlugin(byteArray, fullname, finish, () => {
                            if (onerror) onerror();
                            removeRunDependency(dep)
                        })) {
                        return
                    }
                    finish(byteArray)
                }
                addRunDependency(dep);
                if (typeof url == "string") {
                    asyncLoad(url, byteArray => processData(byteArray), onerror)
                } else {
                    processData(url)
                }
            },
            indexedDB: () => {
                return window.indexedDB || window.mozIndexedDB || window.webkitIndexedDB || window.msIndexedDB
            },
            DB_NAME: () => {
                return "EM_FS_" + window.location.pathname
            },
            DB_VERSION: 20,
            DB_STORE_NAME: "FILE_DATA",
            saveFilesToDB: (paths, onload = (() => {}), onerror = (() => {})) => {
                var indexedDB = FS.indexedDB();
                try {
                    var openRequest = indexedDB.open(FS.DB_NAME(), FS.DB_VERSION)
                } catch (e) {
                    return onerror(e)
                }
                openRequest.onupgradeneeded = () => {
                    out("creating db");
                    var db = openRequest.result;
                    db.createObjectStore(FS.DB_STORE_NAME)
                };
                openRequest.onsuccess = () => {
                    var db = openRequest.result;
                    var transaction = db.transaction([FS.DB_STORE_NAME], "readwrite");
                    var files = transaction.objectStore(FS.DB_STORE_NAME);
                    var ok = 0,
                        fail = 0,
                        total = paths.length;

                    function finish() {
                        if (fail == 0) onload();
                        else onerror()
                    }
                    paths.forEach(path => {
                        var putRequest = files.put(FS.analyzePath(path).object.contents, path);
                        putRequest.onsuccess = () => {
                            ok++;
                            if (ok + fail == total) finish()
                        };
                        putRequest.onerror = () => {
                            fail++;
                            if (ok + fail == total) finish()
                        }
                    });
                    transaction.onerror = onerror
                };
                openRequest.onerror = onerror
            },
            loadFilesFromDB: (paths, onload = (() => {}), onerror = (() => {})) => {
                var indexedDB = FS.indexedDB();
                try {
                    var openRequest = indexedDB.open(FS.DB_NAME(), FS.DB_VERSION)
                } catch (e) {
                    return onerror(e)
                }
                openRequest.onupgradeneeded = onerror;
                openRequest.onsuccess = () => {
                    var db = openRequest.result;
                    try {
                        var transaction = db.transaction([FS.DB_STORE_NAME], "readonly")
                    } catch (e) {
                        onerror(e);
                        return
                    }
                    var files = transaction.objectStore(FS.DB_STORE_NAME);
                    var ok = 0,
                        fail = 0,
                        total = paths.length;

                    function finish() {
                        if (fail == 0) onload();
                        else onerror()
                    }
                    paths.forEach(path => {
                        var getRequest = files.get(path);
                        getRequest.onsuccess = () => {
                            if (FS.analyzePath(path).exists) {
                                FS.unlink(path)
                            }
                            FS.createDataFile(PATH.dirname(path), PATH.basename(path), getRequest.result, true, true, true);
                            ok++;
                            if (ok + fail == total) finish()
                        };
                        getRequest.onerror = () => {
                            fail++;
                            if (ok + fail == total) finish()
                        }
                    });
                    transaction.onerror = onerror
                };
                openRequest.onerror = onerror
            }
        };
        var SYSCALLS = {
            DEFAULT_POLLMASK: 5,
            calculateAt: function (dirfd, path, allowEmpty) {
                if (PATH.isAbs(path)) {
                    return path
                }
                var dir;
                if (dirfd === -100) {
                    dir = FS.cwd()
                } else {
                    var dirstream = SYSCALLS.getStreamFromFD(dirfd);
                    dir = dirstream.path
                }
                if (path.length == 0) {
                    if (!allowEmpty) {
                        throw new FS.ErrnoError(44)
                    }
                    return dir
                }
                return PATH.join2(dir, path)
            },
            doStat: function (func, path, buf) {
                try {
                    var stat = func(path)
                } catch (e) {
                    if (e && e.node && PATH.normalize(path) !== PATH.normalize(FS.getPath(e.node))) {
                        return -54
                    }
                    throw e
                }
                HEAP32[buf >> 2] = stat.dev;
                HEAP32[buf + 8 >> 2] = stat.ino;
                HEAP32[buf + 12 >> 2] = stat.mode;
                HEAPU32[buf + 16 >> 2] = stat.nlink;
                HEAP32[buf + 20 >> 2] = stat.uid;
                HEAP32[buf + 24 >> 2] = stat.gid;
                HEAP32[buf + 28 >> 2] = stat.rdev;
                tempI64 = [stat.size >>> 0, (tempDouble = stat.size, +Math.abs(tempDouble) >= 1 ? tempDouble > 0 ? (Math.min(+Math.floor(tempDouble / 4294967296), 4294967295) | 0) >>> 0 : ~~+Math.ceil((tempDouble - +(~~tempDouble >>> 0)) / 4294967296) >>> 0 : 0)], HEAP32[buf + 40 >> 2] = tempI64[0], HEAP32[buf + 44 >> 2] = tempI64[1];
                HEAP32[buf + 48 >> 2] = 4096;
                HEAP32[buf + 52 >> 2] = stat.blocks;
                var atime = stat.atime.getTime();
                var mtime = stat.mtime.getTime();
                var ctime = stat.ctime.getTime();
                tempI64 = [Math.floor(atime / 1e3) >>> 0, (tempDouble = Math.floor(atime / 1e3), +Math.abs(tempDouble) >= 1 ? tempDouble > 0 ? (Math.min(+Math.floor(tempDouble / 4294967296), 4294967295) | 0) >>> 0 : ~~+Math.ceil((tempDouble - +(~~tempDouble >>> 0)) / 4294967296) >>> 0 : 0)], HEAP32[buf + 56 >> 2] = tempI64[0], HEAP32[buf + 60 >> 2] = tempI64[1];
                HEAPU32[buf + 64 >> 2] = atime % 1e3 * 1e3;
                tempI64 = [Math.floor(mtime / 1e3) >>> 0, (tempDouble = Math.floor(mtime / 1e3), +Math.abs(tempDouble) >= 1 ? tempDouble > 0 ? (Math.min(+Math.floor(tempDouble / 4294967296), 4294967295) | 0) >>> 0 : ~~+Math.ceil((tempDouble - +(~~tempDouble >>> 0)) / 4294967296) >>> 0 : 0)], HEAP32[buf + 72 >> 2] = tempI64[0], HEAP32[buf + 76 >> 2] = tempI64[1];
                HEAPU32[buf + 80 >> 2] = mtime % 1e3 * 1e3;
                tempI64 = [Math.floor(ctime / 1e3) >>> 0, (tempDouble = Math.floor(ctime / 1e3), +Math.abs(tempDouble) >= 1 ? tempDouble > 0 ? (Math.min(+Math.floor(tempDouble / 4294967296), 4294967295) | 0) >>> 0 : ~~+Math.ceil((tempDouble - +(~~tempDouble >>> 0)) / 4294967296) >>> 0 : 0)], HEAP32[buf + 88 >> 2] = tempI64[0], HEAP32[buf + 92 >> 2] = tempI64[1];
                HEAPU32[buf + 96 >> 2] = ctime % 1e3 * 1e3;
                tempI64 = [stat.ino >>> 0, (tempDouble = stat.ino, +Math.abs(tempDouble) >= 1 ? tempDouble > 0 ? (Math.min(+Math.floor(tempDouble / 4294967296), 4294967295) | 0) >>> 0 : ~~+Math.ceil((tempDouble - +(~~tempDouble >>> 0)) / 4294967296) >>> 0 : 0)], HEAP32[buf + 104 >> 2] = tempI64[0], HEAP32[buf + 108 >> 2] = tempI64[1];
                return 0
            },
            doMsync: function (addr, stream, len, flags, offset) {
                if (!FS.isFile(stream.node.mode)) {
                    throw new FS.ErrnoError(43)
                }
                if (flags & 2) {
                    return 0
                }
                var buffer = HEAPU8.slice(addr, addr + len);
                FS.msync(stream, buffer, offset, len, flags)
            },
            varargs: undefined,
            get: function () {
                SYSCALLS.varargs += 4;
                var ret = HEAP32[SYSCALLS.varargs - 4 >> 2];
                return ret
            },
            getStr: function (ptr) {
                var ret = UTF8ToString(ptr);
                return ret
            },
            getStreamFromFD: function (fd) {
                var stream = FS.getStream(fd);
                if (!stream) throw new FS.ErrnoError(8);
                return stream
            }
        };

        function ___syscall_fcntl64(fd, cmd, varargs) {
            SYSCALLS.varargs = varargs;
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                switch (cmd) {
                    case 0: {
                        var arg = SYSCALLS.get();
                        if (arg < 0) {
                            return -28
                        }
                        var newStream;
                        newStream = FS.createStream(stream, arg);
                        return newStream.fd
                    }
                    case 1:
                    case 2:
                        return 0;
                    case 3:
                        return stream.flags;
                    case 4: {
                        var arg = SYSCALLS.get();
                        stream.flags |= arg;
                        return 0
                    }
                    case 5: {
                        var arg = SYSCALLS.get();
                        var offset = 0;
                        HEAP16[arg + offset >> 1] = 2;
                        return 0
                    }
                    case 6:
                    case 7:
                        return 0;
                    case 16:
                    case 8:
                        return -28;
                    case 9:
                        setErrNo(28);
                        return -1;
                    default: {
                        return -28
                    }
                }
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_fstat64(fd, buf) {
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                return SYSCALLS.doStat(FS.stat, stream.path, buf)
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function convertI32PairToI53Checked(lo, hi) {
            return hi + 2097152 >>> 0 < 4194305 - !!lo ? (lo >>> 0) + hi * 4294967296 : NaN
        }

        function ___syscall_ftruncate64(fd, length_low, length_high) {
            try {
                var length = convertI32PairToI53Checked(length_low, length_high);
                if (isNaN(length)) return -61;
                FS.ftruncate(fd, length);
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_getdents64(fd, dirp, count) {
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                if (!stream.getdents) {
                    stream.getdents = FS.readdir(stream.path)
                }
                var struct_size = 280;
                var pos = 0;
                var off = FS.llseek(stream, 0, 1);
                var idx = Math.floor(off / struct_size);
                while (idx < stream.getdents.length && pos + struct_size <= count) {
                    var id;
                    var type;
                    var name = stream.getdents[idx];
                    if (name === ".") {
                        id = stream.node.id;
                        type = 4
                    } else if (name === "..") {
                        var lookup = FS.lookupPath(stream.path, {
                            parent: true
                        });
                        id = lookup.node.id;
                        type = 4
                    } else {
                        var child = FS.lookupNode(stream.node, name);
                        id = child.id;
                        type = FS.isChrdev(child.mode) ? 2 : FS.isDir(child.mode) ? 4 : FS.isLink(child.mode) ? 10 : 8
                    }
                    tempI64 = [id >>> 0, (tempDouble = id, +Math.abs(tempDouble) >= 1 ? tempDouble > 0 ? (Math.min(+Math.floor(tempDouble / 4294967296), 4294967295) | 0) >>> 0 : ~~+Math.ceil((tempDouble - +(~~tempDouble >>> 0)) / 4294967296) >>> 0 : 0)], HEAP32[dirp + pos >> 2] = tempI64[0], HEAP32[dirp + pos + 4 >> 2] = tempI64[1];
                    tempI64 = [(idx + 1) * struct_size >>> 0, (tempDouble = (idx + 1) * struct_size, +Math.abs(tempDouble) >= 1 ? tempDouble > 0 ? (Math.min(+Math.floor(tempDouble / 4294967296), 4294967295) | 0) >>> 0 : ~~+Math.ceil((tempDouble - +(~~tempDouble >>> 0)) / 4294967296) >>> 0 : 0)], HEAP32[dirp + pos + 8 >> 2] = tempI64[0], HEAP32[dirp + pos + 12 >> 2] = tempI64[1];
                    HEAP16[dirp + pos + 16 >> 1] = 280;
                    HEAP8[dirp + pos + 18 >> 0] = type;
                    stringToUTF8(name, dirp + pos + 19, 256);
                    pos += struct_size;
                    idx += 1
                }
                FS.llseek(stream, idx * struct_size, 0);
                return pos
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_ioctl(fd, op, varargs) {
            SYSCALLS.varargs = varargs;
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                switch (op) {
                    case 21509:
                    case 21505: {
                        if (!stream.tty) return -59;
                        return 0
                    }
                    case 21510:
                    case 21511:
                    case 21512:
                    case 21506:
                    case 21507:
                    case 21508: {
                        if (!stream.tty) return -59;
                        return 0
                    }
                    case 21519: {
                        if (!stream.tty) return -59;
                        var argp = SYSCALLS.get();
                        HEAP32[argp >> 2] = 0;
                        return 0
                    }
                    case 21520: {
                        if (!stream.tty) return -59;
                        return -28
                    }
                    case 21531: {
                        var argp = SYSCALLS.get();
                        return FS.ioctl(stream, op, argp)
                    }
                    case 21523: {
                        if (!stream.tty) return -59;
                        return 0
                    }
                    case 21524: {
                        if (!stream.tty) return -59;
                        return 0
                    }
                    default:
                        return -28
                }
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_lstat64(path, buf) {
            try {
                path = SYSCALLS.getStr(path);
                return SYSCALLS.doStat(FS.lstat, path, buf)
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_newfstatat(dirfd, path, buf, flags) {
            try {
                path = SYSCALLS.getStr(path);
                var nofollow = flags & 256;
                var allowEmpty = flags & 4096;
                flags = flags & ~6400;
                path = SYSCALLS.calculateAt(dirfd, path, allowEmpty);
                return SYSCALLS.doStat(nofollow ? FS.lstat : FS.stat, path, buf)
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_openat(dirfd, path, flags, varargs) {
            SYSCALLS.varargs = varargs;
            try {
                path = SYSCALLS.getStr(path);
                path = SYSCALLS.calculateAt(dirfd, path);
                var mode = varargs ? SYSCALLS.get() : 0;
                return FS.open(path, flags, mode).fd
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_rmdir(path) {
            try {
                path = SYSCALLS.getStr(path);
                FS.rmdir(path);
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_stat64(path, buf) {
            try {
                path = SYSCALLS.getStr(path);
                return SYSCALLS.doStat(FS.stat, path, buf)
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_unlinkat(dirfd, path, flags) {
            try {
                path = SYSCALLS.getStr(path);
                path = SYSCALLS.calculateAt(dirfd, path);
                if (flags === 0) {
                    FS.unlink(path)
                } else if (flags === 512) {
                    FS.rmdir(path)
                } else {
                    abort("Invalid flags passed to unlinkat")
                }
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function __emscripten_throw_longjmp() {
            throw Infinity
        }

        function readI53FromI64(ptr) {
            return HEAPU32[ptr >> 2] + HEAP32[ptr + 4 >> 2] * 4294967296
        }

        function __gmtime_js(time, tmPtr) {
            var date = new Date(readI53FromI64(time) * 1e3);
            HEAP32[tmPtr >> 2] = date.getUTCSeconds();
            HEAP32[tmPtr + 4 >> 2] = date.getUTCMinutes();
            HEAP32[tmPtr + 8 >> 2] = date.getUTCHours();
            HEAP32[tmPtr + 12 >> 2] = date.getUTCDate();
            HEAP32[tmPtr + 16 >> 2] = date.getUTCMonth();
            HEAP32[tmPtr + 20 >> 2] = date.getUTCFullYear() - 1900;
            HEAP32[tmPtr + 24 >> 2] = date.getUTCDay();
            var start = Date.UTC(date.getUTCFullYear(), 0, 1, 0, 0, 0, 0);
            var yday = (date.getTime() - start) / (1e3 * 60 * 60 * 24) | 0;
            HEAP32[tmPtr + 28 >> 2] = yday
        }

        function __isLeapYear(year) {
            return year % 4 === 0 && (year % 100 !== 0 || year % 400 === 0)
        }
        var __MONTH_DAYS_LEAP_CUMULATIVE = [0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335];
        var __MONTH_DAYS_REGULAR_CUMULATIVE = [0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334];

        function __yday_from_date(date) {
            var isLeapYear = __isLeapYear(date.getFullYear());
            var monthDaysCumulative = isLeapYear ? __MONTH_DAYS_LEAP_CUMULATIVE : __MONTH_DAYS_REGULAR_CUMULATIVE;
            var yday = monthDaysCumulative[date.getMonth()] + date.getDate() - 1;
            return yday
        }

        function __localtime_js(time, tmPtr) {
            var date = new Date(readI53FromI64(time) * 1e3);
            HEAP32[tmPtr >> 2] = date.getSeconds();
            HEAP32[tmPtr + 4 >> 2] = date.getMinutes();
            HEAP32[tmPtr + 8 >> 2] = date.getHours();
            HEAP32[tmPtr + 12 >> 2] = date.getDate();
            HEAP32[tmPtr + 16 >> 2] = date.getMonth();
            HEAP32[tmPtr + 20 >> 2] = date.getFullYear() - 1900;
            HEAP32[tmPtr + 24 >> 2] = date.getDay();
            var yday = __yday_from_date(date) | 0;
            HEAP32[tmPtr + 28 >> 2] = yday;
            HEAP32[tmPtr + 36 >> 2] = -(date.getTimezoneOffset() * 60);
            var start = new Date(date.getFullYear(), 0, 1);
            var summerOffset = new Date(date.getFullYear(), 6, 1).getTimezoneOffset();
            var winterOffset = start.getTimezoneOffset();
            var dst = (summerOffset != winterOffset && date.getTimezoneOffset() == Math.min(winterOffset, summerOffset)) | 0;
            HEAP32[tmPtr + 32 >> 2] = dst
        }
        var timers = {};

        function handleException(e) {
            if (e instanceof ExitStatus || e == "unwind") {
                return EXITSTATUS
            }
            quit_(1, e)
        }

        function _proc_exit(code) {
            EXITSTATUS = code;
            if (!keepRuntimeAlive()) {
                if (Module["onExit"]) Module["onExit"](code);
                ABORT = true
            }
            quit_(code, new ExitStatus(code))
        }

        function exitJS(status, implicit) {
            EXITSTATUS = status;
            _proc_exit(status)
        }
        var _exit = exitJS;

        function maybeExit() {
            if (!keepRuntimeAlive()) {
                try {
                    _exit(EXITSTATUS)
                } catch (e) {
                    handleException(e)
                }
            }
        }

        function callUserCallback(func) {
            if (ABORT) {
                return
            }
            try {
                func();
                maybeExit()
            } catch (e) {
                handleException(e)
            }
        }
        var _emscripten_get_now;
        if (ENVIRONMENT_IS_NODE) {
            _emscripten_get_now = () => {
                var t = process.hrtime();
                return t[0] * 1e3 + t[1] / 1e6
            }
        } else _emscripten_get_now = () => performance.now();

        function __setitimer_js(which, timeout_ms) {
            if (timers[which]) {
                clearTimeout(timers[which].id);
                delete timers[which]
            }
            if (!timeout_ms) return 0;
            var id = setTimeout(() => {
                delete timers[which];
                callUserCallback(() => __emscripten_timeout(which, _emscripten_get_now()))
            }, timeout_ms);
            timers[which] = {
                id: id,
                timeout_ms: timeout_ms
            };
            return 0
        }

        function allocateUTF8(str) {
            var size = lengthBytesUTF8(str) + 1;
            var ret = _malloc(size);
            if (ret) stringToUTF8Array(str, HEAP8, ret, size);
            return ret
        }

        function __tzset_js(timezone, daylight, tzname) {
            var currentYear = (new Date).getFullYear();
            var winter = new Date(currentYear, 0, 1);
            var summer = new Date(currentYear, 6, 1);
            var winterOffset = winter.getTimezoneOffset();
            var summerOffset = summer.getTimezoneOffset();
            var stdTimezoneOffset = Math.max(winterOffset, summerOffset);
            HEAPU32[timezone >> 2] = stdTimezoneOffset * 60;
            HEAP32[daylight >> 2] = Number(winterOffset != summerOffset);

            function extractZone(date) {
                var match = date.toTimeString().match(/\(([A-Za-z ]+)\)$/);
                return match ? match[1] : "GMT"
            }
            var winterName = extractZone(winter);
            var summerName = extractZone(summer);
            var winterNamePtr = allocateUTF8(winterName);
            var summerNamePtr = allocateUTF8(summerName);
            if (summerOffset < winterOffset) {
                HEAPU32[tzname >> 2] = winterNamePtr;
                HEAPU32[tzname + 4 >> 2] = summerNamePtr
            } else {
                HEAPU32[tzname >> 2] = summerNamePtr;
                HEAPU32[tzname + 4 >> 2] = winterNamePtr
            }
        }

        function _abort() {
            abort("")
        }

        function _emscripten_date_now() {
            return Date.now()
        }

        function _emscripten_memcpy_big(dest, src, num) {
            HEAPU8.copyWithin(dest, src, src + num)
        }

        function getHeapMax() {
            return 2147483648
        }

        function emscripten_realloc_buffer(size) {
            var b = wasmMemory.buffer;
            try {
                wasmMemory.grow(size - b.byteLength + 65535 >>> 16);
                updateMemoryViews();
                return 1
            } catch (e) {}
        }

        function _emscripten_resize_heap(requestedSize) {
            var oldSize = HEAPU8.length;
            requestedSize = requestedSize >>> 0;
            var maxHeapSize = getHeapMax();
            if (requestedSize > maxHeapSize) {
                return false
            }
            let alignUp = (x, multiple) => x + (multiple - x % multiple) % multiple;
            for (var cutDown = 1; cutDown <= 4; cutDown *= 2) {
                var overGrownHeapSize = oldSize * (1 + .2 / cutDown);
                overGrownHeapSize = Math.min(overGrownHeapSize, requestedSize + 100663296);
                var newSize = Math.min(maxHeapSize, alignUp(Math.max(requestedSize, overGrownHeapSize), 65536));
                var replacement = emscripten_realloc_buffer(newSize);
                if (replacement) {
                    return true
                }
            }
            return false
        }
        var ENV = {};

        function getExecutableName() {
            return thisProgram || "./this.program"
        }

        function getEnvStrings() {
            if (!getEnvStrings.strings) {
                var lang = (typeof navigator == "object" && navigator.languages && navigator.languages[0] || "C").replace("-", "_") + ".UTF-8";
                var env = {
                    "USER": "web_user",
                    "LOGNAME": "web_user",
                    "PATH": "/",
                    "PWD": "/",
                    "HOME": "/home/web_user",
                    "LANG": lang,
                    "_": getExecutableName()
                };
                for (var x in ENV) {
                    if (ENV[x] === undefined) delete env[x];
                    else env[x] = ENV[x]
                }
                var strings = [];
                for (var x in env) {
                    strings.push(x + "=" + env[x])
                }
                getEnvStrings.strings = strings
            }
            return getEnvStrings.strings
        }

        function writeAsciiToMemory(str, buffer, dontAddNull) {
            for (var i = 0; i < str.length; ++i) {
                HEAP8[buffer++ >> 0] = str.charCodeAt(i)
            }
            if (!dontAddNull) HEAP8[buffer >> 0] = 0
        }

        function _environ_get(__environ, environ_buf) {
            var bufSize = 0;
            getEnvStrings().forEach(function (string, i) {
                var ptr = environ_buf + bufSize;
                HEAPU32[__environ + i * 4 >> 2] = ptr;
                writeAsciiToMemory(string, ptr);
                bufSize += string.length + 1
            });
            return 0
        }

        function _environ_sizes_get(penviron_count, penviron_buf_size) {
            var strings = getEnvStrings();
            HEAPU32[penviron_count >> 2] = strings.length;
            var bufSize = 0;
            strings.forEach(function (string) {
                bufSize += string.length + 1
            });
            HEAPU32[penviron_buf_size >> 2] = bufSize;
            return 0
        }

        function _fd_close(fd) {
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                FS.close(stream);
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return e.errno
            }
        }

        function doReadv(stream, iov, iovcnt, offset) {
            var ret = 0;
            for (var i = 0; i < iovcnt; i++) {
                var ptr = HEAPU32[iov >> 2];
                var len = HEAPU32[iov + 4 >> 2];
                iov += 8;
                var curr = FS.read(stream, HEAP8, ptr, len, offset);
                if (curr < 0) return -1;
                ret += curr;
                if (curr < len) break;
                if (typeof offset !== "undefined") {
                    offset += curr
                }
            }
            return ret
        }

        function _fd_read(fd, iov, iovcnt, pnum) {
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                var num = doReadv(stream, iov, iovcnt);
                HEAPU32[pnum >> 2] = num;
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return e.errno
            }
        }

        function _fd_seek(fd, offset_low, offset_high, whence, newOffset) {
            try {
                var offset = convertI32PairToI53Checked(offset_low, offset_high);
                if (isNaN(offset)) return 61;
                var stream = SYSCALLS.getStreamFromFD(fd);
                FS.llseek(stream, offset, whence);
                tempI64 = [stream.position >>> 0, (tempDouble = stream.position, +Math.abs(tempDouble) >= 1 ? tempDouble > 0 ? (Math.min(+Math.floor(tempDouble / 4294967296), 4294967295) | 0) >>> 0 : ~~+Math.ceil((tempDouble - +(~~tempDouble >>> 0)) / 4294967296) >>> 0 : 0)], HEAP32[newOffset >> 2] = tempI64[0], HEAP32[newOffset + 4 >> 2] = tempI64[1];
                if (stream.getdents && offset === 0 && whence === 0) stream.getdents = null;
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return e.errno
            }
        }

        function _fd_sync(fd) {
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                if (stream.stream_ops && stream.stream_ops.fsync) {
                    return stream.stream_ops.fsync(stream)
                }
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return e.errno
            }
        }

        function doWritev(stream, iov, iovcnt, offset) {
            var ret = 0;
            for (var i = 0; i < iovcnt; i++) {
                var ptr = HEAPU32[iov >> 2];
                var len = HEAPU32[iov + 4 >> 2];
                iov += 8;
                var curr = FS.write(stream, HEAP8, ptr, len, offset);
                if (curr < 0) return -1;
                ret += curr;
                if (typeof offset !== "undefined") {
                    offset += curr
                }
            }
            return ret
        }

        function _fd_write(fd, iov, iovcnt, pnum) {
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                var num = doWritev(stream, iov, iovcnt);
                HEAPU32[pnum >> 2] = num;
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return e.errno
            }
        }

        function __arraySum(array, index) {
            var sum = 0;
            for (var i = 0; i <= index; sum += array[i++]) {}
            return sum
        }
        var __MONTH_DAYS_LEAP = [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        var __MONTH_DAYS_REGULAR = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

        function __addDays(date, days) {
            var newDate = new Date(date.getTime());
            while (days > 0) {
                var leap = __isLeapYear(newDate.getFullYear());
                var currentMonth = newDate.getMonth();
                var daysInCurrentMonth = (leap ? __MONTH_DAYS_LEAP : __MONTH_DAYS_REGULAR)[currentMonth];
                if (days > daysInCurrentMonth - newDate.getDate()) {
                    days -= daysInCurrentMonth - newDate.getDate() + 1;
                    newDate.setDate(1);
                    if (currentMonth < 11) {
                        newDate.setMonth(currentMonth + 1)
                    } else {
                        newDate.setMonth(0);
                        newDate.setFullYear(newDate.getFullYear() + 1)
                    }
                } else {
                    newDate.setDate(newDate.getDate() + days);
                    return newDate
                }
            }
            return newDate
        }

        function writeArrayToMemory(array, buffer) {
            HEAP8.set(array, buffer)
        }

        function _strftime(s, maxsize, format, tm) {
            var tm_zone = HEAP32[tm + 40 >> 2];
            var date = {
                tm_sec: HEAP32[tm >> 2],
                tm_min: HEAP32[tm + 4 >> 2],
                tm_hour: HEAP32[tm + 8 >> 2],
                tm_mday: HEAP32[tm + 12 >> 2],
                tm_mon: HEAP32[tm + 16 >> 2],
                tm_year: HEAP32[tm + 20 >> 2],
                tm_wday: HEAP32[tm + 24 >> 2],
                tm_yday: HEAP32[tm + 28 >> 2],
                tm_isdst: HEAP32[tm + 32 >> 2],
                tm_gmtoff: HEAP32[tm + 36 >> 2],
                tm_zone: tm_zone ? UTF8ToString(tm_zone) : ""
            };
            var pattern = UTF8ToString(format);
            var EXPANSION_RULES_1 = {
                "%c": "%a %b %d %H:%M:%S %Y",
                "%D": "%m/%d/%y",
                "%F": "%Y-%m-%d",
                "%h": "%b",
                "%r": "%I:%M:%S %p",
                "%R": "%H:%M",
                "%T": "%H:%M:%S",
                "%x": "%m/%d/%y",
                "%X": "%H:%M:%S",
                "%Ec": "%c",
                "%EC": "%C",
                "%Ex": "%m/%d/%y",
                "%EX": "%H:%M:%S",
                "%Ey": "%y",
                "%EY": "%Y",
                "%Od": "%d",
                "%Oe": "%e",
                "%OH": "%H",
                "%OI": "%I",
                "%Om": "%m",
                "%OM": "%M",
                "%OS": "%S",
                "%Ou": "%u",
                "%OU": "%U",
                "%OV": "%V",
                "%Ow": "%w",
                "%OW": "%W",
                "%Oy": "%y"
            };
            for (var rule in EXPANSION_RULES_1) {
                pattern = pattern.replace(new RegExp(rule, "g"), EXPANSION_RULES_1[rule])
            }
            var WEEKDAYS = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
            var MONTHS = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

            function leadingSomething(value, digits, character) {
                var str = typeof value == "number" ? value.toString() : value || "";
                while (str.length < digits) {
                    str = character[0] + str
                }
                return str
            }

            function leadingNulls(value, digits) {
                return leadingSomething(value, digits, "0")
            }

            function compareByDay(date1, date2) {
                function sgn(value) {
                    return value < 0 ? -1 : value > 0 ? 1 : 0
                }
                var compare;
                if ((compare = sgn(date1.getFullYear() - date2.getFullYear())) === 0) {
                    if ((compare = sgn(date1.getMonth() - date2.getMonth())) === 0) {
                        compare = sgn(date1.getDate() - date2.getDate())
                    }
                }
                return compare
            }

            function getFirstWeekStartDate(janFourth) {
                switch (janFourth.getDay()) {
                    case 0:
                        return new Date(janFourth.getFullYear() - 1, 11, 29);
                    case 1:
                        return janFourth;
                    case 2:
                        return new Date(janFourth.getFullYear(), 0, 3);
                    case 3:
                        return new Date(janFourth.getFullYear(), 0, 2);
                    case 4:
                        return new Date(janFourth.getFullYear(), 0, 1);
                    case 5:
                        return new Date(janFourth.getFullYear() - 1, 11, 31);
                    case 6:
                        return new Date(janFourth.getFullYear() - 1, 11, 30)
                }
            }

            function getWeekBasedYear(date) {
                var thisDate = __addDays(new Date(date.tm_year + 1900, 0, 1), date.tm_yday);
                var janFourthThisYear = new Date(thisDate.getFullYear(), 0, 4);
                var janFourthNextYear = new Date(thisDate.getFullYear() + 1, 0, 4);
                var firstWeekStartThisYear = getFirstWeekStartDate(janFourthThisYear);
                var firstWeekStartNextYear = getFirstWeekStartDate(janFourthNextYear);
                if (compareByDay(firstWeekStartThisYear, thisDate) <= 0) {
                    if (compareByDay(firstWeekStartNextYear, thisDate) <= 0) {
                        return thisDate.getFullYear() + 1
                    }
                    return thisDate.getFullYear()
                }
                return thisDate.getFullYear() - 1
            }
            var EXPANSION_RULES_2 = {
                "%a": function (date) {
                    return WEEKDAYS[date.tm_wday].substring(0, 3)
                },
                "%A": function (date) {
                    return WEEKDAYS[date.tm_wday]
                },
                "%b": function (date) {
                    return MONTHS[date.tm_mon].substring(0, 3)
                },
                "%B": function (date) {
                    return MONTHS[date.tm_mon]
                },
                "%C": function (date) {
                    var year = date.tm_year + 1900;
                    return leadingNulls(year / 100 | 0, 2)
                },
                "%d": function (date) {
                    return leadingNulls(date.tm_mday, 2)
                },
                "%e": function (date) {
                    return leadingSomething(date.tm_mday, 2, " ")
                },
                "%g": function (date) {
                    return getWeekBasedYear(date).toString().substring(2)
                },
                "%G": function (date) {
                    return getWeekBasedYear(date)
                },
                "%H": function (date) {
                    return leadingNulls(date.tm_hour, 2)
                },
                "%I": function (date) {
                    var twelveHour = date.tm_hour;
                    if (twelveHour == 0) twelveHour = 12;
                    else if (twelveHour > 12) twelveHour -= 12;
                    return leadingNulls(twelveHour, 2)
                },
                "%j": function (date) {
                    return leadingNulls(date.tm_mday + __arraySum(__isLeapYear(date.tm_year + 1900) ? __MONTH_DAYS_LEAP : __MONTH_DAYS_REGULAR, date.tm_mon - 1), 3)
                },
                "%m": function (date) {
                    return leadingNulls(date.tm_mon + 1, 2)
                },
                "%M": function (date) {
                    return leadingNulls(date.tm_min, 2)
                },
                "%n": function () {
                    return "\n"
                },
                "%p": function (date) {
                    if (date.tm_hour >= 0 && date.tm_hour < 12) {
                        return "AM"
                    }
                    return "PM"
                },
                "%S": function (date) {
                    return leadingNulls(date.tm_sec, 2)
                },
                "%t": function () {
                    return "\t"
                },
                "%u": function (date) {
                    return date.tm_wday || 7
                },
                "%U": function (date) {
                    var days = date.tm_yday + 7 - date.tm_wday;
                    return leadingNulls(Math.floor(days / 7), 2)
                },
                "%V": function (date) {
                    var val = Math.floor((date.tm_yday + 7 - (date.tm_wday + 6) % 7) / 7);
                    if ((date.tm_wday + 371 - date.tm_yday - 2) % 7 <= 2) {
                        val++
                    }
                    if (!val) {
                        val = 52;
                        var dec31 = (date.tm_wday + 7 - date.tm_yday - 1) % 7;
                        if (dec31 == 4 || dec31 == 5 && __isLeapYear(date.tm_year % 400 - 1)) {
                            val++
                        }
                    } else if (val == 53) {
                        var jan1 = (date.tm_wday + 371 - date.tm_yday) % 7;
                        if (jan1 != 4 && (jan1 != 3 || !__isLeapYear(date.tm_year))) val = 1
                    }
                    return leadingNulls(val, 2)
                },
                "%w": function (date) {
                    return date.tm_wday
                },
                "%W": function (date) {
                    var days = date.tm_yday + 7 - (date.tm_wday + 6) % 7;
                    return leadingNulls(Math.floor(days / 7), 2)
                },
                "%y": function (date) {
                    return (date.tm_year + 1900).toString().substring(2)
                },
                "%Y": function (date) {
                    return date.tm_year + 1900
                },
                "%z": function (date) {
                    var off = date.tm_gmtoff;
                    var ahead = off >= 0;
                    off = Math.abs(off) / 60;
                    off = off / 60 * 100 + off % 60;
                    return (ahead ? "+" : "-") + String("0000" + off).slice(-4)
                },
                "%Z": function (date) {
                    return date.tm_zone
                },
                "%%": function () {
                    return "%"
                }
            };
            pattern = pattern.replace(/%%/g, "\0\0");
            for (var rule in EXPANSION_RULES_2) {
                if (pattern.includes(rule)) {
                    pattern = pattern.replace(new RegExp(rule, "g"), EXPANSION_RULES_2[rule](date))
                }
            }
            pattern = pattern.replace(/\0\0/g, "%");
            var bytes = intArrayFromString(pattern, false);
            if (bytes.length > maxsize) {
                return 0
            }
            writeArrayToMemory(bytes, s);
            return bytes.length - 1
        }

        function _strftime_l(s, maxsize, format, tm, loc) {
            return _strftime(s, maxsize, format, tm)
        }

        function getCFunc(ident) {
            var func = Module["_" + ident];
            return func
        }

        function ccall(ident, returnType, argTypes, args, opts) {
            var toC = {
                "string": str => {
                    var ret = 0;
                    if (str !== null && str !== undefined && str !== 0) {
                        var len = (str.length << 2) + 1;
                        ret = stackAlloc(len);
                        stringToUTF8(str, ret, len)
                    }
                    return ret
                },
                "array": arr => {
                    var ret = stackAlloc(arr.length);
                    writeArrayToMemory(arr, ret);
                    return ret
                }
            };

            function convertReturnValue(ret) {
                if (returnType === "string") {
                    return UTF8ToString(ret)
                }
                if (returnType === "boolean") return Boolean(ret);
                return ret
            }
            var func = getCFunc(ident);
            var cArgs = [];
            var stack = 0;
            if (args) {
                for (var i = 0; i < args.length; i++) {
                    var converter = toC[argTypes[i]];
                    if (converter) {
                        if (stack === 0) stack = stackSave();
                        cArgs[i] = converter(args[i])
                    } else {
                        cArgs[i] = args[i]
                    }
                }
            }
            var ret = func.apply(null, cArgs);

            function onDone(ret) {
                if (stack !== 0) stackRestore(stack);
                return convertReturnValue(ret)
            }
            ret = onDone(ret);
            return ret
        }

        function cwrap(ident, returnType, argTypes, opts) {
            var numericArgs = !argTypes || argTypes.every(type => type === "number" || type === "boolean");
            var numericRet = returnType !== "string";
            if (numericRet && numericArgs && !opts) {
                return getCFunc(ident)
            }
            return function () {
                return ccall(ident, returnType, argTypes, arguments, opts)
            }
        }
        var FSNode = function (parent, name, mode, rdev) {
            if (!parent) {
                parent = this
            }
            this.parent = parent;
            this.mount = parent.mount;
            this.mounted = null;
            this.id = FS.nextInode++;
            this.name = name;
            this.mode = mode;
            this.node_ops = {};
            this.stream_ops = {};
            this.rdev = rdev
        };
        var readMode = 292 | 73;
        var writeMode = 146;
        Object.defineProperties(FSNode.prototype, {
            read: {
                get: function () {
                    return (this.mode & readMode) === readMode
                },
                set: function (val) {
                    val ? this.mode |= readMode : this.mode &= ~readMode
                }
            },
            write: {
                get: function () {
                    return (this.mode & writeMode) === writeMode
                },
                set: function (val) {
                    val ? this.mode |= writeMode : this.mode &= ~writeMode
                }
            },
            isFolder: {
                get: function () {
                    return FS.isDir(this.mode)
                }
            },
            isDevice: {
                get: function () {
                    return FS.isChrdev(this.mode)
                }
            }
        });
        FS.FSNode = FSNode;
        FS.staticInit();
        var wasmImports = {
            "__call_sighandler": ___call_sighandler,
            "__syscall_fcntl64": ___syscall_fcntl64,
            "__syscall_fstat64": ___syscall_fstat64,
            "__syscall_ftruncate64": ___syscall_ftruncate64,
            "__syscall_getdents64": ___syscall_getdents64,
            "__syscall_ioctl": ___syscall_ioctl,
            "__syscall_lstat64": ___syscall_lstat64,
            "__syscall_newfstatat": ___syscall_newfstatat,
            "__syscall_openat": ___syscall_openat,
            "__syscall_rmdir": ___syscall_rmdir,
            "__syscall_stat64": ___syscall_stat64,
            "__syscall_unlinkat": ___syscall_unlinkat,
            "_emscripten_throw_longjmp": __emscripten_throw_longjmp,
            "_gmtime_js": __gmtime_js,
            "_localtime_js": __localtime_js,
            "_setitimer_js": __setitimer_js,
            "_tzset_js": __tzset_js,
            "abort": _abort,
            "emscripten_date_now": _emscripten_date_now,
            "emscripten_memcpy_big": _emscripten_memcpy_big,
            "emscripten_resize_heap": _emscripten_resize_heap,
            "environ_get": _environ_get,
            "environ_sizes_get": _environ_sizes_get,
            "fd_close": _fd_close,
            "fd_read": _fd_read,
            "fd_seek": _fd_seek,
            "fd_sync": _fd_sync,
            "fd_write": _fd_write,
            "invoke_ii": invoke_ii,
            "invoke_iii": invoke_iii,
            "invoke_iiii": invoke_iiii,
            "invoke_iiiii": invoke_iiiii,
            "invoke_v": invoke_v,
            "invoke_vi": invoke_vi,
            "invoke_viii": invoke_viii,
            "invoke_viiii": invoke_viiii,
            "strftime_l": _strftime_l
        };
        var asm = createWasm();
        var ___wasm_call_ctors = function () {
            return (___wasm_call_ctors = Module["asm"]["__wasm_call_ctors"]).apply(null, arguments)
        };
        var _FPDFAnnot_IsSupportedSubtype = Module["_FPDFAnnot_IsSupportedSubtype"] = function () {
            return (_FPDFAnnot_IsSupportedSubtype = Module["_FPDFAnnot_IsSupportedSubtype"] = Module["asm"]["FPDFAnnot_IsSupportedSubtype"]).apply(null, arguments)
        };
        var _FPDFPage_CreateAnnot = Module["_FPDFPage_CreateAnnot"] = function () {
            return (_FPDFPage_CreateAnnot = Module["_FPDFPage_CreateAnnot"] = Module["asm"]["FPDFPage_CreateAnnot"]).apply(null, arguments)
        };
        var _FPDFPage_GetAnnotCount = Module["_FPDFPage_GetAnnotCount"] = function () {
            return (_FPDFPage_GetAnnotCount = Module["_FPDFPage_GetAnnotCount"] = Module["asm"]["FPDFPage_GetAnnotCount"]).apply(null, arguments)
        };
        var _FPDFPage_GetAnnot = Module["_FPDFPage_GetAnnot"] = function () {
            return (_FPDFPage_GetAnnot = Module["_FPDFPage_GetAnnot"] = Module["asm"]["FPDFPage_GetAnnot"]).apply(null, arguments)
        };
        var _FPDFPage_GetAnnotIndex = Module["_FPDFPage_GetAnnotIndex"] = function () {
            return (_FPDFPage_GetAnnotIndex = Module["_FPDFPage_GetAnnotIndex"] = Module["asm"]["FPDFPage_GetAnnotIndex"]).apply(null, arguments)
        };
        var _FPDFPage_CloseAnnot = Module["_FPDFPage_CloseAnnot"] = function () {
            return (_FPDFPage_CloseAnnot = Module["_FPDFPage_CloseAnnot"] = Module["asm"]["FPDFPage_CloseAnnot"]).apply(null, arguments)
        };
        var _FPDFPage_RemoveAnnot = Module["_FPDFPage_RemoveAnnot"] = function () {
            return (_FPDFPage_RemoveAnnot = Module["_FPDFPage_RemoveAnnot"] = Module["asm"]["FPDFPage_RemoveAnnot"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetSubtype = Module["_FPDFAnnot_GetSubtype"] = function () {
            return (_FPDFAnnot_GetSubtype = Module["_FPDFAnnot_GetSubtype"] = Module["asm"]["FPDFAnnot_GetSubtype"]).apply(null, arguments)
        };
        var _FPDFAnnot_IsObjectSupportedSubtype = Module["_FPDFAnnot_IsObjectSupportedSubtype"] = function () {
            return (_FPDFAnnot_IsObjectSupportedSubtype = Module["_FPDFAnnot_IsObjectSupportedSubtype"] = Module["asm"]["FPDFAnnot_IsObjectSupportedSubtype"]).apply(null, arguments)
        };
        var _FPDFAnnot_UpdateObject = Module["_FPDFAnnot_UpdateObject"] = function () {
            return (_FPDFAnnot_UpdateObject = Module["_FPDFAnnot_UpdateObject"] = Module["asm"]["FPDFAnnot_UpdateObject"]).apply(null, arguments)
        };
        var _FPDFAnnot_AddInkStroke = Module["_FPDFAnnot_AddInkStroke"] = function () {
            return (_FPDFAnnot_AddInkStroke = Module["_FPDFAnnot_AddInkStroke"] = Module["asm"]["FPDFAnnot_AddInkStroke"]).apply(null, arguments)
        };
        var _FPDFAnnot_RemoveInkList = Module["_FPDFAnnot_RemoveInkList"] = function () {
            return (_FPDFAnnot_RemoveInkList = Module["_FPDFAnnot_RemoveInkList"] = Module["asm"]["FPDFAnnot_RemoveInkList"]).apply(null, arguments)
        };
        var _FPDFAnnot_AppendObject = Module["_FPDFAnnot_AppendObject"] = function () {
            return (_FPDFAnnot_AppendObject = Module["_FPDFAnnot_AppendObject"] = Module["asm"]["FPDFAnnot_AppendObject"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetObjectCount = Module["_FPDFAnnot_GetObjectCount"] = function () {
            return (_FPDFAnnot_GetObjectCount = Module["_FPDFAnnot_GetObjectCount"] = Module["asm"]["FPDFAnnot_GetObjectCount"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetObject = Module["_FPDFAnnot_GetObject"] = function () {
            return (_FPDFAnnot_GetObject = Module["_FPDFAnnot_GetObject"] = Module["asm"]["FPDFAnnot_GetObject"]).apply(null, arguments)
        };
        var _FPDFAnnot_RemoveObject = Module["_FPDFAnnot_RemoveObject"] = function () {
            return (_FPDFAnnot_RemoveObject = Module["_FPDFAnnot_RemoveObject"] = Module["asm"]["FPDFAnnot_RemoveObject"]).apply(null, arguments)
        };
        var _FPDFAnnot_SetColor = Module["_FPDFAnnot_SetColor"] = function () {
            return (_FPDFAnnot_SetColor = Module["_FPDFAnnot_SetColor"] = Module["asm"]["FPDFAnnot_SetColor"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetColor = Module["_FPDFAnnot_GetColor"] = function () {
            return (_FPDFAnnot_GetColor = Module["_FPDFAnnot_GetColor"] = Module["asm"]["FPDFAnnot_GetColor"]).apply(null, arguments)
        };
        var _FPDFAnnot_HasAttachmentPoints = Module["_FPDFAnnot_HasAttachmentPoints"] = function () {
            return (_FPDFAnnot_HasAttachmentPoints = Module["_FPDFAnnot_HasAttachmentPoints"] = Module["asm"]["FPDFAnnot_HasAttachmentPoints"]).apply(null, arguments)
        };
        var _FPDFAnnot_SetAttachmentPoints = Module["_FPDFAnnot_SetAttachmentPoints"] = function () {
            return (_FPDFAnnot_SetAttachmentPoints = Module["_FPDFAnnot_SetAttachmentPoints"] = Module["asm"]["FPDFAnnot_SetAttachmentPoints"]).apply(null, arguments)
        };
        var _FPDFAnnot_AppendAttachmentPoints = Module["_FPDFAnnot_AppendAttachmentPoints"] = function () {
            return (_FPDFAnnot_AppendAttachmentPoints = Module["_FPDFAnnot_AppendAttachmentPoints"] = Module["asm"]["FPDFAnnot_AppendAttachmentPoints"]).apply(null, arguments)
        };
        var _FPDFAnnot_CountAttachmentPoints = Module["_FPDFAnnot_CountAttachmentPoints"] = function () {
            return (_FPDFAnnot_CountAttachmentPoints = Module["_FPDFAnnot_CountAttachmentPoints"] = Module["asm"]["FPDFAnnot_CountAttachmentPoints"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetAttachmentPoints = Module["_FPDFAnnot_GetAttachmentPoints"] = function () {
            return (_FPDFAnnot_GetAttachmentPoints = Module["_FPDFAnnot_GetAttachmentPoints"] = Module["asm"]["FPDFAnnot_GetAttachmentPoints"]).apply(null, arguments)
        };
        var _FPDFAnnot_SetRect = Module["_FPDFAnnot_SetRect"] = function () {
            return (_FPDFAnnot_SetRect = Module["_FPDFAnnot_SetRect"] = Module["asm"]["FPDFAnnot_SetRect"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetRect = Module["_FPDFAnnot_GetRect"] = function () {
            return (_FPDFAnnot_GetRect = Module["_FPDFAnnot_GetRect"] = Module["asm"]["FPDFAnnot_GetRect"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetVertices = Module["_FPDFAnnot_GetVertices"] = function () {
            return (_FPDFAnnot_GetVertices = Module["_FPDFAnnot_GetVertices"] = Module["asm"]["FPDFAnnot_GetVertices"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetInkListCount = Module["_FPDFAnnot_GetInkListCount"] = function () {
            return (_FPDFAnnot_GetInkListCount = Module["_FPDFAnnot_GetInkListCount"] = Module["asm"]["FPDFAnnot_GetInkListCount"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetInkListPath = Module["_FPDFAnnot_GetInkListPath"] = function () {
            return (_FPDFAnnot_GetInkListPath = Module["_FPDFAnnot_GetInkListPath"] = Module["asm"]["FPDFAnnot_GetInkListPath"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetLine = Module["_FPDFAnnot_GetLine"] = function () {
            return (_FPDFAnnot_GetLine = Module["_FPDFAnnot_GetLine"] = Module["asm"]["FPDFAnnot_GetLine"]).apply(null, arguments)
        };
        var _FPDFAnnot_SetBorder = Module["_FPDFAnnot_SetBorder"] = function () {
            return (_FPDFAnnot_SetBorder = Module["_FPDFAnnot_SetBorder"] = Module["asm"]["FPDFAnnot_SetBorder"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetBorder = Module["_FPDFAnnot_GetBorder"] = function () {
            return (_FPDFAnnot_GetBorder = Module["_FPDFAnnot_GetBorder"] = Module["asm"]["FPDFAnnot_GetBorder"]).apply(null, arguments)
        };
        var _FPDFAnnot_HasKey = Module["_FPDFAnnot_HasKey"] = function () {
            return (_FPDFAnnot_HasKey = Module["_FPDFAnnot_HasKey"] = Module["asm"]["FPDFAnnot_HasKey"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetValueType = Module["_FPDFAnnot_GetValueType"] = function () {
            return (_FPDFAnnot_GetValueType = Module["_FPDFAnnot_GetValueType"] = Module["asm"]["FPDFAnnot_GetValueType"]).apply(null, arguments)
        };
        var _FPDFAnnot_SetStringValue = Module["_FPDFAnnot_SetStringValue"] = function () {
            return (_FPDFAnnot_SetStringValue = Module["_FPDFAnnot_SetStringValue"] = Module["asm"]["FPDFAnnot_SetStringValue"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetStringValue = Module["_FPDFAnnot_GetStringValue"] = function () {
            return (_FPDFAnnot_GetStringValue = Module["_FPDFAnnot_GetStringValue"] = Module["asm"]["FPDFAnnot_GetStringValue"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetNumberValue = Module["_FPDFAnnot_GetNumberValue"] = function () {
            return (_FPDFAnnot_GetNumberValue = Module["_FPDFAnnot_GetNumberValue"] = Module["asm"]["FPDFAnnot_GetNumberValue"]).apply(null, arguments)
        };
        var _FPDFAnnot_SetAP = Module["_FPDFAnnot_SetAP"] = function () {
            return (_FPDFAnnot_SetAP = Module["_FPDFAnnot_SetAP"] = Module["asm"]["FPDFAnnot_SetAP"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetAP = Module["_FPDFAnnot_GetAP"] = function () {
            return (_FPDFAnnot_GetAP = Module["_FPDFAnnot_GetAP"] = Module["asm"]["FPDFAnnot_GetAP"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetLinkedAnnot = Module["_FPDFAnnot_GetLinkedAnnot"] = function () {
            return (_FPDFAnnot_GetLinkedAnnot = Module["_FPDFAnnot_GetLinkedAnnot"] = Module["asm"]["FPDFAnnot_GetLinkedAnnot"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFlags = Module["_FPDFAnnot_GetFlags"] = function () {
            return (_FPDFAnnot_GetFlags = Module["_FPDFAnnot_GetFlags"] = Module["asm"]["FPDFAnnot_GetFlags"]).apply(null, arguments)
        };
        var _FPDFAnnot_SetFlags = Module["_FPDFAnnot_SetFlags"] = function () {
            return (_FPDFAnnot_SetFlags = Module["_FPDFAnnot_SetFlags"] = Module["asm"]["FPDFAnnot_SetFlags"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFormFieldFlags = Module["_FPDFAnnot_GetFormFieldFlags"] = function () {
            return (_FPDFAnnot_GetFormFieldFlags = Module["_FPDFAnnot_GetFormFieldFlags"] = Module["asm"]["FPDFAnnot_GetFormFieldFlags"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFormFieldAtPoint = Module["_FPDFAnnot_GetFormFieldAtPoint"] = function () {
            return (_FPDFAnnot_GetFormFieldAtPoint = Module["_FPDFAnnot_GetFormFieldAtPoint"] = Module["asm"]["FPDFAnnot_GetFormFieldAtPoint"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFormFieldName = Module["_FPDFAnnot_GetFormFieldName"] = function () {
            return (_FPDFAnnot_GetFormFieldName = Module["_FPDFAnnot_GetFormFieldName"] = Module["asm"]["FPDFAnnot_GetFormFieldName"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFormFieldType = Module["_FPDFAnnot_GetFormFieldType"] = function () {
            return (_FPDFAnnot_GetFormFieldType = Module["_FPDFAnnot_GetFormFieldType"] = Module["asm"]["FPDFAnnot_GetFormFieldType"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFormAdditionalActionJavaScript = Module["_FPDFAnnot_GetFormAdditionalActionJavaScript"] = function () {
            return (_FPDFAnnot_GetFormAdditionalActionJavaScript = Module["_FPDFAnnot_GetFormAdditionalActionJavaScript"] = Module["asm"]["FPDFAnnot_GetFormAdditionalActionJavaScript"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFormFieldAlternateName = Module["_FPDFAnnot_GetFormFieldAlternateName"] = function () {
            return (_FPDFAnnot_GetFormFieldAlternateName = Module["_FPDFAnnot_GetFormFieldAlternateName"] = Module["asm"]["FPDFAnnot_GetFormFieldAlternateName"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFormFieldValue = Module["_FPDFAnnot_GetFormFieldValue"] = function () {
            return (_FPDFAnnot_GetFormFieldValue = Module["_FPDFAnnot_GetFormFieldValue"] = Module["asm"]["FPDFAnnot_GetFormFieldValue"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetOptionCount = Module["_FPDFAnnot_GetOptionCount"] = function () {
            return (_FPDFAnnot_GetOptionCount = Module["_FPDFAnnot_GetOptionCount"] = Module["asm"]["FPDFAnnot_GetOptionCount"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetOptionLabel = Module["_FPDFAnnot_GetOptionLabel"] = function () {
            return (_FPDFAnnot_GetOptionLabel = Module["_FPDFAnnot_GetOptionLabel"] = Module["asm"]["FPDFAnnot_GetOptionLabel"]).apply(null, arguments)
        };
        var _FPDFAnnot_IsOptionSelected = Module["_FPDFAnnot_IsOptionSelected"] = function () {
            return (_FPDFAnnot_IsOptionSelected = Module["_FPDFAnnot_IsOptionSelected"] = Module["asm"]["FPDFAnnot_IsOptionSelected"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFontSize = Module["_FPDFAnnot_GetFontSize"] = function () {
            return (_FPDFAnnot_GetFontSize = Module["_FPDFAnnot_GetFontSize"] = Module["asm"]["FPDFAnnot_GetFontSize"]).apply(null, arguments)
        };
        var _FPDFAnnot_IsChecked = Module["_FPDFAnnot_IsChecked"] = function () {
            return (_FPDFAnnot_IsChecked = Module["_FPDFAnnot_IsChecked"] = Module["asm"]["FPDFAnnot_IsChecked"]).apply(null, arguments)
        };
        var _FPDFAnnot_SetFocusableSubtypes = Module["_FPDFAnnot_SetFocusableSubtypes"] = function () {
            return (_FPDFAnnot_SetFocusableSubtypes = Module["_FPDFAnnot_SetFocusableSubtypes"] = Module["asm"]["FPDFAnnot_SetFocusableSubtypes"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFocusableSubtypesCount = Module["_FPDFAnnot_GetFocusableSubtypesCount"] = function () {
            return (_FPDFAnnot_GetFocusableSubtypesCount = Module["_FPDFAnnot_GetFocusableSubtypesCount"] = Module["asm"]["FPDFAnnot_GetFocusableSubtypesCount"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFocusableSubtypes = Module["_FPDFAnnot_GetFocusableSubtypes"] = function () {
            return (_FPDFAnnot_GetFocusableSubtypes = Module["_FPDFAnnot_GetFocusableSubtypes"] = Module["asm"]["FPDFAnnot_GetFocusableSubtypes"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetLink = Module["_FPDFAnnot_GetLink"] = function () {
            return (_FPDFAnnot_GetLink = Module["_FPDFAnnot_GetLink"] = Module["asm"]["FPDFAnnot_GetLink"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFormControlCount = Module["_FPDFAnnot_GetFormControlCount"] = function () {
            return (_FPDFAnnot_GetFormControlCount = Module["_FPDFAnnot_GetFormControlCount"] = Module["asm"]["FPDFAnnot_GetFormControlCount"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFormControlIndex = Module["_FPDFAnnot_GetFormControlIndex"] = function () {
            return (_FPDFAnnot_GetFormControlIndex = Module["_FPDFAnnot_GetFormControlIndex"] = Module["asm"]["FPDFAnnot_GetFormControlIndex"]).apply(null, arguments)
        };
        var _FPDFAnnot_GetFormFieldExportValue = Module["_FPDFAnnot_GetFormFieldExportValue"] = function () {
            return (_FPDFAnnot_GetFormFieldExportValue = Module["_FPDFAnnot_GetFormFieldExportValue"] = Module["asm"]["FPDFAnnot_GetFormFieldExportValue"]).apply(null, arguments)
        };
        var _FPDFAnnot_SetURI = Module["_FPDFAnnot_SetURI"] = function () {
            return (_FPDFAnnot_SetURI = Module["_FPDFAnnot_SetURI"] = Module["asm"]["FPDFAnnot_SetURI"]).apply(null, arguments)
        };
        var _FPDFDoc_GetAttachmentCount = Module["_FPDFDoc_GetAttachmentCount"] = function () {
            return (_FPDFDoc_GetAttachmentCount = Module["_FPDFDoc_GetAttachmentCount"] = Module["asm"]["FPDFDoc_GetAttachmentCount"]).apply(null, arguments)
        };
        var _FPDFDoc_AddAttachment = Module["_FPDFDoc_AddAttachment"] = function () {
            return (_FPDFDoc_AddAttachment = Module["_FPDFDoc_AddAttachment"] = Module["asm"]["FPDFDoc_AddAttachment"]).apply(null, arguments)
        };
        var _FPDFDoc_GetAttachment = Module["_FPDFDoc_GetAttachment"] = function () {
            return (_FPDFDoc_GetAttachment = Module["_FPDFDoc_GetAttachment"] = Module["asm"]["FPDFDoc_GetAttachment"]).apply(null, arguments)
        };
        var _FPDFDoc_DeleteAttachment = Module["_FPDFDoc_DeleteAttachment"] = function () {
            return (_FPDFDoc_DeleteAttachment = Module["_FPDFDoc_DeleteAttachment"] = Module["asm"]["FPDFDoc_DeleteAttachment"]).apply(null, arguments)
        };
        var _FPDFAttachment_GetName = Module["_FPDFAttachment_GetName"] = function () {
            return (_FPDFAttachment_GetName = Module["_FPDFAttachment_GetName"] = Module["asm"]["FPDFAttachment_GetName"]).apply(null, arguments)
        };
        var _FPDFAttachment_HasKey = Module["_FPDFAttachment_HasKey"] = function () {
            return (_FPDFAttachment_HasKey = Module["_FPDFAttachment_HasKey"] = Module["asm"]["FPDFAttachment_HasKey"]).apply(null, arguments)
        };
        var _FPDFAttachment_GetValueType = Module["_FPDFAttachment_GetValueType"] = function () {
            return (_FPDFAttachment_GetValueType = Module["_FPDFAttachment_GetValueType"] = Module["asm"]["FPDFAttachment_GetValueType"]).apply(null, arguments)
        };
        var _FPDFAttachment_SetStringValue = Module["_FPDFAttachment_SetStringValue"] = function () {
            return (_FPDFAttachment_SetStringValue = Module["_FPDFAttachment_SetStringValue"] = Module["asm"]["FPDFAttachment_SetStringValue"]).apply(null, arguments)
        };
        var _FPDFAttachment_GetStringValue = Module["_FPDFAttachment_GetStringValue"] = function () {
            return (_FPDFAttachment_GetStringValue = Module["_FPDFAttachment_GetStringValue"] = Module["asm"]["FPDFAttachment_GetStringValue"]).apply(null, arguments)
        };
        var _FPDFAttachment_SetFile = Module["_FPDFAttachment_SetFile"] = function () {
            return (_FPDFAttachment_SetFile = Module["_FPDFAttachment_SetFile"] = Module["asm"]["FPDFAttachment_SetFile"]).apply(null, arguments)
        };
        var _FPDFAttachment_GetFile = Module["_FPDFAttachment_GetFile"] = function () {
            return (_FPDFAttachment_GetFile = Module["_FPDFAttachment_GetFile"] = Module["asm"]["FPDFAttachment_GetFile"]).apply(null, arguments)
        };
        var _FPDFCatalog_IsTagged = Module["_FPDFCatalog_IsTagged"] = function () {
            return (_FPDFCatalog_IsTagged = Module["_FPDFCatalog_IsTagged"] = Module["asm"]["FPDFCatalog_IsTagged"]).apply(null, arguments)
        };
        var _FPDFAvail_Create = Module["_FPDFAvail_Create"] = function () {
            return (_FPDFAvail_Create = Module["_FPDFAvail_Create"] = Module["asm"]["FPDFAvail_Create"]).apply(null, arguments)
        };
        var _FPDFAvail_Destroy = Module["_FPDFAvail_Destroy"] = function () {
            return (_FPDFAvail_Destroy = Module["_FPDFAvail_Destroy"] = Module["asm"]["FPDFAvail_Destroy"]).apply(null, arguments)
        };
        var _FPDFAvail_IsDocAvail = Module["_FPDFAvail_IsDocAvail"] = function () {
            return (_FPDFAvail_IsDocAvail = Module["_FPDFAvail_IsDocAvail"] = Module["asm"]["FPDFAvail_IsDocAvail"]).apply(null, arguments)
        };
        var _FPDFAvail_GetDocument = Module["_FPDFAvail_GetDocument"] = function () {
            return (_FPDFAvail_GetDocument = Module["_FPDFAvail_GetDocument"] = Module["asm"]["FPDFAvail_GetDocument"]).apply(null, arguments)
        };
        var _FPDFAvail_GetFirstPageNum = Module["_FPDFAvail_GetFirstPageNum"] = function () {
            return (_FPDFAvail_GetFirstPageNum = Module["_FPDFAvail_GetFirstPageNum"] = Module["asm"]["FPDFAvail_GetFirstPageNum"]).apply(null, arguments)
        };
        var _FPDFAvail_IsPageAvail = Module["_FPDFAvail_IsPageAvail"] = function () {
            return (_FPDFAvail_IsPageAvail = Module["_FPDFAvail_IsPageAvail"] = Module["asm"]["FPDFAvail_IsPageAvail"]).apply(null, arguments)
        };
        var _FPDFAvail_IsFormAvail = Module["_FPDFAvail_IsFormAvail"] = function () {
            return (_FPDFAvail_IsFormAvail = Module["_FPDFAvail_IsFormAvail"] = Module["asm"]["FPDFAvail_IsFormAvail"]).apply(null, arguments)
        };
        var _FPDFAvail_IsLinearized = Module["_FPDFAvail_IsLinearized"] = function () {
            return (_FPDFAvail_IsLinearized = Module["_FPDFAvail_IsLinearized"] = Module["asm"]["FPDFAvail_IsLinearized"]).apply(null, arguments)
        };
        var _FPDFBookmark_GetFirstChild = Module["_FPDFBookmark_GetFirstChild"] = function () {
            return (_FPDFBookmark_GetFirstChild = Module["_FPDFBookmark_GetFirstChild"] = Module["asm"]["FPDFBookmark_GetFirstChild"]).apply(null, arguments)
        };
        var _FPDFBookmark_GetNextSibling = Module["_FPDFBookmark_GetNextSibling"] = function () {
            return (_FPDFBookmark_GetNextSibling = Module["_FPDFBookmark_GetNextSibling"] = Module["asm"]["FPDFBookmark_GetNextSibling"]).apply(null, arguments)
        };
        var _FPDFBookmark_GetTitle = Module["_FPDFBookmark_GetTitle"] = function () {
            return (_FPDFBookmark_GetTitle = Module["_FPDFBookmark_GetTitle"] = Module["asm"]["FPDFBookmark_GetTitle"]).apply(null, arguments)
        };
        var _FPDFBookmark_GetCount = Module["_FPDFBookmark_GetCount"] = function () {
            return (_FPDFBookmark_GetCount = Module["_FPDFBookmark_GetCount"] = Module["asm"]["FPDFBookmark_GetCount"]).apply(null, arguments)
        };
        var _FPDFBookmark_Find = Module["_FPDFBookmark_Find"] = function () {
            return (_FPDFBookmark_Find = Module["_FPDFBookmark_Find"] = Module["asm"]["FPDFBookmark_Find"]).apply(null, arguments)
        };
        var _FPDFBookmark_GetDest = Module["_FPDFBookmark_GetDest"] = function () {
            return (_FPDFBookmark_GetDest = Module["_FPDFBookmark_GetDest"] = Module["asm"]["FPDFBookmark_GetDest"]).apply(null, arguments)
        };
        var _FPDFBookmark_GetAction = Module["_FPDFBookmark_GetAction"] = function () {
            return (_FPDFBookmark_GetAction = Module["_FPDFBookmark_GetAction"] = Module["asm"]["FPDFBookmark_GetAction"]).apply(null, arguments)
        };
        var _FPDFAction_GetType = Module["_FPDFAction_GetType"] = function () {
            return (_FPDFAction_GetType = Module["_FPDFAction_GetType"] = Module["asm"]["FPDFAction_GetType"]).apply(null, arguments)
        };
        var _FPDFAction_GetDest = Module["_FPDFAction_GetDest"] = function () {
            return (_FPDFAction_GetDest = Module["_FPDFAction_GetDest"] = Module["asm"]["FPDFAction_GetDest"]).apply(null, arguments)
        };
        var _FPDFAction_GetFilePath = Module["_FPDFAction_GetFilePath"] = function () {
            return (_FPDFAction_GetFilePath = Module["_FPDFAction_GetFilePath"] = Module["asm"]["FPDFAction_GetFilePath"]).apply(null, arguments)
        };
        var _FPDFAction_GetURIPath = Module["_FPDFAction_GetURIPath"] = function () {
            return (_FPDFAction_GetURIPath = Module["_FPDFAction_GetURIPath"] = Module["asm"]["FPDFAction_GetURIPath"]).apply(null, arguments)
        };
        var _FPDFDest_GetDestPageIndex = Module["_FPDFDest_GetDestPageIndex"] = function () {
            return (_FPDFDest_GetDestPageIndex = Module["_FPDFDest_GetDestPageIndex"] = Module["asm"]["FPDFDest_GetDestPageIndex"]).apply(null, arguments)
        };
        var _FPDFDest_GetView = Module["_FPDFDest_GetView"] = function () {
            return (_FPDFDest_GetView = Module["_FPDFDest_GetView"] = Module["asm"]["FPDFDest_GetView"]).apply(null, arguments)
        };
        var _FPDFDest_GetLocationInPage = Module["_FPDFDest_GetLocationInPage"] = function () {
            return (_FPDFDest_GetLocationInPage = Module["_FPDFDest_GetLocationInPage"] = Module["asm"]["FPDFDest_GetLocationInPage"]).apply(null, arguments)
        };
        var _FPDFLink_GetLinkAtPoint = Module["_FPDFLink_GetLinkAtPoint"] = function () {
            return (_FPDFLink_GetLinkAtPoint = Module["_FPDFLink_GetLinkAtPoint"] = Module["asm"]["FPDFLink_GetLinkAtPoint"]).apply(null, arguments)
        };
        var _FPDFLink_GetLinkZOrderAtPoint = Module["_FPDFLink_GetLinkZOrderAtPoint"] = function () {
            return (_FPDFLink_GetLinkZOrderAtPoint = Module["_FPDFLink_GetLinkZOrderAtPoint"] = Module["asm"]["FPDFLink_GetLinkZOrderAtPoint"]).apply(null, arguments)
        };
        var _FPDFLink_GetDest = Module["_FPDFLink_GetDest"] = function () {
            return (_FPDFLink_GetDest = Module["_FPDFLink_GetDest"] = Module["asm"]["FPDFLink_GetDest"]).apply(null, arguments)
        };
        var _FPDFLink_GetAction = Module["_FPDFLink_GetAction"] = function () {
            return (_FPDFLink_GetAction = Module["_FPDFLink_GetAction"] = Module["asm"]["FPDFLink_GetAction"]).apply(null, arguments)
        };
        var _FPDFLink_Enumerate = Module["_FPDFLink_Enumerate"] = function () {
            return (_FPDFLink_Enumerate = Module["_FPDFLink_Enumerate"] = Module["asm"]["FPDFLink_Enumerate"]).apply(null, arguments)
        };
        var _FPDFLink_GetAnnot = Module["_FPDFLink_GetAnnot"] = function () {
            return (_FPDFLink_GetAnnot = Module["_FPDFLink_GetAnnot"] = Module["asm"]["FPDFLink_GetAnnot"]).apply(null, arguments)
        };
        var _FPDFLink_GetAnnotRect = Module["_FPDFLink_GetAnnotRect"] = function () {
            return (_FPDFLink_GetAnnotRect = Module["_FPDFLink_GetAnnotRect"] = Module["asm"]["FPDFLink_GetAnnotRect"]).apply(null, arguments)
        };
        var _FPDFLink_CountQuadPoints = Module["_FPDFLink_CountQuadPoints"] = function () {
            return (_FPDFLink_CountQuadPoints = Module["_FPDFLink_CountQuadPoints"] = Module["asm"]["FPDFLink_CountQuadPoints"]).apply(null, arguments)
        };
        var _FPDFLink_GetQuadPoints = Module["_FPDFLink_GetQuadPoints"] = function () {
            return (_FPDFLink_GetQuadPoints = Module["_FPDFLink_GetQuadPoints"] = Module["asm"]["FPDFLink_GetQuadPoints"]).apply(null, arguments)
        };
        var _FPDF_GetPageAAction = Module["_FPDF_GetPageAAction"] = function () {
            return (_FPDF_GetPageAAction = Module["_FPDF_GetPageAAction"] = Module["asm"]["FPDF_GetPageAAction"]).apply(null, arguments)
        };
        var _FPDF_GetFileIdentifier = Module["_FPDF_GetFileIdentifier"] = function () {
            return (_FPDF_GetFileIdentifier = Module["_FPDF_GetFileIdentifier"] = Module["asm"]["FPDF_GetFileIdentifier"]).apply(null, arguments)
        };
        var _FPDF_GetMetaText = Module["_FPDF_GetMetaText"] = function () {
            return (_FPDF_GetMetaText = Module["_FPDF_GetMetaText"] = Module["asm"]["FPDF_GetMetaText"]).apply(null, arguments)
        };
        var _FPDF_GetPageLabel = Module["_FPDF_GetPageLabel"] = function () {
            return (_FPDF_GetPageLabel = Module["_FPDF_GetPageLabel"] = Module["asm"]["FPDF_GetPageLabel"]).apply(null, arguments)
        };
        var _FPDFPageObj_NewImageObj = Module["_FPDFPageObj_NewImageObj"] = function () {
            return (_FPDFPageObj_NewImageObj = Module["_FPDFPageObj_NewImageObj"] = Module["asm"]["FPDFPageObj_NewImageObj"]).apply(null, arguments)
        };
        var _FPDFImageObj_LoadJpegFile = Module["_FPDFImageObj_LoadJpegFile"] = function () {
            return (_FPDFImageObj_LoadJpegFile = Module["_FPDFImageObj_LoadJpegFile"] = Module["asm"]["FPDFImageObj_LoadJpegFile"]).apply(null, arguments)
        };
        var _FPDFImageObj_LoadJpegFileInline = Module["_FPDFImageObj_LoadJpegFileInline"] = function () {
            return (_FPDFImageObj_LoadJpegFileInline = Module["_FPDFImageObj_LoadJpegFileInline"] = Module["asm"]["FPDFImageObj_LoadJpegFileInline"]).apply(null, arguments)
        };
        var _FPDFImageObj_SetMatrix = Module["_FPDFImageObj_SetMatrix"] = function () {
            return (_FPDFImageObj_SetMatrix = Module["_FPDFImageObj_SetMatrix"] = Module["asm"]["FPDFImageObj_SetMatrix"]).apply(null, arguments)
        };
        var _FPDFImageObj_SetBitmap = Module["_FPDFImageObj_SetBitmap"] = function () {
            return (_FPDFImageObj_SetBitmap = Module["_FPDFImageObj_SetBitmap"] = Module["asm"]["FPDFImageObj_SetBitmap"]).apply(null, arguments)
        };
        var _FPDFImageObj_GetBitmap = Module["_FPDFImageObj_GetBitmap"] = function () {
            return (_FPDFImageObj_GetBitmap = Module["_FPDFImageObj_GetBitmap"] = Module["asm"]["FPDFImageObj_GetBitmap"]).apply(null, arguments)
        };
        var _FPDFImageObj_GetRenderedBitmap = Module["_FPDFImageObj_GetRenderedBitmap"] = function () {
            return (_FPDFImageObj_GetRenderedBitmap = Module["_FPDFImageObj_GetRenderedBitmap"] = Module["asm"]["FPDFImageObj_GetRenderedBitmap"]).apply(null, arguments)
        };
        var _FPDFImageObj_GetImageDataDecoded = Module["_FPDFImageObj_GetImageDataDecoded"] = function () {
            return (_FPDFImageObj_GetImageDataDecoded = Module["_FPDFImageObj_GetImageDataDecoded"] = Module["asm"]["FPDFImageObj_GetImageDataDecoded"]).apply(null, arguments)
        };
        var _FPDFImageObj_GetImageDataRaw = Module["_FPDFImageObj_GetImageDataRaw"] = function () {
            return (_FPDFImageObj_GetImageDataRaw = Module["_FPDFImageObj_GetImageDataRaw"] = Module["asm"]["FPDFImageObj_GetImageDataRaw"]).apply(null, arguments)
        };
        var _FPDFImageObj_GetImageFilterCount = Module["_FPDFImageObj_GetImageFilterCount"] = function () {
            return (_FPDFImageObj_GetImageFilterCount = Module["_FPDFImageObj_GetImageFilterCount"] = Module["asm"]["FPDFImageObj_GetImageFilterCount"]).apply(null, arguments)
        };
        var _FPDFImageObj_GetImageFilter = Module["_FPDFImageObj_GetImageFilter"] = function () {
            return (_FPDFImageObj_GetImageFilter = Module["_FPDFImageObj_GetImageFilter"] = Module["asm"]["FPDFImageObj_GetImageFilter"]).apply(null, arguments)
        };
        var _FPDFImageObj_GetImageMetadata = Module["_FPDFImageObj_GetImageMetadata"] = function () {
            return (_FPDFImageObj_GetImageMetadata = Module["_FPDFImageObj_GetImageMetadata"] = Module["asm"]["FPDFImageObj_GetImageMetadata"]).apply(null, arguments)
        };
        var _FPDFImageObj_GetImagePixelSize = Module["_FPDFImageObj_GetImagePixelSize"] = function () {
            return (_FPDFImageObj_GetImagePixelSize = Module["_FPDFImageObj_GetImagePixelSize"] = Module["asm"]["FPDFImageObj_GetImagePixelSize"]).apply(null, arguments)
        };
        var _FPDF_CreateNewDocument = Module["_FPDF_CreateNewDocument"] = function () {
            return (_FPDF_CreateNewDocument = Module["_FPDF_CreateNewDocument"] = Module["asm"]["FPDF_CreateNewDocument"]).apply(null, arguments)
        };
        var _FPDFPage_Delete = Module["_FPDFPage_Delete"] = function () {
            return (_FPDFPage_Delete = Module["_FPDFPage_Delete"] = Module["asm"]["FPDFPage_Delete"]).apply(null, arguments)
        };
        var _FPDFPage_New = Module["_FPDFPage_New"] = function () {
            return (_FPDFPage_New = Module["_FPDFPage_New"] = Module["asm"]["FPDFPage_New"]).apply(null, arguments)
        };
        var _FPDFPage_GetRotation = Module["_FPDFPage_GetRotation"] = function () {
            return (_FPDFPage_GetRotation = Module["_FPDFPage_GetRotation"] = Module["asm"]["FPDFPage_GetRotation"]).apply(null, arguments)
        };
        var _FPDFPage_InsertObject = Module["_FPDFPage_InsertObject"] = function () {
            return (_FPDFPage_InsertObject = Module["_FPDFPage_InsertObject"] = Module["asm"]["FPDFPage_InsertObject"]).apply(null, arguments)
        };
        var _FPDFPage_RemoveObject = Module["_FPDFPage_RemoveObject"] = function () {
            return (_FPDFPage_RemoveObject = Module["_FPDFPage_RemoveObject"] = Module["asm"]["FPDFPage_RemoveObject"]).apply(null, arguments)
        };
        var _FPDFPage_CountObjects = Module["_FPDFPage_CountObjects"] = function () {
            return (_FPDFPage_CountObjects = Module["_FPDFPage_CountObjects"] = Module["asm"]["FPDFPage_CountObjects"]).apply(null, arguments)
        };
        var _FPDFPage_GetObject = Module["_FPDFPage_GetObject"] = function () {
            return (_FPDFPage_GetObject = Module["_FPDFPage_GetObject"] = Module["asm"]["FPDFPage_GetObject"]).apply(null, arguments)
        };
        var _FPDFPage_HasTransparency = Module["_FPDFPage_HasTransparency"] = function () {
            return (_FPDFPage_HasTransparency = Module["_FPDFPage_HasTransparency"] = Module["asm"]["FPDFPage_HasTransparency"]).apply(null, arguments)
        };
        var _FPDFPageObj_Destroy = Module["_FPDFPageObj_Destroy"] = function () {
            return (_FPDFPageObj_Destroy = Module["_FPDFPageObj_Destroy"] = Module["asm"]["FPDFPageObj_Destroy"]).apply(null, arguments)
        };
        var _FPDFPageObj_CountMarks = Module["_FPDFPageObj_CountMarks"] = function () {
            return (_FPDFPageObj_CountMarks = Module["_FPDFPageObj_CountMarks"] = Module["asm"]["FPDFPageObj_CountMarks"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetMark = Module["_FPDFPageObj_GetMark"] = function () {
            return (_FPDFPageObj_GetMark = Module["_FPDFPageObj_GetMark"] = Module["asm"]["FPDFPageObj_GetMark"]).apply(null, arguments)
        };
        var _FPDFPageObj_AddMark = Module["_FPDFPageObj_AddMark"] = function () {
            return (_FPDFPageObj_AddMark = Module["_FPDFPageObj_AddMark"] = Module["asm"]["FPDFPageObj_AddMark"]).apply(null, arguments)
        };
        var _FPDFPageObj_RemoveMark = Module["_FPDFPageObj_RemoveMark"] = function () {
            return (_FPDFPageObj_RemoveMark = Module["_FPDFPageObj_RemoveMark"] = Module["asm"]["FPDFPageObj_RemoveMark"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_GetName = Module["_FPDFPageObjMark_GetName"] = function () {
            return (_FPDFPageObjMark_GetName = Module["_FPDFPageObjMark_GetName"] = Module["asm"]["FPDFPageObjMark_GetName"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_CountParams = Module["_FPDFPageObjMark_CountParams"] = function () {
            return (_FPDFPageObjMark_CountParams = Module["_FPDFPageObjMark_CountParams"] = Module["asm"]["FPDFPageObjMark_CountParams"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_GetParamKey = Module["_FPDFPageObjMark_GetParamKey"] = function () {
            return (_FPDFPageObjMark_GetParamKey = Module["_FPDFPageObjMark_GetParamKey"] = Module["asm"]["FPDFPageObjMark_GetParamKey"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_GetParamValueType = Module["_FPDFPageObjMark_GetParamValueType"] = function () {
            return (_FPDFPageObjMark_GetParamValueType = Module["_FPDFPageObjMark_GetParamValueType"] = Module["asm"]["FPDFPageObjMark_GetParamValueType"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_GetParamIntValue = Module["_FPDFPageObjMark_GetParamIntValue"] = function () {
            return (_FPDFPageObjMark_GetParamIntValue = Module["_FPDFPageObjMark_GetParamIntValue"] = Module["asm"]["FPDFPageObjMark_GetParamIntValue"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_GetParamStringValue = Module["_FPDFPageObjMark_GetParamStringValue"] = function () {
            return (_FPDFPageObjMark_GetParamStringValue = Module["_FPDFPageObjMark_GetParamStringValue"] = Module["asm"]["FPDFPageObjMark_GetParamStringValue"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_GetParamBlobValue = Module["_FPDFPageObjMark_GetParamBlobValue"] = function () {
            return (_FPDFPageObjMark_GetParamBlobValue = Module["_FPDFPageObjMark_GetParamBlobValue"] = Module["asm"]["FPDFPageObjMark_GetParamBlobValue"]).apply(null, arguments)
        };
        var _FPDFPageObj_HasTransparency = Module["_FPDFPageObj_HasTransparency"] = function () {
            return (_FPDFPageObj_HasTransparency = Module["_FPDFPageObj_HasTransparency"] = Module["asm"]["FPDFPageObj_HasTransparency"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_SetIntParam = Module["_FPDFPageObjMark_SetIntParam"] = function () {
            return (_FPDFPageObjMark_SetIntParam = Module["_FPDFPageObjMark_SetIntParam"] = Module["asm"]["FPDFPageObjMark_SetIntParam"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_SetStringParam = Module["_FPDFPageObjMark_SetStringParam"] = function () {
            return (_FPDFPageObjMark_SetStringParam = Module["_FPDFPageObjMark_SetStringParam"] = Module["asm"]["FPDFPageObjMark_SetStringParam"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_SetBlobParam = Module["_FPDFPageObjMark_SetBlobParam"] = function () {
            return (_FPDFPageObjMark_SetBlobParam = Module["_FPDFPageObjMark_SetBlobParam"] = Module["asm"]["FPDFPageObjMark_SetBlobParam"]).apply(null, arguments)
        };
        var _FPDFPageObjMark_RemoveParam = Module["_FPDFPageObjMark_RemoveParam"] = function () {
            return (_FPDFPageObjMark_RemoveParam = Module["_FPDFPageObjMark_RemoveParam"] = Module["asm"]["FPDFPageObjMark_RemoveParam"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetType = Module["_FPDFPageObj_GetType"] = function () {
            return (_FPDFPageObj_GetType = Module["_FPDFPageObj_GetType"] = Module["asm"]["FPDFPageObj_GetType"]).apply(null, arguments)
        };
        var _FPDFPage_GenerateContent = Module["_FPDFPage_GenerateContent"] = function () {
            return (_FPDFPage_GenerateContent = Module["_FPDFPage_GenerateContent"] = Module["asm"]["FPDFPage_GenerateContent"]).apply(null, arguments)
        };
        var _FPDFPageObj_Transform = Module["_FPDFPageObj_Transform"] = function () {
            return (_FPDFPageObj_Transform = Module["_FPDFPageObj_Transform"] = Module["asm"]["FPDFPageObj_Transform"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetMatrix = Module["_FPDFPageObj_GetMatrix"] = function () {
            return (_FPDFPageObj_GetMatrix = Module["_FPDFPageObj_GetMatrix"] = Module["asm"]["FPDFPageObj_GetMatrix"]).apply(null, arguments)
        };
        var _FPDFPageObj_SetMatrix = Module["_FPDFPageObj_SetMatrix"] = function () {
            return (_FPDFPageObj_SetMatrix = Module["_FPDFPageObj_SetMatrix"] = Module["asm"]["FPDFPageObj_SetMatrix"]).apply(null, arguments)
        };
        var _FPDFPageObj_SetBlendMode = Module["_FPDFPageObj_SetBlendMode"] = function () {
            return (_FPDFPageObj_SetBlendMode = Module["_FPDFPageObj_SetBlendMode"] = Module["asm"]["FPDFPageObj_SetBlendMode"]).apply(null, arguments)
        };
        var _FPDFPage_TransformAnnots = Module["_FPDFPage_TransformAnnots"] = function () {
            return (_FPDFPage_TransformAnnots = Module["_FPDFPage_TransformAnnots"] = Module["asm"]["FPDFPage_TransformAnnots"]).apply(null, arguments)
        };
        var _FPDFPage_SetRotation = Module["_FPDFPage_SetRotation"] = function () {
            return (_FPDFPage_SetRotation = Module["_FPDFPage_SetRotation"] = Module["asm"]["FPDFPage_SetRotation"]).apply(null, arguments)
        };
        var _FPDFPageObj_SetFillColor = Module["_FPDFPageObj_SetFillColor"] = function () {
            return (_FPDFPageObj_SetFillColor = Module["_FPDFPageObj_SetFillColor"] = Module["asm"]["FPDFPageObj_SetFillColor"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetFillColor = Module["_FPDFPageObj_GetFillColor"] = function () {
            return (_FPDFPageObj_GetFillColor = Module["_FPDFPageObj_GetFillColor"] = Module["asm"]["FPDFPageObj_GetFillColor"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetBounds = Module["_FPDFPageObj_GetBounds"] = function () {
            return (_FPDFPageObj_GetBounds = Module["_FPDFPageObj_GetBounds"] = Module["asm"]["FPDFPageObj_GetBounds"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetRotatedBounds = Module["_FPDFPageObj_GetRotatedBounds"] = function () {
            return (_FPDFPageObj_GetRotatedBounds = Module["_FPDFPageObj_GetRotatedBounds"] = Module["asm"]["FPDFPageObj_GetRotatedBounds"]).apply(null, arguments)
        };
        var _FPDFPageObj_SetStrokeColor = Module["_FPDFPageObj_SetStrokeColor"] = function () {
            return (_FPDFPageObj_SetStrokeColor = Module["_FPDFPageObj_SetStrokeColor"] = Module["asm"]["FPDFPageObj_SetStrokeColor"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetStrokeColor = Module["_FPDFPageObj_GetStrokeColor"] = function () {
            return (_FPDFPageObj_GetStrokeColor = Module["_FPDFPageObj_GetStrokeColor"] = Module["asm"]["FPDFPageObj_GetStrokeColor"]).apply(null, arguments)
        };
        var _FPDFPageObj_SetStrokeWidth = Module["_FPDFPageObj_SetStrokeWidth"] = function () {
            return (_FPDFPageObj_SetStrokeWidth = Module["_FPDFPageObj_SetStrokeWidth"] = Module["asm"]["FPDFPageObj_SetStrokeWidth"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetStrokeWidth = Module["_FPDFPageObj_GetStrokeWidth"] = function () {
            return (_FPDFPageObj_GetStrokeWidth = Module["_FPDFPageObj_GetStrokeWidth"] = Module["asm"]["FPDFPageObj_GetStrokeWidth"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetLineJoin = Module["_FPDFPageObj_GetLineJoin"] = function () {
            return (_FPDFPageObj_GetLineJoin = Module["_FPDFPageObj_GetLineJoin"] = Module["asm"]["FPDFPageObj_GetLineJoin"]).apply(null, arguments)
        };
        var _FPDFPageObj_SetLineJoin = Module["_FPDFPageObj_SetLineJoin"] = function () {
            return (_FPDFPageObj_SetLineJoin = Module["_FPDFPageObj_SetLineJoin"] = Module["asm"]["FPDFPageObj_SetLineJoin"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetLineCap = Module["_FPDFPageObj_GetLineCap"] = function () {
            return (_FPDFPageObj_GetLineCap = Module["_FPDFPageObj_GetLineCap"] = Module["asm"]["FPDFPageObj_GetLineCap"]).apply(null, arguments)
        };
        var _FPDFPageObj_SetLineCap = Module["_FPDFPageObj_SetLineCap"] = function () {
            return (_FPDFPageObj_SetLineCap = Module["_FPDFPageObj_SetLineCap"] = Module["asm"]["FPDFPageObj_SetLineCap"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetDashPhase = Module["_FPDFPageObj_GetDashPhase"] = function () {
            return (_FPDFPageObj_GetDashPhase = Module["_FPDFPageObj_GetDashPhase"] = Module["asm"]["FPDFPageObj_GetDashPhase"]).apply(null, arguments)
        };
        var _FPDFPageObj_SetDashPhase = Module["_FPDFPageObj_SetDashPhase"] = function () {
            return (_FPDFPageObj_SetDashPhase = Module["_FPDFPageObj_SetDashPhase"] = Module["asm"]["FPDFPageObj_SetDashPhase"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetDashCount = Module["_FPDFPageObj_GetDashCount"] = function () {
            return (_FPDFPageObj_GetDashCount = Module["_FPDFPageObj_GetDashCount"] = Module["asm"]["FPDFPageObj_GetDashCount"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetDashArray = Module["_FPDFPageObj_GetDashArray"] = function () {
            return (_FPDFPageObj_GetDashArray = Module["_FPDFPageObj_GetDashArray"] = Module["asm"]["FPDFPageObj_GetDashArray"]).apply(null, arguments)
        };
        var _FPDFPageObj_SetDashArray = Module["_FPDFPageObj_SetDashArray"] = function () {
            return (_FPDFPageObj_SetDashArray = Module["_FPDFPageObj_SetDashArray"] = Module["asm"]["FPDFPageObj_SetDashArray"]).apply(null, arguments)
        };
        var _FPDFFormObj_CountObjects = Module["_FPDFFormObj_CountObjects"] = function () {
            return (_FPDFFormObj_CountObjects = Module["_FPDFFormObj_CountObjects"] = Module["asm"]["FPDFFormObj_CountObjects"]).apply(null, arguments)
        };
        var _FPDFFormObj_GetObject = Module["_FPDFFormObj_GetObject"] = function () {
            return (_FPDFFormObj_GetObject = Module["_FPDFFormObj_GetObject"] = Module["asm"]["FPDFFormObj_GetObject"]).apply(null, arguments)
        };
        var _FPDFPageObj_CreateNewPath = Module["_FPDFPageObj_CreateNewPath"] = function () {
            return (_FPDFPageObj_CreateNewPath = Module["_FPDFPageObj_CreateNewPath"] = Module["asm"]["FPDFPageObj_CreateNewPath"]).apply(null, arguments)
        };
        var _FPDFPageObj_CreateNewRect = Module["_FPDFPageObj_CreateNewRect"] = function () {
            return (_FPDFPageObj_CreateNewRect = Module["_FPDFPageObj_CreateNewRect"] = Module["asm"]["FPDFPageObj_CreateNewRect"]).apply(null, arguments)
        };
        var _FPDFPath_CountSegments = Module["_FPDFPath_CountSegments"] = function () {
            return (_FPDFPath_CountSegments = Module["_FPDFPath_CountSegments"] = Module["asm"]["FPDFPath_CountSegments"]).apply(null, arguments)
        };
        var _FPDFPath_GetPathSegment = Module["_FPDFPath_GetPathSegment"] = function () {
            return (_FPDFPath_GetPathSegment = Module["_FPDFPath_GetPathSegment"] = Module["asm"]["FPDFPath_GetPathSegment"]).apply(null, arguments)
        };
        var _FPDFPath_MoveTo = Module["_FPDFPath_MoveTo"] = function () {
            return (_FPDFPath_MoveTo = Module["_FPDFPath_MoveTo"] = Module["asm"]["FPDFPath_MoveTo"]).apply(null, arguments)
        };
        var _FPDFPath_LineTo = Module["_FPDFPath_LineTo"] = function () {
            return (_FPDFPath_LineTo = Module["_FPDFPath_LineTo"] = Module["asm"]["FPDFPath_LineTo"]).apply(null, arguments)
        };
        var _FPDFPath_BezierTo = Module["_FPDFPath_BezierTo"] = function () {
            return (_FPDFPath_BezierTo = Module["_FPDFPath_BezierTo"] = Module["asm"]["FPDFPath_BezierTo"]).apply(null, arguments)
        };
        var _FPDFPath_Close = Module["_FPDFPath_Close"] = function () {
            return (_FPDFPath_Close = Module["_FPDFPath_Close"] = Module["asm"]["FPDFPath_Close"]).apply(null, arguments)
        };
        var _FPDFPath_SetDrawMode = Module["_FPDFPath_SetDrawMode"] = function () {
            return (_FPDFPath_SetDrawMode = Module["_FPDFPath_SetDrawMode"] = Module["asm"]["FPDFPath_SetDrawMode"]).apply(null, arguments)
        };
        var _FPDFPath_GetDrawMode = Module["_FPDFPath_GetDrawMode"] = function () {
            return (_FPDFPath_GetDrawMode = Module["_FPDFPath_GetDrawMode"] = Module["asm"]["FPDFPath_GetDrawMode"]).apply(null, arguments)
        };
        var _FPDFPathSegment_GetPoint = Module["_FPDFPathSegment_GetPoint"] = function () {
            return (_FPDFPathSegment_GetPoint = Module["_FPDFPathSegment_GetPoint"] = Module["asm"]["FPDFPathSegment_GetPoint"]).apply(null, arguments)
        };
        var _FPDFPathSegment_GetType = Module["_FPDFPathSegment_GetType"] = function () {
            return (_FPDFPathSegment_GetType = Module["_FPDFPathSegment_GetType"] = Module["asm"]["FPDFPathSegment_GetType"]).apply(null, arguments)
        };
        var _FPDFPathSegment_GetClose = Module["_FPDFPathSegment_GetClose"] = function () {
            return (_FPDFPathSegment_GetClose = Module["_FPDFPathSegment_GetClose"] = Module["asm"]["FPDFPathSegment_GetClose"]).apply(null, arguments)
        };
        var _FPDFPageObj_NewTextObj = Module["_FPDFPageObj_NewTextObj"] = function () {
            return (_FPDFPageObj_NewTextObj = Module["_FPDFPageObj_NewTextObj"] = Module["asm"]["FPDFPageObj_NewTextObj"]).apply(null, arguments)
        };
        var _FPDFText_SetText = Module["_FPDFText_SetText"] = function () {
            return (_FPDFText_SetText = Module["_FPDFText_SetText"] = Module["asm"]["FPDFText_SetText"]).apply(null, arguments)
        };
        var _FPDFText_SetCharcodes = Module["_FPDFText_SetCharcodes"] = function () {
            return (_FPDFText_SetCharcodes = Module["_FPDFText_SetCharcodes"] = Module["asm"]["FPDFText_SetCharcodes"]).apply(null, arguments)
        };
        var _FPDFText_LoadFont = Module["_FPDFText_LoadFont"] = function () {
            return (_FPDFText_LoadFont = Module["_FPDFText_LoadFont"] = Module["asm"]["FPDFText_LoadFont"]).apply(null, arguments)
        };
        var _FPDFText_LoadStandardFont = Module["_FPDFText_LoadStandardFont"] = function () {
            return (_FPDFText_LoadStandardFont = Module["_FPDFText_LoadStandardFont"] = Module["asm"]["FPDFText_LoadStandardFont"]).apply(null, arguments)
        };
        var _FPDFTextObj_GetFontSize = Module["_FPDFTextObj_GetFontSize"] = function () {
            return (_FPDFTextObj_GetFontSize = Module["_FPDFTextObj_GetFontSize"] = Module["asm"]["FPDFTextObj_GetFontSize"]).apply(null, arguments)
        };
        var _FPDFTextObj_GetText = Module["_FPDFTextObj_GetText"] = function () {
            return (_FPDFTextObj_GetText = Module["_FPDFTextObj_GetText"] = Module["asm"]["FPDFTextObj_GetText"]).apply(null, arguments)
        };
        var _FPDFTextObj_GetRenderedBitmap = Module["_FPDFTextObj_GetRenderedBitmap"] = function () {
            return (_FPDFTextObj_GetRenderedBitmap = Module["_FPDFTextObj_GetRenderedBitmap"] = Module["asm"]["FPDFTextObj_GetRenderedBitmap"]).apply(null, arguments)
        };
        var _FPDFFont_Close = Module["_FPDFFont_Close"] = function () {
            return (_FPDFFont_Close = Module["_FPDFFont_Close"] = Module["asm"]["FPDFFont_Close"]).apply(null, arguments)
        };
        var _FPDFPageObj_CreateTextObj = Module["_FPDFPageObj_CreateTextObj"] = function () {
            return (_FPDFPageObj_CreateTextObj = Module["_FPDFPageObj_CreateTextObj"] = Module["asm"]["FPDFPageObj_CreateTextObj"]).apply(null, arguments)
        };
        var _FPDFTextObj_GetTextRenderMode = Module["_FPDFTextObj_GetTextRenderMode"] = function () {
            return (_FPDFTextObj_GetTextRenderMode = Module["_FPDFTextObj_GetTextRenderMode"] = Module["asm"]["FPDFTextObj_GetTextRenderMode"]).apply(null, arguments)
        };
        var _FPDFTextObj_SetTextRenderMode = Module["_FPDFTextObj_SetTextRenderMode"] = function () {
            return (_FPDFTextObj_SetTextRenderMode = Module["_FPDFTextObj_SetTextRenderMode"] = Module["asm"]["FPDFTextObj_SetTextRenderMode"]).apply(null, arguments)
        };
        var _FPDFTextObj_GetFont = Module["_FPDFTextObj_GetFont"] = function () {
            return (_FPDFTextObj_GetFont = Module["_FPDFTextObj_GetFont"] = Module["asm"]["FPDFTextObj_GetFont"]).apply(null, arguments)
        };
        var _FPDFFont_GetFontName = Module["_FPDFFont_GetFontName"] = function () {
            return (_FPDFFont_GetFontName = Module["_FPDFFont_GetFontName"] = Module["asm"]["FPDFFont_GetFontName"]).apply(null, arguments)
        };
        var _FPDFFont_GetFontData = Module["_FPDFFont_GetFontData"] = function () {
            return (_FPDFFont_GetFontData = Module["_FPDFFont_GetFontData"] = Module["asm"]["FPDFFont_GetFontData"]).apply(null, arguments)
        };
        var _FPDFFont_GetIsEmbedded = Module["_FPDFFont_GetIsEmbedded"] = function () {
            return (_FPDFFont_GetIsEmbedded = Module["_FPDFFont_GetIsEmbedded"] = Module["asm"]["FPDFFont_GetIsEmbedded"]).apply(null, arguments)
        };
        var _FPDFFont_GetFlags = Module["_FPDFFont_GetFlags"] = function () {
            return (_FPDFFont_GetFlags = Module["_FPDFFont_GetFlags"] = Module["asm"]["FPDFFont_GetFlags"]).apply(null, arguments)
        };
        var _FPDFFont_GetWeight = Module["_FPDFFont_GetWeight"] = function () {
            return (_FPDFFont_GetWeight = Module["_FPDFFont_GetWeight"] = Module["asm"]["FPDFFont_GetWeight"]).apply(null, arguments)
        };
        var _FPDFFont_GetItalicAngle = Module["_FPDFFont_GetItalicAngle"] = function () {
            return (_FPDFFont_GetItalicAngle = Module["_FPDFFont_GetItalicAngle"] = Module["asm"]["FPDFFont_GetItalicAngle"]).apply(null, arguments)
        };
        var _FPDFFont_GetAscent = Module["_FPDFFont_GetAscent"] = function () {
            return (_FPDFFont_GetAscent = Module["_FPDFFont_GetAscent"] = Module["asm"]["FPDFFont_GetAscent"]).apply(null, arguments)
        };
        var _FPDFFont_GetDescent = Module["_FPDFFont_GetDescent"] = function () {
            return (_FPDFFont_GetDescent = Module["_FPDFFont_GetDescent"] = Module["asm"]["FPDFFont_GetDescent"]).apply(null, arguments)
        };
        var _FPDFFont_GetGlyphWidth = Module["_FPDFFont_GetGlyphWidth"] = function () {
            return (_FPDFFont_GetGlyphWidth = Module["_FPDFFont_GetGlyphWidth"] = Module["asm"]["FPDFFont_GetGlyphWidth"]).apply(null, arguments)
        };
        var _FPDFFont_GetGlyphPath = Module["_FPDFFont_GetGlyphPath"] = function () {
            return (_FPDFFont_GetGlyphPath = Module["_FPDFFont_GetGlyphPath"] = Module["asm"]["FPDFFont_GetGlyphPath"]).apply(null, arguments)
        };
        var _FPDFGlyphPath_CountGlyphSegments = Module["_FPDFGlyphPath_CountGlyphSegments"] = function () {
            return (_FPDFGlyphPath_CountGlyphSegments = Module["_FPDFGlyphPath_CountGlyphSegments"] = Module["asm"]["FPDFGlyphPath_CountGlyphSegments"]).apply(null, arguments)
        };
        var _FPDFGlyphPath_GetGlyphPathSegment = Module["_FPDFGlyphPath_GetGlyphPathSegment"] = function () {
            return (_FPDFGlyphPath_GetGlyphPathSegment = Module["_FPDFGlyphPath_GetGlyphPathSegment"] = Module["asm"]["FPDFGlyphPath_GetGlyphPathSegment"]).apply(null, arguments)
        };
        var _FSDK_SetUnSpObjProcessHandler = Module["_FSDK_SetUnSpObjProcessHandler"] = function () {
            return (_FSDK_SetUnSpObjProcessHandler = Module["_FSDK_SetUnSpObjProcessHandler"] = Module["asm"]["FSDK_SetUnSpObjProcessHandler"]).apply(null, arguments)
        };
        var _FSDK_SetTimeFunction = Module["_FSDK_SetTimeFunction"] = function () {
            return (_FSDK_SetTimeFunction = Module["_FSDK_SetTimeFunction"] = Module["asm"]["FSDK_SetTimeFunction"]).apply(null, arguments)
        };
        var _FSDK_SetLocaltimeFunction = Module["_FSDK_SetLocaltimeFunction"] = function () {
            return (_FSDK_SetLocaltimeFunction = Module["_FSDK_SetLocaltimeFunction"] = Module["asm"]["FSDK_SetLocaltimeFunction"]).apply(null, arguments)
        };
        var _FPDFDoc_GetPageMode = Module["_FPDFDoc_GetPageMode"] = function () {
            return (_FPDFDoc_GetPageMode = Module["_FPDFDoc_GetPageMode"] = Module["asm"]["FPDFDoc_GetPageMode"]).apply(null, arguments)
        };
        var _FPDFPage_Flatten = Module["_FPDFPage_Flatten"] = function () {
            return (_FPDFPage_Flatten = Module["_FPDFPage_Flatten"] = Module["asm"]["FPDFPage_Flatten"]).apply(null, arguments)
        };
        var _FPDFPage_HasFormFieldAtPoint = Module["_FPDFPage_HasFormFieldAtPoint"] = function () {
            return (_FPDFPage_HasFormFieldAtPoint = Module["_FPDFPage_HasFormFieldAtPoint"] = Module["asm"]["FPDFPage_HasFormFieldAtPoint"]).apply(null, arguments)
        };
        var _FPDFPage_FormFieldZOrderAtPoint = Module["_FPDFPage_FormFieldZOrderAtPoint"] = function () {
            return (_FPDFPage_FormFieldZOrderAtPoint = Module["_FPDFPage_FormFieldZOrderAtPoint"] = Module["asm"]["FPDFPage_FormFieldZOrderAtPoint"]).apply(null, arguments)
        };
        var _FPDFDOC_InitFormFillEnvironment = Module["_FPDFDOC_InitFormFillEnvironment"] = function () {
            return (_FPDFDOC_InitFormFillEnvironment = Module["_FPDFDOC_InitFormFillEnvironment"] = Module["asm"]["FPDFDOC_InitFormFillEnvironment"]).apply(null, arguments)
        };
        var _FPDFDOC_ExitFormFillEnvironment = Module["_FPDFDOC_ExitFormFillEnvironment"] = function () {
            return (_FPDFDOC_ExitFormFillEnvironment = Module["_FPDFDOC_ExitFormFillEnvironment"] = Module["asm"]["FPDFDOC_ExitFormFillEnvironment"]).apply(null, arguments)
        };
        var _FORM_OnMouseMove = Module["_FORM_OnMouseMove"] = function () {
            return (_FORM_OnMouseMove = Module["_FORM_OnMouseMove"] = Module["asm"]["FORM_OnMouseMove"]).apply(null, arguments)
        };
        var _FORM_OnMouseWheel = Module["_FORM_OnMouseWheel"] = function () {
            return (_FORM_OnMouseWheel = Module["_FORM_OnMouseWheel"] = Module["asm"]["FORM_OnMouseWheel"]).apply(null, arguments)
        };
        var _FORM_OnFocus = Module["_FORM_OnFocus"] = function () {
            return (_FORM_OnFocus = Module["_FORM_OnFocus"] = Module["asm"]["FORM_OnFocus"]).apply(null, arguments)
        };
        var _FORM_OnLButtonDown = Module["_FORM_OnLButtonDown"] = function () {
            return (_FORM_OnLButtonDown = Module["_FORM_OnLButtonDown"] = Module["asm"]["FORM_OnLButtonDown"]).apply(null, arguments)
        };
        var _FORM_OnLButtonUp = Module["_FORM_OnLButtonUp"] = function () {
            return (_FORM_OnLButtonUp = Module["_FORM_OnLButtonUp"] = Module["asm"]["FORM_OnLButtonUp"]).apply(null, arguments)
        };
        var _FORM_OnLButtonDoubleClick = Module["_FORM_OnLButtonDoubleClick"] = function () {
            return (_FORM_OnLButtonDoubleClick = Module["_FORM_OnLButtonDoubleClick"] = Module["asm"]["FORM_OnLButtonDoubleClick"]).apply(null, arguments)
        };
        var _FORM_OnRButtonDown = Module["_FORM_OnRButtonDown"] = function () {
            return (_FORM_OnRButtonDown = Module["_FORM_OnRButtonDown"] = Module["asm"]["FORM_OnRButtonDown"]).apply(null, arguments)
        };
        var _FORM_OnRButtonUp = Module["_FORM_OnRButtonUp"] = function () {
            return (_FORM_OnRButtonUp = Module["_FORM_OnRButtonUp"] = Module["asm"]["FORM_OnRButtonUp"]).apply(null, arguments)
        };
        var _FORM_OnKeyDown = Module["_FORM_OnKeyDown"] = function () {
            return (_FORM_OnKeyDown = Module["_FORM_OnKeyDown"] = Module["asm"]["FORM_OnKeyDown"]).apply(null, arguments)
        };
        var _FORM_OnKeyUp = Module["_FORM_OnKeyUp"] = function () {
            return (_FORM_OnKeyUp = Module["_FORM_OnKeyUp"] = Module["asm"]["FORM_OnKeyUp"]).apply(null, arguments)
        };
        var _FORM_OnChar = Module["_FORM_OnChar"] = function () {
            return (_FORM_OnChar = Module["_FORM_OnChar"] = Module["asm"]["FORM_OnChar"]).apply(null, arguments)
        };
        var _FORM_GetFocusedText = Module["_FORM_GetFocusedText"] = function () {
            return (_FORM_GetFocusedText = Module["_FORM_GetFocusedText"] = Module["asm"]["FORM_GetFocusedText"]).apply(null, arguments)
        };
        var _FORM_GetSelectedText = Module["_FORM_GetSelectedText"] = function () {
            return (_FORM_GetSelectedText = Module["_FORM_GetSelectedText"] = Module["asm"]["FORM_GetSelectedText"]).apply(null, arguments)
        };
        var _FORM_ReplaceAndKeepSelection = Module["_FORM_ReplaceAndKeepSelection"] = function () {
            return (_FORM_ReplaceAndKeepSelection = Module["_FORM_ReplaceAndKeepSelection"] = Module["asm"]["FORM_ReplaceAndKeepSelection"]).apply(null, arguments)
        };
        var _FORM_ReplaceSelection = Module["_FORM_ReplaceSelection"] = function () {
            return (_FORM_ReplaceSelection = Module["_FORM_ReplaceSelection"] = Module["asm"]["FORM_ReplaceSelection"]).apply(null, arguments)
        };
        var _FORM_SelectAllText = Module["_FORM_SelectAllText"] = function () {
            return (_FORM_SelectAllText = Module["_FORM_SelectAllText"] = Module["asm"]["FORM_SelectAllText"]).apply(null, arguments)
        };
        var _FORM_CanUndo = Module["_FORM_CanUndo"] = function () {
            return (_FORM_CanUndo = Module["_FORM_CanUndo"] = Module["asm"]["FORM_CanUndo"]).apply(null, arguments)
        };
        var _FORM_CanRedo = Module["_FORM_CanRedo"] = function () {
            return (_FORM_CanRedo = Module["_FORM_CanRedo"] = Module["asm"]["FORM_CanRedo"]).apply(null, arguments)
        };
        var _FORM_Undo = Module["_FORM_Undo"] = function () {
            return (_FORM_Undo = Module["_FORM_Undo"] = Module["asm"]["FORM_Undo"]).apply(null, arguments)
        };
        var _FORM_Redo = Module["_FORM_Redo"] = function () {
            return (_FORM_Redo = Module["_FORM_Redo"] = Module["asm"]["FORM_Redo"]).apply(null, arguments)
        };
        var _FORM_ForceToKillFocus = Module["_FORM_ForceToKillFocus"] = function () {
            return (_FORM_ForceToKillFocus = Module["_FORM_ForceToKillFocus"] = Module["asm"]["FORM_ForceToKillFocus"]).apply(null, arguments)
        };
        var _FORM_GetFocusedAnnot = Module["_FORM_GetFocusedAnnot"] = function () {
            return (_FORM_GetFocusedAnnot = Module["_FORM_GetFocusedAnnot"] = Module["asm"]["FORM_GetFocusedAnnot"]).apply(null, arguments)
        };
        var _FORM_SetFocusedAnnot = Module["_FORM_SetFocusedAnnot"] = function () {
            return (_FORM_SetFocusedAnnot = Module["_FORM_SetFocusedAnnot"] = Module["asm"]["FORM_SetFocusedAnnot"]).apply(null, arguments)
        };
        var _FPDF_FFLDraw = Module["_FPDF_FFLDraw"] = function () {
            return (_FPDF_FFLDraw = Module["_FPDF_FFLDraw"] = Module["asm"]["FPDF_FFLDraw"]).apply(null, arguments)
        };
        var _FPDF_SetFormFieldHighlightColor = Module["_FPDF_SetFormFieldHighlightColor"] = function () {
            return (_FPDF_SetFormFieldHighlightColor = Module["_FPDF_SetFormFieldHighlightColor"] = Module["asm"]["FPDF_SetFormFieldHighlightColor"]).apply(null, arguments)
        };
        var _FPDF_SetFormFieldHighlightAlpha = Module["_FPDF_SetFormFieldHighlightAlpha"] = function () {
            return (_FPDF_SetFormFieldHighlightAlpha = Module["_FPDF_SetFormFieldHighlightAlpha"] = Module["asm"]["FPDF_SetFormFieldHighlightAlpha"]).apply(null, arguments)
        };
        var _FPDF_RemoveFormFieldHighlight = Module["_FPDF_RemoveFormFieldHighlight"] = function () {
            return (_FPDF_RemoveFormFieldHighlight = Module["_FPDF_RemoveFormFieldHighlight"] = Module["asm"]["FPDF_RemoveFormFieldHighlight"]).apply(null, arguments)
        };
        var _FORM_OnAfterLoadPage = Module["_FORM_OnAfterLoadPage"] = function () {
            return (_FORM_OnAfterLoadPage = Module["_FORM_OnAfterLoadPage"] = Module["asm"]["FORM_OnAfterLoadPage"]).apply(null, arguments)
        };
        var _FORM_OnBeforeClosePage = Module["_FORM_OnBeforeClosePage"] = function () {
            return (_FORM_OnBeforeClosePage = Module["_FORM_OnBeforeClosePage"] = Module["asm"]["FORM_OnBeforeClosePage"]).apply(null, arguments)
        };
        var _FORM_DoDocumentJSAction = Module["_FORM_DoDocumentJSAction"] = function () {
            return (_FORM_DoDocumentJSAction = Module["_FORM_DoDocumentJSAction"] = Module["asm"]["FORM_DoDocumentJSAction"]).apply(null, arguments)
        };
        var _FORM_DoDocumentOpenAction = Module["_FORM_DoDocumentOpenAction"] = function () {
            return (_FORM_DoDocumentOpenAction = Module["_FORM_DoDocumentOpenAction"] = Module["asm"]["FORM_DoDocumentOpenAction"]).apply(null, arguments)
        };
        var _FORM_DoDocumentAAction = Module["_FORM_DoDocumentAAction"] = function () {
            return (_FORM_DoDocumentAAction = Module["_FORM_DoDocumentAAction"] = Module["asm"]["FORM_DoDocumentAAction"]).apply(null, arguments)
        };
        var _FORM_DoPageAAction = Module["_FORM_DoPageAAction"] = function () {
            return (_FORM_DoPageAAction = Module["_FORM_DoPageAAction"] = Module["asm"]["FORM_DoPageAAction"]).apply(null, arguments)
        };
        var _FORM_SetIndexSelected = Module["_FORM_SetIndexSelected"] = function () {
            return (_FORM_SetIndexSelected = Module["_FORM_SetIndexSelected"] = Module["asm"]["FORM_SetIndexSelected"]).apply(null, arguments)
        };
        var _FORM_IsIndexSelected = Module["_FORM_IsIndexSelected"] = function () {
            return (_FORM_IsIndexSelected = Module["_FORM_IsIndexSelected"] = Module["asm"]["FORM_IsIndexSelected"]).apply(null, arguments)
        };
        var _FPDFDoc_GetJavaScriptActionCount = Module["_FPDFDoc_GetJavaScriptActionCount"] = function () {
            return (_FPDFDoc_GetJavaScriptActionCount = Module["_FPDFDoc_GetJavaScriptActionCount"] = Module["asm"]["FPDFDoc_GetJavaScriptActionCount"]).apply(null, arguments)
        };
        var _FPDFDoc_GetJavaScriptAction = Module["_FPDFDoc_GetJavaScriptAction"] = function () {
            return (_FPDFDoc_GetJavaScriptAction = Module["_FPDFDoc_GetJavaScriptAction"] = Module["asm"]["FPDFDoc_GetJavaScriptAction"]).apply(null, arguments)
        };
        var _FPDFDoc_CloseJavaScriptAction = Module["_FPDFDoc_CloseJavaScriptAction"] = function () {
            return (_FPDFDoc_CloseJavaScriptAction = Module["_FPDFDoc_CloseJavaScriptAction"] = Module["asm"]["FPDFDoc_CloseJavaScriptAction"]).apply(null, arguments)
        };
        var _FPDFJavaScriptAction_GetName = Module["_FPDFJavaScriptAction_GetName"] = function () {
            return (_FPDFJavaScriptAction_GetName = Module["_FPDFJavaScriptAction_GetName"] = Module["asm"]["FPDFJavaScriptAction_GetName"]).apply(null, arguments)
        };
        var _FPDFJavaScriptAction_GetScript = Module["_FPDFJavaScriptAction_GetScript"] = function () {
            return (_FPDFJavaScriptAction_GetScript = Module["_FPDFJavaScriptAction_GetScript"] = Module["asm"]["FPDFJavaScriptAction_GetScript"]).apply(null, arguments)
        };
        var _FPDF_ImportPagesByIndex = Module["_FPDF_ImportPagesByIndex"] = function () {
            return (_FPDF_ImportPagesByIndex = Module["_FPDF_ImportPagesByIndex"] = Module["asm"]["FPDF_ImportPagesByIndex"]).apply(null, arguments)
        };
        var _FPDF_ImportPages = Module["_FPDF_ImportPages"] = function () {
            return (_FPDF_ImportPages = Module["_FPDF_ImportPages"] = Module["asm"]["FPDF_ImportPages"]).apply(null, arguments)
        };
        var _FPDF_ImportNPagesToOne = Module["_FPDF_ImportNPagesToOne"] = function () {
            return (_FPDF_ImportNPagesToOne = Module["_FPDF_ImportNPagesToOne"] = Module["asm"]["FPDF_ImportNPagesToOne"]).apply(null, arguments)
        };
        var _FPDF_NewXObjectFromPage = Module["_FPDF_NewXObjectFromPage"] = function () {
            return (_FPDF_NewXObjectFromPage = Module["_FPDF_NewXObjectFromPage"] = Module["asm"]["FPDF_NewXObjectFromPage"]).apply(null, arguments)
        };
        var _FPDF_CloseXObject = Module["_FPDF_CloseXObject"] = function () {
            return (_FPDF_CloseXObject = Module["_FPDF_CloseXObject"] = Module["asm"]["FPDF_CloseXObject"]).apply(null, arguments)
        };
        var _FPDF_NewFormObjectFromXObject = Module["_FPDF_NewFormObjectFromXObject"] = function () {
            return (_FPDF_NewFormObjectFromXObject = Module["_FPDF_NewFormObjectFromXObject"] = Module["asm"]["FPDF_NewFormObjectFromXObject"]).apply(null, arguments)
        };
        var _FPDF_CopyViewerPreferences = Module["_FPDF_CopyViewerPreferences"] = function () {
            return (_FPDF_CopyViewerPreferences = Module["_FPDF_CopyViewerPreferences"] = Module["asm"]["FPDF_CopyViewerPreferences"]).apply(null, arguments)
        };
        var _FPDF_RenderPageBitmapWithColorScheme_Start = Module["_FPDF_RenderPageBitmapWithColorScheme_Start"] = function () {
            return (_FPDF_RenderPageBitmapWithColorScheme_Start = Module["_FPDF_RenderPageBitmapWithColorScheme_Start"] = Module["asm"]["FPDF_RenderPageBitmapWithColorScheme_Start"]).apply(null, arguments)
        };
        var _FPDF_RenderPageBitmap_Start = Module["_FPDF_RenderPageBitmap_Start"] = function () {
            return (_FPDF_RenderPageBitmap_Start = Module["_FPDF_RenderPageBitmap_Start"] = Module["asm"]["FPDF_RenderPageBitmap_Start"]).apply(null, arguments)
        };
        var _FPDF_RenderPage_Continue = Module["_FPDF_RenderPage_Continue"] = function () {
            return (_FPDF_RenderPage_Continue = Module["_FPDF_RenderPage_Continue"] = Module["asm"]["FPDF_RenderPage_Continue"]).apply(null, arguments)
        };
        var _FPDF_RenderPage_Close = Module["_FPDF_RenderPage_Close"] = function () {
            return (_FPDF_RenderPage_Close = Module["_FPDF_RenderPage_Close"] = Module["asm"]["FPDF_RenderPage_Close"]).apply(null, arguments)
        };
        var _FPDF_SaveAsCopy = Module["_FPDF_SaveAsCopy"] = function () {
            return (_FPDF_SaveAsCopy = Module["_FPDF_SaveAsCopy"] = Module["asm"]["FPDF_SaveAsCopy"]).apply(null, arguments)
        };
        var _FPDF_SaveWithVersion = Module["_FPDF_SaveWithVersion"] = function () {
            return (_FPDF_SaveWithVersion = Module["_FPDF_SaveWithVersion"] = Module["asm"]["FPDF_SaveWithVersion"]).apply(null, arguments)
        };
        var _FPDFText_GetCharIndexFromTextIndex = Module["_FPDFText_GetCharIndexFromTextIndex"] = function () {
            return (_FPDFText_GetCharIndexFromTextIndex = Module["_FPDFText_GetCharIndexFromTextIndex"] = Module["asm"]["FPDFText_GetCharIndexFromTextIndex"]).apply(null, arguments)
        };
        var _FPDFText_GetTextIndexFromCharIndex = Module["_FPDFText_GetTextIndexFromCharIndex"] = function () {
            return (_FPDFText_GetTextIndexFromCharIndex = Module["_FPDFText_GetTextIndexFromCharIndex"] = Module["asm"]["FPDFText_GetTextIndexFromCharIndex"]).apply(null, arguments)
        };
        var _FPDF_GetSignatureCount = Module["_FPDF_GetSignatureCount"] = function () {
            return (_FPDF_GetSignatureCount = Module["_FPDF_GetSignatureCount"] = Module["asm"]["FPDF_GetSignatureCount"]).apply(null, arguments)
        };
        var _FPDF_GetSignatureObject = Module["_FPDF_GetSignatureObject"] = function () {
            return (_FPDF_GetSignatureObject = Module["_FPDF_GetSignatureObject"] = Module["asm"]["FPDF_GetSignatureObject"]).apply(null, arguments)
        };
        var _FPDFSignatureObj_GetContents = Module["_FPDFSignatureObj_GetContents"] = function () {
            return (_FPDFSignatureObj_GetContents = Module["_FPDFSignatureObj_GetContents"] = Module["asm"]["FPDFSignatureObj_GetContents"]).apply(null, arguments)
        };
        var _FPDFSignatureObj_GetByteRange = Module["_FPDFSignatureObj_GetByteRange"] = function () {
            return (_FPDFSignatureObj_GetByteRange = Module["_FPDFSignatureObj_GetByteRange"] = Module["asm"]["FPDFSignatureObj_GetByteRange"]).apply(null, arguments)
        };
        var _FPDFSignatureObj_GetSubFilter = Module["_FPDFSignatureObj_GetSubFilter"] = function () {
            return (_FPDFSignatureObj_GetSubFilter = Module["_FPDFSignatureObj_GetSubFilter"] = Module["asm"]["FPDFSignatureObj_GetSubFilter"]).apply(null, arguments)
        };
        var _FPDFSignatureObj_GetReason = Module["_FPDFSignatureObj_GetReason"] = function () {
            return (_FPDFSignatureObj_GetReason = Module["_FPDFSignatureObj_GetReason"] = Module["asm"]["FPDFSignatureObj_GetReason"]).apply(null, arguments)
        };
        var _FPDFSignatureObj_GetTime = Module["_FPDFSignatureObj_GetTime"] = function () {
            return (_FPDFSignatureObj_GetTime = Module["_FPDFSignatureObj_GetTime"] = Module["asm"]["FPDFSignatureObj_GetTime"]).apply(null, arguments)
        };
        var _FPDFSignatureObj_GetDocMDPPermission = Module["_FPDFSignatureObj_GetDocMDPPermission"] = function () {
            return (_FPDFSignatureObj_GetDocMDPPermission = Module["_FPDFSignatureObj_GetDocMDPPermission"] = Module["asm"]["FPDFSignatureObj_GetDocMDPPermission"]).apply(null, arguments)
        };
        var _FPDF_StructTree_GetForPage = Module["_FPDF_StructTree_GetForPage"] = function () {
            return (_FPDF_StructTree_GetForPage = Module["_FPDF_StructTree_GetForPage"] = Module["asm"]["FPDF_StructTree_GetForPage"]).apply(null, arguments)
        };
        var _FPDF_StructTree_Close = Module["_FPDF_StructTree_Close"] = function () {
            return (_FPDF_StructTree_Close = Module["_FPDF_StructTree_Close"] = Module["asm"]["FPDF_StructTree_Close"]).apply(null, arguments)
        };
        var _FPDF_StructTree_CountChildren = Module["_FPDF_StructTree_CountChildren"] = function () {
            return (_FPDF_StructTree_CountChildren = Module["_FPDF_StructTree_CountChildren"] = Module["asm"]["FPDF_StructTree_CountChildren"]).apply(null, arguments)
        };
        var _FPDF_StructTree_GetChildAtIndex = Module["_FPDF_StructTree_GetChildAtIndex"] = function () {
            return (_FPDF_StructTree_GetChildAtIndex = Module["_FPDF_StructTree_GetChildAtIndex"] = Module["asm"]["FPDF_StructTree_GetChildAtIndex"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetAltText = Module["_FPDF_StructElement_GetAltText"] = function () {
            return (_FPDF_StructElement_GetAltText = Module["_FPDF_StructElement_GetAltText"] = Module["asm"]["FPDF_StructElement_GetAltText"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetActualText = Module["_FPDF_StructElement_GetActualText"] = function () {
            return (_FPDF_StructElement_GetActualText = Module["_FPDF_StructElement_GetActualText"] = Module["asm"]["FPDF_StructElement_GetActualText"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetID = Module["_FPDF_StructElement_GetID"] = function () {
            return (_FPDF_StructElement_GetID = Module["_FPDF_StructElement_GetID"] = Module["asm"]["FPDF_StructElement_GetID"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetLang = Module["_FPDF_StructElement_GetLang"] = function () {
            return (_FPDF_StructElement_GetLang = Module["_FPDF_StructElement_GetLang"] = Module["asm"]["FPDF_StructElement_GetLang"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetAttributeCount = Module["_FPDF_StructElement_GetAttributeCount"] = function () {
            return (_FPDF_StructElement_GetAttributeCount = Module["_FPDF_StructElement_GetAttributeCount"] = Module["asm"]["FPDF_StructElement_GetAttributeCount"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetAttributeAtIndex = Module["_FPDF_StructElement_GetAttributeAtIndex"] = function () {
            return (_FPDF_StructElement_GetAttributeAtIndex = Module["_FPDF_StructElement_GetAttributeAtIndex"] = Module["asm"]["FPDF_StructElement_GetAttributeAtIndex"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetStringAttribute = Module["_FPDF_StructElement_GetStringAttribute"] = function () {
            return (_FPDF_StructElement_GetStringAttribute = Module["_FPDF_StructElement_GetStringAttribute"] = Module["asm"]["FPDF_StructElement_GetStringAttribute"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetMarkedContentID = Module["_FPDF_StructElement_GetMarkedContentID"] = function () {
            return (_FPDF_StructElement_GetMarkedContentID = Module["_FPDF_StructElement_GetMarkedContentID"] = Module["asm"]["FPDF_StructElement_GetMarkedContentID"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetType = Module["_FPDF_StructElement_GetType"] = function () {
            return (_FPDF_StructElement_GetType = Module["_FPDF_StructElement_GetType"] = Module["asm"]["FPDF_StructElement_GetType"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetObjType = Module["_FPDF_StructElement_GetObjType"] = function () {
            return (_FPDF_StructElement_GetObjType = Module["_FPDF_StructElement_GetObjType"] = Module["asm"]["FPDF_StructElement_GetObjType"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetTitle = Module["_FPDF_StructElement_GetTitle"] = function () {
            return (_FPDF_StructElement_GetTitle = Module["_FPDF_StructElement_GetTitle"] = Module["asm"]["FPDF_StructElement_GetTitle"]).apply(null, arguments)
        };
        var _FPDF_StructElement_CountChildren = Module["_FPDF_StructElement_CountChildren"] = function () {
            return (_FPDF_StructElement_CountChildren = Module["_FPDF_StructElement_CountChildren"] = Module["asm"]["FPDF_StructElement_CountChildren"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetChildAtIndex = Module["_FPDF_StructElement_GetChildAtIndex"] = function () {
            return (_FPDF_StructElement_GetChildAtIndex = Module["_FPDF_StructElement_GetChildAtIndex"] = Module["asm"]["FPDF_StructElement_GetChildAtIndex"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetParent = Module["_FPDF_StructElement_GetParent"] = function () {
            return (_FPDF_StructElement_GetParent = Module["_FPDF_StructElement_GetParent"] = Module["asm"]["FPDF_StructElement_GetParent"]).apply(null, arguments)
        };
        var _FPDF_StructElement_Attr_GetCount = Module["_FPDF_StructElement_Attr_GetCount"] = function () {
            return (_FPDF_StructElement_Attr_GetCount = Module["_FPDF_StructElement_Attr_GetCount"] = Module["asm"]["FPDF_StructElement_Attr_GetCount"]).apply(null, arguments)
        };
        var _FPDF_StructElement_Attr_GetName = Module["_FPDF_StructElement_Attr_GetName"] = function () {
            return (_FPDF_StructElement_Attr_GetName = Module["_FPDF_StructElement_Attr_GetName"] = Module["asm"]["FPDF_StructElement_Attr_GetName"]).apply(null, arguments)
        };
        var _FPDF_StructElement_Attr_GetType = Module["_FPDF_StructElement_Attr_GetType"] = function () {
            return (_FPDF_StructElement_Attr_GetType = Module["_FPDF_StructElement_Attr_GetType"] = Module["asm"]["FPDF_StructElement_Attr_GetType"]).apply(null, arguments)
        };
        var _FPDF_StructElement_Attr_GetBooleanValue = Module["_FPDF_StructElement_Attr_GetBooleanValue"] = function () {
            return (_FPDF_StructElement_Attr_GetBooleanValue = Module["_FPDF_StructElement_Attr_GetBooleanValue"] = Module["asm"]["FPDF_StructElement_Attr_GetBooleanValue"]).apply(null, arguments)
        };
        var _FPDF_StructElement_Attr_GetNumberValue = Module["_FPDF_StructElement_Attr_GetNumberValue"] = function () {
            return (_FPDF_StructElement_Attr_GetNumberValue = Module["_FPDF_StructElement_Attr_GetNumberValue"] = Module["asm"]["FPDF_StructElement_Attr_GetNumberValue"]).apply(null, arguments)
        };
        var _FPDF_StructElement_Attr_GetStringValue = Module["_FPDF_StructElement_Attr_GetStringValue"] = function () {
            return (_FPDF_StructElement_Attr_GetStringValue = Module["_FPDF_StructElement_Attr_GetStringValue"] = Module["asm"]["FPDF_StructElement_Attr_GetStringValue"]).apply(null, arguments)
        };
        var _FPDF_StructElement_Attr_GetBlobValue = Module["_FPDF_StructElement_Attr_GetBlobValue"] = function () {
            return (_FPDF_StructElement_Attr_GetBlobValue = Module["_FPDF_StructElement_Attr_GetBlobValue"] = Module["asm"]["FPDF_StructElement_Attr_GetBlobValue"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetMarkedContentIdCount = Module["_FPDF_StructElement_GetMarkedContentIdCount"] = function () {
            return (_FPDF_StructElement_GetMarkedContentIdCount = Module["_FPDF_StructElement_GetMarkedContentIdCount"] = Module["asm"]["FPDF_StructElement_GetMarkedContentIdCount"]).apply(null, arguments)
        };
        var _FPDF_StructElement_GetMarkedContentIdAtIndex = Module["_FPDF_StructElement_GetMarkedContentIdAtIndex"] = function () {
            return (_FPDF_StructElement_GetMarkedContentIdAtIndex = Module["_FPDF_StructElement_GetMarkedContentIdAtIndex"] = Module["asm"]["FPDF_StructElement_GetMarkedContentIdAtIndex"]).apply(null, arguments)
        };
        var _FPDF_AddInstalledFont = Module["_FPDF_AddInstalledFont"] = function () {
            return (_FPDF_AddInstalledFont = Module["_FPDF_AddInstalledFont"] = Module["asm"]["FPDF_AddInstalledFont"]).apply(null, arguments)
        };
        var _FPDF_SetSystemFontInfo = Module["_FPDF_SetSystemFontInfo"] = function () {
            return (_FPDF_SetSystemFontInfo = Module["_FPDF_SetSystemFontInfo"] = Module["asm"]["FPDF_SetSystemFontInfo"]).apply(null, arguments)
        };
        var _FPDF_GetDefaultTTFMap = Module["_FPDF_GetDefaultTTFMap"] = function () {
            return (_FPDF_GetDefaultTTFMap = Module["_FPDF_GetDefaultTTFMap"] = Module["asm"]["FPDF_GetDefaultTTFMap"]).apply(null, arguments)
        };
        var _FPDF_GetDefaultSystemFontInfo = Module["_FPDF_GetDefaultSystemFontInfo"] = function () {
            return (_FPDF_GetDefaultSystemFontInfo = Module["_FPDF_GetDefaultSystemFontInfo"] = Module["asm"]["FPDF_GetDefaultSystemFontInfo"]).apply(null, arguments)
        };
        var _FPDF_FreeDefaultSystemFontInfo = Module["_FPDF_FreeDefaultSystemFontInfo"] = function () {
            return (_FPDF_FreeDefaultSystemFontInfo = Module["_FPDF_FreeDefaultSystemFontInfo"] = Module["asm"]["FPDF_FreeDefaultSystemFontInfo"]).apply(null, arguments)
        };
        var _FPDFText_LoadPage = Module["_FPDFText_LoadPage"] = function () {
            return (_FPDFText_LoadPage = Module["_FPDFText_LoadPage"] = Module["asm"]["FPDFText_LoadPage"]).apply(null, arguments)
        };
        var _FPDFText_ClosePage = Module["_FPDFText_ClosePage"] = function () {
            return (_FPDFText_ClosePage = Module["_FPDFText_ClosePage"] = Module["asm"]["FPDFText_ClosePage"]).apply(null, arguments)
        };
        var _FPDFText_CountChars = Module["_FPDFText_CountChars"] = function () {
            return (_FPDFText_CountChars = Module["_FPDFText_CountChars"] = Module["asm"]["FPDFText_CountChars"]).apply(null, arguments)
        };
        var _FPDFText_GetUnicode = Module["_FPDFText_GetUnicode"] = function () {
            return (_FPDFText_GetUnicode = Module["_FPDFText_GetUnicode"] = Module["asm"]["FPDFText_GetUnicode"]).apply(null, arguments)
        };
        var _FPDFText_IsGenerated = Module["_FPDFText_IsGenerated"] = function () {
            return (_FPDFText_IsGenerated = Module["_FPDFText_IsGenerated"] = Module["asm"]["FPDFText_IsGenerated"]).apply(null, arguments)
        };
        var _FPDFText_HasUnicodeMapError = Module["_FPDFText_HasUnicodeMapError"] = function () {
            return (_FPDFText_HasUnicodeMapError = Module["_FPDFText_HasUnicodeMapError"] = Module["asm"]["FPDFText_HasUnicodeMapError"]).apply(null, arguments)
        };
        var _FPDFText_GetFontSize = Module["_FPDFText_GetFontSize"] = function () {
            return (_FPDFText_GetFontSize = Module["_FPDFText_GetFontSize"] = Module["asm"]["FPDFText_GetFontSize"]).apply(null, arguments)
        };
        var _FPDFText_GetFontInfo = Module["_FPDFText_GetFontInfo"] = function () {
            return (_FPDFText_GetFontInfo = Module["_FPDFText_GetFontInfo"] = Module["asm"]["FPDFText_GetFontInfo"]).apply(null, arguments)
        };
        var _FPDFText_GetFontWeight = Module["_FPDFText_GetFontWeight"] = function () {
            return (_FPDFText_GetFontWeight = Module["_FPDFText_GetFontWeight"] = Module["asm"]["FPDFText_GetFontWeight"]).apply(null, arguments)
        };
        var _FPDFText_GetTextRenderMode = Module["_FPDFText_GetTextRenderMode"] = function () {
            return (_FPDFText_GetTextRenderMode = Module["_FPDFText_GetTextRenderMode"] = Module["asm"]["FPDFText_GetTextRenderMode"]).apply(null, arguments)
        };
        var _FPDFText_GetFillColor = Module["_FPDFText_GetFillColor"] = function () {
            return (_FPDFText_GetFillColor = Module["_FPDFText_GetFillColor"] = Module["asm"]["FPDFText_GetFillColor"]).apply(null, arguments)
        };
        var _FPDFText_GetStrokeColor = Module["_FPDFText_GetStrokeColor"] = function () {
            return (_FPDFText_GetStrokeColor = Module["_FPDFText_GetStrokeColor"] = Module["asm"]["FPDFText_GetStrokeColor"]).apply(null, arguments)
        };
        var _FPDFText_GetCharAngle = Module["_FPDFText_GetCharAngle"] = function () {
            return (_FPDFText_GetCharAngle = Module["_FPDFText_GetCharAngle"] = Module["asm"]["FPDFText_GetCharAngle"]).apply(null, arguments)
        };
        var _FPDFText_GetCharBox = Module["_FPDFText_GetCharBox"] = function () {
            return (_FPDFText_GetCharBox = Module["_FPDFText_GetCharBox"] = Module["asm"]["FPDFText_GetCharBox"]).apply(null, arguments)
        };
        var _FPDFText_GetLooseCharBox = Module["_FPDFText_GetLooseCharBox"] = function () {
            return (_FPDFText_GetLooseCharBox = Module["_FPDFText_GetLooseCharBox"] = Module["asm"]["FPDFText_GetLooseCharBox"]).apply(null, arguments)
        };
        var _FPDFText_GetMatrix = Module["_FPDFText_GetMatrix"] = function () {
            return (_FPDFText_GetMatrix = Module["_FPDFText_GetMatrix"] = Module["asm"]["FPDFText_GetMatrix"]).apply(null, arguments)
        };
        var _FPDFText_GetCharOrigin = Module["_FPDFText_GetCharOrigin"] = function () {
            return (_FPDFText_GetCharOrigin = Module["_FPDFText_GetCharOrigin"] = Module["asm"]["FPDFText_GetCharOrigin"]).apply(null, arguments)
        };
        var _FPDFText_GetCharIndexAtPos = Module["_FPDFText_GetCharIndexAtPos"] = function () {
            return (_FPDFText_GetCharIndexAtPos = Module["_FPDFText_GetCharIndexAtPos"] = Module["asm"]["FPDFText_GetCharIndexAtPos"]).apply(null, arguments)
        };
        var _FPDFText_GetText = Module["_FPDFText_GetText"] = function () {
            return (_FPDFText_GetText = Module["_FPDFText_GetText"] = Module["asm"]["FPDFText_GetText"]).apply(null, arguments)
        };
        var _FPDFText_CountRects = Module["_FPDFText_CountRects"] = function () {
            return (_FPDFText_CountRects = Module["_FPDFText_CountRects"] = Module["asm"]["FPDFText_CountRects"]).apply(null, arguments)
        };
        var _FPDFText_GetRect = Module["_FPDFText_GetRect"] = function () {
            return (_FPDFText_GetRect = Module["_FPDFText_GetRect"] = Module["asm"]["FPDFText_GetRect"]).apply(null, arguments)
        };
        var _FPDFText_GetBoundedText = Module["_FPDFText_GetBoundedText"] = function () {
            return (_FPDFText_GetBoundedText = Module["_FPDFText_GetBoundedText"] = Module["asm"]["FPDFText_GetBoundedText"]).apply(null, arguments)
        };
        var _FPDFText_FindStart = Module["_FPDFText_FindStart"] = function () {
            return (_FPDFText_FindStart = Module["_FPDFText_FindStart"] = Module["asm"]["FPDFText_FindStart"]).apply(null, arguments)
        };
        var _FPDFText_FindNext = Module["_FPDFText_FindNext"] = function () {
            return (_FPDFText_FindNext = Module["_FPDFText_FindNext"] = Module["asm"]["FPDFText_FindNext"]).apply(null, arguments)
        };
        var _FPDFText_FindPrev = Module["_FPDFText_FindPrev"] = function () {
            return (_FPDFText_FindPrev = Module["_FPDFText_FindPrev"] = Module["asm"]["FPDFText_FindPrev"]).apply(null, arguments)
        };
        var _FPDFText_GetSchResultIndex = Module["_FPDFText_GetSchResultIndex"] = function () {
            return (_FPDFText_GetSchResultIndex = Module["_FPDFText_GetSchResultIndex"] = Module["asm"]["FPDFText_GetSchResultIndex"]).apply(null, arguments)
        };
        var _FPDFText_GetSchCount = Module["_FPDFText_GetSchCount"] = function () {
            return (_FPDFText_GetSchCount = Module["_FPDFText_GetSchCount"] = Module["asm"]["FPDFText_GetSchCount"]).apply(null, arguments)
        };
        var _FPDFText_FindClose = Module["_FPDFText_FindClose"] = function () {
            return (_FPDFText_FindClose = Module["_FPDFText_FindClose"] = Module["asm"]["FPDFText_FindClose"]).apply(null, arguments)
        };
        var _FPDFLink_LoadWebLinks = Module["_FPDFLink_LoadWebLinks"] = function () {
            return (_FPDFLink_LoadWebLinks = Module["_FPDFLink_LoadWebLinks"] = Module["asm"]["FPDFLink_LoadWebLinks"]).apply(null, arguments)
        };
        var _FPDFLink_CountWebLinks = Module["_FPDFLink_CountWebLinks"] = function () {
            return (_FPDFLink_CountWebLinks = Module["_FPDFLink_CountWebLinks"] = Module["asm"]["FPDFLink_CountWebLinks"]).apply(null, arguments)
        };
        var _FPDFLink_GetURL = Module["_FPDFLink_GetURL"] = function () {
            return (_FPDFLink_GetURL = Module["_FPDFLink_GetURL"] = Module["asm"]["FPDFLink_GetURL"]).apply(null, arguments)
        };
        var _FPDFLink_CountRects = Module["_FPDFLink_CountRects"] = function () {
            return (_FPDFLink_CountRects = Module["_FPDFLink_CountRects"] = Module["asm"]["FPDFLink_CountRects"]).apply(null, arguments)
        };
        var _FPDFLink_GetRect = Module["_FPDFLink_GetRect"] = function () {
            return (_FPDFLink_GetRect = Module["_FPDFLink_GetRect"] = Module["asm"]["FPDFLink_GetRect"]).apply(null, arguments)
        };
        var _FPDFLink_GetTextRange = Module["_FPDFLink_GetTextRange"] = function () {
            return (_FPDFLink_GetTextRange = Module["_FPDFLink_GetTextRange"] = Module["asm"]["FPDFLink_GetTextRange"]).apply(null, arguments)
        };
        var _FPDFLink_CloseWebLinks = Module["_FPDFLink_CloseWebLinks"] = function () {
            return (_FPDFLink_CloseWebLinks = Module["_FPDFLink_CloseWebLinks"] = Module["asm"]["FPDFLink_CloseWebLinks"]).apply(null, arguments)
        };
        var _FPDFPage_GetDecodedThumbnailData = Module["_FPDFPage_GetDecodedThumbnailData"] = function () {
            return (_FPDFPage_GetDecodedThumbnailData = Module["_FPDFPage_GetDecodedThumbnailData"] = Module["asm"]["FPDFPage_GetDecodedThumbnailData"]).apply(null, arguments)
        };
        var _FPDFPage_GetRawThumbnailData = Module["_FPDFPage_GetRawThumbnailData"] = function () {
            return (_FPDFPage_GetRawThumbnailData = Module["_FPDFPage_GetRawThumbnailData"] = Module["asm"]["FPDFPage_GetRawThumbnailData"]).apply(null, arguments)
        };
        var _FPDFPage_GetThumbnailAsBitmap = Module["_FPDFPage_GetThumbnailAsBitmap"] = function () {
            return (_FPDFPage_GetThumbnailAsBitmap = Module["_FPDFPage_GetThumbnailAsBitmap"] = Module["asm"]["FPDFPage_GetThumbnailAsBitmap"]).apply(null, arguments)
        };
        var _FPDFPage_SetMediaBox = Module["_FPDFPage_SetMediaBox"] = function () {
            return (_FPDFPage_SetMediaBox = Module["_FPDFPage_SetMediaBox"] = Module["asm"]["FPDFPage_SetMediaBox"]).apply(null, arguments)
        };
        var _FPDFPage_SetCropBox = Module["_FPDFPage_SetCropBox"] = function () {
            return (_FPDFPage_SetCropBox = Module["_FPDFPage_SetCropBox"] = Module["asm"]["FPDFPage_SetCropBox"]).apply(null, arguments)
        };
        var _FPDFPage_SetBleedBox = Module["_FPDFPage_SetBleedBox"] = function () {
            return (_FPDFPage_SetBleedBox = Module["_FPDFPage_SetBleedBox"] = Module["asm"]["FPDFPage_SetBleedBox"]).apply(null, arguments)
        };
        var _FPDFPage_SetTrimBox = Module["_FPDFPage_SetTrimBox"] = function () {
            return (_FPDFPage_SetTrimBox = Module["_FPDFPage_SetTrimBox"] = Module["asm"]["FPDFPage_SetTrimBox"]).apply(null, arguments)
        };
        var _FPDFPage_SetArtBox = Module["_FPDFPage_SetArtBox"] = function () {
            return (_FPDFPage_SetArtBox = Module["_FPDFPage_SetArtBox"] = Module["asm"]["FPDFPage_SetArtBox"]).apply(null, arguments)
        };
        var _FPDFPage_GetMediaBox = Module["_FPDFPage_GetMediaBox"] = function () {
            return (_FPDFPage_GetMediaBox = Module["_FPDFPage_GetMediaBox"] = Module["asm"]["FPDFPage_GetMediaBox"]).apply(null, arguments)
        };
        var _FPDFPage_GetCropBox = Module["_FPDFPage_GetCropBox"] = function () {
            return (_FPDFPage_GetCropBox = Module["_FPDFPage_GetCropBox"] = Module["asm"]["FPDFPage_GetCropBox"]).apply(null, arguments)
        };
        var _FPDFPage_GetBleedBox = Module["_FPDFPage_GetBleedBox"] = function () {
            return (_FPDFPage_GetBleedBox = Module["_FPDFPage_GetBleedBox"] = Module["asm"]["FPDFPage_GetBleedBox"]).apply(null, arguments)
        };
        var _FPDFPage_GetTrimBox = Module["_FPDFPage_GetTrimBox"] = function () {
            return (_FPDFPage_GetTrimBox = Module["_FPDFPage_GetTrimBox"] = Module["asm"]["FPDFPage_GetTrimBox"]).apply(null, arguments)
        };
        var _FPDFPage_GetArtBox = Module["_FPDFPage_GetArtBox"] = function () {
            return (_FPDFPage_GetArtBox = Module["_FPDFPage_GetArtBox"] = Module["asm"]["FPDFPage_GetArtBox"]).apply(null, arguments)
        };
        var _FPDFPage_TransFormWithClip = Module["_FPDFPage_TransFormWithClip"] = function () {
            return (_FPDFPage_TransFormWithClip = Module["_FPDFPage_TransFormWithClip"] = Module["asm"]["FPDFPage_TransFormWithClip"]).apply(null, arguments)
        };
        var _FPDFPageObj_TransformClipPath = Module["_FPDFPageObj_TransformClipPath"] = function () {
            return (_FPDFPageObj_TransformClipPath = Module["_FPDFPageObj_TransformClipPath"] = Module["asm"]["FPDFPageObj_TransformClipPath"]).apply(null, arguments)
        };
        var _FPDFPageObj_GetClipPath = Module["_FPDFPageObj_GetClipPath"] = function () {
            return (_FPDFPageObj_GetClipPath = Module["_FPDFPageObj_GetClipPath"] = Module["asm"]["FPDFPageObj_GetClipPath"]).apply(null, arguments)
        };
        var _FPDFClipPath_CountPaths = Module["_FPDFClipPath_CountPaths"] = function () {
            return (_FPDFClipPath_CountPaths = Module["_FPDFClipPath_CountPaths"] = Module["asm"]["FPDFClipPath_CountPaths"]).apply(null, arguments)
        };
        var _FPDFClipPath_CountPathSegments = Module["_FPDFClipPath_CountPathSegments"] = function () {
            return (_FPDFClipPath_CountPathSegments = Module["_FPDFClipPath_CountPathSegments"] = Module["asm"]["FPDFClipPath_CountPathSegments"]).apply(null, arguments)
        };
        var _FPDFClipPath_GetPathSegment = Module["_FPDFClipPath_GetPathSegment"] = function () {
            return (_FPDFClipPath_GetPathSegment = Module["_FPDFClipPath_GetPathSegment"] = Module["asm"]["FPDFClipPath_GetPathSegment"]).apply(null, arguments)
        };
        var _FPDF_CreateClipPath = Module["_FPDF_CreateClipPath"] = function () {
            return (_FPDF_CreateClipPath = Module["_FPDF_CreateClipPath"] = Module["asm"]["FPDF_CreateClipPath"]).apply(null, arguments)
        };
        var _FPDF_DestroyClipPath = Module["_FPDF_DestroyClipPath"] = function () {
            return (_FPDF_DestroyClipPath = Module["_FPDF_DestroyClipPath"] = Module["asm"]["FPDF_DestroyClipPath"]).apply(null, arguments)
        };
        var _FPDFPage_InsertClipPath = Module["_FPDFPage_InsertClipPath"] = function () {
            return (_FPDFPage_InsertClipPath = Module["_FPDFPage_InsertClipPath"] = Module["asm"]["FPDFPage_InsertClipPath"]).apply(null, arguments)
        };
        var _FPDF_InitLibrary = Module["_FPDF_InitLibrary"] = function () {
            return (_FPDF_InitLibrary = Module["_FPDF_InitLibrary"] = Module["asm"]["FPDF_InitLibrary"]).apply(null, arguments)
        };
        var _FPDF_InitLibraryWithConfig = Module["_FPDF_InitLibraryWithConfig"] = function () {
            return (_FPDF_InitLibraryWithConfig = Module["_FPDF_InitLibraryWithConfig"] = Module["asm"]["FPDF_InitLibraryWithConfig"]).apply(null, arguments)
        };
        var _FPDF_DestroyLibrary = Module["_FPDF_DestroyLibrary"] = function () {
            return (_FPDF_DestroyLibrary = Module["_FPDF_DestroyLibrary"] = Module["asm"]["FPDF_DestroyLibrary"]).apply(null, arguments)
        };
        var _FPDF_SetSandBoxPolicy = Module["_FPDF_SetSandBoxPolicy"] = function () {
            return (_FPDF_SetSandBoxPolicy = Module["_FPDF_SetSandBoxPolicy"] = Module["asm"]["FPDF_SetSandBoxPolicy"]).apply(null, arguments)
        };
        var _FPDF_LoadDocument = Module["_FPDF_LoadDocument"] = function () {
            return (_FPDF_LoadDocument = Module["_FPDF_LoadDocument"] = Module["asm"]["FPDF_LoadDocument"]).apply(null, arguments)
        };
        var _FPDF_GetFormType = Module["_FPDF_GetFormType"] = function () {
            return (_FPDF_GetFormType = Module["_FPDF_GetFormType"] = Module["asm"]["FPDF_GetFormType"]).apply(null, arguments)
        };
        var _FPDF_LoadXFA = Module["_FPDF_LoadXFA"] = function () {
            return (_FPDF_LoadXFA = Module["_FPDF_LoadXFA"] = Module["asm"]["FPDF_LoadXFA"]).apply(null, arguments)
        };
        var _FPDF_LoadMemDocument = Module["_FPDF_LoadMemDocument"] = function () {
            return (_FPDF_LoadMemDocument = Module["_FPDF_LoadMemDocument"] = Module["asm"]["FPDF_LoadMemDocument"]).apply(null, arguments)
        };
        var _FPDF_LoadMemDocument64 = Module["_FPDF_LoadMemDocument64"] = function () {
            return (_FPDF_LoadMemDocument64 = Module["_FPDF_LoadMemDocument64"] = Module["asm"]["FPDF_LoadMemDocument64"]).apply(null, arguments)
        };
        var _FPDF_LoadCustomDocument = Module["_FPDF_LoadCustomDocument"] = function () {
            return (_FPDF_LoadCustomDocument = Module["_FPDF_LoadCustomDocument"] = Module["asm"]["FPDF_LoadCustomDocument"]).apply(null, arguments)
        };
        var _FPDF_GetFileVersion = Module["_FPDF_GetFileVersion"] = function () {
            return (_FPDF_GetFileVersion = Module["_FPDF_GetFileVersion"] = Module["asm"]["FPDF_GetFileVersion"]).apply(null, arguments)
        };
        var _FPDF_DocumentHasValidCrossReferenceTable = Module["_FPDF_DocumentHasValidCrossReferenceTable"] = function () {
            return (_FPDF_DocumentHasValidCrossReferenceTable = Module["_FPDF_DocumentHasValidCrossReferenceTable"] = Module["asm"]["FPDF_DocumentHasValidCrossReferenceTable"]).apply(null, arguments)
        };
        var _FPDF_GetDocPermissions = Module["_FPDF_GetDocPermissions"] = function () {
            return (_FPDF_GetDocPermissions = Module["_FPDF_GetDocPermissions"] = Module["asm"]["FPDF_GetDocPermissions"]).apply(null, arguments)
        };
        var _FPDF_GetSecurityHandlerRevision = Module["_FPDF_GetSecurityHandlerRevision"] = function () {
            return (_FPDF_GetSecurityHandlerRevision = Module["_FPDF_GetSecurityHandlerRevision"] = Module["asm"]["FPDF_GetSecurityHandlerRevision"]).apply(null, arguments)
        };
        var _FPDF_GetPageCount = Module["_FPDF_GetPageCount"] = function () {
            return (_FPDF_GetPageCount = Module["_FPDF_GetPageCount"] = Module["asm"]["FPDF_GetPageCount"]).apply(null, arguments)
        };
        var _FPDF_LoadPage = Module["_FPDF_LoadPage"] = function () {
            return (_FPDF_LoadPage = Module["_FPDF_LoadPage"] = Module["asm"]["FPDF_LoadPage"]).apply(null, arguments)
        };
        var _FPDF_GetPageWidthF = Module["_FPDF_GetPageWidthF"] = function () {
            return (_FPDF_GetPageWidthF = Module["_FPDF_GetPageWidthF"] = Module["asm"]["FPDF_GetPageWidthF"]).apply(null, arguments)
        };
        var _FPDF_GetPageWidth = Module["_FPDF_GetPageWidth"] = function () {
            return (_FPDF_GetPageWidth = Module["_FPDF_GetPageWidth"] = Module["asm"]["FPDF_GetPageWidth"]).apply(null, arguments)
        };
        var _FPDF_GetPageHeightF = Module["_FPDF_GetPageHeightF"] = function () {
            return (_FPDF_GetPageHeightF = Module["_FPDF_GetPageHeightF"] = Module["asm"]["FPDF_GetPageHeightF"]).apply(null, arguments)
        };
        var _FPDF_GetPageHeight = Module["_FPDF_GetPageHeight"] = function () {
            return (_FPDF_GetPageHeight = Module["_FPDF_GetPageHeight"] = Module["asm"]["FPDF_GetPageHeight"]).apply(null, arguments)
        };
        var _FPDF_GetPageBoundingBox = Module["_FPDF_GetPageBoundingBox"] = function () {
            return (_FPDF_GetPageBoundingBox = Module["_FPDF_GetPageBoundingBox"] = Module["asm"]["FPDF_GetPageBoundingBox"]).apply(null, arguments)
        };
        var _FPDF_RenderPageBitmap = Module["_FPDF_RenderPageBitmap"] = function () {
            return (_FPDF_RenderPageBitmap = Module["_FPDF_RenderPageBitmap"] = Module["asm"]["FPDF_RenderPageBitmap"]).apply(null, arguments)
        };
        var _FPDF_RenderPageBitmapWithMatrix = Module["_FPDF_RenderPageBitmapWithMatrix"] = function () {
            return (_FPDF_RenderPageBitmapWithMatrix = Module["_FPDF_RenderPageBitmapWithMatrix"] = Module["asm"]["FPDF_RenderPageBitmapWithMatrix"]).apply(null, arguments)
        };
        var _FPDF_ClosePage = Module["_FPDF_ClosePage"] = function () {
            return (_FPDF_ClosePage = Module["_FPDF_ClosePage"] = Module["asm"]["FPDF_ClosePage"]).apply(null, arguments)
        };
        var _FPDF_CloseDocument = Module["_FPDF_CloseDocument"] = function () {
            return (_FPDF_CloseDocument = Module["_FPDF_CloseDocument"] = Module["asm"]["FPDF_CloseDocument"]).apply(null, arguments)
        };
        var _FPDF_GetLastError = Module["_FPDF_GetLastError"] = function () {
            return (_FPDF_GetLastError = Module["_FPDF_GetLastError"] = Module["asm"]["FPDF_GetLastError"]).apply(null, arguments)
        };
        var _FPDF_DeviceToPage = Module["_FPDF_DeviceToPage"] = function () {
            return (_FPDF_DeviceToPage = Module["_FPDF_DeviceToPage"] = Module["asm"]["FPDF_DeviceToPage"]).apply(null, arguments)
        };
        var _FPDF_PageToDevice = Module["_FPDF_PageToDevice"] = function () {
            return (_FPDF_PageToDevice = Module["_FPDF_PageToDevice"] = Module["asm"]["FPDF_PageToDevice"]).apply(null, arguments)
        };
        var _FPDFBitmap_Create = Module["_FPDFBitmap_Create"] = function () {
            return (_FPDFBitmap_Create = Module["_FPDFBitmap_Create"] = Module["asm"]["FPDFBitmap_Create"]).apply(null, arguments)
        };
        var _FPDFBitmap_CreateEx = Module["_FPDFBitmap_CreateEx"] = function () {
            return (_FPDFBitmap_CreateEx = Module["_FPDFBitmap_CreateEx"] = Module["asm"]["FPDFBitmap_CreateEx"]).apply(null, arguments)
        };
        var _FPDFBitmap_GetFormat = Module["_FPDFBitmap_GetFormat"] = function () {
            return (_FPDFBitmap_GetFormat = Module["_FPDFBitmap_GetFormat"] = Module["asm"]["FPDFBitmap_GetFormat"]).apply(null, arguments)
        };
        var _FPDFBitmap_FillRect = Module["_FPDFBitmap_FillRect"] = function () {
            return (_FPDFBitmap_FillRect = Module["_FPDFBitmap_FillRect"] = Module["asm"]["FPDFBitmap_FillRect"]).apply(null, arguments)
        };
        var _FPDFBitmap_GetBuffer = Module["_FPDFBitmap_GetBuffer"] = function () {
            return (_FPDFBitmap_GetBuffer = Module["_FPDFBitmap_GetBuffer"] = Module["asm"]["FPDFBitmap_GetBuffer"]).apply(null, arguments)
        };
        var _FPDFBitmap_GetWidth = Module["_FPDFBitmap_GetWidth"] = function () {
            return (_FPDFBitmap_GetWidth = Module["_FPDFBitmap_GetWidth"] = Module["asm"]["FPDFBitmap_GetWidth"]).apply(null, arguments)
        };
        var _FPDFBitmap_GetHeight = Module["_FPDFBitmap_GetHeight"] = function () {
            return (_FPDFBitmap_GetHeight = Module["_FPDFBitmap_GetHeight"] = Module["asm"]["FPDFBitmap_GetHeight"]).apply(null, arguments)
        };
        var _FPDFBitmap_GetStride = Module["_FPDFBitmap_GetStride"] = function () {
            return (_FPDFBitmap_GetStride = Module["_FPDFBitmap_GetStride"] = Module["asm"]["FPDFBitmap_GetStride"]).apply(null, arguments)
        };
        var _FPDFBitmap_Destroy = Module["_FPDFBitmap_Destroy"] = function () {
            return (_FPDFBitmap_Destroy = Module["_FPDFBitmap_Destroy"] = Module["asm"]["FPDFBitmap_Destroy"]).apply(null, arguments)
        };
        var _FPDF_GetPageSizeByIndexF = Module["_FPDF_GetPageSizeByIndexF"] = function () {
            return (_FPDF_GetPageSizeByIndexF = Module["_FPDF_GetPageSizeByIndexF"] = Module["asm"]["FPDF_GetPageSizeByIndexF"]).apply(null, arguments)
        };
        var _FPDF_GetPageSizeByIndex = Module["_FPDF_GetPageSizeByIndex"] = function () {
            return (_FPDF_GetPageSizeByIndex = Module["_FPDF_GetPageSizeByIndex"] = Module["asm"]["FPDF_GetPageSizeByIndex"]).apply(null, arguments)
        };
        var _FPDF_VIEWERREF_GetPrintScaling = Module["_FPDF_VIEWERREF_GetPrintScaling"] = function () {
            return (_FPDF_VIEWERREF_GetPrintScaling = Module["_FPDF_VIEWERREF_GetPrintScaling"] = Module["asm"]["FPDF_VIEWERREF_GetPrintScaling"]).apply(null, arguments)
        };
        var _FPDF_VIEWERREF_GetNumCopies = Module["_FPDF_VIEWERREF_GetNumCopies"] = function () {
            return (_FPDF_VIEWERREF_GetNumCopies = Module["_FPDF_VIEWERREF_GetNumCopies"] = Module["asm"]["FPDF_VIEWERREF_GetNumCopies"]).apply(null, arguments)
        };
        var _FPDF_VIEWERREF_GetPrintPageRange = Module["_FPDF_VIEWERREF_GetPrintPageRange"] = function () {
            return (_FPDF_VIEWERREF_GetPrintPageRange = Module["_FPDF_VIEWERREF_GetPrintPageRange"] = Module["asm"]["FPDF_VIEWERREF_GetPrintPageRange"]).apply(null, arguments)
        };
        var _FPDF_VIEWERREF_GetPrintPageRangeCount = Module["_FPDF_VIEWERREF_GetPrintPageRangeCount"] = function () {
            return (_FPDF_VIEWERREF_GetPrintPageRangeCount = Module["_FPDF_VIEWERREF_GetPrintPageRangeCount"] = Module["asm"]["FPDF_VIEWERREF_GetPrintPageRangeCount"]).apply(null, arguments)
        };
        var _FPDF_VIEWERREF_GetPrintPageRangeElement = Module["_FPDF_VIEWERREF_GetPrintPageRangeElement"] = function () {
            return (_FPDF_VIEWERREF_GetPrintPageRangeElement = Module["_FPDF_VIEWERREF_GetPrintPageRangeElement"] = Module["asm"]["FPDF_VIEWERREF_GetPrintPageRangeElement"]).apply(null, arguments)
        };
        var _FPDF_VIEWERREF_GetDuplex = Module["_FPDF_VIEWERREF_GetDuplex"] = function () {
            return (_FPDF_VIEWERREF_GetDuplex = Module["_FPDF_VIEWERREF_GetDuplex"] = Module["asm"]["FPDF_VIEWERREF_GetDuplex"]).apply(null, arguments)
        };
        var _FPDF_VIEWERREF_GetName = Module["_FPDF_VIEWERREF_GetName"] = function () {
            return (_FPDF_VIEWERREF_GetName = Module["_FPDF_VIEWERREF_GetName"] = Module["asm"]["FPDF_VIEWERREF_GetName"]).apply(null, arguments)
        };
        var _FPDF_CountNamedDests = Module["_FPDF_CountNamedDests"] = function () {
            return (_FPDF_CountNamedDests = Module["_FPDF_CountNamedDests"] = Module["asm"]["FPDF_CountNamedDests"]).apply(null, arguments)
        };
        var _FPDF_GetNamedDestByName = Module["_FPDF_GetNamedDestByName"] = function () {
            return (_FPDF_GetNamedDestByName = Module["_FPDF_GetNamedDestByName"] = Module["asm"]["FPDF_GetNamedDestByName"]).apply(null, arguments)
        };
        var _FPDF_GetNamedDest = Module["_FPDF_GetNamedDest"] = function () {
            return (_FPDF_GetNamedDest = Module["_FPDF_GetNamedDest"] = Module["asm"]["FPDF_GetNamedDest"]).apply(null, arguments)
        };
        var _FPDF_GetXFAPacketCount = Module["_FPDF_GetXFAPacketCount"] = function () {
            return (_FPDF_GetXFAPacketCount = Module["_FPDF_GetXFAPacketCount"] = Module["asm"]["FPDF_GetXFAPacketCount"]).apply(null, arguments)
        };
        var _FPDF_GetXFAPacketName = Module["_FPDF_GetXFAPacketName"] = function () {
            return (_FPDF_GetXFAPacketName = Module["_FPDF_GetXFAPacketName"] = Module["asm"]["FPDF_GetXFAPacketName"]).apply(null, arguments)
        };
        var _FPDF_GetXFAPacketContent = Module["_FPDF_GetXFAPacketContent"] = function () {
            return (_FPDF_GetXFAPacketContent = Module["_FPDF_GetXFAPacketContent"] = Module["asm"]["FPDF_GetXFAPacketContent"]).apply(null, arguments)
        };
        var _FPDF_GetTrailerEnds = Module["_FPDF_GetTrailerEnds"] = function () {
            return (_FPDF_GetTrailerEnds = Module["_FPDF_GetTrailerEnds"] = Module["asm"]["FPDF_GetTrailerEnds"]).apply(null, arguments)
        };
        var ___errno_location = function () {
            return (___errno_location = Module["asm"]["__errno_location"]).apply(null, arguments)
        };
        var __emscripten_timeout = function () {
            return (__emscripten_timeout = Module["asm"]["_emscripten_timeout"]).apply(null, arguments)
        };
        var _malloc = function () {
            return (_malloc = Module["asm"]["malloc"]).apply(null, arguments)
        };
        var _free = function () {
            return (_free = Module["asm"]["free"]).apply(null, arguments)
        };
        var _emscripten_builtin_memalign = function () {
            return (_emscripten_builtin_memalign = Module["asm"]["emscripten_builtin_memalign"]).apply(null, arguments)
        };
        var _setThrew = function () {
            return (_setThrew = Module["asm"]["setThrew"]).apply(null, arguments)
        };
        var _saveSetjmp = function () {
            return (_saveSetjmp = Module["asm"]["saveSetjmp"]).apply(null, arguments)
        };
        var stackSave = function () {
            return (stackSave = Module["asm"]["stackSave"]).apply(null, arguments)
        };
        var stackRestore = function () {
            return (stackRestore = Module["asm"]["stackRestore"]).apply(null, arguments)
        };
        var stackAlloc = function () {
            return (stackAlloc = Module["asm"]["stackAlloc"]).apply(null, arguments)
        };
        var dynCall_jiji = Module["dynCall_jiji"] = function () {
            return (dynCall_jiji = Module["dynCall_jiji"] = Module["asm"]["dynCall_jiji"]).apply(null, arguments)
        };
        var dynCall_iiiiij = Module["dynCall_iiiiij"] = function () {
            return (dynCall_iiiiij = Module["dynCall_iiiiij"] = Module["asm"]["dynCall_iiiiij"]).apply(null, arguments)
        };
        var dynCall_iiiiijj = Module["dynCall_iiiiijj"] = function () {
            return (dynCall_iiiiijj = Module["dynCall_iiiiijj"] = Module["asm"]["dynCall_iiiiijj"]).apply(null, arguments)
        };
        var dynCall_iiiiiijj = Module["dynCall_iiiiiijj"] = function () {
            return (dynCall_iiiiiijj = Module["dynCall_iiiiiijj"] = Module["asm"]["dynCall_iiiiiijj"]).apply(null, arguments)
        };
        var dynCall_viijii = Module["dynCall_viijii"] = function () {
            return (dynCall_viijii = Module["dynCall_viijii"] = Module["asm"]["dynCall_viijii"]).apply(null, arguments)
        };
        var dynCall_ji = Module["dynCall_ji"] = function () {
            return (dynCall_ji = Module["dynCall_ji"] = Module["asm"]["dynCall_ji"]).apply(null, arguments)
        };
        var dynCall_jij = Module["dynCall_jij"] = function () {
            return (dynCall_jij = Module["dynCall_jij"] = Module["asm"]["dynCall_jij"]).apply(null, arguments)
        };
        var dynCall_iiiij = Module["dynCall_iiiij"] = function () {
            return (dynCall_iiiij = Module["dynCall_iiiij"] = Module["asm"]["dynCall_iiiij"]).apply(null, arguments)
        };
        var dynCall_iij = Module["dynCall_iij"] = function () {
            return (dynCall_iij = Module["dynCall_iij"] = Module["asm"]["dynCall_iij"]).apply(null, arguments)
        };
        var dynCall_iiij = Module["dynCall_iiij"] = function () {
            return (dynCall_iiij = Module["dynCall_iiij"] = Module["asm"]["dynCall_iiij"]).apply(null, arguments)
        };
        var dynCall_j = Module["dynCall_j"] = function () {
            return (dynCall_j = Module["dynCall_j"] = Module["asm"]["dynCall_j"]).apply(null, arguments)
        };
        var dynCall_iji = Module["dynCall_iji"] = function () {
            return (dynCall_iji = Module["dynCall_iji"] = Module["asm"]["dynCall_iji"]).apply(null, arguments)
        };
        var dynCall_jji = Module["dynCall_jji"] = function () {
            return (dynCall_jji = Module["dynCall_jji"] = Module["asm"]["dynCall_jji"]).apply(null, arguments)
        };
        var dynCall_iiji = Module["dynCall_iiji"] = function () {
            return (dynCall_iiji = Module["dynCall_iiji"] = Module["asm"]["dynCall_iiji"]).apply(null, arguments)
        };
        var dynCall_viji = Module["dynCall_viji"] = function () {
            return (dynCall_viji = Module["dynCall_viji"] = Module["asm"]["dynCall_viji"]).apply(null, arguments)
        };

        function invoke_viiii(index, a1, a2, a3, a4) {
            var sp = stackSave();
            try {
                getWasmTableEntry(index)(a1, a2, a3, a4)
            } catch (e) {
                stackRestore(sp);
                if (e !== e + 0) throw e;
                _setThrew(1, 0)
            }
        }

        function invoke_iii(index, a1, a2) {
            var sp = stackSave();
            try {
                return getWasmTableEntry(index)(a1, a2)
            } catch (e) {
                stackRestore(sp);
                if (e !== e + 0) throw e;
                _setThrew(1, 0)
            }
        }

        function invoke_iiiii(index, a1, a2, a3, a4) {
            var sp = stackSave();
            try {
                return getWasmTableEntry(index)(a1, a2, a3, a4)
            } catch (e) {
                stackRestore(sp);
                if (e !== e + 0) throw e;
                _setThrew(1, 0)
            }
        }

        function invoke_v(index) {
            var sp = stackSave();
            try {
                getWasmTableEntry(index)()
            } catch (e) {
                stackRestore(sp);
                if (e !== e + 0) throw e;
                _setThrew(1, 0)
            }
        }

        function invoke_iiii(index, a1, a2, a3) {
            var sp = stackSave();
            try {
                return getWasmTableEntry(index)(a1, a2, a3)
            } catch (e) {
                stackRestore(sp);
                if (e !== e + 0) throw e;
                _setThrew(1, 0)
            }
        }

        function invoke_viii(index, a1, a2, a3) {
            var sp = stackSave();
            try {
                getWasmTableEntry(index)(a1, a2, a3)
            } catch (e) {
                stackRestore(sp);
                if (e !== e + 0) throw e;
                _setThrew(1, 0)
            }
        }

        function invoke_vi(index, a1) {
            var sp = stackSave();
            try {
                getWasmTableEntry(index)(a1)
            } catch (e) {
                stackRestore(sp);
                if (e !== e + 0) throw e;
                _setThrew(1, 0)
            }
        }

        function invoke_ii(index, a1) {
            var sp = stackSave();
            try {
                return getWasmTableEntry(index)(a1)
            } catch (e) {
                stackRestore(sp);
                if (e !== e + 0) throw e;
                _setThrew(1, 0)
            }
        }
        Module["ccall"] = ccall;
        Module["cwrap"] = cwrap;
        var calledRun;
        dependenciesFulfilled = function runCaller() {
            if (!calledRun) run();
            if (!calledRun) dependenciesFulfilled = runCaller
        };

        function run() {
            if (runDependencies > 0) {
                return
            }
            preRun();
            if (runDependencies > 0) {
                return
            }

            function doRun() {
                if (calledRun) return;
                calledRun = true;
                Module["calledRun"] = true;
                if (ABORT) return;
                initRuntime();
                if (Module["onRuntimeInitialized"]) Module["onRuntimeInitialized"]();
                postRun()
            }
            if (Module["setStatus"]) {
                Module["setStatus"]("Running...");
                setTimeout(function () {
                    setTimeout(function () {
                        Module["setStatus"]("")
                    }, 1);
                    doRun()
                }, 1)
            } else {
                doRun()
            }
        }
        if (Module["preInit"]) {
            if (typeof Module["preInit"] == "function") Module["preInit"] = [Module["preInit"]];
            while (Module["preInit"].length > 0) {
                Module["preInit"].pop()()
            }
        }
        run();
        return PDFiumModule.ready
    });
})();
if (typeof exports === 'object' && typeof module === 'object')
    module.exports = PDFiumModule;
else if (typeof define === 'function' && define['amd'])
    define([], function () {
        return PDFiumModule;
    });
else if (typeof exports === 'object')
    exports["PDFiumModule"] = PDFiumModule;
