var PDFiumModule = (() => {
    var _scriptDir = typeof document !== 'undefined' && document.currentScript ? document.currentScript.src : undefined;
    if (typeof __filename !== 'undefined')
        _scriptDir = _scriptDir || __filename;
    return (function (PDFiumModule = {}) {
        var Module = typeof PDFiumModule != "undefined" ? PDFiumModule : {};
        var ENVIRONMENT_IS_WEB = typeof window == "object";
        var ENVIRONMENT_IS_WORKER = typeof WorkerGlobalScope != "undefined";
        var ENVIRONMENT_IS_NODE = typeof process == "object" && process.versions && process.versions.node && process.type != "renderer";
        var arguments_ = [];
        var thisProgram = "./this.program";
        var quit_ = (status, toThrow) => {
            throw toThrow
        };
        var _scriptName = typeof document != "undefined" ? document.currentScript && document.currentScript.src : undefined;
        if (typeof __filename != "undefined") {
            _scriptName = __filename
        } else if (ENVIRONMENT_IS_WORKER) {
            _scriptName = self.location.href
        }
        var scriptDirectory = "";

        function locateFile(path) {
            if (Module["locateFile"]) {
                return Module["locateFile"](path, scriptDirectory)
            }
            return scriptDirectory + path
        }
        var readAsync, readBinary;
        if (ENVIRONMENT_IS_NODE) {
            var fs = require("fs");
            scriptDirectory = __dirname + "/";
            readBinary = filename => {
                filename = isFileURI(filename) ? new URL(filename) : filename;
                var ret = fs.readFileSync(filename);
                return ret
            };
            readAsync = async (filename, binary = true) => {
                filename = isFileURI(filename) ? new URL(filename) : filename;
                var ret = fs.readFileSync(filename, binary ? undefined : "utf8");
                return ret
            };
            if (process.argv.length > 1) {
                thisProgram = process.argv[1].replace(/\\/g, "/")
            }
            arguments_ = process.argv.slice(2);
            if (typeof module != "undefined") {
                module["exports"] = Module
            }
            quit_ = (status, toThrow) => {
                process.exitCode = status;
                throw toThrow
            }
        } else if (ENVIRONMENT_IS_WEB || ENVIRONMENT_IS_WORKER) {
            try {
                scriptDirectory = new URL(".", _scriptName).href
            } catch {} {
                if (ENVIRONMENT_IS_WORKER) {
                    readBinary = url => {
                        var xhr = new XMLHttpRequest;
                        xhr.open("GET", url, false);
                        xhr.responseType = "arraybuffer";
                        xhr.send(null);
                        return new Uint8Array(xhr.response)
                    }
                }
                readAsync = async url => {
                    if (isFileURI(url)) {
                        return new Promise((resolve, reject) => {
                            var xhr = new XMLHttpRequest;
                            xhr.open("GET", url, true);
                            xhr.responseType = "arraybuffer";
                            xhr.onload = () => {
                                if (xhr.status == 200 || xhr.status == 0 && xhr.response) {
                                    resolve(xhr.response);
                                    return
                                }
                                reject(xhr.status)
                            };
                            xhr.onerror = reject;
                            xhr.send(null)
                        })
                    }
                    var response = await fetch(url, {
                        credentials: "same-origin"
                    });
                    if (response.ok) {
                        return response.arrayBuffer()
                    }
                    throw new Error(response.status + " : " + response.url)
                }
            }
        } else {}
        var out = console.log.bind(console);
        var err = console.error.bind(console);
        var wasmBinary;
        var ABORT = false;
        var isFileURI = filename => filename.startsWith("file://");
        var wasmMemory;
        var HEAP8, HEAPU8, HEAP16, HEAPU16, HEAP32, HEAPU32, HEAPF32, HEAPF64;
        var HEAP64, HEAPU64;
        var runtimeInitialized = false;

        function updateMemoryViews() {
            var b = wasmMemory.buffer;
            Module["HEAP8"] = HEAP8 = new Int8Array(b);
            Module["HEAP16"] = HEAP16 = new Int16Array(b);
            Module["HEAPU8"] = HEAPU8 = new Uint8Array(b);
            Module["HEAPU16"] = HEAPU16 = new Uint16Array(b);
            Module["HEAP32"] = HEAP32 = new Int32Array(b);
            Module["HEAPU32"] = HEAPU32 = new Uint32Array(b);
            Module["HEAPF32"] = HEAPF32 = new Float32Array(b);
            Module["HEAPF64"] = HEAPF64 = new Float64Array(b);
            Module["HEAP64"] = HEAP64 = new BigInt64Array(b);
            Module["HEAPU64"] = HEAPU64 = new BigUint64Array(b)
        }

        function preRun() {
            if (Module["preRun"]) {
                if (typeof Module["preRun"] == "function") Module["preRun"] = [Module["preRun"]];
                while (Module["preRun"].length) {
                    addOnPreRun(Module["preRun"].shift())
                }
            }
            callRuntimeCallbacks(onPreRuns)
        }

        function initRuntime() {
            runtimeInitialized = true;
            if (!Module["noFSInit"] && !FS.initialized) FS.init();
            TTY.init();
            wasmExports["__wasm_call_ctors"]();
            FS.ignorePermissions = false
        }

        function postRun() {
            if (Module["postRun"]) {
                if (typeof Module["postRun"] == "function") Module["postRun"] = [Module["postRun"]];
                while (Module["postRun"].length) {
                    addOnPostRun(Module["postRun"].shift())
                }
            }
            callRuntimeCallbacks(onPostRuns)
        }
        var runDependencies = 0;
        var dependenciesFulfilled = null;

        function addRunDependency(id) {
            runDependencies++;
            if(Module["monitorRunDependencies"]){
                Module["monitorRunDependencies"](runDependencies)
            }
        }

        function removeRunDependency(id) {
            runDependencies--;
            if (Module["monitorRunDependencies"]) {
                Module["monitorRunDependencies"](runDependencies);
            }
            if (runDependencies == 0) {
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
            what += ". Build with -sASSERTIONS for more info.";
            var e = new WebAssembly.RuntimeError(what);
            throw e
        }
        var dataURIPrefix = "data:application/octet-stream;base64,";
        function isDataURI(filename) {
            return filename.startsWith(dataURIPrefix)
        }
        var wasmBinaryFile;
        function findWasmBinary() {
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
            return locateFile(wasmBinaryFile)
        }

        function getBinarySync(file) {
            if (file == wasmBinaryFile && wasmBinary) {
                return new Uint8Array(wasmBinary)
            }
            if (readBinary) {
                return readBinary(file)
            }
            throw "both async and sync fetching of the wasm failed"
        }
        async function getWasmBinary(binaryFile) {
            if (!wasmBinary) {
                try {
                    var response = await readAsync(binaryFile);
                    return new Uint8Array(response)
                } catch {}
            }
            return getBinarySync(binaryFile)
        }
        async function instantiateArrayBuffer(binaryFile, imports) {
            try {
                var binary = await getWasmBinary(binaryFile);
                var instance = await WebAssembly.instantiate(binary, imports);
                return instance
            } catch (reason) {
                err(`failed to asynchronously prepare wasm: ${reason}`);
                abort(reason)
            }
        }
        async function instantiateAsync(binary, binaryFile, imports) {
            if (!binary && typeof WebAssembly.instantiateStreaming == "function" && !isFileURI(binaryFile) && !ENVIRONMENT_IS_NODE) {
                try {
                    var response = fetch(binaryFile, {
                        credentials: "same-origin"
                    });
                    var instantiationResult = await WebAssembly.instantiateStreaming(response, imports);
                    return instantiationResult
                } catch (reason) {
                    err(`wasm streaming compile failed: ${reason}`);
                    err("falling back to ArrayBuffer instantiation")
                }
            }
            return instantiateArrayBuffer(binaryFile, imports)
        }

        function getWasmImports() {
            return {
                env: wasmImports,
                wasi_snapshot_preview1: wasmImports
            }
        }
        async function createWasm() {
            function receiveInstance(instance, module) {
                wasmExports = instance.exports;
                wasmExports = applySignatureConversions(wasmExports);
                wasmMemory = wasmExports["memory"];
                updateMemoryViews();
                wasmTable = wasmExports["__indirect_function_table"];
                assignWasmExports(wasmExports);
                removeRunDependency("wasm-instantiate");
                return wasmExports
            }
            addRunDependency("wasm-instantiate");

            function receiveInstantiationResult(result) {
                return receiveInstance(result["instance"])
            }
            var info = getWasmImports();
            if (Module["instantiateWasm"]) {
                return new Promise((resolve, reject) => {
                    Module["instantiateWasm"](info, (mod, inst) => {
                        resolve(receiveInstance(mod, inst))
                    })
                })
            }
            wasmBinaryFile = findWasmBinary();
            var result = await instantiateAsync(wasmBinary, wasmBinaryFile, info);
            var exports = receiveInstantiationResult(result);
            return exports
        }
        class ExitStatus {
            name = "ExitStatus";
            constructor(status) {
                this.message = `Program terminated with exit(${status})`;
                this.status = status
            }
        }
        var callRuntimeCallbacks = callbacks => {
            while (callbacks.length > 0) {
                callbacks.shift()(Module)
            }
        };
        var onPostRuns = [];
        var addOnPostRun = cb => onPostRuns.push(cb);
        var onPreRuns = [];
        var addOnPreRun = cb => onPreRuns.push(cb);
        var noExitRuntime = true;

        function setValue(ptr, value, type = "i8") {
            if (type.endsWith("*")) type = "*";
            switch (type) {
                case "i1":
                    HEAP8[ptr >>> 0] = value;
                    break;
                case "i8":
                    HEAP8[ptr >>> 0] = value;
                    break;
                case "i16":
                    HEAP16[ptr >>> 1 >>> 0] = value;
                    break;
                case "i32":
                    HEAP32[ptr >>> 2 >>> 0] = value;
                    break;
                case "i64":
                    HEAP64[ptr >>> 3 >>> 0] = BigInt(value);
                    break;
                case "float":
                    HEAPF32[ptr >>> 2 >>> 0] = value;
                    break;
                case "double":
                    HEAPF64[ptr >>> 3 >>> 0] = value;
                    break;
                case "*":
                    HEAPU32[ptr >>> 2 >>> 0] = value;
                    break;
                default:
                    abort(`invalid type for setValue: ${type}`)
            }
        }
        var stackRestore = val => __emscripten_stack_restore(val);
        var stackSave = () => _emscripten_stack_get_current();
        var syscallGetVarargI = () => {
            var ret = HEAP32[+SYSCALLS.varargs >>> 2 >>> 0];
            SYSCALLS.varargs += 4;
            return ret
        };
        var syscallGetVarargP = syscallGetVarargI;
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
                    trailingSlash = path.slice(-1) === "/";
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
                    dir = dir.slice(0, -1)
                }
                return root + dir
            },
            basename: path => path && path.match(/([^\/]+|\/)\/*$/)[1],
            join: (...paths) => PATH.normalize(paths.join("/")),
            join2: (l, r) => PATH.normalize(l + "/" + r)
        };
        var initRandomFill = () => {
            if (ENVIRONMENT_IS_NODE) {
                var nodeCrypto = require("crypto");
                return view => nodeCrypto.randomFillSync(view)
            }
            return view => crypto.getRandomValues(view)
        };
        var randomFill = view => {
            (randomFill = initRandomFill())(view)
        };
        var PATH_FS = {
            resolve: (...args) => {
                var resolvedPath = "",
                    resolvedAbsolute = false;
                for (var i = args.length - 1; i >= -1 && !resolvedAbsolute; i--) {
                    var path = i >= 0 ? args[i] : FS.cwd();
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
                from = PATH_FS.resolve(from).slice(1);
                to = PATH_FS.resolve(to).slice(1);

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
        var UTF8Decoder = typeof TextDecoder != "undefined" ? new TextDecoder : undefined;
        var UTF8ArrayToString = (heapOrArray, idx = 0, maxBytesToRead = NaN) => {
            idx >>>= 0;
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
        };
        var FS_stdin_getChar_buffer = [];
        var lengthBytesUTF8 = str => {
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
        };
        var stringToUTF8Array = (str, heap, outIdx, maxBytesToWrite) => {
            outIdx >>>= 0;
            if (!(maxBytesToWrite > 0)) return 0;
            var startIdx = outIdx;
            var endIdx = outIdx + maxBytesToWrite - 1;
            for (var i = 0; i < str.length; ++i) {
                var u = str.codePointAt(i);
                if (u <= 127) {
                    if (outIdx >= endIdx) break;
                    heap[outIdx++ >>> 0] = u
                } else if (u <= 2047) {
                    if (outIdx + 1 >= endIdx) break;
                    heap[outIdx++ >>> 0] = 192 | u >> 6;
                    heap[outIdx++ >>> 0] = 128 | u & 63
                } else if (u <= 65535) {
                    if (outIdx + 2 >= endIdx) break;
                    heap[outIdx++ >>> 0] = 224 | u >> 12;
                    heap[outIdx++ >>> 0] = 128 | u >> 6 & 63;
                    heap[outIdx++ >>> 0] = 128 | u & 63
                } else {
                    if (outIdx + 3 >= endIdx) break;
                    heap[outIdx++ >>> 0] = 240 | u >> 18;
                    heap[outIdx++ >>> 0] = 128 | u >> 12 & 63;
                    heap[outIdx++ >>> 0] = 128 | u >> 6 & 63;
                    heap[outIdx++ >>> 0] = 128 | u & 63;
                    i++
                }
            }
            heap[outIdx >>> 0] = 0;
            return outIdx - startIdx
        };
        var intArrayFromString = (stringy, dontAddNull, length) => {
            var len = length > 0 ? length : lengthBytesUTF8(stringy) + 1;
            var u8array = new Array(len);
            var numBytesWritten = stringToUTF8Array(stringy, u8array, 0, u8array.length);
            if (dontAddNull) u8array.length = numBytesWritten;
            return u8array
        };
        var FS_stdin_getChar = () => {
            if (!FS_stdin_getChar_buffer.length) {
                var result = null;
                if (ENVIRONMENT_IS_NODE) {
                    var BUFSIZE = 256;
                    var buf = Buffer.alloc(BUFSIZE);
                    var bytesRead = 0;
                    var fd = process.stdin.fd;
                    try {
                        bytesRead = fs.readSync(fd, buf, 0, BUFSIZE)
                    } catch (e) {
                        if (e.toString().includes("EOF")) bytesRead = 0;
                        else throw e
                    }
                    if (bytesRead > 0) {
                        result = buf.slice(0, bytesRead).toString("utf-8")
                    }
                } else if (typeof window != "undefined" && typeof window.prompt == "function") {
                    result = window.prompt("Input: ");
                    if (result !== null) {
                        result += "\n"
                    }
                } else {}
                if (!result) {
                    return null
                }
                FS_stdin_getChar_buffer = intArrayFromString(result, true)
            }
            return FS_stdin_getChar_buffer.shift()
        };
        var TTY = {
            ttys: [],
            init() {},
            shutdown() {},
            register(dev, ops) {
                TTY.ttys[dev] = {
                    input: [],
                    output: [],
                    ops
                };
                FS.registerDevice(dev, TTY.stream_ops)
            },
            stream_ops: {
                open(stream) {
                    var tty = TTY.ttys[stream.node.rdev];
                    if (!tty) {
                        throw new FS.ErrnoError(43)
                    }
                    stream.tty = tty;
                    stream.seekable = false
                },
                close(stream) {
                    stream.tty.ops.fsync(stream.tty)
                },
                fsync(stream) {
                    stream.tty.ops.fsync(stream.tty)
                },
                read(stream, buffer, offset, length, pos) {
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
                        stream.node.atime = Date.now()
                    }
                    return bytesRead
                },
                write(stream, buffer, offset, length, pos) {
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
                        stream.node.mtime = stream.node.ctime = Date.now()
                    }
                    return i
                }
            },
            default_tty_ops: {
                get_char(tty) {
                    return FS_stdin_getChar()
                },
                put_char(tty, val) {
                    if (val === null || val === 10) {
                        out(UTF8ArrayToString(tty.output));
                        tty.output = []
                    } else {
                        if (val != 0) tty.output.push(val)
                    }
                },
                fsync(tty) {
                    if (tty.output && tty.output.length > 0) {
                        out(UTF8ArrayToString(tty.output));
                        tty.output = []
                    }
                },
                ioctl_tcgets(tty) {
                    return {
                        c_iflag: 25856,
                        c_oflag: 5,
                        c_cflag: 191,
                        c_lflag: 35387,
                        c_cc: [3, 28, 127, 21, 4, 0, 1, 0, 17, 19, 26, 0, 18, 15, 23, 22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
                    }
                },
                ioctl_tcsets(tty, optional_actions, data) {
                    return 0
                },
                ioctl_tiocgwinsz(tty) {
                    return [24, 80]
                }
            },
            default_tty1_ops: {
                put_char(tty, val) {
                    if (val === null || val === 10) {
                        err(UTF8ArrayToString(tty.output));
                        tty.output = []
                    } else {
                        if (val != 0) tty.output.push(val)
                    }
                },
                fsync(tty) {
                    if (tty.output && tty.output.length > 0) {
                        err(UTF8ArrayToString(tty.output));
                        tty.output = []
                    }
                }
            }
        };
        var zeroMemory = (ptr, size) => HEAPU8.fill(0, ptr, ptr + size);
        var alignMemory = (size, alignment) => Math.ceil(size / alignment) * alignment;
        var mmapAlloc = size => {
            size = alignMemory(size, 65536);
            var ptr = _emscripten_builtin_memalign(65536, size);
            if (ptr) zeroMemory(ptr, size);
            return ptr
        };
        var MEMFS = {
            ops_table: null,
            mount(mount) {
                return MEMFS.createNode(null, "/", 16895, 0)
            },
            createNode(parent, name, mode, dev) {
                if (FS.isBlkdev(mode) || FS.isFIFO(mode)) {
                    throw new FS.ErrnoError(63)
                }
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
                };
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
                node.atime = node.mtime = node.ctime = Date.now();
                if (parent) {
                    parent.contents[name] = node;
                    parent.atime = parent.mtime = parent.ctime = node.atime
                }
                return node
            },
            getFileDataAsTypedArray(node) {
                if (!node.contents) return new Uint8Array(0);
                if (node.contents.subarray) return node.contents.subarray(0, node.usedBytes);
                return new Uint8Array(node.contents)
            },
            expandFileStorage(node, newCapacity) {
                var prevCapacity = node.contents ? node.contents.length : 0;
                if (prevCapacity >= newCapacity) return;
                var CAPACITY_DOUBLING_MAX = 1024 * 1024;
                newCapacity = Math.max(newCapacity, prevCapacity * (prevCapacity < CAPACITY_DOUBLING_MAX ? 2 : 1.125) >>> 0);
                if (prevCapacity != 0) newCapacity = Math.max(newCapacity, 256);
                var oldContents = node.contents;
                node.contents = new Uint8Array(newCapacity);
                if (node.usedBytes > 0) node.contents.set(oldContents.subarray(0, node.usedBytes), 0)
            },
            resizeFileStorage(node, newSize) {
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
                getattr(node) {
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
                    attr.atime = new Date(node.atime);
                    attr.mtime = new Date(node.mtime);
                    attr.ctime = new Date(node.ctime);
                    attr.blksize = 4096;
                    attr.blocks = Math.ceil(attr.size / attr.blksize);
                    return attr
                },
                setattr(node, attr) {
                    for (const key of ["mode", "atime", "mtime", "ctime"]) {
                        if (attr[key] != null) {
                            node[key] = attr[key]
                        }
                    }
                    if (attr.size !== undefined) {
                        MEMFS.resizeFileStorage(node, attr.size)
                    }
                },
                lookup(parent, name) {
                    throw MEMFS.doesNotExistError
                },
                mknod(parent, name, mode, dev) {
                    return MEMFS.createNode(parent, name, mode, dev)
                },
                rename(old_node, new_dir, new_name) {
                    var new_node;
                    try {
                        new_node = FS.lookupNode(new_dir, new_name)
                    } catch (e) {}
                    if (new_node) {
                        if (FS.isDir(old_node.mode)) {
                            for (var i in new_node.contents) {
                                throw new FS.ErrnoError(55)
                            }
                        }
                        FS.hashRemoveNode(new_node)
                    }
                    delete old_node.parent.contents[old_node.name];
                    new_dir.contents[new_name] = old_node;
                    old_node.name = new_name;
                    new_dir.ctime = new_dir.mtime = old_node.parent.ctime = old_node.parent.mtime = Date.now()
                },
                unlink(parent, name) {
                    delete parent.contents[name];
                    parent.ctime = parent.mtime = Date.now()
                },
                rmdir(parent, name) {
                    var node = FS.lookupNode(parent, name);
                    for (var i in node.contents) {
                        throw new FS.ErrnoError(55)
                    }
                    delete parent.contents[name];
                    parent.ctime = parent.mtime = Date.now()
                },
                readdir(node) {
                    return [".", "..", ...Object.keys(node.contents)]
                },
                symlink(parent, newname, oldpath) {
                    var node = MEMFS.createNode(parent, newname, 511 | 40960, 0);
                    node.link = oldpath;
                    return node
                },
                readlink(node) {
                    if (!FS.isLink(node.mode)) {
                        throw new FS.ErrnoError(28)
                    }
                    return node.link
                }
            },
            stream_ops: {
                read(stream, buffer, offset, length, position) {
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
                write(stream, buffer, offset, length, position, canOwn) {
                    if (buffer.buffer === HEAP8.buffer) {
                        canOwn = false
                    }
                    if (!length) return 0;
                    var node = stream.node;
                    node.mtime = node.ctime = Date.now();
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
                llseek(stream, offset, whence) {
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
                mmap(stream, length, position, prot, flags) {
                    if (!FS.isFile(stream.node.mode)) {
                        throw new FS.ErrnoError(43)
                    }
                    var ptr;
                    var allocated;
                    var contents = stream.node.contents;
                    if (!(flags & 2) && contents && contents.buffer === HEAP8.buffer) {
                        allocated = false;
                        ptr = contents.byteOffset
                    } else {
                        allocated = true;
                        ptr = mmapAlloc(length);
                        if (!ptr) {
                            throw new FS.ErrnoError(48)
                        }
                        if (contents) {
                            if (position > 0 || position + length < contents.length) {
                                if (contents.subarray) {
                                    contents = contents.subarray(position, position + length)
                                } else {
                                    contents = Array.prototype.slice.call(contents, position, position + length)
                                }
                            }
                            HEAP8.set(contents, ptr >>> 0)
                        }
                    }
                    return {
                        ptr,
                        allocated
                    }
                },
                msync(stream, buffer, offset, length, mmapFlags) {
                    MEMFS.stream_ops.write(stream, buffer, 0, length, offset, false);
                    return 0
                }
            }
        };
        var asyncLoad = async url => {
            var arrayBuffer = await readAsync(url);
            return new Uint8Array(arrayBuffer)
        };
        var FS_createDataFile = (...args) => FS.createDataFile(...args);
        var getUniqueRunDependency = id => id;
        var preloadPlugins = [];
        var FS_handledByPreloadPlugin = (byteArray, fullname, finish, onerror) => {
            if (typeof Browser != "undefined") Browser.init();
            var handled = false;
            preloadPlugins.forEach(plugin => {
                if (handled) return;
                if (plugin["canHandle"](fullname)) {
                    plugin["handle"](byteArray, fullname, finish, onerror);
                    handled = true
                }
            });
            return handled
        };
        var FS_createPreloadedFile = (parent, name, url, canRead, canWrite, onload, onerror, dontCreateFile, canOwn, preFinish) => {
            var fullname = name ? PATH_FS.resolve(PATH.join2(parent, name)) : parent;
            var dep = getUniqueRunDependency(`cp ${fullname}`);

            function processData(byteArray) {
                function finish(byteArray) {
                    if(preFinish) preFinish();
                    if (!dontCreateFile) {
                        FS_createDataFile(parent, name, byteArray, canRead, canWrite, canOwn)
                    }
                    if(onload) onload();
                    removeRunDependency(dep)
                }
                if (FS_handledByPreloadPlugin(byteArray, fullname, finish, () => {
                        if(onerror) onerror();
                        removeRunDependency(dep)
                    })) {
                    return
                }
                finish(byteArray)
            }
            addRunDependency(dep);
            if (typeof url == "string") {
                asyncLoad(url).then(processData, onerror)
            } else {
                processData(url)
            }
        };
        var FS_modeStringToFlags = str => {
            var flagModes = {
                r: 0,
                "r+": 2,
                w: 512 | 64 | 1,
                "w+": 512 | 64 | 2,
                a: 1024 | 64 | 1,
                "a+": 1024 | 64 | 2
            };
            var flags = flagModes[str];
            if (typeof flags == "undefined") {
                throw new Error(`Unknown file open mode: ${str}`)
            }
            return flags
        };
        var FS_getMode = (canRead, canWrite) => {
            var mode = 0;
            if (canRead) mode |= 292 | 73;
            if (canWrite) mode |= 146;
            return mode
        };
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
            filesystems: null,
            syncFSRequests: 0,
            readFiles: {},
            ErrnoError: class {
                name = "ErrnoError";
                constructor(errno) {
                    this.errno = errno
                }
            },
            FSStream: class {
                shared = {};
                get object() {
                    return this.node
                }
                set object(val) {
                    this.node = val
                }
                get isRead() {
                    return (this.flags & 2097155) !== 1
                }
                get isWrite() {
                    return (this.flags & 2097155) !== 0
                }
                get isAppend() {
                    return this.flags & 1024
                }
                get flags() {
                    return this.shared.flags
                }
                set flags(val) {
                    this.shared.flags = val
                }
                get position() {
                    return this.shared.position
                }
                set position(val) {
                    this.shared.position = val
                }
            },
            FSNode: class {
                node_ops = {};
                stream_ops = {};
                readMode = 292 | 73;
                writeMode = 146;
                mounted = null;
                constructor(parent, name, mode, rdev) {
                    if (!parent) {
                        parent = this
                    }
                    this.parent = parent;
                    this.mount = parent.mount;
                    this.id = FS.nextInode++;
                    this.name = name;
                    this.mode = mode;
                    this.rdev = rdev;
                    this.atime = this.mtime = this.ctime = Date.now()
                }
                get read() {
                    return (this.mode & this.readMode) === this.readMode
                }
                set read(val) {
                    val ? this.mode |= this.readMode : this.mode &= ~this.readMode
                }
                get write() {
                    return (this.mode & this.writeMode) === this.writeMode
                }
                set write(val) {
                    val ? this.mode |= this.writeMode : this.mode &= ~this.writeMode
                }
                get isFolder() {
                    return FS.isDir(this.mode)
                }
                get isDevice() {
                    return FS.isChrdev(this.mode)
                }
            },
            lookupPath(path, opts = {}) {
                if (!path) {
                    throw new FS.ErrnoError(44)
                }
                opts.follow_mount = true;
                if (!PATH.isAbs(path)) {
                    path = FS.cwd() + "/" + path
                }
                linkloop: for (var nlinks = 0; nlinks < 40; nlinks++) {
                    var parts = path.split("/").filter(p => !!p);
                    var current = FS.root;
                    var current_path = "/";
                    for (var i = 0; i < parts.length; i++) {
                        var islast = i === parts.length - 1;
                        if (islast && opts.parent) {
                            break
                        }
                        if (parts[i] === ".") {
                            continue
                        }
                        if (parts[i] === "..") {
                            current_path = PATH.dirname(current_path);
                            if (FS.isRoot(current)) {
                                path = current_path + "/" + parts.slice(i + 1).join("/");
                                continue linkloop
                            } else {
                                current = current.parent
                            }
                            continue
                        }
                        current_path = PATH.join2(current_path, parts[i]);
                        try {
                            current = FS.lookupNode(current, parts[i])
                        } catch (e) {
                            if (e && e.errno === 44 && islast && opts.noent_okay) {
                                return {
                                    path: current_path
                                }
                            }
                            throw e
                        }
                        if (FS.isMountpoint(current) && (!islast || opts.follow_mount)) {
                            current = current.mounted.root
                        }
                        if (FS.isLink(current.mode) && (!islast || opts.follow)) {
                            if (!current.node_ops.readlink) {
                                throw new FS.ErrnoError(52)
                            }
                            var link = current.node_ops.readlink(current);
                            if (!PATH.isAbs(link)) {
                                link = PATH.dirname(current_path) + "/" + link
                            }
                            path = link + "/" + parts.slice(i + 1).join("/");
                            continue linkloop
                        }
                    }
                    return {
                        path: current_path,
                        node: current
                    }
                }
                throw new FS.ErrnoError(32)
            },
            getPath(node) {
                var path;
                while (true) {
                    if (FS.isRoot(node)) {
                        var mount = node.mount.mountpoint;
                        if (!path) return mount;
                        return mount[mount.length - 1] !== "/" ? `${mount}/${path}` : mount + path
                    }
                    path = path ? `${node.name}/${path}` : node.name;
                    node = node.parent
                }
            },
            hashName(parentid, name) {
                var hash = 0;
                for (var i = 0; i < name.length; i++) {
                    hash = (hash << 5) - hash + name.charCodeAt(i) | 0
                }
                return (parentid + hash >>> 0) % FS.nameTable.length
            },
            hashAddNode(node) {
                var hash = FS.hashName(node.parent.id, node.name);
                node.name_next = FS.nameTable[hash];
                FS.nameTable[hash] = node
            },
            hashRemoveNode(node) {
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
            lookupNode(parent, name) {
                var errCode = FS.mayLookup(parent);
                if (errCode) {
                    throw new FS.ErrnoError(errCode)
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
            createNode(parent, name, mode, rdev) {
                var node = new FS.FSNode(parent, name, mode, rdev);
                FS.hashAddNode(node);
                return node
            },
            destroyNode(node) {
                FS.hashRemoveNode(node)
            },
            isRoot(node) {
                return node === node.parent
            },
            isMountpoint(node) {
                return !!node.mounted
            },
            isFile(mode) {
                return (mode & 61440) === 32768
            },
            isDir(mode) {
                return (mode & 61440) === 16384
            },
            isLink(mode) {
                return (mode & 61440) === 40960
            },
            isChrdev(mode) {
                return (mode & 61440) === 8192
            },
            isBlkdev(mode) {
                return (mode & 61440) === 24576
            },
            isFIFO(mode) {
                return (mode & 61440) === 4096
            },
            isSocket(mode) {
                return (mode & 49152) === 49152
            },
            flagsToPermissionString(flag) {
                var perms = ["r", "w", "rw"][flag & 3];
                if (flag & 512) {
                    perms += "w"
                }
                return perms
            },
            nodePermissions(node, perms) {
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
            mayLookup(dir) {
                if (!FS.isDir(dir.mode)) return 54;
                var errCode = FS.nodePermissions(dir, "x");
                if (errCode) return errCode;
                if (!dir.node_ops.lookup) return 2;
                return 0
            },
            mayCreate(dir, name) {
                if (!FS.isDir(dir.mode)) {
                    return 54
                }
                try {
                    var node = FS.lookupNode(dir, name);
                    return 20
                } catch (e) {}
                return FS.nodePermissions(dir, "wx")
            },
            mayDelete(dir, name, isdir) {
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
            mayOpen(node, flags) {
                if (!node) {
                    return 44
                }
                if (FS.isLink(node.mode)) {
                    return 32
                } else if (FS.isDir(node.mode)) {
                    if (FS.flagsToPermissionString(flags) !== "r" || flags & (512 | 64)) {
                        return 31
                    }
                }
                return FS.nodePermissions(node, FS.flagsToPermissionString(flags))
            },
            checkOpExists(op, err) {
                if (!op) {
                    throw new FS.ErrnoError(err)
                }
                return op
            },
            MAX_OPEN_FDS: 4096,
            nextfd() {
                for (var fd = 0; fd <= FS.MAX_OPEN_FDS; fd++) {
                    if (!FS.streams[fd]) {
                        return fd
                    }
                }
                throw new FS.ErrnoError(33)
            },
            getStreamChecked(fd) {
                var stream = FS.getStream(fd);
                if (!stream) {
                    throw new FS.ErrnoError(8)
                }
                return stream
            },
            getStream: fd => FS.streams[fd],
            createStream(stream, fd = -1) {
                stream = Object.assign(new FS.FSStream, stream);
                if (fd == -1) {
                    fd = FS.nextfd()
                }
                stream.fd = fd;
                FS.streams[fd] = stream;
                return stream
            },
            closeStream(fd) {
                FS.streams[fd] = null
            },
            dupStream(origStream, fd = -1) {
                var stream = FS.createStream(origStream, fd);
                if (stream.stream_ops && stream.stream_ops.dup) {
                    stream.stream_ops.dup(stream);
                }
                return stream
            },
            doSetAttr(stream, node, attr) {
                var setattr = stream && stream.stream_ops && stream.stream_ops.setattr;
                var arg = setattr ? stream : node;
                setattr = node.node_ops.setattr;
                FS.checkOpExists(setattr, 63);
                setattr(arg, attr)
            },
            chrdev_stream_ops: {
                open(stream) {
                    var device = FS.getDevice(stream.node.rdev);
                    stream.stream_ops = device.stream_ops;
                    stream.stream_ops.open(stream)
                },
                llseek() {
                    throw new FS.ErrnoError(70)
                }
            },
            major: dev => dev >> 8,
            minor: dev => dev & 255,
            makedev: (ma, mi) => ma << 8 | mi,
            registerDevice(dev, ops) {
                FS.devices[dev] = {
                    stream_ops: ops
                }
            },
            getDevice: dev => FS.devices[dev],
            getMounts(mount) {
                var mounts = [];
                var check = [mount];
                while (check.length) {
                    var m = check.pop();
                    mounts.push(m);
                    check.push(...m.mounts)
                }
                return mounts
            },
            syncfs(populate, callback) {
                if (typeof populate == "function") {
                    callback = populate;
                    populate = false
                }
                FS.syncFSRequests++;
                if (FS.syncFSRequests > 1) {
                    err(`warning: ${FS.syncFSRequests} FS.syncfs operations in flight at once, probably just doing extra work`)
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
            mount(type, opts, mountpoint) {
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
                    type,
                    opts,
                    mountpoint,
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
            unmount(mountpoint) {
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
            lookup(parent, name) {
                return parent.node_ops.lookup(parent, name)
            },
            mknod(path, mode, dev) {
                var lookup = FS.lookupPath(path, {
                    parent: true
                });
                var parent = lookup.node;
                var name = PATH.basename(path);
                if (!name) {
                    throw new FS.ErrnoError(28)
                }
                if (name === "." || name === "..") {
                    throw new FS.ErrnoError(20)
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
            statfs(path) {
                return FS.statfsNode(FS.lookupPath(path, {
                    follow: true
                }).node)
            },
            statfsStream(stream) {
                return FS.statfsNode(stream.node)
            },
            statfsNode(node) {
                var rtn = {
                    bsize: 4096,
                    frsize: 4096,
                    blocks: 1e6,
                    bfree: 5e5,
                    bavail: 5e5,
                    files: FS.nextInode,
                    ffree: FS.nextInode - 1,
                    fsid: 42,
                    flags: 2,
                    namelen: 255
                };
                if (node.node_ops.statfs) {
                    Object.assign(rtn, node.node_ops.statfs(node.mount.opts.root))
                }
                return rtn
            },
            create(path, mode = 438) {
                mode &= 4095;
                mode |= 32768;
                return FS.mknod(path, mode, 0)
            },
            mkdir(path, mode = 511) {
                mode &= 511 | 512;
                mode |= 16384;
                return FS.mknod(path, mode, 0)
            },
            mkdirTree(path, mode) {
                var dirs = path.split("/");
                var d = "";
                for (var dir of dirs) {
                    if (!dir) continue;
                    if (d || PATH.isAbs(path)) d += "/";
                    d += dir;
                    try {
                        FS.mkdir(d, mode)
                    } catch (e) {
                        if (e.errno != 20) throw e
                    }
                }
            },
            mkdev(path, mode, dev) {
                if (typeof dev == "undefined") {
                    dev = mode;
                    mode = 438
                }
                mode |= 8192;
                return FS.mknod(path, mode, dev)
            },
            symlink(oldpath, newpath) {
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
            rename(old_path, new_path) {
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
                    old_dir.node_ops.rename(old_node, new_dir, new_name);
                    old_node.parent = new_dir
                } catch (e) {
                    throw e
                } finally {
                    FS.hashAddNode(old_node)
                }
            },
            rmdir(path) {
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
            readdir(path) {
                var lookup = FS.lookupPath(path, {
                    follow: true
                });
                var node = lookup.node;
                var readdir = FS.checkOpExists(node.node_ops.readdir, 54);
                return readdir(node)
            },
            unlink(path) {
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
            readlink(path) {
                var lookup = FS.lookupPath(path);
                var link = lookup.node;
                if (!link) {
                    throw new FS.ErrnoError(44)
                }
                if (!link.node_ops.readlink) {
                    throw new FS.ErrnoError(28)
                }
                return link.node_ops.readlink(link)
            },
            stat(path, dontFollow) {
                var lookup = FS.lookupPath(path, {
                    follow: !dontFollow
                });
                var node = lookup.node;
                var getattr = FS.checkOpExists(node.node_ops.getattr, 63);
                return getattr(node)
            },
            fstat(fd) {
                var stream = FS.getStreamChecked(fd);
                var node = stream.node;
                var getattr = stream.stream_ops.getattr;
                var arg = getattr ? stream : node;
                getattr = node.node_ops.getattr;
                FS.checkOpExists(getattr, 63);
                return getattr(arg)
            },
            lstat(path) {
                return FS.stat(path, true)
            },
            doChmod(stream, node, mode, dontFollow) {
                FS.doSetAttr(stream, node, {
                    mode: mode & 4095 | node.mode & ~4095,
                    ctime: Date.now(),
                    dontFollow
                })
            },
            chmod(path, mode, dontFollow) {
                var node;
                if (typeof path == "string") {
                    var lookup = FS.lookupPath(path, {
                        follow: !dontFollow
                    });
                    node = lookup.node
                } else {
                    node = path
                }
                FS.doChmod(null, node, mode, dontFollow)
            },
            lchmod(path, mode) {
                FS.chmod(path, mode, true)
            },
            fchmod(fd, mode) {
                var stream = FS.getStreamChecked(fd);
                FS.doChmod(stream, stream.node, mode, false)
            },
            doChown(stream, node, dontFollow) {
                FS.doSetAttr(stream, node, {
                    timestamp: Date.now(),
                    dontFollow
                })
            },
            chown(path, uid, gid, dontFollow) {
                var node;
                if (typeof path == "string") {
                    var lookup = FS.lookupPath(path, {
                        follow: !dontFollow
                    });
                    node = lookup.node
                } else {
                    node = path
                }
                FS.doChown(null, node, dontFollow)
            },
            lchown(path, uid, gid) {
                FS.chown(path, uid, gid, true)
            },
            fchown(fd, uid, gid) {
                var stream = FS.getStreamChecked(fd);
                FS.doChown(stream, stream.node, false)
            },
            doTruncate(stream, node, len) {
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
                FS.doSetAttr(stream, node, {
                    size: len,
                    timestamp: Date.now()
                })
            },
            truncate(path, len) {
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
                FS.doTruncate(null, node, len)
            },
            ftruncate(fd, len) {
                var stream = FS.getStreamChecked(fd);
                if (len < 0 || (stream.flags & 2097155) === 0) {
                    throw new FS.ErrnoError(28)
                }
                FS.doTruncate(stream, stream.node, len)
            },
            utime(path, atime, mtime) {
                var lookup = FS.lookupPath(path, {
                    follow: true
                });
                var node = lookup.node;
                var setattr = FS.checkOpExists(node.node_ops.setattr, 63);
                setattr(node, {
                    atime,
                    mtime
                })
            },
            open(path, flags, mode = 438) {
                if (path === "") {
                    throw new FS.ErrnoError(44)
                }
                flags = typeof flags == "string" ? FS_modeStringToFlags(flags) : flags;
                if (flags & 64) {
                    mode = mode & 4095 | 32768
                } else {
                    mode = 0
                }
                var node;
                var isDirPath;
                if (typeof path == "object") {
                    node = path
                } else {
                    isDirPath = path.endsWith("/");
                    var lookup = FS.lookupPath(path, {
                        follow: !(flags & 131072),
                        noent_okay: true
                    });
                    node = lookup.node;
                    path = lookup.path
                }
                var created = false;
                if (flags & 64) {
                    if (node) {
                        if (flags & 128) {
                            throw new FS.ErrnoError(20)
                        }
                    } else if (isDirPath) {
                        throw new FS.ErrnoError(31)
                    } else {
                        node = FS.mknod(path, mode | 511, 0);
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
                    node,
                    path: FS.getPath(node),
                    flags,
                    seekable: true,
                    position: 0,
                    stream_ops: node.stream_ops,
                    ungotten: [],
                    error: false
                });
                if (stream.stream_ops.open) {
                    stream.stream_ops.open(stream)
                }
                if (created) {
                    FS.chmod(node, mode & 511)
                }
                if (Module["logReadFiles"] && !(flags & 1)) {
                    if (!(path in FS.readFiles)) {
                        FS.readFiles[path] = 1
                    }
                }
                return stream
            },
            close(stream) {
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
            isClosed(stream) {
                return stream.fd === null
            },
            llseek(stream, offset, whence) {
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
            read(stream, buffer, offset, length, position) {
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
            write(stream, buffer, offset, length, position, canOwn) {
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
            mmap(stream, length, position, prot, flags) {
                if ((prot & 2) !== 0 && (flags & 2) === 0 && (stream.flags & 2097155) !== 2) {
                    throw new FS.ErrnoError(2)
                }
                if ((stream.flags & 2097155) === 1) {
                    throw new FS.ErrnoError(2)
                }
                if (!stream.stream_ops.mmap) {
                    throw new FS.ErrnoError(43)
                }
                if (!length) {
                    throw new FS.ErrnoError(28)
                }
                return stream.stream_ops.mmap(stream, length, position, prot, flags)
            },
            msync(stream, buffer, offset, length, mmapFlags) {
                if (!stream.stream_ops.msync) {
                    return 0
                }
                return stream.stream_ops.msync(stream, buffer, offset, length, mmapFlags)
            },
            ioctl(stream, cmd, arg) {
                if (!stream.stream_ops.ioctl) {
                    throw new FS.ErrnoError(59)
                }
                return stream.stream_ops.ioctl(stream, cmd, arg)
            },
            readFile(path, opts = {}) {
                opts.flags = opts.flags || 0;
                opts.encoding = opts.encoding || "binary";
                if (opts.encoding !== "utf8" && opts.encoding !== "binary") {
                    throw new Error(`Invalid encoding type "${opts.encoding}"`)
                }
                var stream = FS.open(path, opts.flags);
                var stat = FS.stat(path);
                var length = stat.size;
                var buf = new Uint8Array(length);
                FS.read(stream, buf, 0, length, 0);
                if (opts.encoding === "utf8") {
                    buf = UTF8ArrayToString(buf)
                }
                FS.close(stream);
                return buf
            },
            writeFile(path, data, opts = {}) {
                opts.flags = opts.flags || 577;
                var stream = FS.open(path, opts.flags, opts.mode);
                if (typeof data == "string") {
                    data = new Uint8Array(intArrayFromString(data, true))
                }
                if (ArrayBuffer.isView(data)) {
                    FS.write(stream, data, 0, data.byteLength, undefined, opts.canOwn)
                } else {
                    throw new Error("Unsupported data type")
                }
                FS.close(stream)
            },
            cwd: () => FS.currentPath,
            chdir(path) {
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
            createDefaultDirectories() {
                FS.mkdir("/tmp");
                FS.mkdir("/home");
                FS.mkdir("/home/web_user")
            },
            createDefaultDevices() {
                FS.mkdir("/dev");
                FS.registerDevice(FS.makedev(1, 3), {
                    read: () => 0,
                    write: (stream, buffer, offset, length, pos) => length,
                    llseek: () => 0
                });
                FS.mkdev("/dev/null", FS.makedev(1, 3));
                TTY.register(FS.makedev(5, 0), TTY.default_tty_ops);
                TTY.register(FS.makedev(6, 0), TTY.default_tty1_ops);
                FS.mkdev("/dev/tty", FS.makedev(5, 0));
                FS.mkdev("/dev/tty1", FS.makedev(6, 0));
                var randomBuffer = new Uint8Array(1024),
                    randomLeft = 0;
                var randomByte = () => {
                    if (randomLeft === 0) {
                        randomFill(randomBuffer);
                        randomLeft = randomBuffer.byteLength
                    }
                    return randomBuffer[--randomLeft]
                };
                FS.createDevice("/dev", "random", randomByte);
                FS.createDevice("/dev", "urandom", randomByte);
                FS.mkdir("/dev/shm");
                FS.mkdir("/dev/shm/tmp")
            },
            createSpecialDirectories() {
                FS.mkdir("/proc");
                var proc_self = FS.mkdir("/proc/self");
                FS.mkdir("/proc/self/fd");
                FS.mount({
                    mount() {
                        var node = FS.createNode(proc_self, "fd", 16895, 73);
                        node.stream_ops = {
                            llseek: MEMFS.stream_ops.llseek
                        };
                        node.node_ops = {
                            lookup(parent, name) {
                                var fd = +name;
                                var stream = FS.getStreamChecked(fd);
                                var ret = {
                                    parent: null,
                                    mount: {
                                        mountpoint: "fake"
                                    },
                                    node_ops: {
                                        readlink: () => stream.path
                                    },
                                    id: fd + 1
                                };
                                ret.parent = ret;
                                return ret
                            },
                            readdir() {
                                return Array.from(FS.streams.entries()).filter(([k, v]) => v).map(([k, v]) => k.toString())
                            }
                        };
                        return node
                    }
                }, {}, "/proc/self/fd")
            },
            createStandardStreams(input, output, error) {
                if (input) {
                    FS.createDevice("/dev", "stdin", input)
                } else {
                    FS.symlink("/dev/tty", "/dev/stdin")
                }
                if (output) {
                    FS.createDevice("/dev", "stdout", null, output)
                } else {
                    FS.symlink("/dev/tty", "/dev/stdout")
                }
                if (error) {
                    FS.createDevice("/dev", "stderr", null, error)
                } else {
                    FS.symlink("/dev/tty1", "/dev/stderr")
                }
                var stdin = FS.open("/dev/stdin", 0);
                var stdout = FS.open("/dev/stdout", 1);
                var stderr = FS.open("/dev/stderr", 1)
            },
            staticInit() {
                FS.nameTable = new Array(4096);
                FS.mount(MEMFS, {}, "/");
                FS.createDefaultDirectories();
                FS.createDefaultDevices();
                FS.createSpecialDirectories();
                FS.filesystems = {
                    MEMFS
                }
            },
            init(input, output, error) {
                FS.initialized = true;
                input = Module["stdin"];
                output = Module["stdout"];
                error = Module["stderr"];
                FS.createStandardStreams(input, output, error)
            },
            quit() {
                FS.initialized = false;
                for (var stream of FS.streams) {
                    if (stream) {
                        FS.close(stream)
                    }
                }
            },
            findObject(path, dontResolveLastLink) {
                var ret = FS.analyzePath(path, dontResolveLastLink);
                if (!ret.exists) {
                    return null
                }
                return ret.object
            },
            analyzePath(path, dontResolveLastLink) {
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
            createPath(parent, path, canRead, canWrite) {
                parent = typeof parent == "string" ? parent : FS.getPath(parent);
                var parts = path.split("/").reverse();
                while (parts.length) {
                    var part = parts.pop();
                    if (!part) continue;
                    var current = PATH.join2(parent, part);
                    try {
                        FS.mkdir(current)
                    } catch (e) {
                        if (e.errno != 20) throw e
                    }
                    parent = current
                }
                return current
            },
            createFile(parent, name, properties, canRead, canWrite) {
                var path = PATH.join2(typeof parent == "string" ? parent : FS.getPath(parent), name);
                var mode = FS_getMode(canRead, canWrite);
                return FS.create(path, mode)
            },
            createDataFile(parent, name, data, canRead, canWrite, canOwn) {
                var path = name;
                if (parent) {
                    parent = typeof parent == "string" ? parent : FS.getPath(parent);
                    path = name ? PATH.join2(parent, name) : parent
                }
                var mode = FS_getMode(canRead, canWrite);
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
            },
            createDevice(parent, name, input, output) {
                var path = PATH.join2(typeof parent == "string" ? parent : FS.getPath(parent), name);
                var mode = FS_getMode(!!input, !!output);
                FS.createDevice.major = 64;
                var dev = FS.makedev(FS.createDevice.major++, 0);
                FS.registerDevice(dev, {
                    open(stream) {
                        stream.seekable = false
                    },
                    close(stream) {
                        if (output && output.buffer && output.buffer.length) {
                            output(10)
                        }
                    },
                    read(stream, buffer, offset, length, pos) {
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
                            stream.node.atime = Date.now()
                        }
                        return bytesRead
                    },
                    write(stream, buffer, offset, length, pos) {
                        for (var i = 0; i < length; i++) {
                            try {
                                output(buffer[offset + i])
                            } catch (e) {
                                throw new FS.ErrnoError(29)
                            }
                        }
                        if (length) {
                            stream.node.mtime = stream.node.ctime = Date.now()
                        }
                        return i
                    }
                });
                return FS.mkdev(path, mode, dev)
            },
            forceLoadFile(obj) {
                if (obj.isDevice || obj.isFolder || obj.link || obj.contents) return true;
                if (typeof XMLHttpRequest != "undefined") {
                    throw new Error("Lazy loading should have been performed (contents set) in createLazyFile, but it was not. Lazy loading only works in web workers. Use --embed-file or --preload-file in emcc on the main thread.")
                } else {
                    try {
                        obj.contents = readBinary(obj.url);
                        obj.usedBytes = obj.contents.length
                    } catch (e) {
                        throw new FS.ErrnoError(29)
                    }
                }
            },
            createLazyFile(parent, name, url, canRead, canWrite) {
                class LazyUint8Array {
                    lengthKnown = false;
                    chunks = [];
                    get(idx) {
                        if (idx > this.length - 1 || idx < 0) {
                            return undefined
                        }
                        var chunkOffset = idx % this.chunkSize;
                        var chunkNum = idx / this.chunkSize | 0;
                        return this.getter(chunkNum)[chunkOffset]
                    }
                    setDataGetter(getter) {
                        this.getter = getter
                    }
                    cacheLength() {
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
                    }
                    get length() {
                        if (!this.lengthKnown) {
                            this.cacheLength()
                        }
                        return this._length
                    }
                    get chunkSize() {
                        if (!this.lengthKnown) {
                            this.cacheLength()
                        }
                        return this._chunkSize
                    }
                }
                if (typeof XMLHttpRequest != "undefined") {
                    if (!ENVIRONMENT_IS_WORKER) throw "Cannot do synchronous binary XHRs outside webworkers in modern browsers. Use --embed-file or --preload-file in emcc";
                    var lazyArray = new LazyUint8Array;
                    var properties = {
                        isDevice: false,
                        contents: lazyArray
                    }
                } else {
                    var properties = {
                        isDevice: false,
                        url
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
                    stream_ops[key] = (...args) => {
                        FS.forceLoadFile(node);
                        return fn(...args)
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
                        ptr,
                        allocated: true
                    }
                };
                node.stream_ops = stream_ops;
                return node
            }
        };
        var UTF8ToString = (ptr, maxBytesToRead) => {
            ptr >>>= 0;
            return ptr ? UTF8ArrayToString(HEAPU8, ptr, maxBytesToRead) : ""
        };
        var SYSCALLS = {
            DEFAULT_POLLMASK: 5,
            calculateAt(dirfd, path, allowEmpty) {
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
                return dir + "/" + path
            },
            writeStat(buf, stat) {
                HEAP32[buf >>> 2 >>> 0] = stat.dev;
                HEAP32[buf + 4 >>> 2 >>> 0] = stat.mode;
                HEAPU32[buf + 8 >>> 2 >>> 0] = stat.nlink;
                HEAP32[buf + 12 >>> 2 >>> 0] = stat.uid;
                HEAP32[buf + 16 >>> 2 >>> 0] = stat.gid;
                HEAP32[buf + 20 >>> 2 >>> 0] = stat.rdev;
                HEAP64[buf + 24 >>> 3 >>> 0] = BigInt(stat.size);
                HEAP32[buf + 32 >>> 2 >>> 0] = 4096;
                HEAP32[buf + 36 >>> 2 >>> 0] = stat.blocks;
                var atime = stat.atime.getTime();
                var mtime = stat.mtime.getTime();
                var ctime = stat.ctime.getTime();
                HEAP64[buf + 40 >>> 3 >>> 0] = BigInt(Math.floor(atime / 1e3));
                HEAPU32[buf + 48 >>> 2 >>> 0] = atime % 1e3 * 1e3 * 1e3;
                HEAP64[buf + 56 >>> 3 >>> 0] = BigInt(Math.floor(mtime / 1e3));
                HEAPU32[buf + 64 >>> 2 >>> 0] = mtime % 1e3 * 1e3 * 1e3;
                HEAP64[buf + 72 >>> 3 >>> 0] = BigInt(Math.floor(ctime / 1e3));
                HEAPU32[buf + 80 >>> 2 >>> 0] = ctime % 1e3 * 1e3 * 1e3;
                HEAP64[buf + 88 >>> 3 >>> 0] = BigInt(stat.ino);
                return 0
            },
            writeStatFs(buf, stats) {
                HEAP32[buf + 4 >>> 2 >>> 0] = stats.bsize;
                HEAP32[buf + 40 >>> 2 >>> 0] = stats.bsize;
                HEAP32[buf + 8 >>> 2 >>> 0] = stats.blocks;
                HEAP32[buf + 12 >>> 2 >>> 0] = stats.bfree;
                HEAP32[buf + 16 >>> 2 >>> 0] = stats.bavail;
                HEAP32[buf + 20 >>> 2 >>> 0] = stats.files;
                HEAP32[buf + 24 >>> 2 >>> 0] = stats.ffree;
                HEAP32[buf + 28 >>> 2 >>> 0] = stats.fsid;
                HEAP32[buf + 44 >>> 2 >>> 0] = stats.flags;
                HEAP32[buf + 36 >>> 2 >>> 0] = stats.namelen
            },
            doMsync(addr, stream, len, flags, offset) {
                if (!FS.isFile(stream.node.mode)) {
                    throw new FS.ErrnoError(43)
                }
                if (flags & 2) {
                    return 0
                }
                var buffer = HEAPU8.slice(addr, addr + len);
                FS.msync(stream, buffer, offset, len, flags)
            },
            getStreamFromFD(fd) {
                var stream = FS.getStreamChecked(fd);
                return stream
            },
            varargs: undefined,
            getStr(ptr) {
                var ret = UTF8ToString(ptr);
                return ret
            }
        };
        var INT53_MAX = 9007199254740992;
        var INT53_MIN = -9007199254740992;
        var bigintToI53Checked = num => num < INT53_MIN || num > INT53_MAX ? NaN : Number(num);

        function ___syscall_fcntl64(fd, cmd, varargs) {
            varargs >>>= 0;
            SYSCALLS.varargs = varargs;
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                switch (cmd) {
                    case 0: {
                        var arg = syscallGetVarargI();
                        if (arg < 0) {
                            return -28
                        }
                        while (FS.streams[arg]) {
                            arg++
                        }
                        var newStream;
                        newStream = FS.dupStream(stream, arg);
                        return newStream.fd
                    }
                    case 1:
                    case 2:
                        return 0;
                    case 3:
                        return stream.flags;
                    case 4: {
                        var arg = syscallGetVarargI();
                        stream.flags |= arg;
                        return 0
                    }
                    case 12: {
                        var arg = syscallGetVarargP();
                        var offset = 0;
                        HEAP16[arg + offset >>> 1 >>> 0] = 2;
                        return 0
                    }
                    case 13:
                    case 14:
                        return 0
                }
                return -28
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_fstat64(fd, buf) {
            buf >>>= 0;
            try {
                return SYSCALLS.writeStat(buf, FS.fstat(fd))
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_ftruncate64(fd, length) {
            length = bigintToI53Checked(length);
            try {
                if (isNaN(length)) return -61;
                FS.ftruncate(fd, length);
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }
        var stringToUTF8 = (str, outPtr, maxBytesToWrite) => stringToUTF8Array(str, HEAPU8, outPtr, maxBytesToWrite);

        function ___syscall_getdents64(fd, dirp, count) {
            dirp >>>= 0;
            count >>>= 0;
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                stream.getdents = FS.readdir(stream.path);
                var struct_size = 280;
                var pos = 0;
                var off = FS.llseek(stream, 0, 1);
                var startIdx = Math.floor(off / struct_size);
                var endIdx = Math.min(stream.getdents.length, startIdx + Math.floor(count / struct_size));
                for (var idx = startIdx; idx < endIdx; idx++) {
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
                        var child;
                        try {
                            child = FS.lookupNode(stream.node, name)
                        } catch (e) {
                            if (e && e.errno === 28) {
                                continue
                            }
                            throw e
                        }
                        id = child.id;
                        type = FS.isChrdev(child.mode) ? 2 : FS.isDir(child.mode) ? 4 : FS.isLink(child.mode) ? 10 : 8
                    }
                    HEAP64[dirp + pos >>> 3 >>> 0] = BigInt(id);
                    HEAP64[dirp + pos + 8 >>> 3 >>> 0] = BigInt((idx + 1) * struct_size);
                    HEAP16[dirp + pos + 16 >>> 1 >>> 0] = 280;
                    HEAP8[dirp + pos + 18 >>> 0] = type;
                    stringToUTF8(name, dirp + pos + 19, 256);
                    pos += struct_size
                }
                FS.llseek(stream, idx * struct_size, 0);
                return pos
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_ioctl(fd, op, varargs) {
            varargs >>>= 0;
            SYSCALLS.varargs = varargs;
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                switch (op) {
                    case 21509: {
                        if (!stream.tty) return -59;
                        return 0
                    }
                    case 21505: {
                        if (!stream.tty) return -59;
                        if (stream.tty.ops.ioctl_tcgets) {
                            var termios = stream.tty.ops.ioctl_tcgets(stream);
                            var argp = syscallGetVarargP();
                            HEAP32[argp >>> 2 >>> 0] = termios.c_iflag || 0;
                            HEAP32[argp + 4 >>> 2 >>> 0] = termios.c_oflag || 0;
                            HEAP32[argp + 8 >>> 2 >>> 0] = termios.c_cflag || 0;
                            HEAP32[argp + 12 >>> 2 >>> 0] = termios.c_lflag || 0;
                            for (var i = 0; i < 32; i++) {
                                HEAP8[argp + i + 17 >>> 0] = termios.c_cc[i] || 0
                            }
                            return 0
                        }
                        return 0
                    }
                    case 21510:
                    case 21511:
                    case 21512: {
                        if (!stream.tty) return -59;
                        return 0
                    }
                    case 21506:
                    case 21507:
                    case 21508: {
                        if (!stream.tty) return -59;
                        if (stream.tty.ops.ioctl_tcsets) {
                            var argp = syscallGetVarargP();
                            var c_iflag = HEAP32[argp >>> 2 >>> 0];
                            var c_oflag = HEAP32[argp + 4 >>> 2 >>> 0];
                            var c_cflag = HEAP32[argp + 8 >>> 2 >>> 0];
                            var c_lflag = HEAP32[argp + 12 >>> 2 >>> 0];
                            var c_cc = [];
                            for (var i = 0; i < 32; i++) {
                                c_cc.push(HEAP8[argp + i + 17 >>> 0])
                            }
                            return stream.tty.ops.ioctl_tcsets(stream.tty, op, {
                                c_iflag,
                                c_oflag,
                                c_cflag,
                                c_lflag,
                                c_cc
                            })
                        }
                        return 0
                    }
                    case 21519: {
                        if (!stream.tty) return -59;
                        var argp = syscallGetVarargP();
                        HEAP32[argp >>> 2 >>> 0] = 0;
                        return 0
                    }
                    case 21520: {
                        if (!stream.tty) return -59;
                        return -28
                    }
                    case 21531: {
                        var argp = syscallGetVarargP();
                        return FS.ioctl(stream, op, argp)
                    }
                    case 21523: {
                        if (!stream.tty) return -59;
                        if (stream.tty.ops.ioctl_tiocgwinsz) {
                            var winsize = stream.tty.ops.ioctl_tiocgwinsz(stream.tty);
                            var argp = syscallGetVarargP();
                            HEAP16[argp >>> 1 >>> 0] = winsize[0];
                            HEAP16[argp + 2 >>> 1 >>> 0] = winsize[1]
                        }
                        return 0
                    }
                    case 21524: {
                        if (!stream.tty) return -59;
                        return 0
                    }
                    case 21515: {
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
            path >>>= 0;
            buf >>>= 0;
            try {
                path = SYSCALLS.getStr(path);
                return SYSCALLS.writeStat(buf, FS.lstat(path))
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_newfstatat(dirfd, path, buf, flags) {
            path >>>= 0;
            buf >>>= 0;
            try {
                path = SYSCALLS.getStr(path);
                var nofollow = flags & 256;
                var allowEmpty = flags & 4096;
                flags = flags & ~6400;
                path = SYSCALLS.calculateAt(dirfd, path, allowEmpty);
                return SYSCALLS.writeStat(buf, nofollow ? FS.lstat(path) : FS.stat(path))
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_openat(dirfd, path, flags, varargs) {
            path >>>= 0;
            varargs >>>= 0;
            SYSCALLS.varargs = varargs;
            try {
                path = SYSCALLS.getStr(path);
                path = SYSCALLS.calculateAt(dirfd, path);
                var mode = varargs ? syscallGetVarargI() : 0;
                return FS.open(path, flags, mode).fd
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_rmdir(path) {
            path >>>= 0;
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
            path >>>= 0;
            buf >>>= 0;
            try {
                path = SYSCALLS.getStr(path);
                return SYSCALLS.writeStat(buf, FS.stat(path))
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }

        function ___syscall_unlinkat(dirfd, path, flags) {
            path >>>= 0;
            try {
                path = SYSCALLS.getStr(path);
                path = SYSCALLS.calculateAt(dirfd, path);
                if (!flags) {
                    FS.unlink(path)
                } else if (flags === 512) {
                    FS.rmdir(path)
                } else {
                    return -28
                }
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return -e.errno
            }
        }
        var __abort_js = () => abort("");
        var __emscripten_throw_longjmp = () => {
            throw Infinity
        };

        function __gmtime_js(time, tmPtr) {
            time = bigintToI53Checked(time);
            tmPtr >>>= 0;
            var date = new Date(time * 1e3);
            HEAP32[tmPtr >>> 2 >>> 0] = date.getUTCSeconds();
            HEAP32[tmPtr + 4 >>> 2 >>> 0] = date.getUTCMinutes();
            HEAP32[tmPtr + 8 >>> 2 >>> 0] = date.getUTCHours();
            HEAP32[tmPtr + 12 >>> 2 >>> 0] = date.getUTCDate();
            HEAP32[tmPtr + 16 >>> 2 >>> 0] = date.getUTCMonth();
            HEAP32[tmPtr + 20 >>> 2 >>> 0] = date.getUTCFullYear() - 1900;
            HEAP32[tmPtr + 24 >>> 2 >>> 0] = date.getUTCDay();
            var start = Date.UTC(date.getUTCFullYear(), 0, 1, 0, 0, 0, 0);
            var yday = (date.getTime() - start) / (1e3 * 60 * 60 * 24) | 0;
            HEAP32[tmPtr + 28 >>> 2 >>> 0] = yday
        }
        var isLeapYear = year => year % 4 === 0 && (year % 100 !== 0 || year % 400 === 0);
        var MONTH_DAYS_LEAP_CUMULATIVE = [0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335];
        var MONTH_DAYS_REGULAR_CUMULATIVE = [0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334];
        var ydayFromDate = date => {
            var leap = isLeapYear(date.getFullYear());
            var monthDaysCumulative = leap ? MONTH_DAYS_LEAP_CUMULATIVE : MONTH_DAYS_REGULAR_CUMULATIVE;
            var yday = monthDaysCumulative[date.getMonth()] + date.getDate() - 1;
            return yday
        };

        function __localtime_js(time, tmPtr) {
            time = bigintToI53Checked(time);
            tmPtr >>>= 0;
            var date = new Date(time * 1e3);
            HEAP32[tmPtr >>> 2 >>> 0] = date.getSeconds();
            HEAP32[tmPtr + 4 >>> 2 >>> 0] = date.getMinutes();
            HEAP32[tmPtr + 8 >>> 2 >>> 0] = date.getHours();
            HEAP32[tmPtr + 12 >>> 2 >>> 0] = date.getDate();
            HEAP32[tmPtr + 16 >>> 2 >>> 0] = date.getMonth();
            HEAP32[tmPtr + 20 >>> 2 >>> 0] = date.getFullYear() - 1900;
            HEAP32[tmPtr + 24 >>> 2 >>> 0] = date.getDay();
            var yday = ydayFromDate(date) | 0;
            HEAP32[tmPtr + 28 >>> 2 >>> 0] = yday;
            HEAP32[tmPtr + 36 >>> 2 >>> 0] = -(date.getTimezoneOffset() * 60);
            var start = new Date(date.getFullYear(), 0, 1);
            var summerOffset = new Date(date.getFullYear(), 6, 1).getTimezoneOffset();
            var winterOffset = start.getTimezoneOffset();
            var dst = (summerOffset != winterOffset && date.getTimezoneOffset() == Math.min(winterOffset, summerOffset)) | 0;
            HEAP32[tmPtr + 32 >>> 2 >>> 0] = dst
        }
        var __tzset_js = function (timezone, daylight, std_name, dst_name) {
            timezone >>>= 0;
            daylight >>>= 0;
            std_name >>>= 0;
            dst_name >>>= 0;
            var currentYear = (new Date).getFullYear();
            var winter = new Date(currentYear, 0, 1);
            var summer = new Date(currentYear, 6, 1);
            var winterOffset = winter.getTimezoneOffset();
            var summerOffset = summer.getTimezoneOffset();
            var stdTimezoneOffset = Math.max(winterOffset, summerOffset);
            HEAPU32[timezone >>> 2 >>> 0] = stdTimezoneOffset * 60;
            HEAP32[daylight >>> 2 >>> 0] = Number(winterOffset != summerOffset);
            var extractZone = timezoneOffset => {
                var sign = timezoneOffset >= 0 ? "-" : "+";
                var absOffset = Math.abs(timezoneOffset);
                var hours = String(Math.floor(absOffset / 60)).padStart(2, "0");
                var minutes = String(absOffset % 60).padStart(2, "0");
                return `UTC${sign}${hours}${minutes}`
            };
            var winterName = extractZone(winterOffset);
            var summerName = extractZone(summerOffset);
            if (summerOffset < winterOffset) {
                stringToUTF8(winterName, std_name, 17);
                stringToUTF8(summerName, dst_name, 17)
            } else {
                stringToUTF8(winterName, dst_name, 17);
                stringToUTF8(summerName, std_name, 17)
            }
        };
        var _emscripten_date_now = () => Date.now();
        var getHeapMax = () => 4294901760;
        var growMemory = size => {
            var b = wasmMemory.buffer;
            var pages = (size - b.byteLength + 65535) / 65536 | 0;
            try {
                wasmMemory.grow(pages);
                updateMemoryViews();
                return 1
            } catch (e) {}
        };

        function _emscripten_resize_heap(requestedSize) {
            requestedSize >>>= 0;
            var oldSize = HEAPU8.length;
            var maxHeapSize = getHeapMax();
            if (requestedSize > maxHeapSize) {
                return false
            }
            for (var cutDown = 1; cutDown <= 4; cutDown *= 2) {
                var overGrownHeapSize = oldSize * (1 + .2 / cutDown);
                overGrownHeapSize = Math.min(overGrownHeapSize, requestedSize + 100663296);
                var newSize = Math.min(maxHeapSize, alignMemory(Math.max(requestedSize, overGrownHeapSize), 65536));
                var replacement = growMemory(newSize);
                if (replacement) {
                    return true
                }
            }
            return false
        }
        var ENV = {};
        var getExecutableName = () => thisProgram || "./this.program";
        var getEnvStrings = () => {
            if (!getEnvStrings.strings) {
                var lang = (typeof navigator == "object" && navigator.language || "C").replace("-", "_") + ".UTF-8";
                var env = {
                    USER: "web_user",
                    LOGNAME: "web_user",
                    PATH: "/",
                    PWD: "/",
                    HOME: "/home/web_user",
                    LANG: lang,
                    _: getExecutableName()
                };
                for (var x in ENV) {
                    if (ENV[x] === undefined) delete env[x];
                    else env[x] = ENV[x]
                }
                var strings = [];
                for (var x in env) {
                    strings.push(`${x}=${env[x]}`)
                }
                getEnvStrings.strings = strings
            }
            return getEnvStrings.strings
        };

        function _environ_get(__environ, environ_buf) {
            __environ >>>= 0;
            environ_buf >>>= 0;
            var bufSize = 0;
            var envp = 0;
            for (var string of getEnvStrings()) {
                var ptr = environ_buf + bufSize;
                HEAPU32[__environ + envp >>> 2 >>> 0] = ptr;
                bufSize += stringToUTF8(string, ptr, Infinity) + 1;
                envp += 4
            }
            return 0
        }

        function _environ_sizes_get(penviron_count, penviron_buf_size) {
            penviron_count >>>= 0;
            penviron_buf_size >>>= 0;
            var strings = getEnvStrings();
            HEAPU32[penviron_count >>> 2 >>> 0] = strings.length;
            var bufSize = 0;
            for (var string of strings) {
                bufSize += lengthBytesUTF8(string) + 1
            }
            HEAPU32[penviron_buf_size >>> 2 >>> 0] = bufSize;
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
        var doReadv = (stream, iov, iovcnt, offset) => {
            var ret = 0;
            for (var i = 0; i < iovcnt; i++) {
                var ptr = HEAPU32[iov >>> 2 >>> 0];
                var len = HEAPU32[iov + 4 >>> 2 >>> 0];
                iov += 8;
                var curr = FS.read(stream, HEAP8, ptr, len, offset);
                if (curr < 0) return -1;
                ret += curr;
                if (curr < len) break;
                if (typeof offset != "undefined") {
                    offset += curr
                }
            }
            return ret
        };

        function _fd_read(fd, iov, iovcnt, pnum) {
            iov >>>= 0;
            iovcnt >>>= 0;
            pnum >>>= 0;
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                var num = doReadv(stream, iov, iovcnt);
                HEAPU32[pnum >>> 2 >>> 0] = num;
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return e.errno
            }
        }

        function _fd_seek(fd, offset, whence, newOffset) {
            offset = bigintToI53Checked(offset);
            newOffset >>>= 0;
            try {
                if (isNaN(offset)) return 61;
                var stream = SYSCALLS.getStreamFromFD(fd);
                FS.llseek(stream, offset, whence);
                HEAP64[newOffset >>> 3 >>> 0] = BigInt(stream.position);
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
        var doWritev = (stream, iov, iovcnt, offset) => {
            var ret = 0;
            for (var i = 0; i < iovcnt; i++) {
                var ptr = HEAPU32[iov >>> 2 >>> 0];
                var len = HEAPU32[iov + 4 >>> 2 >>> 0];
                iov += 8;
                var curr = FS.write(stream, HEAP8, ptr, len, offset);
                if (curr < 0) return -1;
                ret += curr;
                if (curr < len) {
                    break
                }
                if (typeof offset != "undefined") {
                    offset += curr
                }
            }
            return ret
        };

        function _fd_write(fd, iov, iovcnt, pnum) {
            iov >>>= 0;
            iovcnt >>>= 0;
            pnum >>>= 0;
            try {
                var stream = SYSCALLS.getStreamFromFD(fd);
                var num = doWritev(stream, iov, iovcnt);
                HEAPU32[pnum >>> 2 >>> 0] = num;
                return 0
            } catch (e) {
                if (typeof FS == "undefined" || !(e.name === "ErrnoError")) throw e;
                return e.errno
            }
        }
        var wasmTableMirror = [];
        var wasmTable;
        var getWasmTableEntry = funcPtr => {
            var func = wasmTableMirror[funcPtr];
            if (!func) {
                wasmTableMirror[funcPtr] = func = wasmTable.get(funcPtr)
            }
            return func
        };
        var getCFunc = ident => {
            var func = Module["_" + ident];
            return func
        };
        var writeArrayToMemory = (array, buffer) => {
            HEAP8.set(array, buffer >>> 0)
        };
        var stackAlloc = sz => __emscripten_stack_alloc(sz);
        var stringToUTF8OnStack = str => {
            var size = lengthBytesUTF8(str) + 1;
            var ret = stackAlloc(size);
            stringToUTF8(str, ret, size);
            return ret
        };
        var ccall = (ident, returnType, argTypes, args, opts) => {
            var toC = {
                string: str => {
                    var ret = 0;
                    if (str !== null && str !== undefined && str !== 0) {
                        ret = stringToUTF8OnStack(str)
                    }
                    return ret
                },
                array: arr => {
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
            var ret = func(...cArgs);

            function onDone(ret) {
                if (stack !== 0) stackRestore(stack);
                return convertReturnValue(ret)
            }
            ret = onDone(ret);
            return ret
        };
        var cwrap = (ident, returnType, argTypes, opts) => {
            var numericArgs = !argTypes || argTypes.every(type => type === "number" || type === "boolean");
            var numericRet = returnType !== "string";
            if (numericRet && numericArgs && !opts) {
                return getCFunc(ident)
            }
            return (...args) => ccall(ident, returnType, argTypes, args, opts)
        };
        var uleb128Encode = (n, target) => {
            if (n < 128) {
                target.push(n)
            } else {
                target.push(n % 128 | 128, n >> 7)
            }
        };
        var sigToWasmTypes = sig => {
            var typeNames = {
                i: "i32",
                j: "i64",
                f: "f32",
                d: "f64",
                e: "externref",
                p: "i32"
            };
            var type = {
                parameters: [],
                results: sig[0] == "v" ? [] : [typeNames[sig[0]]]
            };
            for (var i = 1; i < sig.length; ++i) {
                type.parameters.push(typeNames[sig[i]])
            }
            return type
        };
        var generateFuncType = (sig, target) => {
            var sigRet = sig.slice(0, 1);
            var sigParam = sig.slice(1);
            var typeCodes = {
                i: 127,
                p: 127,
                j: 126,
                f: 125,
                d: 124,
                e: 111
            };
            target.push(96);
            uleb128Encode(sigParam.length, target);
            for (var paramType of sigParam) {
                target.push(typeCodes[paramType])
            }
            if (sigRet == "v") {
                target.push(0)
            } else {
                target.push(1, typeCodes[sigRet])
            }
        };
        var convertJsFunctionToWasm = (func, sig) => {
            if (typeof WebAssembly.Function == "function") {
                return new WebAssembly.Function(sigToWasmTypes(sig), func)
            }
            var typeSectionBody = [1];
            generateFuncType(sig, typeSectionBody);
            var bytes = [0, 97, 115, 109, 1, 0, 0, 0, 1];
            uleb128Encode(typeSectionBody.length, bytes);
            bytes.push(...typeSectionBody);
            bytes.push(2, 7, 1, 1, 101, 1, 102, 0, 0, 7, 5, 1, 1, 102, 0, 0);
            var module = new WebAssembly.Module(new Uint8Array(bytes));
            var instance = new WebAssembly.Instance(module, {
                e: {
                    f: func
                }
            });
            var wrappedFunc = instance.exports["f"];
            return wrappedFunc
        };
        var updateTableMap = (offset, count) => {
            if (functionsInTableMap) {
                for (var i = offset; i < offset + count; i++) {
                    var item = getWasmTableEntry(i);
                    if (item) {
                        functionsInTableMap.set(item, i)
                    }
                }
            }
        };
        var functionsInTableMap;
        var getFunctionAddress = func => {
            if (!functionsInTableMap) {
                functionsInTableMap = new WeakMap;
                updateTableMap(0, wasmTable.length)
            }
            return functionsInTableMap.get(func) || 0
        };
        var freeTableIndexes = [];
        var getEmptyTableSlot = () => {
            if (freeTableIndexes.length) {
                return freeTableIndexes.pop()
            }
            try {
                wasmTable.grow(1)
            } catch (err) {
                if (!(err instanceof RangeError)) {
                    throw err
                }
                throw "Unable to grow wasm table. Set ALLOW_TABLE_GROWTH."
            }
            return wasmTable.length - 1
        };
        var setWasmTableEntry = (idx, func) => {
            wasmTable.set(idx, func);
            wasmTableMirror[idx] = wasmTable.get(idx)
        };
        var addFunction = (func, sig) => {
            var rtn = getFunctionAddress(func);
            if (rtn) {
                return rtn
            }
            var ret = getEmptyTableSlot();
            try {
                setWasmTableEntry(ret, func)
            } catch (err) {
                if (!(err instanceof TypeError)) {
                    throw err
                }
                var wrapped = convertJsFunctionToWasm(func, sig);
                setWasmTableEntry(ret, wrapped)
            }
            functionsInTableMap.set(func, ret);
            return ret
        };
        var removeFunction = index => {
            functionsInTableMap.delete(getWasmTableEntry(index));
            setWasmTableEntry(index, null);
            freeTableIndexes.push(index)
        };
        FS.createPreloadedFile = FS_createPreloadedFile;
        FS.staticInit();
        Module["FS"] = FS;
        MEMFS.doesNotExistError = new FS.ErrnoError(44);
        MEMFS.doesNotExistError.stack = "<generic error, no stack>"; {
            if (Module["noExitRuntime"]) noExitRuntime = Module["noExitRuntime"];
            if (Module["preloadPlugins"]) preloadPlugins = Module["preloadPlugins"];
            if (Module["print"]) out = Module["print"];
            if (Module["printErr"]) err = Module["printErr"];
            if (Module["wasmBinary"]) wasmBinary = Module["wasmBinary"];
            if (Module["arguments"]) arguments_ = Module["arguments"];
            if (Module["thisProgram"]) thisProgram = Module["thisProgram"]
        }
        Module["ccall"] = ccall;
        Module["cwrap"] = cwrap;
        Module["addFunction"] = addFunction;
        Module["removeFunction"] = removeFunction;
        Module["setValue"] = setValue;
        var _FPDFAnnot_IsSupportedSubtype, _FPDFPage_CreateAnnot, _FPDFPage_GetAnnotCount, _FPDFPage_GetAnnot, _FPDFPage_GetAnnotIndex, _FPDFPage_CloseAnnot, _FPDFPage_RemoveAnnot, _FPDFAnnot_GetSubtype, _FPDFAnnot_IsObjectSupportedSubtype, _FPDFAnnot_UpdateObject, _FPDFAnnot_AddInkStroke, _FPDFAnnot_RemoveInkList, _FPDFAnnot_AppendObject, _FPDFAnnot_GetObjectCount, _FPDFAnnot_GetObject, _FPDFAnnot_RemoveObject, _FPDFAnnot_SetColor, _FPDFAnnot_GetColor, _FPDFAnnot_HasAttachmentPoints, _FPDFAnnot_SetAttachmentPoints, _FPDFAnnot_AppendAttachmentPoints, _FPDFAnnot_CountAttachmentPoints, _FPDFAnnot_GetAttachmentPoints, _FPDFAnnot_SetRect, _FPDFAnnot_GetRect, _FPDFAnnot_GetVertices, _FPDFAnnot_GetInkListCount, _FPDFAnnot_GetInkListPath, _FPDFAnnot_GetLine, _FPDFAnnot_SetBorder, _FPDFAnnot_GetBorder, _FPDFAnnot_HasKey, _FPDFAnnot_GetValueType, _FPDFAnnot_SetStringValue, _FPDFAnnot_GetStringValue, _FPDFAnnot_GetNumberValue, _FPDFAnnot_SetAP, _FPDFAnnot_GetAP, _FPDFAnnot_GetLinkedAnnot, _FPDFAnnot_GetFlags, _FPDFAnnot_SetFlags, _FPDFAnnot_GetFormFieldFlags, _FPDFAnnot_SetFormFieldFlags, _FPDFAnnot_GetFormFieldAtPoint, _FPDFAnnot_GetFormFieldName, _FPDFAnnot_GetFormFieldType, _FPDFAnnot_GetFormAdditionalActionJavaScript, _FPDFAnnot_GetFormFieldAlternateName, _FPDFAnnot_GetFormFieldValue, _FPDFAnnot_GetOptionCount, _FPDFAnnot_GetOptionLabel, _FPDFAnnot_IsOptionSelected, _FPDFAnnot_GetFontSize, _FPDFAnnot_SetFontColor, _FPDFAnnot_GetFontColor, _FPDFAnnot_IsChecked, _FPDFAnnot_SetFocusableSubtypes, _FPDFAnnot_GetFocusableSubtypesCount, _FPDFAnnot_GetFocusableSubtypes, _FPDFAnnot_GetLink, _FPDFAnnot_GetFormControlCount, _FPDFAnnot_GetFormControlIndex, _FPDFAnnot_GetFormFieldExportValue, _FPDFAnnot_SetURI, _FPDFAnnot_GetFileAttachment, _FPDFAnnot_AddFileAttachment, _FPDFDoc_GetAttachmentCount, _FPDFDoc_AddAttachment, _FPDFDoc_GetAttachment, _FPDFDoc_DeleteAttachment, _FPDFAttachment_GetName, _FPDFAttachment_HasKey, _FPDFAttachment_GetValueType, _FPDFAttachment_SetStringValue, _FPDFAttachment_GetStringValue, _FPDFAttachment_SetFile, _FPDFAttachment_GetFile, _FPDFAttachment_GetSubtype, _FPDFCatalog_IsTagged, _FPDFCatalog_SetLanguage, _FPDFAvail_Create, _FPDFAvail_Destroy, _FPDFAvail_IsDocAvail, _FPDFAvail_GetDocument, _FPDFAvail_GetFirstPageNum, _FPDFAvail_IsPageAvail, _FPDFAvail_IsFormAvail, _FPDFAvail_IsLinearized, _FPDFBookmark_GetFirstChild, _FPDFBookmark_GetNextSibling, _FPDFBookmark_GetTitle, _FPDFBookmark_GetCount, _FPDFBookmark_Find, _FPDFBookmark_GetDest, _FPDFBookmark_GetAction, _FPDFAction_GetType, _FPDFAction_GetDest, _FPDFAction_GetFilePath, _FPDFAction_GetURIPath, _FPDFDest_GetDestPageIndex, _FPDFDest_GetView, _FPDFDest_GetLocationInPage, _FPDFLink_GetLinkAtPoint, _FPDFLink_GetLinkZOrderAtPoint, _FPDFLink_GetDest, _FPDFLink_GetAction, _FPDFLink_Enumerate, _FPDFLink_GetAnnot, _FPDFLink_GetAnnotRect, _FPDFLink_CountQuadPoints, _FPDFLink_GetQuadPoints, _FPDF_GetPageAAction, _FPDF_GetFileIdentifier, _FPDF_GetMetaText, _FPDF_GetPageLabel, _FPDFPageObj_NewImageObj, _FPDFImageObj_LoadJpegFile, _FPDFImageObj_LoadJpegFileInline, _FPDFImageObj_SetMatrix, _FPDFImageObj_SetBitmap, _FPDFImageObj_GetBitmap, _FPDFImageObj_GetRenderedBitmap, _FPDFImageObj_GetImageDataDecoded, _FPDFImageObj_GetImageDataRaw, _FPDFImageObj_GetImageFilterCount, _FPDFImageObj_GetImageFilter, _FPDFImageObj_GetImageMetadata, _FPDFImageObj_GetImagePixelSize, _FPDFImageObj_GetIccProfileDataDecoded, _FPDF_CreateNewDocument, _FPDFPage_Delete, _FPDF_MovePages, _FPDFPage_New, _FPDFPage_GetRotation, _FPDFPage_InsertObject, _FPDFPage_InsertObjectAtIndex, _FPDFPage_RemoveObject, _FPDFPage_CountObjects, _FPDFPage_GetObject, _FPDFPage_HasTransparency, _FPDFPageObj_Destroy, _FPDFPageObj_GetMarkedContentID, _FPDFPageObj_CountMarks, _FPDFPageObj_GetMark, _FPDFPageObj_AddMark, _FPDFPageObj_RemoveMark, _FPDFPageObjMark_GetName, _FPDFPageObjMark_CountParams, _FPDFPageObjMark_GetParamKey, _FPDFPageObjMark_GetParamValueType, _FPDFPageObjMark_GetParamIntValue, _FPDFPageObjMark_GetParamStringValue, _FPDFPageObjMark_GetParamBlobValue, _FPDFPageObj_HasTransparency, _FPDFPageObjMark_SetIntParam, _FPDFPageObjMark_SetStringParam, _FPDFPageObjMark_SetBlobParam, _FPDFPageObjMark_RemoveParam, _FPDFPageObj_GetType, _FPDFPageObj_GetIsActive, _FPDFPageObj_SetIsActive, _FPDFPage_GenerateContent, _FPDFPageObj_Transform, _FPDFPageObj_TransformF, _FPDFPageObj_GetMatrix, _FPDFPageObj_SetMatrix, _FPDFPageObj_SetBlendMode, _FPDFPage_TransformAnnots, _FPDFPage_SetRotation, _FPDFPageObj_SetFillColor, _FPDFPageObj_GetFillColor, _FPDFPageObj_GetBounds, _FPDFPageObj_GetRotatedBounds, _FPDFPageObj_SetStrokeColor, _FPDFPageObj_GetStrokeColor, _FPDFPageObj_SetStrokeWidth, _FPDFPageObj_GetStrokeWidth, _FPDFPageObj_GetLineJoin, _FPDFPageObj_SetLineJoin, _FPDFPageObj_GetLineCap, _FPDFPageObj_SetLineCap, _FPDFPageObj_GetDashPhase, _FPDFPageObj_SetDashPhase, _FPDFPageObj_GetDashCount, _FPDFPageObj_GetDashArray, _FPDFPageObj_SetDashArray, _FPDFFormObj_CountObjects, _FPDFFormObj_GetObject, _FPDFFormObj_RemoveObject, _FPDFPageObj_CreateNewPath, _FPDFPageObj_CreateNewRect, _FPDFPath_CountSegments, _FPDFPath_GetPathSegment, _FPDFPath_MoveTo, _FPDFPath_LineTo, _FPDFPath_BezierTo, _FPDFPath_Close, _FPDFPath_SetDrawMode, _FPDFPath_GetDrawMode, _FPDFPathSegment_GetPoint, _FPDFPathSegment_GetType, _FPDFPathSegment_GetClose, _FPDFPageObj_NewTextObj, _FPDFText_SetText, _FPDFText_SetCharcodes, _FPDFText_LoadFont, _FPDFText_LoadStandardFont, _FPDFText_LoadCidType2Font, _FPDFTextObj_GetFontSize, _FPDFTextObj_GetText, _FPDFTextObj_GetRenderedBitmap, _FPDFFont_Close, _FPDFPageObj_CreateTextObj, _FPDFTextObj_GetTextRenderMode, _FPDFTextObj_SetTextRenderMode, _FPDFTextObj_GetFont, _FPDFFont_GetBaseFontName, _FPDFFont_GetFamilyName, _FPDFFont_GetFontData, _FPDFFont_GetIsEmbedded, _FPDFFont_GetFlags, _FPDFFont_GetWeight, _FPDFFont_GetItalicAngle, _FPDFFont_GetAscent, _FPDFFont_GetDescent, _FPDFFont_GetGlyphWidth, _FPDFFont_GetGlyphPath, _FPDFGlyphPath_CountGlyphSegments, _FPDFGlyphPath_GetGlyphPathSegment, _FSDK_SetUnSpObjProcessHandler, _FSDK_SetTimeFunction, _FSDK_SetLocaltimeFunction, _FPDFDoc_GetPageMode, _FPDFPage_Flatten, _FPDFPage_HasFormFieldAtPoint, _FPDFPage_FormFieldZOrderAtPoint, _FPDFDOC_InitFormFillEnvironment, _FPDFDOC_ExitFormFillEnvironment, _FORM_OnMouseMove, _FORM_OnMouseWheel, _FORM_OnFocus, _FORM_OnLButtonDown, _FORM_OnLButtonUp, _FORM_OnLButtonDoubleClick, _FORM_OnRButtonDown, _FORM_OnRButtonUp, _FORM_OnKeyDown, _FORM_OnKeyUp, _FORM_OnChar, _FORM_GetFocusedText, _FORM_GetSelectedText, _FORM_ReplaceAndKeepSelection, _FORM_ReplaceSelection, _FORM_SelectAllText, _FORM_CanUndo, _FORM_CanRedo, _FORM_Undo, _FORM_Redo, _FORM_ForceToKillFocus, _FORM_GetFocusedAnnot, _FORM_SetFocusedAnnot, _FPDF_FFLDraw, _FPDF_SetFormFieldHighlightColor, _FPDF_SetFormFieldHighlightAlpha, _FPDF_RemoveFormFieldHighlight, _FORM_OnAfterLoadPage, _FORM_OnBeforeClosePage, _FORM_DoDocumentJSAction, _FORM_DoDocumentOpenAction, _FORM_DoDocumentAAction, _FORM_DoPageAAction, _FORM_SetIndexSelected, _FORM_IsIndexSelected, _FPDFDoc_GetJavaScriptActionCount, _FPDFDoc_GetJavaScriptAction, _FPDFDoc_CloseJavaScriptAction, _FPDFJavaScriptAction_GetName, _FPDFJavaScriptAction_GetScript, _FPDF_ImportPagesByIndex, _FPDF_ImportPages, _FPDF_ImportNPagesToOne, _FPDF_NewXObjectFromPage, _FPDF_CloseXObject, _FPDF_NewFormObjectFromXObject, _FPDF_CopyViewerPreferences, _FPDF_RenderPageBitmapWithColorScheme_Start, _FPDF_RenderPageBitmap_Start, _FPDF_RenderPage_Continue, _FPDF_RenderPage_Close, _FPDF_SaveAsCopy, _FPDF_SaveWithVersion, _FPDFText_GetCharIndexFromTextIndex, _FPDFText_GetTextIndexFromCharIndex, _FPDF_GetSignatureCount, _FPDF_GetSignatureObject, _FPDFSignatureObj_GetContents, _FPDFSignatureObj_GetByteRange, _FPDFSignatureObj_GetSubFilter, _FPDFSignatureObj_GetReason, _FPDFSignatureObj_GetTime, _FPDFSignatureObj_GetDocMDPPermission, _FPDF_StructTree_GetForPage, _FPDF_StructTree_Close, _FPDF_StructTree_CountChildren, _FPDF_StructTree_GetChildAtIndex, _FPDF_StructElement_GetAltText, _FPDF_StructElement_GetActualText, _FPDF_StructElement_GetID, _FPDF_StructElement_GetLang, _FPDF_StructElement_GetAttributeCount, _FPDF_StructElement_GetAttributeAtIndex, _FPDF_StructElement_GetStringAttribute, _FPDF_StructElement_GetMarkedContentID, _FPDF_StructElement_GetType, _FPDF_StructElement_GetObjType, _FPDF_StructElement_GetTitle, _FPDF_StructElement_CountChildren, _FPDF_StructElement_GetChildAtIndex, _FPDF_StructElement_GetChildMarkedContentID, _FPDF_StructElement_GetParent, _FPDF_StructElement_Attr_GetCount, _FPDF_StructElement_Attr_GetName, _FPDF_StructElement_Attr_GetValue, _FPDF_StructElement_Attr_GetType, _FPDF_StructElement_Attr_GetBooleanValue, _FPDF_StructElement_Attr_GetNumberValue, _FPDF_StructElement_Attr_GetStringValue, _FPDF_StructElement_Attr_GetBlobValue, _FPDF_StructElement_Attr_CountChildren, _FPDF_StructElement_Attr_GetChildAtIndex, _FPDF_StructElement_GetMarkedContentIdCount, _FPDF_StructElement_GetMarkedContentIdAtIndex, _FPDF_AddInstalledFont, _FPDF_SetSystemFontInfo, _FPDF_GetDefaultTTFMap, _FPDF_GetDefaultTTFMapCount, _FPDF_GetDefaultTTFMapEntry, _FPDF_GetDefaultSystemFontInfo, _FPDF_FreeDefaultSystemFontInfo, _FPDFText_LoadPage, _FPDFText_ClosePage, _FPDFText_CountChars, _FPDFText_GetUnicode, _FPDFText_GetTextObject, _FPDFText_IsGenerated, _FPDFText_IsHyphen, _FPDFText_HasUnicodeMapError, _FPDFText_GetFontSize, _FPDFText_GetFontInfo, _FPDFText_GetFontWeight, _FPDFText_GetFillColor, _FPDFText_GetStrokeColor, _FPDFText_GetCharAngle, _FPDFText_GetCharBox, _FPDFText_GetLooseCharBox, _FPDFText_GetMatrix, _FPDFText_GetCharOrigin, _FPDFText_GetCharIndexAtPos, _FPDFText_GetText, _FPDFText_CountRects, _FPDFText_GetRect, _FPDFText_GetBoundedText, _FPDFText_FindStart, _FPDFText_FindNext, _FPDFText_FindPrev, _FPDFText_GetSchResultIndex, _FPDFText_GetSchCount, _FPDFText_FindClose, _FPDFLink_LoadWebLinks, _FPDFLink_CountWebLinks, _FPDFLink_GetURL, _FPDFLink_CountRects, _FPDFLink_GetRect, _FPDFLink_GetTextRange, _FPDFLink_CloseWebLinks, _FPDFPage_GetDecodedThumbnailData, _FPDFPage_GetRawThumbnailData, _FPDFPage_GetThumbnailAsBitmap, _FPDFPage_SetMediaBox, _FPDFPage_SetCropBox, _FPDFPage_SetBleedBox, _FPDFPage_SetTrimBox, _FPDFPage_SetArtBox, _FPDFPage_GetMediaBox, _FPDFPage_GetCropBox, _FPDFPage_GetBleedBox, _FPDFPage_GetTrimBox, _FPDFPage_GetArtBox, _FPDFPage_TransFormWithClip, _FPDFPageObj_TransformClipPath, _FPDFPageObj_GetClipPath, _FPDFClipPath_CountPaths, _FPDFClipPath_CountPathSegments, _FPDFClipPath_GetPathSegment, _FPDF_CreateClipPath, _FPDF_DestroyClipPath, _FPDFPage_InsertClipPath, _FPDF_InitLibrary, _FPDF_InitLibraryWithConfig, _FPDF_DestroyLibrary, _FPDF_SetSandBoxPolicy, _FPDF_LoadDocument, _FPDF_GetFormType, _FPDF_LoadXFA, _FPDF_LoadMemDocument, _FPDF_LoadMemDocument64, _FPDF_LoadCustomDocument, _FPDF_GetFileVersion, _FPDF_DocumentHasValidCrossReferenceTable, _FPDF_GetDocPermissions, _FPDF_GetDocUserPermissions, _FPDF_GetSecurityHandlerRevision, _FPDF_GetPageCount, _FPDF_LoadPage, _FPDF_GetPageWidthF, _FPDF_GetPageWidth, _FPDF_GetPageHeightF, _FPDF_GetPageHeight, _FPDF_GetPageBoundingBox, _FPDF_RenderPageBitmap, _FPDF_RenderPageBitmapWithMatrix, _FPDF_ClosePage, _FPDF_CloseDocument, _FPDF_GetLastError, _FPDF_DeviceToPage, _FPDF_PageToDevice, _FPDFBitmap_Create, _FPDFBitmap_CreateEx, _FPDFBitmap_GetFormat, _FPDFBitmap_FillRect, _FPDFBitmap_GetBuffer, _FPDFBitmap_GetWidth, _FPDFBitmap_GetHeight, _FPDFBitmap_GetStride, _FPDFBitmap_Destroy, _FPDF_GetPageSizeByIndexF, _FPDF_GetPageSizeByIndex, _FPDF_VIEWERREF_GetPrintScaling, _FPDF_VIEWERREF_GetNumCopies, _FPDF_VIEWERREF_GetPrintPageRange, _FPDF_VIEWERREF_GetPrintPageRangeCount, _FPDF_VIEWERREF_GetPrintPageRangeElement, _FPDF_VIEWERREF_GetDuplex, _FPDF_VIEWERREF_GetName, _FPDF_CountNamedDests, _FPDF_GetNamedDestByName, _FPDF_GetNamedDest, _FPDF_GetXFAPacketCount, _FPDF_GetXFAPacketName, _FPDF_GetXFAPacketContent, _FPDF_GetTrailerEnds, _emscripten_builtin_memalign, _malloc, _free, _calloc, _realloc, _setThrew, __emscripten_stack_restore, __emscripten_stack_alloc, _emscripten_stack_get_current;

        function assignWasmExports(wasmExports) {
            Module["_FPDFAnnot_IsSupportedSubtype"] = _FPDFAnnot_IsSupportedSubtype = wasmExports["FPDFAnnot_IsSupportedSubtype"];
            Module["_FPDFPage_CreateAnnot"] = _FPDFPage_CreateAnnot = wasmExports["FPDFPage_CreateAnnot"];
            Module["_FPDFPage_GetAnnotCount"] = _FPDFPage_GetAnnotCount = wasmExports["FPDFPage_GetAnnotCount"];
            Module["_FPDFPage_GetAnnot"] = _FPDFPage_GetAnnot = wasmExports["FPDFPage_GetAnnot"];
            Module["_FPDFPage_GetAnnotIndex"] = _FPDFPage_GetAnnotIndex = wasmExports["FPDFPage_GetAnnotIndex"];
            Module["_FPDFPage_CloseAnnot"] = _FPDFPage_CloseAnnot = wasmExports["FPDFPage_CloseAnnot"];
            Module["_FPDFPage_RemoveAnnot"] = _FPDFPage_RemoveAnnot = wasmExports["FPDFPage_RemoveAnnot"];
            Module["_FPDFAnnot_GetSubtype"] = _FPDFAnnot_GetSubtype = wasmExports["FPDFAnnot_GetSubtype"];
            Module["_FPDFAnnot_IsObjectSupportedSubtype"] = _FPDFAnnot_IsObjectSupportedSubtype = wasmExports["FPDFAnnot_IsObjectSupportedSubtype"];
            Module["_FPDFAnnot_UpdateObject"] = _FPDFAnnot_UpdateObject = wasmExports["FPDFAnnot_UpdateObject"];
            Module["_FPDFAnnot_AddInkStroke"] = _FPDFAnnot_AddInkStroke = wasmExports["FPDFAnnot_AddInkStroke"];
            Module["_FPDFAnnot_RemoveInkList"] = _FPDFAnnot_RemoveInkList = wasmExports["FPDFAnnot_RemoveInkList"];
            Module["_FPDFAnnot_AppendObject"] = _FPDFAnnot_AppendObject = wasmExports["FPDFAnnot_AppendObject"];
            Module["_FPDFAnnot_GetObjectCount"] = _FPDFAnnot_GetObjectCount = wasmExports["FPDFAnnot_GetObjectCount"];
            Module["_FPDFAnnot_GetObject"] = _FPDFAnnot_GetObject = wasmExports["FPDFAnnot_GetObject"];
            Module["_FPDFAnnot_RemoveObject"] = _FPDFAnnot_RemoveObject = wasmExports["FPDFAnnot_RemoveObject"];
            Module["_FPDFAnnot_SetColor"] = _FPDFAnnot_SetColor = wasmExports["FPDFAnnot_SetColor"];
            Module["_FPDFAnnot_GetColor"] = _FPDFAnnot_GetColor = wasmExports["FPDFAnnot_GetColor"];
            Module["_FPDFAnnot_HasAttachmentPoints"] = _FPDFAnnot_HasAttachmentPoints = wasmExports["FPDFAnnot_HasAttachmentPoints"];
            Module["_FPDFAnnot_SetAttachmentPoints"] = _FPDFAnnot_SetAttachmentPoints = wasmExports["FPDFAnnot_SetAttachmentPoints"];
            Module["_FPDFAnnot_AppendAttachmentPoints"] = _FPDFAnnot_AppendAttachmentPoints = wasmExports["FPDFAnnot_AppendAttachmentPoints"];
            Module["_FPDFAnnot_CountAttachmentPoints"] = _FPDFAnnot_CountAttachmentPoints = wasmExports["FPDFAnnot_CountAttachmentPoints"];
            Module["_FPDFAnnot_GetAttachmentPoints"] = _FPDFAnnot_GetAttachmentPoints = wasmExports["FPDFAnnot_GetAttachmentPoints"];
            Module["_FPDFAnnot_SetRect"] = _FPDFAnnot_SetRect = wasmExports["FPDFAnnot_SetRect"];
            Module["_FPDFAnnot_GetRect"] = _FPDFAnnot_GetRect = wasmExports["FPDFAnnot_GetRect"];
            Module["_FPDFAnnot_GetVertices"] = _FPDFAnnot_GetVertices = wasmExports["FPDFAnnot_GetVertices"];
            Module["_FPDFAnnot_GetInkListCount"] = _FPDFAnnot_GetInkListCount = wasmExports["FPDFAnnot_GetInkListCount"];
            Module["_FPDFAnnot_GetInkListPath"] = _FPDFAnnot_GetInkListPath = wasmExports["FPDFAnnot_GetInkListPath"];
            Module["_FPDFAnnot_GetLine"] = _FPDFAnnot_GetLine = wasmExports["FPDFAnnot_GetLine"];
            Module["_FPDFAnnot_SetBorder"] = _FPDFAnnot_SetBorder = wasmExports["FPDFAnnot_SetBorder"];
            Module["_FPDFAnnot_GetBorder"] = _FPDFAnnot_GetBorder = wasmExports["FPDFAnnot_GetBorder"];
            Module["_FPDFAnnot_HasKey"] = _FPDFAnnot_HasKey = wasmExports["FPDFAnnot_HasKey"];
            Module["_FPDFAnnot_GetValueType"] = _FPDFAnnot_GetValueType = wasmExports["FPDFAnnot_GetValueType"];
            Module["_FPDFAnnot_SetStringValue"] = _FPDFAnnot_SetStringValue = wasmExports["FPDFAnnot_SetStringValue"];
            Module["_FPDFAnnot_GetStringValue"] = _FPDFAnnot_GetStringValue = wasmExports["FPDFAnnot_GetStringValue"];
            Module["_FPDFAnnot_GetNumberValue"] = _FPDFAnnot_GetNumberValue = wasmExports["FPDFAnnot_GetNumberValue"];
            Module["_FPDFAnnot_SetAP"] = _FPDFAnnot_SetAP = wasmExports["FPDFAnnot_SetAP"];
            Module["_FPDFAnnot_GetAP"] = _FPDFAnnot_GetAP = wasmExports["FPDFAnnot_GetAP"];
            Module["_FPDFAnnot_GetLinkedAnnot"] = _FPDFAnnot_GetLinkedAnnot = wasmExports["FPDFAnnot_GetLinkedAnnot"];
            Module["_FPDFAnnot_GetFlags"] = _FPDFAnnot_GetFlags = wasmExports["FPDFAnnot_GetFlags"];
            Module["_FPDFAnnot_SetFlags"] = _FPDFAnnot_SetFlags = wasmExports["FPDFAnnot_SetFlags"];
            Module["_FPDFAnnot_GetFormFieldFlags"] = _FPDFAnnot_GetFormFieldFlags = wasmExports["FPDFAnnot_GetFormFieldFlags"];
            Module["_FPDFAnnot_SetFormFieldFlags"] = _FPDFAnnot_SetFormFieldFlags = wasmExports["FPDFAnnot_SetFormFieldFlags"];
            Module["_FPDFAnnot_GetFormFieldAtPoint"] = _FPDFAnnot_GetFormFieldAtPoint = wasmExports["FPDFAnnot_GetFormFieldAtPoint"];
            Module["_FPDFAnnot_GetFormFieldName"] = _FPDFAnnot_GetFormFieldName = wasmExports["FPDFAnnot_GetFormFieldName"];
            Module["_FPDFAnnot_GetFormFieldType"] = _FPDFAnnot_GetFormFieldType = wasmExports["FPDFAnnot_GetFormFieldType"];
            Module["_FPDFAnnot_GetFormAdditionalActionJavaScript"] = _FPDFAnnot_GetFormAdditionalActionJavaScript = wasmExports["FPDFAnnot_GetFormAdditionalActionJavaScript"];
            Module["_FPDFAnnot_GetFormFieldAlternateName"] = _FPDFAnnot_GetFormFieldAlternateName = wasmExports["FPDFAnnot_GetFormFieldAlternateName"];
            Module["_FPDFAnnot_GetFormFieldValue"] = _FPDFAnnot_GetFormFieldValue = wasmExports["FPDFAnnot_GetFormFieldValue"];
            Module["_FPDFAnnot_GetOptionCount"] = _FPDFAnnot_GetOptionCount = wasmExports["FPDFAnnot_GetOptionCount"];
            Module["_FPDFAnnot_GetOptionLabel"] = _FPDFAnnot_GetOptionLabel = wasmExports["FPDFAnnot_GetOptionLabel"];
            Module["_FPDFAnnot_IsOptionSelected"] = _FPDFAnnot_IsOptionSelected = wasmExports["FPDFAnnot_IsOptionSelected"];
            Module["_FPDFAnnot_GetFontSize"] = _FPDFAnnot_GetFontSize = wasmExports["FPDFAnnot_GetFontSize"];
            Module["_FPDFAnnot_SetFontColor"] = _FPDFAnnot_SetFontColor = wasmExports["FPDFAnnot_SetFontColor"];
            Module["_FPDFAnnot_GetFontColor"] = _FPDFAnnot_GetFontColor = wasmExports["FPDFAnnot_GetFontColor"];
            Module["_FPDFAnnot_IsChecked"] = _FPDFAnnot_IsChecked = wasmExports["FPDFAnnot_IsChecked"];
            Module["_FPDFAnnot_SetFocusableSubtypes"] = _FPDFAnnot_SetFocusableSubtypes = wasmExports["FPDFAnnot_SetFocusableSubtypes"];
            Module["_FPDFAnnot_GetFocusableSubtypesCount"] = _FPDFAnnot_GetFocusableSubtypesCount = wasmExports["FPDFAnnot_GetFocusableSubtypesCount"];
            Module["_FPDFAnnot_GetFocusableSubtypes"] = _FPDFAnnot_GetFocusableSubtypes = wasmExports["FPDFAnnot_GetFocusableSubtypes"];
            Module["_FPDFAnnot_GetLink"] = _FPDFAnnot_GetLink = wasmExports["FPDFAnnot_GetLink"];
            Module["_FPDFAnnot_GetFormControlCount"] = _FPDFAnnot_GetFormControlCount = wasmExports["FPDFAnnot_GetFormControlCount"];
            Module["_FPDFAnnot_GetFormControlIndex"] = _FPDFAnnot_GetFormControlIndex = wasmExports["FPDFAnnot_GetFormControlIndex"];
            Module["_FPDFAnnot_GetFormFieldExportValue"] = _FPDFAnnot_GetFormFieldExportValue = wasmExports["FPDFAnnot_GetFormFieldExportValue"];
            Module["_FPDFAnnot_SetURI"] = _FPDFAnnot_SetURI = wasmExports["FPDFAnnot_SetURI"];
            Module["_FPDFAnnot_GetFileAttachment"] = _FPDFAnnot_GetFileAttachment = wasmExports["FPDFAnnot_GetFileAttachment"];
            Module["_FPDFAnnot_AddFileAttachment"] = _FPDFAnnot_AddFileAttachment = wasmExports["FPDFAnnot_AddFileAttachment"];
            Module["_FPDFDoc_GetAttachmentCount"] = _FPDFDoc_GetAttachmentCount = wasmExports["FPDFDoc_GetAttachmentCount"];
            Module["_FPDFDoc_AddAttachment"] = _FPDFDoc_AddAttachment = wasmExports["FPDFDoc_AddAttachment"];
            Module["_FPDFDoc_GetAttachment"] = _FPDFDoc_GetAttachment = wasmExports["FPDFDoc_GetAttachment"];
            Module["_FPDFDoc_DeleteAttachment"] = _FPDFDoc_DeleteAttachment = wasmExports["FPDFDoc_DeleteAttachment"];
            Module["_FPDFAttachment_GetName"] = _FPDFAttachment_GetName = wasmExports["FPDFAttachment_GetName"];
            Module["_FPDFAttachment_HasKey"] = _FPDFAttachment_HasKey = wasmExports["FPDFAttachment_HasKey"];
            Module["_FPDFAttachment_GetValueType"] = _FPDFAttachment_GetValueType = wasmExports["FPDFAttachment_GetValueType"];
            Module["_FPDFAttachment_SetStringValue"] = _FPDFAttachment_SetStringValue = wasmExports["FPDFAttachment_SetStringValue"];
            Module["_FPDFAttachment_GetStringValue"] = _FPDFAttachment_GetStringValue = wasmExports["FPDFAttachment_GetStringValue"];
            Module["_FPDFAttachment_SetFile"] = _FPDFAttachment_SetFile = wasmExports["FPDFAttachment_SetFile"];
            Module["_FPDFAttachment_GetFile"] = _FPDFAttachment_GetFile = wasmExports["FPDFAttachment_GetFile"];
            Module["_FPDFAttachment_GetSubtype"] = _FPDFAttachment_GetSubtype = wasmExports["FPDFAttachment_GetSubtype"];
            Module["_FPDFCatalog_IsTagged"] = _FPDFCatalog_IsTagged = wasmExports["FPDFCatalog_IsTagged"];
            Module["_FPDFCatalog_SetLanguage"] = _FPDFCatalog_SetLanguage = wasmExports["FPDFCatalog_SetLanguage"];
            Module["_FPDFAvail_Create"] = _FPDFAvail_Create = wasmExports["FPDFAvail_Create"];
            Module["_FPDFAvail_Destroy"] = _FPDFAvail_Destroy = wasmExports["FPDFAvail_Destroy"];
            Module["_FPDFAvail_IsDocAvail"] = _FPDFAvail_IsDocAvail = wasmExports["FPDFAvail_IsDocAvail"];
            Module["_FPDFAvail_GetDocument"] = _FPDFAvail_GetDocument = wasmExports["FPDFAvail_GetDocument"];
            Module["_FPDFAvail_GetFirstPageNum"] = _FPDFAvail_GetFirstPageNum = wasmExports["FPDFAvail_GetFirstPageNum"];
            Module["_FPDFAvail_IsPageAvail"] = _FPDFAvail_IsPageAvail = wasmExports["FPDFAvail_IsPageAvail"];
            Module["_FPDFAvail_IsFormAvail"] = _FPDFAvail_IsFormAvail = wasmExports["FPDFAvail_IsFormAvail"];
            Module["_FPDFAvail_IsLinearized"] = _FPDFAvail_IsLinearized = wasmExports["FPDFAvail_IsLinearized"];
            Module["_FPDFBookmark_GetFirstChild"] = _FPDFBookmark_GetFirstChild = wasmExports["FPDFBookmark_GetFirstChild"];
            Module["_FPDFBookmark_GetNextSibling"] = _FPDFBookmark_GetNextSibling = wasmExports["FPDFBookmark_GetNextSibling"];
            Module["_FPDFBookmark_GetTitle"] = _FPDFBookmark_GetTitle = wasmExports["FPDFBookmark_GetTitle"];
            Module["_FPDFBookmark_GetCount"] = _FPDFBookmark_GetCount = wasmExports["FPDFBookmark_GetCount"];
            Module["_FPDFBookmark_Find"] = _FPDFBookmark_Find = wasmExports["FPDFBookmark_Find"];
            Module["_FPDFBookmark_GetDest"] = _FPDFBookmark_GetDest = wasmExports["FPDFBookmark_GetDest"];
            Module["_FPDFBookmark_GetAction"] = _FPDFBookmark_GetAction = wasmExports["FPDFBookmark_GetAction"];
            Module["_FPDFAction_GetType"] = _FPDFAction_GetType = wasmExports["FPDFAction_GetType"];
            Module["_FPDFAction_GetDest"] = _FPDFAction_GetDest = wasmExports["FPDFAction_GetDest"];
            Module["_FPDFAction_GetFilePath"] = _FPDFAction_GetFilePath = wasmExports["FPDFAction_GetFilePath"];
            Module["_FPDFAction_GetURIPath"] = _FPDFAction_GetURIPath = wasmExports["FPDFAction_GetURIPath"];
            Module["_FPDFDest_GetDestPageIndex"] = _FPDFDest_GetDestPageIndex = wasmExports["FPDFDest_GetDestPageIndex"];
            Module["_FPDFDest_GetView"] = _FPDFDest_GetView = wasmExports["FPDFDest_GetView"];
            Module["_FPDFDest_GetLocationInPage"] = _FPDFDest_GetLocationInPage = wasmExports["FPDFDest_GetLocationInPage"];
            Module["_FPDFLink_GetLinkAtPoint"] = _FPDFLink_GetLinkAtPoint = wasmExports["FPDFLink_GetLinkAtPoint"];
            Module["_FPDFLink_GetLinkZOrderAtPoint"] = _FPDFLink_GetLinkZOrderAtPoint = wasmExports["FPDFLink_GetLinkZOrderAtPoint"];
            Module["_FPDFLink_GetDest"] = _FPDFLink_GetDest = wasmExports["FPDFLink_GetDest"];
            Module["_FPDFLink_GetAction"] = _FPDFLink_GetAction = wasmExports["FPDFLink_GetAction"];
            Module["_FPDFLink_Enumerate"] = _FPDFLink_Enumerate = wasmExports["FPDFLink_Enumerate"];
            Module["_FPDFLink_GetAnnot"] = _FPDFLink_GetAnnot = wasmExports["FPDFLink_GetAnnot"];
            Module["_FPDFLink_GetAnnotRect"] = _FPDFLink_GetAnnotRect = wasmExports["FPDFLink_GetAnnotRect"];
            Module["_FPDFLink_CountQuadPoints"] = _FPDFLink_CountQuadPoints = wasmExports["FPDFLink_CountQuadPoints"];
            Module["_FPDFLink_GetQuadPoints"] = _FPDFLink_GetQuadPoints = wasmExports["FPDFLink_GetQuadPoints"];
            Module["_FPDF_GetPageAAction"] = _FPDF_GetPageAAction = wasmExports["FPDF_GetPageAAction"];
            Module["_FPDF_GetFileIdentifier"] = _FPDF_GetFileIdentifier = wasmExports["FPDF_GetFileIdentifier"];
            Module["_FPDF_GetMetaText"] = _FPDF_GetMetaText = wasmExports["FPDF_GetMetaText"];
            Module["_FPDF_GetPageLabel"] = _FPDF_GetPageLabel = wasmExports["FPDF_GetPageLabel"];
            Module["_FPDFPageObj_NewImageObj"] = _FPDFPageObj_NewImageObj = wasmExports["FPDFPageObj_NewImageObj"];
            Module["_FPDFImageObj_LoadJpegFile"] = _FPDFImageObj_LoadJpegFile = wasmExports["FPDFImageObj_LoadJpegFile"];
            Module["_FPDFImageObj_LoadJpegFileInline"] = _FPDFImageObj_LoadJpegFileInline = wasmExports["FPDFImageObj_LoadJpegFileInline"];
            Module["_FPDFImageObj_SetMatrix"] = _FPDFImageObj_SetMatrix = wasmExports["FPDFImageObj_SetMatrix"];
            Module["_FPDFImageObj_SetBitmap"] = _FPDFImageObj_SetBitmap = wasmExports["FPDFImageObj_SetBitmap"];
            Module["_FPDFImageObj_GetBitmap"] = _FPDFImageObj_GetBitmap = wasmExports["FPDFImageObj_GetBitmap"];
            Module["_FPDFImageObj_GetRenderedBitmap"] = _FPDFImageObj_GetRenderedBitmap = wasmExports["FPDFImageObj_GetRenderedBitmap"];
            Module["_FPDFImageObj_GetImageDataDecoded"] = _FPDFImageObj_GetImageDataDecoded = wasmExports["FPDFImageObj_GetImageDataDecoded"];
            Module["_FPDFImageObj_GetImageDataRaw"] = _FPDFImageObj_GetImageDataRaw = wasmExports["FPDFImageObj_GetImageDataRaw"];
            Module["_FPDFImageObj_GetImageFilterCount"] = _FPDFImageObj_GetImageFilterCount = wasmExports["FPDFImageObj_GetImageFilterCount"];
            Module["_FPDFImageObj_GetImageFilter"] = _FPDFImageObj_GetImageFilter = wasmExports["FPDFImageObj_GetImageFilter"];
            Module["_FPDFImageObj_GetImageMetadata"] = _FPDFImageObj_GetImageMetadata = wasmExports["FPDFImageObj_GetImageMetadata"];
            Module["_FPDFImageObj_GetImagePixelSize"] = _FPDFImageObj_GetImagePixelSize = wasmExports["FPDFImageObj_GetImagePixelSize"];
            Module["_FPDFImageObj_GetIccProfileDataDecoded"] = _FPDFImageObj_GetIccProfileDataDecoded = wasmExports["FPDFImageObj_GetIccProfileDataDecoded"];
            Module["_FPDF_CreateNewDocument"] = _FPDF_CreateNewDocument = wasmExports["FPDF_CreateNewDocument"];
            Module["_FPDFPage_Delete"] = _FPDFPage_Delete = wasmExports["FPDFPage_Delete"];
            Module["_FPDF_MovePages"] = _FPDF_MovePages = wasmExports["FPDF_MovePages"];
            Module["_FPDFPage_New"] = _FPDFPage_New = wasmExports["FPDFPage_New"];
            Module["_FPDFPage_GetRotation"] = _FPDFPage_GetRotation = wasmExports["FPDFPage_GetRotation"];
            Module["_FPDFPage_InsertObject"] = _FPDFPage_InsertObject = wasmExports["FPDFPage_InsertObject"];
            Module["_FPDFPage_InsertObjectAtIndex"] = _FPDFPage_InsertObjectAtIndex = wasmExports["FPDFPage_InsertObjectAtIndex"];
            Module["_FPDFPage_RemoveObject"] = _FPDFPage_RemoveObject = wasmExports["FPDFPage_RemoveObject"];
            Module["_FPDFPage_CountObjects"] = _FPDFPage_CountObjects = wasmExports["FPDFPage_CountObjects"];
            Module["_FPDFPage_GetObject"] = _FPDFPage_GetObject = wasmExports["FPDFPage_GetObject"];
            Module["_FPDFPage_HasTransparency"] = _FPDFPage_HasTransparency = wasmExports["FPDFPage_HasTransparency"];
            Module["_FPDFPageObj_Destroy"] = _FPDFPageObj_Destroy = wasmExports["FPDFPageObj_Destroy"];
            Module["_FPDFPageObj_GetMarkedContentID"] = _FPDFPageObj_GetMarkedContentID = wasmExports["FPDFPageObj_GetMarkedContentID"];
            Module["_FPDFPageObj_CountMarks"] = _FPDFPageObj_CountMarks = wasmExports["FPDFPageObj_CountMarks"];
            Module["_FPDFPageObj_GetMark"] = _FPDFPageObj_GetMark = wasmExports["FPDFPageObj_GetMark"];
            Module["_FPDFPageObj_AddMark"] = _FPDFPageObj_AddMark = wasmExports["FPDFPageObj_AddMark"];
            Module["_FPDFPageObj_RemoveMark"] = _FPDFPageObj_RemoveMark = wasmExports["FPDFPageObj_RemoveMark"];
            Module["_FPDFPageObjMark_GetName"] = _FPDFPageObjMark_GetName = wasmExports["FPDFPageObjMark_GetName"];
            Module["_FPDFPageObjMark_CountParams"] = _FPDFPageObjMark_CountParams = wasmExports["FPDFPageObjMark_CountParams"];
            Module["_FPDFPageObjMark_GetParamKey"] = _FPDFPageObjMark_GetParamKey = wasmExports["FPDFPageObjMark_GetParamKey"];
            Module["_FPDFPageObjMark_GetParamValueType"] = _FPDFPageObjMark_GetParamValueType = wasmExports["FPDFPageObjMark_GetParamValueType"];
            Module["_FPDFPageObjMark_GetParamIntValue"] = _FPDFPageObjMark_GetParamIntValue = wasmExports["FPDFPageObjMark_GetParamIntValue"];
            Module["_FPDFPageObjMark_GetParamStringValue"] = _FPDFPageObjMark_GetParamStringValue = wasmExports["FPDFPageObjMark_GetParamStringValue"];
            Module["_FPDFPageObjMark_GetParamBlobValue"] = _FPDFPageObjMark_GetParamBlobValue = wasmExports["FPDFPageObjMark_GetParamBlobValue"];
            Module["_FPDFPageObj_HasTransparency"] = _FPDFPageObj_HasTransparency = wasmExports["FPDFPageObj_HasTransparency"];
            Module["_FPDFPageObjMark_SetIntParam"] = _FPDFPageObjMark_SetIntParam = wasmExports["FPDFPageObjMark_SetIntParam"];
            Module["_FPDFPageObjMark_SetStringParam"] = _FPDFPageObjMark_SetStringParam = wasmExports["FPDFPageObjMark_SetStringParam"];
            Module["_FPDFPageObjMark_SetBlobParam"] = _FPDFPageObjMark_SetBlobParam = wasmExports["FPDFPageObjMark_SetBlobParam"];
            Module["_FPDFPageObjMark_RemoveParam"] = _FPDFPageObjMark_RemoveParam = wasmExports["FPDFPageObjMark_RemoveParam"];
            Module["_FPDFPageObj_GetType"] = _FPDFPageObj_GetType = wasmExports["FPDFPageObj_GetType"];
            Module["_FPDFPageObj_GetIsActive"] = _FPDFPageObj_GetIsActive = wasmExports["FPDFPageObj_GetIsActive"];
            Module["_FPDFPageObj_SetIsActive"] = _FPDFPageObj_SetIsActive = wasmExports["FPDFPageObj_SetIsActive"];
            Module["_FPDFPage_GenerateContent"] = _FPDFPage_GenerateContent = wasmExports["FPDFPage_GenerateContent"];
            Module["_FPDFPageObj_Transform"] = _FPDFPageObj_Transform = wasmExports["FPDFPageObj_Transform"];
            Module["_FPDFPageObj_TransformF"] = _FPDFPageObj_TransformF = wasmExports["FPDFPageObj_TransformF"];
            Module["_FPDFPageObj_GetMatrix"] = _FPDFPageObj_GetMatrix = wasmExports["FPDFPageObj_GetMatrix"];
            Module["_FPDFPageObj_SetMatrix"] = _FPDFPageObj_SetMatrix = wasmExports["FPDFPageObj_SetMatrix"];
            Module["_FPDFPageObj_SetBlendMode"] = _FPDFPageObj_SetBlendMode = wasmExports["FPDFPageObj_SetBlendMode"];
            Module["_FPDFPage_TransformAnnots"] = _FPDFPage_TransformAnnots = wasmExports["FPDFPage_TransformAnnots"];
            Module["_FPDFPage_SetRotation"] = _FPDFPage_SetRotation = wasmExports["FPDFPage_SetRotation"];
            Module["_FPDFPageObj_SetFillColor"] = _FPDFPageObj_SetFillColor = wasmExports["FPDFPageObj_SetFillColor"];
            Module["_FPDFPageObj_GetFillColor"] = _FPDFPageObj_GetFillColor = wasmExports["FPDFPageObj_GetFillColor"];
            Module["_FPDFPageObj_GetBounds"] = _FPDFPageObj_GetBounds = wasmExports["FPDFPageObj_GetBounds"];
            Module["_FPDFPageObj_GetRotatedBounds"] = _FPDFPageObj_GetRotatedBounds = wasmExports["FPDFPageObj_GetRotatedBounds"];
            Module["_FPDFPageObj_SetStrokeColor"] = _FPDFPageObj_SetStrokeColor = wasmExports["FPDFPageObj_SetStrokeColor"];
            Module["_FPDFPageObj_GetStrokeColor"] = _FPDFPageObj_GetStrokeColor = wasmExports["FPDFPageObj_GetStrokeColor"];
            Module["_FPDFPageObj_SetStrokeWidth"] = _FPDFPageObj_SetStrokeWidth = wasmExports["FPDFPageObj_SetStrokeWidth"];
            Module["_FPDFPageObj_GetStrokeWidth"] = _FPDFPageObj_GetStrokeWidth = wasmExports["FPDFPageObj_GetStrokeWidth"];
            Module["_FPDFPageObj_GetLineJoin"] = _FPDFPageObj_GetLineJoin = wasmExports["FPDFPageObj_GetLineJoin"];
            Module["_FPDFPageObj_SetLineJoin"] = _FPDFPageObj_SetLineJoin = wasmExports["FPDFPageObj_SetLineJoin"];
            Module["_FPDFPageObj_GetLineCap"] = _FPDFPageObj_GetLineCap = wasmExports["FPDFPageObj_GetLineCap"];
            Module["_FPDFPageObj_SetLineCap"] = _FPDFPageObj_SetLineCap = wasmExports["FPDFPageObj_SetLineCap"];
            Module["_FPDFPageObj_GetDashPhase"] = _FPDFPageObj_GetDashPhase = wasmExports["FPDFPageObj_GetDashPhase"];
            Module["_FPDFPageObj_SetDashPhase"] = _FPDFPageObj_SetDashPhase = wasmExports["FPDFPageObj_SetDashPhase"];
            Module["_FPDFPageObj_GetDashCount"] = _FPDFPageObj_GetDashCount = wasmExports["FPDFPageObj_GetDashCount"];
            Module["_FPDFPageObj_GetDashArray"] = _FPDFPageObj_GetDashArray = wasmExports["FPDFPageObj_GetDashArray"];
            Module["_FPDFPageObj_SetDashArray"] = _FPDFPageObj_SetDashArray = wasmExports["FPDFPageObj_SetDashArray"];
            Module["_FPDFFormObj_CountObjects"] = _FPDFFormObj_CountObjects = wasmExports["FPDFFormObj_CountObjects"];
            Module["_FPDFFormObj_GetObject"] = _FPDFFormObj_GetObject = wasmExports["FPDFFormObj_GetObject"];
            Module["_FPDFFormObj_RemoveObject"] = _FPDFFormObj_RemoveObject = wasmExports["FPDFFormObj_RemoveObject"];
            Module["_FPDFPageObj_CreateNewPath"] = _FPDFPageObj_CreateNewPath = wasmExports["FPDFPageObj_CreateNewPath"];
            Module["_FPDFPageObj_CreateNewRect"] = _FPDFPageObj_CreateNewRect = wasmExports["FPDFPageObj_CreateNewRect"];
            Module["_FPDFPath_CountSegments"] = _FPDFPath_CountSegments = wasmExports["FPDFPath_CountSegments"];
            Module["_FPDFPath_GetPathSegment"] = _FPDFPath_GetPathSegment = wasmExports["FPDFPath_GetPathSegment"];
            Module["_FPDFPath_MoveTo"] = _FPDFPath_MoveTo = wasmExports["FPDFPath_MoveTo"];
            Module["_FPDFPath_LineTo"] = _FPDFPath_LineTo = wasmExports["FPDFPath_LineTo"];
            Module["_FPDFPath_BezierTo"] = _FPDFPath_BezierTo = wasmExports["FPDFPath_BezierTo"];
            Module["_FPDFPath_Close"] = _FPDFPath_Close = wasmExports["FPDFPath_Close"];
            Module["_FPDFPath_SetDrawMode"] = _FPDFPath_SetDrawMode = wasmExports["FPDFPath_SetDrawMode"];
            Module["_FPDFPath_GetDrawMode"] = _FPDFPath_GetDrawMode = wasmExports["FPDFPath_GetDrawMode"];
            Module["_FPDFPathSegment_GetPoint"] = _FPDFPathSegment_GetPoint = wasmExports["FPDFPathSegment_GetPoint"];
            Module["_FPDFPathSegment_GetType"] = _FPDFPathSegment_GetType = wasmExports["FPDFPathSegment_GetType"];
            Module["_FPDFPathSegment_GetClose"] = _FPDFPathSegment_GetClose = wasmExports["FPDFPathSegment_GetClose"];
            Module["_FPDFPageObj_NewTextObj"] = _FPDFPageObj_NewTextObj = wasmExports["FPDFPageObj_NewTextObj"];
            Module["_FPDFText_SetText"] = _FPDFText_SetText = wasmExports["FPDFText_SetText"];
            Module["_FPDFText_SetCharcodes"] = _FPDFText_SetCharcodes = wasmExports["FPDFText_SetCharcodes"];
            Module["_FPDFText_LoadFont"] = _FPDFText_LoadFont = wasmExports["FPDFText_LoadFont"];
            Module["_FPDFText_LoadStandardFont"] = _FPDFText_LoadStandardFont = wasmExports["FPDFText_LoadStandardFont"];
            Module["_FPDFText_LoadCidType2Font"] = _FPDFText_LoadCidType2Font = wasmExports["FPDFText_LoadCidType2Font"];
            Module["_FPDFTextObj_GetFontSize"] = _FPDFTextObj_GetFontSize = wasmExports["FPDFTextObj_GetFontSize"];
            Module["_FPDFTextObj_GetText"] = _FPDFTextObj_GetText = wasmExports["FPDFTextObj_GetText"];
            Module["_FPDFTextObj_GetRenderedBitmap"] = _FPDFTextObj_GetRenderedBitmap = wasmExports["FPDFTextObj_GetRenderedBitmap"];
            Module["_FPDFFont_Close"] = _FPDFFont_Close = wasmExports["FPDFFont_Close"];
            Module["_FPDFPageObj_CreateTextObj"] = _FPDFPageObj_CreateTextObj = wasmExports["FPDFPageObj_CreateTextObj"];
            Module["_FPDFTextObj_GetTextRenderMode"] = _FPDFTextObj_GetTextRenderMode = wasmExports["FPDFTextObj_GetTextRenderMode"];
            Module["_FPDFTextObj_SetTextRenderMode"] = _FPDFTextObj_SetTextRenderMode = wasmExports["FPDFTextObj_SetTextRenderMode"];
            Module["_FPDFTextObj_GetFont"] = _FPDFTextObj_GetFont = wasmExports["FPDFTextObj_GetFont"];
            Module["_FPDFFont_GetBaseFontName"] = _FPDFFont_GetBaseFontName = wasmExports["FPDFFont_GetBaseFontName"];
            Module["_FPDFFont_GetFamilyName"] = _FPDFFont_GetFamilyName = wasmExports["FPDFFont_GetFamilyName"];
            Module["_FPDFFont_GetFontData"] = _FPDFFont_GetFontData = wasmExports["FPDFFont_GetFontData"];
            Module["_FPDFFont_GetIsEmbedded"] = _FPDFFont_GetIsEmbedded = wasmExports["FPDFFont_GetIsEmbedded"];
            Module["_FPDFFont_GetFlags"] = _FPDFFont_GetFlags = wasmExports["FPDFFont_GetFlags"];
            Module["_FPDFFont_GetWeight"] = _FPDFFont_GetWeight = wasmExports["FPDFFont_GetWeight"];
            Module["_FPDFFont_GetItalicAngle"] = _FPDFFont_GetItalicAngle = wasmExports["FPDFFont_GetItalicAngle"];
            Module["_FPDFFont_GetAscent"] = _FPDFFont_GetAscent = wasmExports["FPDFFont_GetAscent"];
            Module["_FPDFFont_GetDescent"] = _FPDFFont_GetDescent = wasmExports["FPDFFont_GetDescent"];
            Module["_FPDFFont_GetGlyphWidth"] = _FPDFFont_GetGlyphWidth = wasmExports["FPDFFont_GetGlyphWidth"];
            Module["_FPDFFont_GetGlyphPath"] = _FPDFFont_GetGlyphPath = wasmExports["FPDFFont_GetGlyphPath"];
            Module["_FPDFGlyphPath_CountGlyphSegments"] = _FPDFGlyphPath_CountGlyphSegments = wasmExports["FPDFGlyphPath_CountGlyphSegments"];
            Module["_FPDFGlyphPath_GetGlyphPathSegment"] = _FPDFGlyphPath_GetGlyphPathSegment = wasmExports["FPDFGlyphPath_GetGlyphPathSegment"];
            Module["_FSDK_SetUnSpObjProcessHandler"] = _FSDK_SetUnSpObjProcessHandler = wasmExports["FSDK_SetUnSpObjProcessHandler"];
            Module["_FSDK_SetTimeFunction"] = _FSDK_SetTimeFunction = wasmExports["FSDK_SetTimeFunction"];
            Module["_FSDK_SetLocaltimeFunction"] = _FSDK_SetLocaltimeFunction = wasmExports["FSDK_SetLocaltimeFunction"];
            Module["_FPDFDoc_GetPageMode"] = _FPDFDoc_GetPageMode = wasmExports["FPDFDoc_GetPageMode"];
            Module["_FPDFPage_Flatten"] = _FPDFPage_Flatten = wasmExports["FPDFPage_Flatten"];
            Module["_FPDFPage_HasFormFieldAtPoint"] = _FPDFPage_HasFormFieldAtPoint = wasmExports["FPDFPage_HasFormFieldAtPoint"];
            Module["_FPDFPage_FormFieldZOrderAtPoint"] = _FPDFPage_FormFieldZOrderAtPoint = wasmExports["FPDFPage_FormFieldZOrderAtPoint"];
            Module["_FPDFDOC_InitFormFillEnvironment"] = _FPDFDOC_InitFormFillEnvironment = wasmExports["FPDFDOC_InitFormFillEnvironment"];
            Module["_FPDFDOC_ExitFormFillEnvironment"] = _FPDFDOC_ExitFormFillEnvironment = wasmExports["FPDFDOC_ExitFormFillEnvironment"];
            Module["_FORM_OnMouseMove"] = _FORM_OnMouseMove = wasmExports["FORM_OnMouseMove"];
            Module["_FORM_OnMouseWheel"] = _FORM_OnMouseWheel = wasmExports["FORM_OnMouseWheel"];
            Module["_FORM_OnFocus"] = _FORM_OnFocus = wasmExports["FORM_OnFocus"];
            Module["_FORM_OnLButtonDown"] = _FORM_OnLButtonDown = wasmExports["FORM_OnLButtonDown"];
            Module["_FORM_OnLButtonUp"] = _FORM_OnLButtonUp = wasmExports["FORM_OnLButtonUp"];
            Module["_FORM_OnLButtonDoubleClick"] = _FORM_OnLButtonDoubleClick = wasmExports["FORM_OnLButtonDoubleClick"];
            Module["_FORM_OnRButtonDown"] = _FORM_OnRButtonDown = wasmExports["FORM_OnRButtonDown"];
            Module["_FORM_OnRButtonUp"] = _FORM_OnRButtonUp = wasmExports["FORM_OnRButtonUp"];
            Module["_FORM_OnKeyDown"] = _FORM_OnKeyDown = wasmExports["FORM_OnKeyDown"];
            Module["_FORM_OnKeyUp"] = _FORM_OnKeyUp = wasmExports["FORM_OnKeyUp"];
            Module["_FORM_OnChar"] = _FORM_OnChar = wasmExports["FORM_OnChar"];
            Module["_FORM_GetFocusedText"] = _FORM_GetFocusedText = wasmExports["FORM_GetFocusedText"];
            Module["_FORM_GetSelectedText"] = _FORM_GetSelectedText = wasmExports["FORM_GetSelectedText"];
            Module["_FORM_ReplaceAndKeepSelection"] = _FORM_ReplaceAndKeepSelection = wasmExports["FORM_ReplaceAndKeepSelection"];
            Module["_FORM_ReplaceSelection"] = _FORM_ReplaceSelection = wasmExports["FORM_ReplaceSelection"];
            Module["_FORM_SelectAllText"] = _FORM_SelectAllText = wasmExports["FORM_SelectAllText"];
            Module["_FORM_CanUndo"] = _FORM_CanUndo = wasmExports["FORM_CanUndo"];
            Module["_FORM_CanRedo"] = _FORM_CanRedo = wasmExports["FORM_CanRedo"];
            Module["_FORM_Undo"] = _FORM_Undo = wasmExports["FORM_Undo"];
            Module["_FORM_Redo"] = _FORM_Redo = wasmExports["FORM_Redo"];
            Module["_FORM_ForceToKillFocus"] = _FORM_ForceToKillFocus = wasmExports["FORM_ForceToKillFocus"];
            Module["_FORM_GetFocusedAnnot"] = _FORM_GetFocusedAnnot = wasmExports["FORM_GetFocusedAnnot"];
            Module["_FORM_SetFocusedAnnot"] = _FORM_SetFocusedAnnot = wasmExports["FORM_SetFocusedAnnot"];
            Module["_FPDF_FFLDraw"] = _FPDF_FFLDraw = wasmExports["FPDF_FFLDraw"];
            Module["_FPDF_SetFormFieldHighlightColor"] = _FPDF_SetFormFieldHighlightColor = wasmExports["FPDF_SetFormFieldHighlightColor"];
            Module["_FPDF_SetFormFieldHighlightAlpha"] = _FPDF_SetFormFieldHighlightAlpha = wasmExports["FPDF_SetFormFieldHighlightAlpha"];
            Module["_FPDF_RemoveFormFieldHighlight"] = _FPDF_RemoveFormFieldHighlight = wasmExports["FPDF_RemoveFormFieldHighlight"];
            Module["_FORM_OnAfterLoadPage"] = _FORM_OnAfterLoadPage = wasmExports["FORM_OnAfterLoadPage"];
            Module["_FORM_OnBeforeClosePage"] = _FORM_OnBeforeClosePage = wasmExports["FORM_OnBeforeClosePage"];
            Module["_FORM_DoDocumentJSAction"] = _FORM_DoDocumentJSAction = wasmExports["FORM_DoDocumentJSAction"];
            Module["_FORM_DoDocumentOpenAction"] = _FORM_DoDocumentOpenAction = wasmExports["FORM_DoDocumentOpenAction"];
            Module["_FORM_DoDocumentAAction"] = _FORM_DoDocumentAAction = wasmExports["FORM_DoDocumentAAction"];
            Module["_FORM_DoPageAAction"] = _FORM_DoPageAAction = wasmExports["FORM_DoPageAAction"];
            Module["_FORM_SetIndexSelected"] = _FORM_SetIndexSelected = wasmExports["FORM_SetIndexSelected"];
            Module["_FORM_IsIndexSelected"] = _FORM_IsIndexSelected = wasmExports["FORM_IsIndexSelected"];
            Module["_FPDFDoc_GetJavaScriptActionCount"] = _FPDFDoc_GetJavaScriptActionCount = wasmExports["FPDFDoc_GetJavaScriptActionCount"];
            Module["_FPDFDoc_GetJavaScriptAction"] = _FPDFDoc_GetJavaScriptAction = wasmExports["FPDFDoc_GetJavaScriptAction"];
            Module["_FPDFDoc_CloseJavaScriptAction"] = _FPDFDoc_CloseJavaScriptAction = wasmExports["FPDFDoc_CloseJavaScriptAction"];
            Module["_FPDFJavaScriptAction_GetName"] = _FPDFJavaScriptAction_GetName = wasmExports["FPDFJavaScriptAction_GetName"];
            Module["_FPDFJavaScriptAction_GetScript"] = _FPDFJavaScriptAction_GetScript = wasmExports["FPDFJavaScriptAction_GetScript"];
            Module["_FPDF_ImportPagesByIndex"] = _FPDF_ImportPagesByIndex = wasmExports["FPDF_ImportPagesByIndex"];
            Module["_FPDF_ImportPages"] = _FPDF_ImportPages = wasmExports["FPDF_ImportPages"];
            Module["_FPDF_ImportNPagesToOne"] = _FPDF_ImportNPagesToOne = wasmExports["FPDF_ImportNPagesToOne"];
            Module["_FPDF_NewXObjectFromPage"] = _FPDF_NewXObjectFromPage = wasmExports["FPDF_NewXObjectFromPage"];
            Module["_FPDF_CloseXObject"] = _FPDF_CloseXObject = wasmExports["FPDF_CloseXObject"];
            Module["_FPDF_NewFormObjectFromXObject"] = _FPDF_NewFormObjectFromXObject = wasmExports["FPDF_NewFormObjectFromXObject"];
            Module["_FPDF_CopyViewerPreferences"] = _FPDF_CopyViewerPreferences = wasmExports["FPDF_CopyViewerPreferences"];
            Module["_FPDF_RenderPageBitmapWithColorScheme_Start"] = _FPDF_RenderPageBitmapWithColorScheme_Start = wasmExports["FPDF_RenderPageBitmapWithColorScheme_Start"];
            Module["_FPDF_RenderPageBitmap_Start"] = _FPDF_RenderPageBitmap_Start = wasmExports["FPDF_RenderPageBitmap_Start"];
            Module["_FPDF_RenderPage_Continue"] = _FPDF_RenderPage_Continue = wasmExports["FPDF_RenderPage_Continue"];
            Module["_FPDF_RenderPage_Close"] = _FPDF_RenderPage_Close = wasmExports["FPDF_RenderPage_Close"];
            Module["_FPDF_SaveAsCopy"] = _FPDF_SaveAsCopy = wasmExports["FPDF_SaveAsCopy"];
            Module["_FPDF_SaveWithVersion"] = _FPDF_SaveWithVersion = wasmExports["FPDF_SaveWithVersion"];
            Module["_FPDFText_GetCharIndexFromTextIndex"] = _FPDFText_GetCharIndexFromTextIndex = wasmExports["FPDFText_GetCharIndexFromTextIndex"];
            Module["_FPDFText_GetTextIndexFromCharIndex"] = _FPDFText_GetTextIndexFromCharIndex = wasmExports["FPDFText_GetTextIndexFromCharIndex"];
            Module["_FPDF_GetSignatureCount"] = _FPDF_GetSignatureCount = wasmExports["FPDF_GetSignatureCount"];
            Module["_FPDF_GetSignatureObject"] = _FPDF_GetSignatureObject = wasmExports["FPDF_GetSignatureObject"];
            Module["_FPDFSignatureObj_GetContents"] = _FPDFSignatureObj_GetContents = wasmExports["FPDFSignatureObj_GetContents"];
            Module["_FPDFSignatureObj_GetByteRange"] = _FPDFSignatureObj_GetByteRange = wasmExports["FPDFSignatureObj_GetByteRange"];
            Module["_FPDFSignatureObj_GetSubFilter"] = _FPDFSignatureObj_GetSubFilter = wasmExports["FPDFSignatureObj_GetSubFilter"];
            Module["_FPDFSignatureObj_GetReason"] = _FPDFSignatureObj_GetReason = wasmExports["FPDFSignatureObj_GetReason"];
            Module["_FPDFSignatureObj_GetTime"] = _FPDFSignatureObj_GetTime = wasmExports["FPDFSignatureObj_GetTime"];
            Module["_FPDFSignatureObj_GetDocMDPPermission"] = _FPDFSignatureObj_GetDocMDPPermission = wasmExports["FPDFSignatureObj_GetDocMDPPermission"];
            Module["_FPDF_StructTree_GetForPage"] = _FPDF_StructTree_GetForPage = wasmExports["FPDF_StructTree_GetForPage"];
            Module["_FPDF_StructTree_Close"] = _FPDF_StructTree_Close = wasmExports["FPDF_StructTree_Close"];
            Module["_FPDF_StructTree_CountChildren"] = _FPDF_StructTree_CountChildren = wasmExports["FPDF_StructTree_CountChildren"];
            Module["_FPDF_StructTree_GetChildAtIndex"] = _FPDF_StructTree_GetChildAtIndex = wasmExports["FPDF_StructTree_GetChildAtIndex"];
            Module["_FPDF_StructElement_GetAltText"] = _FPDF_StructElement_GetAltText = wasmExports["FPDF_StructElement_GetAltText"];
            Module["_FPDF_StructElement_GetActualText"] = _FPDF_StructElement_GetActualText = wasmExports["FPDF_StructElement_GetActualText"];
            Module["_FPDF_StructElement_GetID"] = _FPDF_StructElement_GetID = wasmExports["FPDF_StructElement_GetID"];
            Module["_FPDF_StructElement_GetLang"] = _FPDF_StructElement_GetLang = wasmExports["FPDF_StructElement_GetLang"];
            Module["_FPDF_StructElement_GetAttributeCount"] = _FPDF_StructElement_GetAttributeCount = wasmExports["FPDF_StructElement_GetAttributeCount"];
            Module["_FPDF_StructElement_GetAttributeAtIndex"] = _FPDF_StructElement_GetAttributeAtIndex = wasmExports["FPDF_StructElement_GetAttributeAtIndex"];
            Module["_FPDF_StructElement_GetStringAttribute"] = _FPDF_StructElement_GetStringAttribute = wasmExports["FPDF_StructElement_GetStringAttribute"];
            Module["_FPDF_StructElement_GetMarkedContentID"] = _FPDF_StructElement_GetMarkedContentID = wasmExports["FPDF_StructElement_GetMarkedContentID"];
            Module["_FPDF_StructElement_GetType"] = _FPDF_StructElement_GetType = wasmExports["FPDF_StructElement_GetType"];
            Module["_FPDF_StructElement_GetObjType"] = _FPDF_StructElement_GetObjType = wasmExports["FPDF_StructElement_GetObjType"];
            Module["_FPDF_StructElement_GetTitle"] = _FPDF_StructElement_GetTitle = wasmExports["FPDF_StructElement_GetTitle"];
            Module["_FPDF_StructElement_CountChildren"] = _FPDF_StructElement_CountChildren = wasmExports["FPDF_StructElement_CountChildren"];
            Module["_FPDF_StructElement_GetChildAtIndex"] = _FPDF_StructElement_GetChildAtIndex = wasmExports["FPDF_StructElement_GetChildAtIndex"];
            Module["_FPDF_StructElement_GetChildMarkedContentID"] = _FPDF_StructElement_GetChildMarkedContentID = wasmExports["FPDF_StructElement_GetChildMarkedContentID"];
            Module["_FPDF_StructElement_GetParent"] = _FPDF_StructElement_GetParent = wasmExports["FPDF_StructElement_GetParent"];
            Module["_FPDF_StructElement_Attr_GetCount"] = _FPDF_StructElement_Attr_GetCount = wasmExports["FPDF_StructElement_Attr_GetCount"];
            Module["_FPDF_StructElement_Attr_GetName"] = _FPDF_StructElement_Attr_GetName = wasmExports["FPDF_StructElement_Attr_GetName"];
            Module["_FPDF_StructElement_Attr_GetValue"] = _FPDF_StructElement_Attr_GetValue = wasmExports["FPDF_StructElement_Attr_GetValue"];
            Module["_FPDF_StructElement_Attr_GetType"] = _FPDF_StructElement_Attr_GetType = wasmExports["FPDF_StructElement_Attr_GetType"];
            Module["_FPDF_StructElement_Attr_GetBooleanValue"] = _FPDF_StructElement_Attr_GetBooleanValue = wasmExports["FPDF_StructElement_Attr_GetBooleanValue"];
            Module["_FPDF_StructElement_Attr_GetNumberValue"] = _FPDF_StructElement_Attr_GetNumberValue = wasmExports["FPDF_StructElement_Attr_GetNumberValue"];
            Module["_FPDF_StructElement_Attr_GetStringValue"] = _FPDF_StructElement_Attr_GetStringValue = wasmExports["FPDF_StructElement_Attr_GetStringValue"];
            Module["_FPDF_StructElement_Attr_GetBlobValue"] = _FPDF_StructElement_Attr_GetBlobValue = wasmExports["FPDF_StructElement_Attr_GetBlobValue"];
            Module["_FPDF_StructElement_Attr_CountChildren"] = _FPDF_StructElement_Attr_CountChildren = wasmExports["FPDF_StructElement_Attr_CountChildren"];
            Module["_FPDF_StructElement_Attr_GetChildAtIndex"] = _FPDF_StructElement_Attr_GetChildAtIndex = wasmExports["FPDF_StructElement_Attr_GetChildAtIndex"];
            Module["_FPDF_StructElement_GetMarkedContentIdCount"] = _FPDF_StructElement_GetMarkedContentIdCount = wasmExports["FPDF_StructElement_GetMarkedContentIdCount"];
            Module["_FPDF_StructElement_GetMarkedContentIdAtIndex"] = _FPDF_StructElement_GetMarkedContentIdAtIndex = wasmExports["FPDF_StructElement_GetMarkedContentIdAtIndex"];
            Module["_FPDF_AddInstalledFont"] = _FPDF_AddInstalledFont = wasmExports["FPDF_AddInstalledFont"];
            Module["_FPDF_SetSystemFontInfo"] = _FPDF_SetSystemFontInfo = wasmExports["FPDF_SetSystemFontInfo"];
            Module["_FPDF_GetDefaultTTFMap"] = _FPDF_GetDefaultTTFMap = wasmExports["FPDF_GetDefaultTTFMap"];
            Module["_FPDF_GetDefaultTTFMapCount"] = _FPDF_GetDefaultTTFMapCount = wasmExports["FPDF_GetDefaultTTFMapCount"];
            Module["_FPDF_GetDefaultTTFMapEntry"] = _FPDF_GetDefaultTTFMapEntry = wasmExports["FPDF_GetDefaultTTFMapEntry"];
            Module["_FPDF_GetDefaultSystemFontInfo"] = _FPDF_GetDefaultSystemFontInfo = wasmExports["FPDF_GetDefaultSystemFontInfo"];
            Module["_FPDF_FreeDefaultSystemFontInfo"] = _FPDF_FreeDefaultSystemFontInfo = wasmExports["FPDF_FreeDefaultSystemFontInfo"];
            Module["_FPDFText_LoadPage"] = _FPDFText_LoadPage = wasmExports["FPDFText_LoadPage"];
            Module["_FPDFText_ClosePage"] = _FPDFText_ClosePage = wasmExports["FPDFText_ClosePage"];
            Module["_FPDFText_CountChars"] = _FPDFText_CountChars = wasmExports["FPDFText_CountChars"];
            Module["_FPDFText_GetUnicode"] = _FPDFText_GetUnicode = wasmExports["FPDFText_GetUnicode"];
            Module["_FPDFText_GetTextObject"] = _FPDFText_GetTextObject = wasmExports["FPDFText_GetTextObject"];
            Module["_FPDFText_IsGenerated"] = _FPDFText_IsGenerated = wasmExports["FPDFText_IsGenerated"];
            Module["_FPDFText_IsHyphen"] = _FPDFText_IsHyphen = wasmExports["FPDFText_IsHyphen"];
            Module["_FPDFText_HasUnicodeMapError"] = _FPDFText_HasUnicodeMapError = wasmExports["FPDFText_HasUnicodeMapError"];
            Module["_FPDFText_GetFontSize"] = _FPDFText_GetFontSize = wasmExports["FPDFText_GetFontSize"];
            Module["_FPDFText_GetFontInfo"] = _FPDFText_GetFontInfo = wasmExports["FPDFText_GetFontInfo"];
            Module["_FPDFText_GetFontWeight"] = _FPDFText_GetFontWeight = wasmExports["FPDFText_GetFontWeight"];
            Module["_FPDFText_GetFillColor"] = _FPDFText_GetFillColor = wasmExports["FPDFText_GetFillColor"];
            Module["_FPDFText_GetStrokeColor"] = _FPDFText_GetStrokeColor = wasmExports["FPDFText_GetStrokeColor"];
            Module["_FPDFText_GetCharAngle"] = _FPDFText_GetCharAngle = wasmExports["FPDFText_GetCharAngle"];
            Module["_FPDFText_GetCharBox"] = _FPDFText_GetCharBox = wasmExports["FPDFText_GetCharBox"];
            Module["_FPDFText_GetLooseCharBox"] = _FPDFText_GetLooseCharBox = wasmExports["FPDFText_GetLooseCharBox"];
            Module["_FPDFText_GetMatrix"] = _FPDFText_GetMatrix = wasmExports["FPDFText_GetMatrix"];
            Module["_FPDFText_GetCharOrigin"] = _FPDFText_GetCharOrigin = wasmExports["FPDFText_GetCharOrigin"];
            Module["_FPDFText_GetCharIndexAtPos"] = _FPDFText_GetCharIndexAtPos = wasmExports["FPDFText_GetCharIndexAtPos"];
            Module["_FPDFText_GetText"] = _FPDFText_GetText = wasmExports["FPDFText_GetText"];
            Module["_FPDFText_CountRects"] = _FPDFText_CountRects = wasmExports["FPDFText_CountRects"];
            Module["_FPDFText_GetRect"] = _FPDFText_GetRect = wasmExports["FPDFText_GetRect"];
            Module["_FPDFText_GetBoundedText"] = _FPDFText_GetBoundedText = wasmExports["FPDFText_GetBoundedText"];
            Module["_FPDFText_FindStart"] = _FPDFText_FindStart = wasmExports["FPDFText_FindStart"];
            Module["_FPDFText_FindNext"] = _FPDFText_FindNext = wasmExports["FPDFText_FindNext"];
            Module["_FPDFText_FindPrev"] = _FPDFText_FindPrev = wasmExports["FPDFText_FindPrev"];
            Module["_FPDFText_GetSchResultIndex"] = _FPDFText_GetSchResultIndex = wasmExports["FPDFText_GetSchResultIndex"];
            Module["_FPDFText_GetSchCount"] = _FPDFText_GetSchCount = wasmExports["FPDFText_GetSchCount"];
            Module["_FPDFText_FindClose"] = _FPDFText_FindClose = wasmExports["FPDFText_FindClose"];
            Module["_FPDFLink_LoadWebLinks"] = _FPDFLink_LoadWebLinks = wasmExports["FPDFLink_LoadWebLinks"];
            Module["_FPDFLink_CountWebLinks"] = _FPDFLink_CountWebLinks = wasmExports["FPDFLink_CountWebLinks"];
            Module["_FPDFLink_GetURL"] = _FPDFLink_GetURL = wasmExports["FPDFLink_GetURL"];
            Module["_FPDFLink_CountRects"] = _FPDFLink_CountRects = wasmExports["FPDFLink_CountRects"];
            Module["_FPDFLink_GetRect"] = _FPDFLink_GetRect = wasmExports["FPDFLink_GetRect"];
            Module["_FPDFLink_GetTextRange"] = _FPDFLink_GetTextRange = wasmExports["FPDFLink_GetTextRange"];
            Module["_FPDFLink_CloseWebLinks"] = _FPDFLink_CloseWebLinks = wasmExports["FPDFLink_CloseWebLinks"];
            Module["_FPDFPage_GetDecodedThumbnailData"] = _FPDFPage_GetDecodedThumbnailData = wasmExports["FPDFPage_GetDecodedThumbnailData"];
            Module["_FPDFPage_GetRawThumbnailData"] = _FPDFPage_GetRawThumbnailData = wasmExports["FPDFPage_GetRawThumbnailData"];
            Module["_FPDFPage_GetThumbnailAsBitmap"] = _FPDFPage_GetThumbnailAsBitmap = wasmExports["FPDFPage_GetThumbnailAsBitmap"];
            Module["_FPDFPage_SetMediaBox"] = _FPDFPage_SetMediaBox = wasmExports["FPDFPage_SetMediaBox"];
            Module["_FPDFPage_SetCropBox"] = _FPDFPage_SetCropBox = wasmExports["FPDFPage_SetCropBox"];
            Module["_FPDFPage_SetBleedBox"] = _FPDFPage_SetBleedBox = wasmExports["FPDFPage_SetBleedBox"];
            Module["_FPDFPage_SetTrimBox"] = _FPDFPage_SetTrimBox = wasmExports["FPDFPage_SetTrimBox"];
            Module["_FPDFPage_SetArtBox"] = _FPDFPage_SetArtBox = wasmExports["FPDFPage_SetArtBox"];
            Module["_FPDFPage_GetMediaBox"] = _FPDFPage_GetMediaBox = wasmExports["FPDFPage_GetMediaBox"];
            Module["_FPDFPage_GetCropBox"] = _FPDFPage_GetCropBox = wasmExports["FPDFPage_GetCropBox"];
            Module["_FPDFPage_GetBleedBox"] = _FPDFPage_GetBleedBox = wasmExports["FPDFPage_GetBleedBox"];
            Module["_FPDFPage_GetTrimBox"] = _FPDFPage_GetTrimBox = wasmExports["FPDFPage_GetTrimBox"];
            Module["_FPDFPage_GetArtBox"] = _FPDFPage_GetArtBox = wasmExports["FPDFPage_GetArtBox"];
            Module["_FPDFPage_TransFormWithClip"] = _FPDFPage_TransFormWithClip = wasmExports["FPDFPage_TransFormWithClip"];
            Module["_FPDFPageObj_TransformClipPath"] = _FPDFPageObj_TransformClipPath = wasmExports["FPDFPageObj_TransformClipPath"];
            Module["_FPDFPageObj_GetClipPath"] = _FPDFPageObj_GetClipPath = wasmExports["FPDFPageObj_GetClipPath"];
            Module["_FPDFClipPath_CountPaths"] = _FPDFClipPath_CountPaths = wasmExports["FPDFClipPath_CountPaths"];
            Module["_FPDFClipPath_CountPathSegments"] = _FPDFClipPath_CountPathSegments = wasmExports["FPDFClipPath_CountPathSegments"];
            Module["_FPDFClipPath_GetPathSegment"] = _FPDFClipPath_GetPathSegment = wasmExports["FPDFClipPath_GetPathSegment"];
            Module["_FPDF_CreateClipPath"] = _FPDF_CreateClipPath = wasmExports["FPDF_CreateClipPath"];
            Module["_FPDF_DestroyClipPath"] = _FPDF_DestroyClipPath = wasmExports["FPDF_DestroyClipPath"];
            Module["_FPDFPage_InsertClipPath"] = _FPDFPage_InsertClipPath = wasmExports["FPDFPage_InsertClipPath"];
            Module["_FPDF_InitLibrary"] = _FPDF_InitLibrary = wasmExports["FPDF_InitLibrary"];
            Module["_FPDF_InitLibraryWithConfig"] = _FPDF_InitLibraryWithConfig = wasmExports["FPDF_InitLibraryWithConfig"];
            Module["_FPDF_DestroyLibrary"] = _FPDF_DestroyLibrary = wasmExports["FPDF_DestroyLibrary"];
            Module["_FPDF_SetSandBoxPolicy"] = _FPDF_SetSandBoxPolicy = wasmExports["FPDF_SetSandBoxPolicy"];
            Module["_FPDF_LoadDocument"] = _FPDF_LoadDocument = wasmExports["FPDF_LoadDocument"];
            Module["_FPDF_GetFormType"] = _FPDF_GetFormType = wasmExports["FPDF_GetFormType"];
            Module["_FPDF_LoadXFA"] = _FPDF_LoadXFA = wasmExports["FPDF_LoadXFA"];
            Module["_FPDF_LoadMemDocument"] = _FPDF_LoadMemDocument = wasmExports["FPDF_LoadMemDocument"];
            Module["_FPDF_LoadMemDocument64"] = _FPDF_LoadMemDocument64 = wasmExports["FPDF_LoadMemDocument64"];
            Module["_FPDF_LoadCustomDocument"] = _FPDF_LoadCustomDocument = wasmExports["FPDF_LoadCustomDocument"];
            Module["_FPDF_GetFileVersion"] = _FPDF_GetFileVersion = wasmExports["FPDF_GetFileVersion"];
            Module["_FPDF_DocumentHasValidCrossReferenceTable"] = _FPDF_DocumentHasValidCrossReferenceTable = wasmExports["FPDF_DocumentHasValidCrossReferenceTable"];
            Module["_FPDF_GetDocPermissions"] = _FPDF_GetDocPermissions = wasmExports["FPDF_GetDocPermissions"];
            Module["_FPDF_GetDocUserPermissions"] = _FPDF_GetDocUserPermissions = wasmExports["FPDF_GetDocUserPermissions"];
            Module["_FPDF_GetSecurityHandlerRevision"] = _FPDF_GetSecurityHandlerRevision = wasmExports["FPDF_GetSecurityHandlerRevision"];
            Module["_FPDF_GetPageCount"] = _FPDF_GetPageCount = wasmExports["FPDF_GetPageCount"];
            Module["_FPDF_LoadPage"] = _FPDF_LoadPage = wasmExports["FPDF_LoadPage"];
            Module["_FPDF_GetPageWidthF"] = _FPDF_GetPageWidthF = wasmExports["FPDF_GetPageWidthF"];
            Module["_FPDF_GetPageWidth"] = _FPDF_GetPageWidth = wasmExports["FPDF_GetPageWidth"];
            Module["_FPDF_GetPageHeightF"] = _FPDF_GetPageHeightF = wasmExports["FPDF_GetPageHeightF"];
            Module["_FPDF_GetPageHeight"] = _FPDF_GetPageHeight = wasmExports["FPDF_GetPageHeight"];
            Module["_FPDF_GetPageBoundingBox"] = _FPDF_GetPageBoundingBox = wasmExports["FPDF_GetPageBoundingBox"];
            Module["_FPDF_RenderPageBitmap"] = _FPDF_RenderPageBitmap = wasmExports["FPDF_RenderPageBitmap"];
            Module["_FPDF_RenderPageBitmapWithMatrix"] = _FPDF_RenderPageBitmapWithMatrix = wasmExports["FPDF_RenderPageBitmapWithMatrix"];
            Module["_FPDF_ClosePage"] = _FPDF_ClosePage = wasmExports["FPDF_ClosePage"];
            Module["_FPDF_CloseDocument"] = _FPDF_CloseDocument = wasmExports["FPDF_CloseDocument"];
            Module["_FPDF_GetLastError"] = _FPDF_GetLastError = wasmExports["FPDF_GetLastError"];
            Module["_FPDF_DeviceToPage"] = _FPDF_DeviceToPage = wasmExports["FPDF_DeviceToPage"];
            Module["_FPDF_PageToDevice"] = _FPDF_PageToDevice = wasmExports["FPDF_PageToDevice"];
            Module["_FPDFBitmap_Create"] = _FPDFBitmap_Create = wasmExports["FPDFBitmap_Create"];
            Module["_FPDFBitmap_CreateEx"] = _FPDFBitmap_CreateEx = wasmExports["FPDFBitmap_CreateEx"];
            Module["_FPDFBitmap_GetFormat"] = _FPDFBitmap_GetFormat = wasmExports["FPDFBitmap_GetFormat"];
            Module["_FPDFBitmap_FillRect"] = _FPDFBitmap_FillRect = wasmExports["FPDFBitmap_FillRect"];
            Module["_FPDFBitmap_GetBuffer"] = _FPDFBitmap_GetBuffer = wasmExports["FPDFBitmap_GetBuffer"];
            Module["_FPDFBitmap_GetWidth"] = _FPDFBitmap_GetWidth = wasmExports["FPDFBitmap_GetWidth"];
            Module["_FPDFBitmap_GetHeight"] = _FPDFBitmap_GetHeight = wasmExports["FPDFBitmap_GetHeight"];
            Module["_FPDFBitmap_GetStride"] = _FPDFBitmap_GetStride = wasmExports["FPDFBitmap_GetStride"];
            Module["_FPDFBitmap_Destroy"] = _FPDFBitmap_Destroy = wasmExports["FPDFBitmap_Destroy"];
            Module["_FPDF_GetPageSizeByIndexF"] = _FPDF_GetPageSizeByIndexF = wasmExports["FPDF_GetPageSizeByIndexF"];
            Module["_FPDF_GetPageSizeByIndex"] = _FPDF_GetPageSizeByIndex = wasmExports["FPDF_GetPageSizeByIndex"];
            Module["_FPDF_VIEWERREF_GetPrintScaling"] = _FPDF_VIEWERREF_GetPrintScaling = wasmExports["FPDF_VIEWERREF_GetPrintScaling"];
            Module["_FPDF_VIEWERREF_GetNumCopies"] = _FPDF_VIEWERREF_GetNumCopies = wasmExports["FPDF_VIEWERREF_GetNumCopies"];
            Module["_FPDF_VIEWERREF_GetPrintPageRange"] = _FPDF_VIEWERREF_GetPrintPageRange = wasmExports["FPDF_VIEWERREF_GetPrintPageRange"];
            Module["_FPDF_VIEWERREF_GetPrintPageRangeCount"] = _FPDF_VIEWERREF_GetPrintPageRangeCount = wasmExports["FPDF_VIEWERREF_GetPrintPageRangeCount"];
            Module["_FPDF_VIEWERREF_GetPrintPageRangeElement"] = _FPDF_VIEWERREF_GetPrintPageRangeElement = wasmExports["FPDF_VIEWERREF_GetPrintPageRangeElement"];
            Module["_FPDF_VIEWERREF_GetDuplex"] = _FPDF_VIEWERREF_GetDuplex = wasmExports["FPDF_VIEWERREF_GetDuplex"];
            Module["_FPDF_VIEWERREF_GetName"] = _FPDF_VIEWERREF_GetName = wasmExports["FPDF_VIEWERREF_GetName"];
            Module["_FPDF_CountNamedDests"] = _FPDF_CountNamedDests = wasmExports["FPDF_CountNamedDests"];
            Module["_FPDF_GetNamedDestByName"] = _FPDF_GetNamedDestByName = wasmExports["FPDF_GetNamedDestByName"];
            Module["_FPDF_GetNamedDest"] = _FPDF_GetNamedDest = wasmExports["FPDF_GetNamedDest"];
            Module["_FPDF_GetXFAPacketCount"] = _FPDF_GetXFAPacketCount = wasmExports["FPDF_GetXFAPacketCount"];
            Module["_FPDF_GetXFAPacketName"] = _FPDF_GetXFAPacketName = wasmExports["FPDF_GetXFAPacketName"];
            Module["_FPDF_GetXFAPacketContent"] = _FPDF_GetXFAPacketContent = wasmExports["FPDF_GetXFAPacketContent"];
            Module["_FPDF_GetTrailerEnds"] = _FPDF_GetTrailerEnds = wasmExports["FPDF_GetTrailerEnds"];
            _emscripten_builtin_memalign = wasmExports["emscripten_builtin_memalign"];
            Module["_malloc"] = _malloc = wasmExports["malloc"];
            Module["_free"] = _free = wasmExports["free"];
            Module["_calloc"] = _calloc = wasmExports["calloc"];
            Module["_realloc"] = _realloc = wasmExports["realloc"];
            _setThrew = wasmExports["setThrew"];
            __emscripten_stack_restore = wasmExports["_emscripten_stack_restore"];
            __emscripten_stack_alloc = wasmExports["_emscripten_stack_alloc"];
            _emscripten_stack_get_current = wasmExports["emscripten_stack_get_current"]
        }
        var wasmImports = {
            __syscall_fcntl64: ___syscall_fcntl64,
            __syscall_fstat64: ___syscall_fstat64,
            __syscall_ftruncate64: ___syscall_ftruncate64,
            __syscall_getdents64: ___syscall_getdents64,
            __syscall_ioctl: ___syscall_ioctl,
            __syscall_lstat64: ___syscall_lstat64,
            __syscall_newfstatat: ___syscall_newfstatat,
            __syscall_openat: ___syscall_openat,
            __syscall_rmdir: ___syscall_rmdir,
            __syscall_stat64: ___syscall_stat64,
            __syscall_unlinkat: ___syscall_unlinkat,
            _abort_js: __abort_js,
            _emscripten_throw_longjmp: __emscripten_throw_longjmp,
            _gmtime_js: __gmtime_js,
            _localtime_js: __localtime_js,
            _tzset_js: __tzset_js,
            emscripten_date_now: _emscripten_date_now,
            emscripten_resize_heap: _emscripten_resize_heap,
            environ_get: _environ_get,
            environ_sizes_get: _environ_sizes_get,
            fd_close: _fd_close,
            fd_read: _fd_read,
            fd_seek: _fd_seek,
            fd_sync: _fd_sync,
            fd_write: _fd_write,
            invoke_ii,
            invoke_iii,
            invoke_iiii,
            invoke_iiiii,
            invoke_v,
            invoke_viii,
            invoke_viiii
        };
        var wasmExports;
        createWasm();

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

        function applySignatureConversions(wasmExports) {
            wasmExports = Object.assign({}, wasmExports);
            var makeWrapper_ppp = f => (a0, a1) => f(a0, a1) >>> 0;
            var makeWrapper_pp = f => a0 => f(a0) >>> 0;
            var makeWrapper_p = f => () => f() >>> 0;
            wasmExports["emscripten_builtin_memalign"] = makeWrapper_ppp(wasmExports["emscripten_builtin_memalign"]);
            wasmExports["malloc"] = makeWrapper_pp(wasmExports["malloc"]);
            wasmExports["calloc"] = makeWrapper_ppp(wasmExports["calloc"]);
            wasmExports["realloc"] = makeWrapper_ppp(wasmExports["realloc"]);
            wasmExports["_emscripten_stack_alloc"] = makeWrapper_pp(wasmExports["_emscripten_stack_alloc"]);
            wasmExports["emscripten_stack_get_current"] = makeWrapper_p(wasmExports["emscripten_stack_get_current"]);
            return wasmExports
        }

        function run() {
            if (runDependencies > 0) {
                dependenciesFulfilled = run;
                return
            }
            preRun();
            if (runDependencies > 0) {
                dependenciesFulfilled = run;
                return
            }

            function doRun() {
                Module["calledRun"] = true;
                if (ABORT) return;
                initRuntime();
                if (Module["onRuntimeInitialized"]) {
                    Module["onRuntimeInitialized"]();
                }
                postRun()
            }
            if (Module["setStatus"]) {
                Module["setStatus"]("Running...");
                setTimeout(() => {
                    setTimeout(() => Module["setStatus"](""), 1);
                    doRun()
                }, 1)
            } else {
                doRun()
            }
        }

        function preInit() {
            if (Module["preInit"]) {
                if (typeof Module["preInit"] == "function") Module["preInit"] = [Module["preInit"]];
                while (Module["preInit"].length > 0) {
                    Module["preInit"].shift()()
                }
            }
        }
        preInit();
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