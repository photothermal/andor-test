using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC.Andor;

namespace andor_test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var stpw = new System.Diagnostics.Stopwatch();

                Console.Write("Initializing ATMCD32D... ");
                stpw.Reset();
                stpw.Start();
                Try(ATMCD32D.Initialize(string.Empty)); // try camera SDK
                Console.WriteLine("[done: {0:0.###} seconds]", stpw.Elapsed.TotalSeconds);

                Try(ATMCD32D.GetSoftwareVersion(out var eprom, out var coffile, out var fxdrev, out var vxdver, out var dllrev, out var dllver));
                Console.WriteLine("eprom = {0}\ncoffile = {1}\nfxdrev = {2}\nvxdver = {3}\ndllrev = {4}\ndllver = {5}",
                    eprom, coffile, fxdrev, vxdver, dllrev, dllver);

                var idandordll = ATMCD32D.IdAndorDll();
                Console.WriteLine("IdAndorDLL = {0}", idandordll);

                // test some camera crap?
                Try(ATMCD32D.GetAvailableCameras(out var totalCameras));
                Console.WriteLine("available cameras = {0}", totalCameras);

                for (int index = 0; index < totalCameras; index++)
                {
                    Console.Write("Initializing camera... ");
                    stpw.Reset();
                    stpw.Start();
                    ATMCD32D.Initialize(string.Empty);
                    Console.WriteLine("[done: {0:0.###} seconds]", stpw.Elapsed.TotalSeconds);

                    Try(ATMCD32D.GetCameraHandle(index, out var cameraHandle));
                    Console.WriteLine("camera {0} handle = {1}", index, cameraHandle);

                    Try(ATMCD32D.GetCameraInformation(index, out var information));
                    Console.WriteLine("camera {0} information = {1}", index, information);

                    Console.Write("Selecting camera device {0}... ", index);
                    stpw.Reset();
                    stpw.Start();
                    Try(ATMCD32D.SelectDevice(index));
                    Console.WriteLine("[done: {0:0.###} seconds]", stpw.Elapsed.TotalSeconds);

                    Try(ATMCD32D.GetCameraSerialNumber(out var number));
                    Console.WriteLine("    serial number = {0}", number);

                    var model = new StringBuilder(32);
                    Try(ATMCD32D.GetHeadModel(model));
                    Console.WriteLine("    model = {0}", model.ToString());

                    Try(ATMCD32D.GetDetector(out var xpixels, out var ypixels));
                    Console.WriteLine("    xpixels = {0}", xpixels);
                    Console.WriteLine("    ypixels = {0}", ypixels);

                    Try(ATMCD32D.GetNumberADChannels(out var numChannels));
                    Console.WriteLine("    ADC channels = {0}", numChannels);

                    Try(ATMCD32D.GetNumberAmp(out var numAmp));
                    Console.WriteLine("    number of amp = {0}", numAmp);

                    //Try(ATMCD32D.GetNumberDDGExternalOutputs(out var numOutputs));
                    //Console.WriteLine("    DDG external outputs = {0}", numOutputs);

                    Try(ATMCD32D.GetNumberPreAmpGains(out var numGains));
                    Console.WriteLine("    pre amp gains = {0}", numGains);

                    Try(ATMCD32D.GetTemperatureRange(out var minTemp, out var maxTemp));
                    Console.WriteLine("    min temp = {0}", minTemp);
                    Console.WriteLine("    max temp = {0}", maxTemp);

                    var versionInfo = new StringBuilder(256);
                    Try(ATMCD32D.GetVersionInfo(ATMCD32D.VersionInfoId.SDKVersion, versionInfo, (uint)versionInfo.Capacity));
                    Console.WriteLine("    SDK version = {0}", versionInfo.ToString());

                    Try(ATMCD32D.GetVersionInfo(ATMCD32D.VersionInfoId.DeviceDriverVersion, versionInfo, (uint)versionInfo.Capacity));
                    Console.WriteLine("    device driver version = {0}", versionInfo.ToString());

                    var caps = new ATMCD32D.AndorCapabilities();
                    caps.ulSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(caps);
                    Try(ATMCD32D.GetCapabilities(ref caps));
                    Console.WriteLine(caps);    // punt
                }

                string iniFilePath = string.Empty;  // todo: this

                Console.Write("Initializing ATSpectrograph... ");
                stpw.Reset();
                stpw.Start();
                Try(ATSpectrographSDK.ATSpectrographInitialize(iniFilePath));   //String to the Andor camera DETECTOR.ini file
                Console.WriteLine("[done: {0:0.###} seconds]", stpw.Elapsed.TotalSeconds);

                Try(ATSpectrographSDK.ATSpectrographGetNumberDevices(out var numDevices));
                Console.WriteLine("There {1} {0} spectrometer device{2} found.", numDevices, 1 == numDevices ? "is" : "are", 1 == numDevices ? "" : "s");

                if (numDevices > 0)
                {
                    for (int i = 0; i < numDevices; i++)
                    {
                        var s = new StringBuilder(256);
                        Try(ATSpectrographSDK.ATSpectrographGetSerialNumber(i, s, s.Capacity));
                        Console.WriteLine("Device {0}: S/N = {1}", i, s.ToString());

                        Try(ATSpectrographSDK.ATSpectrographEepromGetOpticalParams(i, out var focalLength, out var angularDeviation, out var focalTilt));
                        Console.WriteLine("Device {0}: focal length = {1}", i, focalLength);
                        Console.WriteLine("          angular deviation = {0}", angularDeviation);
                        Console.WriteLine("          focal tilt = {0}", focalTilt);

                        Try(ATSpectrographSDK.ATSpectrographGratingIsPresent(i, out var present));
                        Console.WriteLine("Device {0}: grating is present = {1}", i, present.ToString().ToLower());
                        if (present)
                        {
                            Try(ATSpectrographSDK.ATSpectrographGetNumberGratings(i, out var numGratings));
                            Console.WriteLine("Device {0}: number of gratings = {1}", i, numGratings);

                            s = new StringBuilder(256);
                            for (int j = 1; j <= numGratings; j++)
                            {
                                Try(ATSpectrographSDK.ATSpectrographGetGratingInfo(i, j, out var lines, s, s.Capacity, out var home, out var offset));
                                Console.WriteLine("Grating {0}: lines = {1}", j, lines);
                                Console.WriteLine("           blaze = {1}", j, s.ToString());
                                Console.WriteLine("           home = {1}", j, home);
                                Console.WriteLine("           offset = {1}", j, offset);
                            }

                            Try(ATSpectrographSDK.ATSpectrographGetGrating(i, out var grating));
                            Console.WriteLine("Device {0}: grating = {1}", i, grating);

                            // set grating test
                            Console.Write("Device {0}: moving to grating {1}... ", i, (grating % numGratings) + 1);
                            stpw.Reset();
                            stpw.Start();
                            Try(ATSpectrographSDK.ATSpectrographSetGrating(i, (grating % numGratings) + 1));
                            Console.WriteLine("[done: {0:0.###} seconds]", stpw.Elapsed.TotalSeconds);
                        }

                        // test bool marshalling
                        Try(ATSpectrographSDK.ATSpectrographWavelengthIsPresent(i, out present));
                        Console.WriteLine("Device {0}: wavelength is present = {1}", i, present.ToString().ToLower());
                        if (present)
                        {
                            Console.WriteLine("Grating limits:");
                            Try(ATSpectrographSDK.ATSpectrographGetNumberGratings(i, out var numGratings));
                            var limits = new Dictionary<int, (float min, float max)>();
                            for (int g = 1; g <= numGratings; g++)
                            {
                                Try(ATSpectrographSDK.ATSpectrographGetWavelengthLimits(i, g, out var min, out var max));
                                Console.WriteLine("     grating {0} : [ {1:0.####}, {2:0.####} ]", g, min, max);
                                limits.Add(g, (min, max));
                            }

                            Try(ATSpectrographSDK.ATSpectrographGetWavelength(i, out var wavelength));
                            Console.WriteLine("wavelength = {0:0.####}", wavelength);

                            Try(ATSpectrographSDK.ATSpectrographAtZeroOrder(i, out var atZeroOrder));
                            Console.WriteLine("at zero order = {0}", atZeroOrder);

                            Console.Write("Device {0}: reset wavelength... ", i);
                            stpw.Reset();
                            stpw.Start();
                            Try(ATSpectrographSDK.ATSpectrographWavelengthReset(i));
                            Console.WriteLine("[done: {0:0.###} seconds]", stpw.Elapsed.TotalSeconds);

                            Try(ATSpectrographSDK.ATSpectrographGetWavelength(i, out wavelength));
                            Console.WriteLine("wavelength = {0:0.####}", wavelength);

                            Try(ATSpectrographSDK.ATSpectrographAtZeroOrder(i, out atZeroOrder));
                            Console.WriteLine("at zero order = {0}", atZeroOrder);

                            Console.Write("Device {0}: moving to zero order... ", i);
                            stpw.Reset();
                            stpw.Start();
                            Try(ATSpectrographSDK.ATSpectrographGotoZeroOrder(i));
                            Console.WriteLine("[done: {0:0.###} seconds]", stpw.Elapsed.TotalSeconds);

                            Try(ATSpectrographSDK.ATSpectrographAtZeroOrder(i, out atZeroOrder));
                            Console.WriteLine("at zero order = {0}", atZeroOrder);

                            Try(ATSpectrographSDK.ATSpectrographGetWavelength(i, out wavelength));
                            Console.WriteLine("wavelength = {0:0.####}", wavelength);

                            Try(ATSpectrographSDK.ATSpectrographGetGrating(i, out var grating));
                            wavelength = (limits[grating].min + limits[grating].max) / 2;
                            Console.Write("Device {0}: setting wavelength to {1}... ", i, wavelength);
                            stpw.Reset();
                            stpw.Start();
                            Try(ATSpectrographSDK.ATSpectrographSetWavelength(i, wavelength));
                            Console.WriteLine("[done: {0:0.###} seconds]", stpw.Elapsed.TotalSeconds);

                            Try(ATSpectrographSDK.ATSpectrographAtZeroOrder(i, out atZeroOrder));
                            Console.WriteLine("at zero order = {0}", atZeroOrder);

                            Try(ATSpectrographSDK.ATSpectrographGetWavelength(i, out wavelength));
                            Console.WriteLine("wavelength = {0:0.####}", wavelength);
                        }
                        Try(ATSpectrographSDK.ATSpectrographSlitIsPresent(i, ATSpectrographSDK.SlitIndex.INPUT_DIRECT, out present));
                        Console.WriteLine("Device {0}: slit {2} is present = {1}", i, present.ToString().ToLower(), ATSpectrographSDK.SlitIndex.INPUT_DIRECT);
                        if (present)
                        {
                            //public static extern ReturnCode ATSpectrographSlitReset(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] SlitIndex slit);
                            //public static extern ReturnCode ATSpectrographSetSlitWidth(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] SlitIndex slit,
                            //    float width);
                            //public static extern ReturnCode ATSpectrographGetSlitWidth(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] SlitIndex slit,
                            //    out float width);
                            //public static extern ReturnCode ATSpectrographSetSlitZeroPosition(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] SlitIndex slit,
                            //    int offset);
                            //public static extern ReturnCode ATSpectrographGetSlitZeroPosition(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] SlitIndex slit,
                            //    out int offset);
                            //public static extern ReturnCode ATSpectrographSetSlitCoefficients(
                            //    int device,
                            //    int x1,
                            //    int y1,
                            //    int x2,
                            //    int y2);
                            //public static extern ReturnCode ATSpectrographGetSlitCoefficients(
                            //    int device,
                            //    out int x1,
                            //    out int y1,
                            //    out int x2,
                            //    out int y2);
                        }
                        Try(ATSpectrographSDK.ATSpectrographShutterIsPresent(i, out present));
                        Console.WriteLine("Device {0}: shutter is present = {1}", i, present.ToString().ToLower());
                        if (present)
                        {
                            Try(ATSpectrographSDK.ATSpectrographIsShutterModePossible(i, ATSpectrographSDK.ShutterMode.SHUTTER_BNC, out var possible));
                            Console.WriteLine("Device {0}: shutter-mode {2} is present = {1}", i, present.ToString().ToLower(), ATSpectrographSDK.ShutterMode.SHUTTER_BNC);
                        }
                        Try(ATSpectrographSDK.ATSpectrographFilterIsPresent(i, out present));
                        Console.WriteLine("Device {0}: filter is present = {1}", i, present.ToString().ToLower());
                        if (present)
                        {
                            //public static extern ReturnCode ATSpectrographFilterReset(
                            //    int device);
                            //public static extern ReturnCode ATSpectrographSetFilter(
                            //    int device,
                            //    int filter);
                            //public static extern ReturnCode ATSpectrographGetFilter(
                            //    int device,
                            //    out int filter);
                            //public static extern ReturnCode ATSpectrographGetFilterInfo(
                            //    int device,
                            //    int filter,
                            //    StringBuilder info,
                            //    int maxInfoLen);
                            //public static extern ReturnCode ATSpectrographSetFilterInfo(
                            //    int device,
                            //    int filter,
                            //    [MarshalAs(UnmanagedType.LPTStr)] string info);
                        }
                        Try(ATSpectrographSDK.ATSpectrographFlipperMirrorIsPresent(i, ATSpectrographSDK.Flipper.INPUT_FLIPPER, out present));
                        Console.WriteLine("Device {0}: flipper-mirror {2} is present = {1}", i, present.ToString().ToLower(), ATSpectrographSDK.Flipper.INPUT_FLIPPER);
                        if (present)
                        {
                            //public static extern ReturnCode ATSpectrographFlipperMirrorReset(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] Flipper flipper);
                            //public static extern ReturnCode ATSpectrographSetFlipperMirror(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] Flipper flipper,
                            //    [MarshalAs(UnmanagedType.I4)] PortPosition port);
                            //public static extern ReturnCode ATSpectrographGetFlipperMirror(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] Flipper flipper,
                            //    [MarshalAs(UnmanagedType.I4)] out PortPosition port);
                            //public static extern ReturnCode ATSpectrographSetFlipperMirrorPosition(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] Flipper flipper,
                            //    int position);
                            //public static extern ReturnCode ATSpectrographGetFlipperMirrorPosition(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] Flipper flipper,
                            //    out int position);
                            //public static extern ReturnCode ATSpectrographGetFlipperMirrorMaxPosition(
                            //    int device,
                            //    [MarshalAs(UnmanagedType.I4)] Flipper flipper,
                            //    out int maxPosition);
                        }
                        Try(ATSpectrographSDK.ATSpectrographAccessoryIsPresent(i, out present));
                        Console.WriteLine("Device {0}: accessory is present = {1}", i, present.ToString().ToLower());
                        if (present)
                        {
                            //public static extern ReturnCode ATSpectrographSetAccessoryState(
                            //    int device,
                            //    int accessory,
                            //    int state);
        
                            //public static extern ReturnCode ATSpectrographGetAccessoryState(
                            //    int device,
                            //    int accessory,
                            //    out int state);
                        }
                        Try(ATSpectrographSDK.ATSpectrographFocusMirrorIsPresent(i, out present));
                        Console.WriteLine("Device {0}: focus-mirror is present = {1}", i, present.ToString().ToLower());
                        if (present)
                        {

                            //public static extern ReturnCode ATSpectrographFocusMirrorReset(
                            //    int device);
                            //public static extern ReturnCode ATSpectrographSetFocusMirror(
                            //    int device,
                            //    int focus);
                            //public static extern ReturnCode ATSpectrographGetFocusMirror(
                            //    int device,
                            //    out int focus);
                            //public static extern ReturnCode ATSpectrographGetFocusMirrorMaxSteps(
                            //    int device,
                            //    out int steps);
                        }
                        Try(ATSpectrographSDK.ATSpectrographIrisIsPresent(i, ATSpectrographSDK.PortPosition.DIRECT, out present));
                        Console.WriteLine("Device {0}: iris {2} is present = {1}", i, present.ToString().ToLower(), ATSpectrographSDK.PortPosition.DIRECT);
                        if (present)
                        {
                            // ATSpectrographGetIris
                            // ATSpectrographSetIris
                        }

                    }
                }

                Try(ATSpectrographSDK.ATSpectrographClose());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }

        static void Try(ATSpectrographSDK.ReturnCode e)
        {
            switch(e)
            {
                case ATSpectrographSDK.ReturnCode.SUCCESS:
                    return;
                default:
                    var s = new StringBuilder(ATSpectrographSDK.ERRORLENGTH);
                    ATSpectrographSDK.ATSpectrographGetFunctionReturnDescription(e, s, s.Capacity);
                    throw new Exception(s.ToString());
            }
        }

        static void Try(ATMCD32D.ReturnCode e)
        {
            switch(e)
            {
                case ATMCD32D.ReturnCode.SUCCESS:
                    return;
                default:
                    throw new Exception(e.ToString());  // TODO: make an error translator for this.
            }
        }
    }
}
