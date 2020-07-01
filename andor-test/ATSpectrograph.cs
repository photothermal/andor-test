using System.Runtime.InteropServices;
using System.Text;

namespace PSC.Andor
{
    sealed class ATSpectrographSDK
    {
        public static readonly int ERRORLENGTH = 64;

        /// <summary>The possible error codes returned by the ATSpectrograph SDK functions are the following:</summary>
        public enum ReturnCode : int
        {
            /// <summary>A general communication error occurred. Retry the command, if the problem persists check the connection to the spectrograph.</summary>
            /// <typeparam name="eATSpectrographReturnCodes"/>
            COMMUNICATION_ERROR = 20201,
            /// <summary>The command succeeded.</summary>
            /// <typeparam name="eATSpectrographReturnCodes"/>
            SUCCESS = 20202,
            /// <summary>The command failed.</summary>
            /// <typeparam name="eATSpectrographReturnCodes"/>
            ERROR = 20249,
            /// <summary>The first parameter was out of range.</summary>
            /// <typeparam name="eATSpectrographReturnCodes"/>
            P1INVALID = 20266,
            /// <summary>The second parameter was out of range.</summary>
            /// <typeparam name="eATSpectrographReturnCodes"/>
            P2INVALID = 20267,
            /// <summary>The third parameter was out of range.</summary>
            /// <typeparam name="eATSpectrographReturnCodes"/>
            P3INVALID = 20268,
            /// <summary>The fourth parameter was out of range.</summary>
            /// <typeparam name="eATSpectrographReturnCodes"/>
            P4INVALID = 20269,
            /// <summary>The fifth parameter was out of range.</summary>
            /// <typeparam name="eATSpectrographReturnCodes"/>
            P5INVALID = 20270,
            /// <summary>The requested spectrograph was not initialized.</summary>
            /// <typeparam name="eATSpectrographReturnCodes"/>
            NOT_INITIALIZED = 20275,
            /// <summary>The requested speectrograph was not available.</summary>
            /// <typeparam name="eATSpectrographReturnCodes"/>
            NOT_AVAILABLE = 20292,
        }

        /// <summary>This indicates which port flipper mirror to talk to.</summary>
        public enum Flipper : int
        {
            /// <summary>The input flipper mirror.</summary>
            /// <typeparam name="eATSpectrographFlipper"/>
            INPUT_FLIPPER = 1,
            /// <summary>The output flipper mirror.</summary>
            /// <typeparam name="eATSpectrographFlipper"/>
            OUTPUT_FLIPPER = 2,
        }

        /// <summary>This indicates a position for a port (input or output).</summary>
        public enum PortPosition : int
        {
            /// <summary>The DIRECT input or output.</summary>
            /// <typeparam name="eATSpectrographPortPosition"/>
            DIRECT = 0,
            /// <summary>The SIDE input or output.</summary>
            /// <typeparam name="eATSpectrographPortPosition"/>
            SIDE = 1,
        }

        /// <summary>This indicates a slit position.</summary>
        public enum SlitIndex : int
        {
            /// <summary>The side input slit.</summary>
            /// <typeparam name="eATSpectrographSlitIndex"/>
            INPUT_SIDE = 1,
            /// <summary>The direct input slit.</summary>
            /// <typeparam name="eATSpectrographSlitIndex"/>
            INPUT_DIRECT = 2,
            /// <summary>The side output slit.</summary>
            /// <typeparam name="eATSpectrographSlitIndex"/>
            OUTPUT_SIDE = 3,
            /// <summary>The direct output slit.</summary>
            /// <typeparam name="eATSpectrographSlitIndex"/>
            OUTPUT_DIRECT = 4
        }

        /// <summary>This indicates the mode of the shutter.</summary>
        public enum ShutterMode : int
        {
            /// <summary>The shutter is open always.</summary>
            /// <typeparam name="eATSpectrographShutterMode"/>
            SHUTTER_CLOSED = 0,
            /// <summary>The shutter is closed always.</summary>
            /// <typeparam name="eATSpectrographShutterMode"/>
            SHUTTER_OPEN = 1,
            /// <summary>The shutter will open when a TTL high is present on the external shutter BNC connected. Note this does not apply to the SR-303 as it has no external shutter BNC connector.</summary>
            /// <typeparam name="eATSpectrographShutterMode"/>
            SHUTTER_BNC = 2,
        }

        // DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographInitialize(const char* iniPath);
        [DllImport("ATSpectrograph.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographInitialize(
         [MarshalAs(UnmanagedType.LPTStr)] string iniPath);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographClose();
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographClose();

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetNumberDevices(int* noDevices);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetNumberDevices(
            out int noDevices);
        //[MarshalAs(UnmanagedType.I4), Out] out int noDevices);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetFunctionReturnDescription(eATSpectrographReturnCodes error, char* description, int maxDescStrLen);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetFunctionReturnDescription(
            [MarshalAs(UnmanagedType.I4)] ReturnCode error,
            StringBuilder description,
            int maxDescStrLen);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetSerialNumber(int device, char* serial, int maxSerialStrLen);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetSerialNumber(
            int device,
            StringBuilder serial,
            int maxSerialStrLen);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographEepromSetOpticalParams(int device, float focalLength, float angularDeviation, float focalTilt);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographEepromSetOpticalParams(
            int device,
            float focalLength,
            float angularDeviation,
            float focalTilt);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographEepromGetOpticalParams(int device, float* focalLength, float* angularDeviation, float* focalTilt);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographEepromGetOpticalParams(
            int device,
            out float focalLength,
            out float angularDeviation,
            out float focalTilt);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetNumberGratings(int device, int* noGratings);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetNumberGratings(
            int device,
            out int noGratings);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetGrating(int device, int grating);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetGrating(
            int device,
            int grating);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetGrating(int device, int* grating);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetGrating(
            int device,
            out int grating);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetGratingInfo(int device, int grating, float* lines, char* blaze, int maxBlazeStrLen, int* home, int* offset);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetGratingInfo(
            int device,
            int grating,
            out float lines,
            StringBuilder blaze,
            int maxBlazeStrLen,
            out int home,
            out int offset);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGratingIsPresent(int device, int* present);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGratingIsPresent(
            int device,
            [MarshalAs(UnmanagedType.I1)] out bool present);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetDetectorOffset(int device, eATSpectrographPortPosition entrancePort, eATSpectrographPortPosition exitPort, int offset);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetDetectorOffset(
            int device,
            [MarshalAs(UnmanagedType.I4)] ATSpectrographSDK.PortPosition entrancePort,
            [MarshalAs(UnmanagedType.I4)] ATSpectrographSDK.PortPosition exitPort,
            int offset);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetDetectorOffset(int device, eATSpectrographPortPosition entrancePort, eATSpectrographPortPosition exitPort, int* offset);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetDetectorOffset(
            int device,
            [MarshalAs(UnmanagedType.I4)] ATSpectrographSDK.PortPosition entrancePort,
            [MarshalAs(UnmanagedType.I4)] ATSpectrographSDK.PortPosition exitPort,
            out int offset);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetGratingOffset(int device, int grating, int offset);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetGratingOffset(
            int device,
            int grating,
            int offset);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetGratingOffset(int device, int grating, int* offset);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetGratingOffset(
            int device,
            int grating,
            out int offset);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetTurret(int device, int turret);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetTurret(
            int device,
            int turret);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetTurret(int device, int* turret);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetTurret(
            int device,
            out int turret);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographWavelengthIsPresent(int device, int* present);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographWavelengthIsPresent(
            int device,
            [MarshalAs(UnmanagedType.I1)] out bool present);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographWavelengthReset(int device);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographWavelengthReset(
            int device);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetWavelength(int device, float wavelength);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetWavelength(
            int device,
            float wavelength);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetWavelength(int device, float* wavelength);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetWavelength(
            int device,
            out float wavelength);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGotoZeroOrder(int device);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGotoZeroOrder(
            int device);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographAtZeroOrder(int device, int* atZeroOrder);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographAtZeroOrder(
            int device,
            [MarshalAs(UnmanagedType.I1)] out bool atZeroOrder);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetWavelengthLimits(int device, int grating, float* min, float* max);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetWavelengthLimits(
            int device,
            int grating,
            out float min,
            out float max);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSlitIsPresent(int device, eATSpectrographSlitIndex slit, int* present);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSlitIsPresent(
            int device,
            [MarshalAs(UnmanagedType.I4)] SlitIndex slit,
            [MarshalAs(UnmanagedType.I1)] out bool present);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSlitReset(int device, eATSpectrographSlitIndex slit);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSlitReset(
            int device,
            [MarshalAs(UnmanagedType.I4)] SlitIndex slit);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetSlitWidth(int device, eATSpectrographSlitIndex slit, float width);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetSlitWidth(
            int device,
            [MarshalAs(UnmanagedType.I4)] SlitIndex slit,
            float width);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetSlitWidth(int device, eATSpectrographSlitIndex slit, float* width);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetSlitWidth(
            int device,
            [MarshalAs(UnmanagedType.I4)] SlitIndex slit,
            out float width);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetSlitZeroPosition(int device, eATSpectrographSlitIndex slit, int offset);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetSlitZeroPosition(
            int device,
            [MarshalAs(UnmanagedType.I4)] SlitIndex slit,
            int offset);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetSlitZeroPosition(int device, eATSpectrographSlitIndex slit, int* offset);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetSlitZeroPosition(
            int device,
            [MarshalAs(UnmanagedType.I4)] SlitIndex slit,
            out int offset);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetSlitCoefficients(int device, int x1, int y1, int x2, int y2);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetSlitCoefficients(
            int device,
            int x1,
            int y1,
            int x2,
            int y2);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetSlitCoefficients(int device, int* x1, int* y1, int* x2, int* y2);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetSlitCoefficients(
            int device,
            out int x1,
            out int y1,
            out int x2,
            out int y2);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographShutterIsPresent(int device, int* present);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographShutterIsPresent(
            int device,
            [MarshalAs(UnmanagedType.I1)] out bool present);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographIsShutterModePossible(int device, eATSpectrographShutterMode mode, int* possible);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographIsShutterModePossible(
            int device,
            [MarshalAs(UnmanagedType.I4)] ShutterMode mode,
            [MarshalAs(UnmanagedType.I1)] out bool possible);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetShutter(int device, eATSpectrographShutterMode mode);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetShutter(
            int device,
            [MarshalAs(UnmanagedType.I4)] ShutterMode mode);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetShutter(int device, eATSpectrographShutterMode* mode);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetShutter(
            int device,
            [MarshalAs(UnmanagedType.I4)] out ShutterMode mode);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographFilterIsPresent(int device, int* present);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographFilterIsPresent(
            int device,
            [MarshalAs(UnmanagedType.I1)] out bool present);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographFilterReset(int device);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographFilterReset(
            int device);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetFilter(int device, int filter);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetFilter(
            int device,
            int filter);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetFilter(int device, int* filter);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetFilter(
            int device,
            out int filter);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetFilterInfo(int device, int Filter, char* info, int maxInfoLen);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetFilterInfo(
            int device,
            int filter,
            StringBuilder info,
            int maxInfoLen);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetFilterInfo(int device, int Filter, char* info);
        [DllImport("ATSpectrograph.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetFilterInfo(
            int device,
            int filter,
            [MarshalAs(UnmanagedType.LPTStr)] string info);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographFlipperMirrorIsPresent(int device, eATSpectrographFlipper flipper, int* present);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographFlipperMirrorIsPresent(
            int device,
            [MarshalAs(UnmanagedType.I4)] Flipper flipper,
            [MarshalAs(UnmanagedType.I1)] out bool present);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographFlipperMirrorReset(int device, eATSpectrographFlipper flipper);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographFlipperMirrorReset(
            int device,
            [MarshalAs(UnmanagedType.I4)] Flipper flipper);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetFlipperMirror(int device, eATSpectrographFlipper flipper, eATSpectrographPortPosition port);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetFlipperMirror(
            int device,
            [MarshalAs(UnmanagedType.I4)] Flipper flipper,
            [MarshalAs(UnmanagedType.I4)] PortPosition port);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetFlipperMirror(int device, eATSpectrographFlipper flipper, eATSpectrographPortPosition* port);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetFlipperMirror(
            int device,
            [MarshalAs(UnmanagedType.I4)] Flipper flipper,
            [MarshalAs(UnmanagedType.I4)] out PortPosition port);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetFlipperMirrorPosition(int device, eATSpectrographFlipper flipper, int position);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetFlipperMirrorPosition(
            int device,
            [MarshalAs(UnmanagedType.I4)] Flipper flipper,
            int position);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetFlipperMirrorPosition(int device, eATSpectrographFlipper flipper, int* position);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetFlipperMirrorPosition(
            int device,
            [MarshalAs(UnmanagedType.I4)] Flipper flipper,
            out int position);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetFlipperMirrorMaxPosition(int device, eATSpectrographFlipper flipper, int* maxPosition);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetFlipperMirrorMaxPosition(
            int device,
            [MarshalAs(UnmanagedType.I4)] Flipper flipper,
            out int maxPosition);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetCCDLimits(int device, eATSpectrographPortPosition port, float* low, float* high);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetCCDLimits(
            int device,
            [MarshalAs(UnmanagedType.I4)] PortPosition port,
            out float low,
            out float high);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographAccessoryIsPresent(int device, int* present);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographAccessoryIsPresent(
            int device,
            [MarshalAs(UnmanagedType.I1)] out bool present);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetAccessoryState(int device, int accessory, int state);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetAccessoryState(
            int device,
            int accessory,
            int state);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetAccessoryState(int device, int accessory, int* state);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetAccessoryState(
            int device,
            int accessory,
            out int state);


        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographFocusMirrorIsPresent(int device, int* present);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographFocusMirrorIsPresent(
            int device,
            [MarshalAs(UnmanagedType.I1)] out bool present);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographFocusMirrorReset(int device);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographFocusMirrorReset(
            int device);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetFocusMirror(int device, int focus);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetFocusMirror(
            int device,
            int focus);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetFocusMirror(int device, int* focus);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetFocusMirror(
            int device,
            out int focus);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetFocusMirrorMaxSteps(int device, int* steps);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetFocusMirrorMaxSteps(
            int device,
            out int steps);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetPixelWidth(int device, float width);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetPixelWidth(
            int device,
            float width);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetPixelWidth(int device, float* width);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetPixelWidth(
            int device,
            out float width);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetNumberPixels(int device, int numberPixels);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetNumberPixels(
            int device,
            int numberPixels);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetNumberPixels(int device, int* numberPixels);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetNumberPixels(
            int device,
            out int numberPixels);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetCalibration(int device, float* calibrationValues, int numberPixels);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetCalibration(
            int device,
            float[] calibrationValues,
            int numberPixels);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetPixelCalibrationCoefficients(int device, float* A, float* B, float* C, float* D);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetPixelCalibrationCoefficients(
            int device,
            out float A,
            out float B,
            out float C,
            out float D);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographIrisIsPresent(int device, eATSpectrographPortPosition iris, int* present);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographIrisIsPresent(
            int device,
            [MarshalAs(UnmanagedType.I4)] PortPosition iris,
            [MarshalAs(UnmanagedType.I1)] out bool present);
        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographSetIris(int device, eATSpectrographPortPosition iris, int value);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographSetIris(
            int device,
            [MarshalAs(UnmanagedType.I4)] PortPosition iris,
            int value);

        //DLL_DEF eATSpectrographReturnCodes WINAPI ATSpectrographGetIris(int device, eATSpectrographPortPosition iris, int* value);
        [DllImport("ATSpectrograph.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode ATSpectrographGetIris(
            int device,
            [MarshalAs(UnmanagedType.I4)] PortPosition iris,
            out int value);
    }
}
