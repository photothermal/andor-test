using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PSC.Andor
{
    public sealed class ATMCD32D
    {
        // ===================================
        // Version Information Definitions
        // ===================================

        //Version Information Enumeration - NOTE: Increment the count constant below when
        //                                        this structure is extended
        // Using large numbers to force size to an integer
        public enum VersionInfoId
        {
            SDKVersion = 0x40000000,
            DeviceDriverVersion = 0x40000001
        }

        // Count of the number of elements in the Version Information Enumeration
        // NOTE: Increment when extending enumeration
        public const int NoOfVersionInfoIds = 2;

        // Minimum recommended length of the Version Info buffer parameter
        public const int VERSION_INFO_LEN = 80;
        // Minimum recommended length of the Controller Card Model buffer parameter
        public const int CONTROLLER_CARD_MODEL_LEN = 80;
        // ===================================

        // ===================================
        // DDG Lite Definitions
        // ===================================

        //Channel enumeration
        public enum DDGLiteChannelId
        {
            // Using large numbers to force size to an integer
            ChannelA = 0x40000000,
            ChannelB = 0x40000001,
            ChannelC = 0x40000002
        }
        // Control byte flags
        public const int DDGLite_ControlBit_GlobalEnable = 0x01;

        public const int DDGLite_ControlBit_ChannelEnable = 0x01;
        public const int DDGLite_ControlBit_FreeRun = 0x02;
        public const int DDGLite_ControlBit_DisableOnFrame = 0x04;
        public const int DDGLite_ControlBit_RestartOnFire = 0x08;
        public const int DDGLite_ControlBit_Invert = 0x10;
        public const int DDGLite_ControlBit_EnableOnFire = 0x20;
        // ===================================

        // ===================================
        // USB iStar Definitions
        // ===================================

        public enum DDG_Polarity : int
        {
            POSITIVE = 0,
            NEGATIVE = 1,
        }

        public enum DDG_Termination : int
        {
            _50OHMS,
            HIGHZ,
        }

        public enum StepMode : int
        {
            CONSTANT = 0,
            EXPONENTIAL = 1,
            LOGARITHMIC = 2,
            LINEAR = 3,
            OFF = 100,
        }

        public enum GateMode : int
        {
            FIRE_AND_GATE = 0,
            FIRE_ONLY = 1,
            GATE_ONLY = 2,
            CW_ON = 3,
            CW_OFF = 4,
            DDG = 5,
        }
        // ===================================


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public unsafe struct AndorCapabilities
        {
            public uint ulSize;
            public uint ulAcqModes;
            public uint ulReadModes;
            public uint ulTriggerModes;
            public uint ulCameraType;
            public uint ulPixelMode;
            public uint ulSetFunctions;
            public uint ulGetFunctions;
            public uint ulFeatures;
            public uint ulPCICard;
            public uint ulEMGainCapability;
            public uint ulFTReadModes;
            public uint ulFeatures2;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public unsafe struct ColorDemosaicInfo
        {
            public int iX;
            public int iY;
            public int iAlgorithm;
            public int iXPhase;
            public int iYPhase;
            public int iBackground;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public unsafe struct WhiteBalanceInfo
        {
            public int iSize;
            public int iX;
            public int iY;
            public int iAlgorithm;
            public int iROI_left;
            public int iROI_right;
            public int iROI_top;
            public int iROI_bottom;
            public int iOperation;
        }

        public enum ReturnCode : uint
        {
            FALSE = 0,
            TRUE = 1,
            ERROR_CODES = 20001,
            SUCCESS = 20002,
            VXDNOTINSTALLED = 20003,
            ERROR_SCAN = 20004,
            ERROR_CHECK_SUM = 20005,
            ERROR_FILELOAD = 20006,
            UNKNOWN_FUNCTION = 20007,
            ERROR_VXD_INIT = 20008,
            ERROR_ADDRESS = 20009,
            ERROR_PAGELOCK = 20010,
            ERROR_PAGEUNLOCK = 20011,
            ERROR_BOARDTEST = 20012,
            ERROR_ACK = 20013,
            ERROR_UP_FIFO = 20014,
            ERROR_PATTERN = 20015,

            ACQUISITION_ERRORS = 20017,
            ACQ_BUFFER = 20018,
            ACQ_DOWNFIFO_FULL = 20019,
            PROC_UNKONWN_INSTRUCTION = 20020,
            ILLEGAL_OP_CODE = 20021,
            KINETIC_TIME_NOT_MET = 20022,
            ACCUM_TIME_NOT_MET = 20023,
            NO_NEW_DATA = 20024,
            PCI_DMA_FAIL = 20025,
            SPOOLERROR = 20026,
            SPOOLSETUPERROR = 20027,
            FILESIZELIMITERROR = 20028,
            ERROR_FILESAVE = 20029,

            TEMPERATURE_CODES = 20033,
            TEMPERATURE_OFF = 20034,
            TEMPERATURE_NOT_STABILIZED = 20035,
            TEMPERATURE_STABILIZED = 20036,
            TEMPERATURE_NOT_REACHED = 20037,
            TEMPERATURE_OUT_RANGE = 20038,
            TEMPERATURE_NOT_SUPPORTED = 20039,
            TEMPERATURE_DRIFT = 20040,

            TEMP_CODES = 20033,
            TEMP_OFF = 20034,
            TEMP_NOT_STABILIZED = 20035,
            TEMP_STABILIZED = 20036,
            TEMP_NOT_REACHED = 20037,
            TEMP_OUT_RANGE = 20038,
            TEMP_NOT_SUPPORTED = 20039,
            TEMP_DRIFT = 20040,

            GENERAL_ERRORS = 20049,
            INVALID_AUX = 20050,
            COF_NOTLOADED = 20051,
            FPGAPROG = 20052,
            FLEXERROR = 20053,
            GPIBERROR = 20054,
            EEPROMVERSIONERROR = 20055,

            DATATYPE = 20064,
            DRIVER_ERRORS = 20065,
            P1INVALID = 20066,
            P2INVALID = 20067,
            P3INVALID = 20068,
            P4INVALID = 20069,
            INIERROR = 20070,
            COFERROR = 20071,
            ACQUIRING = 20072,
            IDLE = 20073,
            TEMPCYCLE = 20074,
            NOT_INITIALIZED = 20075,
            P5INVALID = 20076,
            P6INVALID = 20077,
            INVALID_MODE = 20078,
            INVALID_FILTER = 20079,

            I2CERRORS = 20080,
            I2CDEVNOTFOUND = 20081,
            I2CTIMEOUT = 20082,
            P7INVALID = 20083,
            P8INVALID = 20084,
            P9INVALID = 20085,
            P10INVALID = 20086,
            P11INVALID = 20087,

            USBERROR = 20089,
            IOCERROR = 20090,
            VRMVERSIONERROR = 20091,
            GATESTEPERROR = 20092,
            USB_INTERRUPT_ENDPOINT_ERROR = 20093,
            RANDOM_TRACK_ERROR = 20094,
            INVALID_TRIGGER_MODE = 20095,
            LOAD_FIRMWARE_ERROR = 20096,
            DIVIDE_BY_ZERO_ERROR = 20097,
            INVALID_RINGEXPOSURES = 20098,
            BINNING_ERROR = 20099,
            INVALID_AMPLIFIER = 20100,
            INVALID_COUNTCONVERT_MODE = 20101,
            USB_INTERRUPT_ENDPOINT_TIMEOUT = 20102,

            ERROR_NOCAMERA = 20990,
            NOT_SUPPORTED = 20991,
            NOT_AVAILABLE = 20992,

            ERROR_MAP = 20115,
            ERROR_UNMAP = 20116,
            ERROR_MDL = 20117,
            ERROR_UNMDL = 20118,
            ERROR_BUFFSIZE = 20119,
            ERROR_NOHANDLE = 20121,

            GATING_NOT_AVAILABLE = 20130,
            FPGA_VOLTAGE_ERROR = 20131,

            OW_CMD_FAIL = 20150,
            OWMEMORY_BAD_ADDR = 20151,
            OWCMD_NOT_AVAILABLE = 20152,
            OW_NO_SLAVES = 20153,
            OW_NOT_INITIALIZED = 20154,
            OW_ERROR_SLAVE_NUM = 20155,
            MSTIMINGS_ERROR = 20156,

            OA_NULL_ERROR = 20173,
            OA_PARSE_DTD_ERROR = 20174,
            OA_DTD_VALIDATE_ERROR = 20175,
            OA_FILE_ACCESS_ERROR = 20176,
            OA_FILE_DOES_NOT_EXIST = 20177,
            OA_XML_INVALID_OR_NOT_FOUND_ERROR = 20178,
            OA_PRESET_FILE_NOT_LOADED = 20179,
            OA_USER_FILE_NOT_LOADED = 20180,
            OA_PRESET_AND_USER_FILE_NOT_LOADED = 20181,
            OA_INVALID_FILE = 20182,
            OA_FILE_HAS_BEEN_MODIFIED = 20183,
            OA_BUFFER_FULL = 20184,
            OA_INVALID_STRING_LENGTH = 20185,
            OA_INVALID_CHARS_IN_NAME = 20186,
            OA_INVALID_NAMING = 20187,
            OA_GET_CAMERA_ERROR = 20188,
            OA_MODE_ALREADY_EXISTS = 20189,
            OA_STRINGS_NOT_EQUAL = 20190,
            OA_NO_USER_DATA = 20191,
            OA_VALUE_NOT_SUPPORTED = 20192,
            OA_MODE_DOES_NOT_EXIST = 20193,
            OA_CAMERA_NOT_SUPPORTED = 20194,
            OA_FAILED_TO_GET_MODE = 20195,
            OA_CAMERA_NOT_AVAILABLE = 20196,

            PROCESSING_FAILED = 20211,
        }

        public enum AcqMode : int
        {
            SINGLE = 1,
            VIDEO = 2,
            ACCUMULATE = 4,
            KINETIC = 8,
            FRAMETRANSFER = 16,
            FASTKINETICS = 32,
            OVERLAP = 64,
            TDI = 0x80,
        }

        public enum ReadMode : int
        {
            FULLIMAGE = 1,
            SUBIMAGE = 2,
            SINGLETRACK = 4,
            FVB = 8,
            MULTITRACK = 16,
            RANDOMTRACK = 32,
            MULTITRACKSCAN = 64,
        }
        public enum TriggerMode : int
        {
            INTERNAL = 1,
            EXTERNAL = 2,
            EXTERNAL_FVB_EM = 4,
            CONTINUOUS = 8,
            EXTERNALSTART = 16,
            EXTERNALEXPOSURE = 32,
            INVERTED = 0x40,
            EXTERNAL_CHARGESHIFTING = 0x80,
            EXTERNAL_RISING = 0x0100,
            EXTERNAL_PURGE = 0x0200,
        }

        public enum CameraType : int
        {
            PDA = 0,
            IXON = 1,
            ICCD = 2,
            EMCCD = 3,
            CCD = 4,
            ISTAR = 5,
            VIDEO = 6,
            IDUS = 7,
            NEWTON = 8,
            SURCAM = 9,
            USBICCD = 10,
            LUCA = 11,
            RESERVED = 12,
            IKON = 13,
            INGAAS = 14,
            IVAC = 15,
            UNPROGRAMME = 16,
            CLARA = 17,
            USBISTAR = 18,
            SIMCAM = 19,
            NEO = 20,
            IXONULTRA = 21,
            VOLMOS = 22,
            IVAC_CCD = 23,
            ASPEN = 24,
            ASCENT = 25,
            ALTA = 26,
            ALTAF = 27,
            IKONXL = 28,
            CMOS_GEN2 = 29,
            ISTAR_SCMOS = 30,
            IKONLR = 31,
        }

        public enum PixelMode : int
        {
            _8BIT = 1,
            _14BIT = 2,
            _16BIT = 4,
            _32BIT = 8,

            MONO = 0x000000,
            RGB = 0x010000,
            CMY = 0x020000,
        }

        public enum SetFunction : uint
        {
            VREADOUT = 0x01,
            HREADOUT = 0x02,
            TEMPERATURE = 0x04,
            MCPGAIN = 0x08,
            EMCCDGAIN = 0x10,
            BASELINECLAMP = 0x20,
            VSAMPLITUDE = 0x40,
            HIGHCAPACITY = 0x80,
            BASELINEOFFSET = 0x0100,
            PREAMPGAIN = 0x0200,
            CROPMODE = 0x0400,
            DMAPARAMETERS = 0x0800,
            HORIZONTALBIN = 0x1000,
            MULTITRACKHRANGE = 0x2000,
            RANDOMTRACKNOGAPS = 0x4000,
            EMADVANCED = 0x8000,
            GATEMODE = 0x010000,
            DDGTIMES = 0x020000,
            IOC = 0x040000,
            INTELLIGATE = 0x080000,
            INSERTION_DELAY = 0x100000,
            GATESTEP = 0x200000,
            GATEDELAYSTEP = 0x200000,
            TRIGGERTERMINATION = 0x400000,
            EXTENDEDNIR = 0x800000,
            SPOOLTHREADCOUNT = 0x1000000,
            REGISTERPACK = 0x2000000,
            PRESCANS = 0x4000000,
            GATEWIDTHSTEP = 0x8000000,
            EXTENDED_CROP_MODE = 0x10000000,
            SUPERKINETICS = 0x20000000,
            TIMESCAN = 0x40000000,
            CROPMODETYPE = 0x80000000,
        }

        public enum GetFunction : uint
        {
            TEMPERATURE = 0x01,
            TARGETTEMPERATURE = 0x02,
            TEMPERATURERANGE = 0x04,
            DETECTORSIZE = 0x08,
            MCPGAIN = 0x10,
            EMCCDGAIN = 0x20,
            HVFLAG = 0x40,
            GATEMODE = 0x80,
            DDGTIMES = 0x0100,
            IOC = 0x0200,
            INTELLIGATE = 0x0400,
            INSERTION_DELAY = 0x0800,
            GATESTEP = 0x1000,
            GATEDELAYSTEP = 0x1000,
            PHOSPHORSTATUS = 0x2000,
            MCPGAINTABLE = 0x4000,
            BASELINECLAMP = 0x8000,
            GATEWIDTHSTEP = 0x10000,
        }

        public enum Features : uint
        {
            POLLING = 1,
            EVENTS = 2,
            SPOOLING = 4,
            SHUTTER = 8,
            SHUTTEREX = 16,
            EXTERNAL_I2C = 32,
            SATURATIONEVENT = 64,
            FANCONTROL = 128,
            MIDFANCONTROL = 256,
            TEMPERATUREDURINGACQUISITION = 512,
            KEEPCLEANCONTROL = 1024,
            DDGLITE = 0x0800,
            FTEXTERNALEXPOSURE = 0x1000,
            KINETICEXTERNALEXPOSURE = 0x2000,
            DACCONTROL = 0x4000,
            METADATA = 0x8000,
            IOCONTROL = 0x10000,
            PHOTONCOUNTING = 0x20000,
            COUNTCONVERT = 0x40000,
            DUALMODE = 0x80000,
            OPTACQUIRE = 0x100000,
            REALTIMESPURIOUSNOISEFILTER = 0x200000,
            POSTPROCESSSPURIOUSNOISEFILTER = 0x400000,
            DUALPREAMPGAIN = 0x800000,
            DEFECT_CORRECTION = 0x1000000,
            STARTOFEXPOSURE_EVENT = 0x2000000,
            ENDOFEXPOSURE_EVENT = 0x4000000,
            CAMERALINK = 0x8000000,
            FIFOFULL_EVENT = 0x10000000,
            SENSOR_PORT_CONFIGURATION = 0x20000000,
            SENSOR_COMPENSATION = 0x40000000,
            IRIG_SUPPORT = 0x80000000,
        }

        public enum EMGain : int
        {
            _8BIT = 1,
            _12BIT = 2,
            LINEAR12 = 4,
            REAL12 = 8,
        }

        public enum Features2 : int
        {
            ESD_EVENTS = 1,
            DUAL_PORT_CONFIGURATION = 2,
            OVERTEMP_EVENTS = 4,
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public unsafe struct SYSTEMTIME
        {
            public UInt16 wYear;
            public UInt16 wMonth;
            public UInt16 wDayOfWeek;
            public UInt16 wDay;
            public UInt16 wHour;
            public UInt16 wMinute;
            public UInt16 wSecond;
            public UInt16 wMilliseconds;
        }


        //unsigned int WINAPI AbortAcquisition(void);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode AbortAcquisition();
        //unsigned int WINAPI CancelWait(void);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode CancelWait();
        //unsigned int WINAPI CoolerOFF(void);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode CoolerOFF();
        //unsigned int WINAPI CoolerON(void);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode CoolerON();
        //unsigned int WINAPI DemosaicImage(WORD* grey, WORD* red, WORD* green, WORD* blue, ColorDemosaicInfo* info);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode DemosaicImage(
            ushort[] grey,
            ushort[] red,
            ushort[] green,
            ushort[] blue,
            ref ColorDemosaicInfo info);
        //unsigned int WINAPI EnableKeepCleans(int iMode);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode EnableKeepCleans(
            int iMode);
        //unsigned int WINAPI EnableSensorCompensation(int iMode);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode EnableSensorCompensation(
            int iMode);
        //unsigned int WINAPI SetIRIGModulation(char mode);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode SetIRIGModulation(
            char mode);
        //unsigned int WINAPI FreeInternalMemory(void);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode FreeInternalMemory();
        //unsigned int WINAPI GetAcquiredData(at_32* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetAcquiredData(
            Int32[] arr,
            UInt32 size);
        //unsigned int WINAPI GetAcquiredData16(WORD* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetAcquiredData16(
            UInt16[] arr,
            UInt32 size);
        //unsigned int WINAPI GetAcquiredFloatData(float* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetAcquiredFloatData(
            float[] arr,
            UInt32 size);
        //unsigned int WINAPI GetAcquisitionProgress(long* acc, long* series);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetAcquisitionProgress(
            out Int32 acc,
            out Int32 series);
        //unsigned int WINAPI GetAcquisitionTimings(float* exposure, float* accumulate, float* kinetic);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetAcquisitionTimings(
            out float exposure,
            out float accumulate,
            out float kinetic);
        //unsigned int WINAPI GetAdjustedRingExposureTimes(int inumTimes, float* fptimes);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetAdjustedRingExposureTimes(
            int inumTimes,
            out float fptimes);
        //unsigned int WINAPI GetAllDMAData(at_32* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetAllDMAData(
            Int32[] arr,
            UInt32 size);
        //unsigned int WINAPI GetAmpDesc(int index, char* name, int length);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetAmpDesc(
            int index,
            StringBuilder name,
            int length);
        //unsigned int WINAPI GetAmpMaxSpeed(int index, float* speed);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetAmpMaxSpeed(
            int index,
            out float speed);
        //unsigned int WINAPI GetAvailableCameras(long* totalCameras);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetAvailableCameras(
            out Int32 totalCameras);
        //unsigned int WINAPI GetBackground(at_32* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetBackground(
            Int32[] arr,
            UInt32 size);
        //unsigned int WINAPI GetBaselineClamp(int* state);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetBaselineClamp(
            out int state);
        //unsigned int WINAPI GetBitDepth(int channel, int* depth);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetBitDepth(
            int channel,
            out int depth);
        //unsigned int WINAPI GetBitsPerPixel(int readout_index, int index, int* value);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetBitsPerPixel(
            int readout_index,
            int index,
            out int value);
        //unsigned int WINAPI GetCameraEventStatus(DWORD* camStatus);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetCameraEventStatus(
            out UInt32 camStatus);
        //unsigned int WINAPI GetCameraHandle(long cameraIndex, long* cameraHandle);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetCameraHandle(
            Int32 cameraIndex,
            out Int32 cameraHandle);
        //unsigned int WINAPI GetCameraInformation(int index, long* information);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetCameraInformation(
            int index,
            out Int32 information);
        //unsigned int WINAPI GetCameraSerialNumber(int* number);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetCameraSerialNumber(
            out int number);
        //unsigned int WINAPI GetCapabilities(AndorCapabilities* caps);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetCapabilities(
            ref AndorCapabilities caps);
        //unsigned int WINAPI GetControllerCardModel(char* controllerCardModel);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetControllerCardModel(
            out char controllerCardModel);
        //unsigned int WINAPI GetCountConvertWavelengthRange(float* minval, float* maxval);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetCountConvertWavelengthRange(
            out float minval,
            out float maxval);
        //unsigned int WINAPI GetCurrentCamera(long* cameraHandle);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetCurrentCamera(
            out Int32 cameraHandle);
        //unsigned int WINAPI GetCYMGShift(int* iXshift, int* iYShift);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetCYMGShift(
            out int iXshift,
            out int iYShift);
        //unsigned int WINAPI GetDDGExternalOutputEnabled(at_u32 uiIndex, at_u32* puiEnabled);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGExternalOutputEnabled(
            UInt32 uiIndex,
            [MarshalAs(UnmanagedType.U4)] out bool enabled);
        //unsigned int WINAPI GetDDGExternalOutputPolarity(at_u32 uiIndex, at_u32* puiPolarity);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGExternalOutputPolarity(
            UInt32 uiIndex,
            out UInt32 uiPolarity);
        //unsigned int WINAPI GetDDGExternalOutputStepEnabled(at_u32 uiIndex, at_u32* puiEnabled);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGExternalOutputStepEnabled(
            UInt32 uiIndex,
            [MarshalAs(UnmanagedType.U4)] out bool enabled);
        //unsigned int WINAPI GetDDGExternalOutputTime(at_u32 uiIndex, at_u64* puiDelay, at_u64* puiWidth);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGExternalOutputTime(
            UInt32 uiIndex,
            out UInt64 uiDelay,
            out UInt64 uiWidth);
        //unsigned int WINAPI GetDDGTTLGateWidth(at_u64 opticalWidth, at_u64* ttlWidth);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGTTLGateWidth(
            UInt64 opticalWidth,
            out UInt64 ttlWidth);
        //unsigned int WINAPI GetDDGGateTime(at_u64* puiDelay, at_u64* puiWidth);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGGateTime(
            out UInt64 uiDelay,
            out UInt64 uiWidth);
        //unsigned int WINAPI GetDDGInsertionDelay(int* piState);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGInsertionDelay(
            out int iState);
        //unsigned int WINAPI GetDDGIntelligate(int* piState);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGIntelligate(
            out int iState);
        //unsigned int WINAPI GetDDGIOC(int* state);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGIOC(
            out int iState);
        //unsigned int WINAPI GetDDGIOCFrequency(double* frequency);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGIOCFrequency(
            out double frequency);
        //unsigned int WINAPI GetDDGIOCNumber(unsigned long* numberPulses);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGIOCNumber(
            out UInt32 numberPulses);
        //unsigned int WINAPI GetDDGIOCNumberRequested(at_u32* pulses);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGIOCNumberRequested(
            out UInt32 pulses);
        //unsigned int WINAPI GetDDGIOCPeriod(at_u64* period);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGIOCPeriod(
            out UInt64 period);
        //unsigned int WINAPI GetDDGIOCPulses(int* pulses);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGIOCPulses(
            out int pulses);
        //unsigned int WINAPI GetDDGIOCTrigger(at_u32* trigger);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGIOCTrigger(
            out UInt32 trigger);
        //unsigned int WINAPI GetDDGOpticalWidthEnabled(at_u32* puiEnabled);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGOpticalWidthEnabled(
            [MarshalAs(UnmanagedType.U4)] out bool enabled);

        //// DDG Lite functions
        //unsigned int WINAPI GetDDGLiteGlobalControlByte(unsigned char* control);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGLiteGlobalControlByte(
            out byte control);
        //unsigned int WINAPI GetDDGLiteControlByte(AT_DDGLiteChannelId channel, unsigned char* control);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGLiteControlByte(
            DDGLiteChannelId channel,
            out byte control);
        //unsigned int WINAPI GetDDGLiteInitialDelay(AT_DDGLiteChannelId channel, float* fDelay);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGLiteInitialDelay(
            DDGLiteChannelId channel,
            out float fDelay);
        //unsigned int WINAPI GetDDGLitePulseWidth(AT_DDGLiteChannelId channel, float* fWidth);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGLitePulseWidth(
            DDGLiteChannelId channel,
            out float fWidth);
        //unsigned int WINAPI GetDDGLiteInterPulseDelay(AT_DDGLiteChannelId channel, float* fDelay);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGLiteInterPulseDelay(
            DDGLiteChannelId channel,
            out float fDelay);
        //unsigned int WINAPI GetDDGLitePulsesPerExposure(AT_DDGLiteChannelId channel, at_u32* ui32Pulses);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGLitePulsesPerExposure(
            DDGLiteChannelId channel,
            out UInt32 ui32Pulses);

        //unsigned int WINAPI GetDDGPulse(double wid, double resolution, double* Delay, double* Width);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGPulse(
            double wid,
            double resolution,
            out double Delay,
            out double Width);
        //unsigned int WINAPI GetDDGStepCoefficients(at_u32 mode, double* p1, double* p2);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGStepCoefficients(
            UInt32 mode,
            out double p1,
            out double p2);
        //unsigned int WINAPI GetDDGWidthStepCoefficients(at_u32 mode, double* p1, double* p2);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGWidthStepCoefficients(
            UInt32 mode,
            out double p1,
            out double p2);
        //unsigned int WINAPI GetDDGStepMode(at_u32* mode);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGStepMode(
            out UInt32 mode);
        //unsigned int WINAPI GetDDGWidthStepMode(at_u32* mode);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDDGWidthStepMode(
            out UInt32 mode);
        //unsigned int WINAPI GetDetector(int* xpixels, int* ypixels);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDetector(
            out int xpixels,
            out int ypixels);
        //unsigned int WINAPI GetDICameraInfo(void* info);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDICameraInfo(
            ref IntPtr info);
        //unsigned int WINAPI GetEMAdvanced(int* state);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetEMAdvanced(
            out int state);
        //unsigned int WINAPI GetEMCCDGain(int* gain);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetEMCCDGain(
            out int gain);
        //unsigned int WINAPI GetEMGainRange(int* low, int* high);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetEMGainRange(
            out int low,
            out int high);
        //unsigned int WINAPI GetESDEventStatus(DWORD* camStatus);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetESDEventStatus(
            out UInt16 camStatus);
        //unsigned int WINAPI GetExternalTriggerTermination(at_u32* puiTermination);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetExternalTriggerTermination(
            out UInt32 uiTermination);
        //unsigned int WINAPI GetFastestRecommendedVSSpeed(int* index, float* speed);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetFastestRecommendedVSSpeed(
            ref int index,
            out float speed);
        //unsigned int WINAPI GetFIFOUsage(int* FIFOusage);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetFIFOUsage(
            out int FIFOusage);
        //unsigned int WINAPI GetFilterMode(int* mode);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetFilterMode(
            out int mode);
        //unsigned int WINAPI GetFKExposureTime(float* time);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetFKExposureTime(
            out float time);
        //unsigned int WINAPI GetFKVShiftSpeed(int index, int* speed);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetFKVShiftSpeed(
            int index,
            out int speed);
        //unsigned int WINAPI GetFKVShiftSpeedF(int index, float* speed);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetFKVShiftSpeedF(
            int index,
            out float speed);
        //unsigned int WINAPI GetFrontEndStatus(int* piFlag);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetFrontEndStatus(
            out int iFlag);
        //unsigned int WINAPI GetGateMode(int* piGatemode);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetGateMode(
            out int iGatemode);
        //unsigned int WINAPI GetHardwareVersion(unsigned int* PCB, unsigned int* Decode, unsigned int* dummy1, unsigned int* dummy2, unsigned int* CameraFirmwareVersion, unsigned int* CameraFirmwareBuild);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetHardwareVersion(
            out uint PCB,
            out uint Decode,
            out uint dummy1,
            out uint dummy2,
            out uint CameraFirmwareVersion,
            out uint CameraFirmwareBuild);
        //unsigned int WINAPI GetHeadModel(char* name);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetHeadModel(
            StringBuilder name);
        //unsigned int WINAPI GetHorizontalSpeed(int index, int* speed);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetHorizontalSpeed(
            int index,
            out int speed);
        //unsigned int WINAPI GetHSSpeed(int channel, int typ, int index, float* speed);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetHSSpeed(
            int channel,
            int typ,
            int index,
            out float speed);
        //unsigned int WINAPI GetHVflag(int* bFlag);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetHVflag(
            out int bFlag);
        //unsigned int WINAPI GetID(int devNum, int* id);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetID(
            int devNum,
            out int id);
        //unsigned int WINAPI GetImageFlip(int* iHFlip, int* iVFlip);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetImageFlip(
            [MarshalAs(UnmanagedType.I4)] out bool HFlip,
            [MarshalAs(UnmanagedType.I4)] out bool VFlip);
        //unsigned int WINAPI GetImageRotate(int* iRotate);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetImageRotate(
            out int Rotate);
        //unsigned int WINAPI GetImages(long first, long last, at_32* arr, unsigned long size, long* validfirst, long* validlast);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetImages(
            Int32 fist,
            Int32 last,
            Int32[] arr,
            UInt32 size,
            out Int32 validFirst,
            out Int32 validLast);
        //unsigned int WINAPI GetImages16(long first, long last, WORD* arr, unsigned long size, long* validfirst, long* validlast);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetImages16(
            Int32 first,
            Int32 last,
            UInt16[] arr,
            UInt32 size,
            out Int32 validFirst,
            out Int32 validLast);
        //unsigned int WINAPI GetImagesPerDMA(unsigned long* images);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetImagesPerDMA(
            out UInt32 images);
        //unsigned int WINAPI GetIRQ(int* IRQ);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetIRQ(
            out int IRQ);
        //unsigned int WINAPI GetKeepCleanTime(float* KeepCleanTime);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetKeepCleanTime(
            out float KeepCleanTime);
        //unsigned int WINAPI GetMaximumBinning(int ReadMode, int HorzVert, int* MaxBinning);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMaximumBinning(
            int ReadMode,
            int HorzVert,
            out int MaxBinning);
        //unsigned int WINAPI GetMaximumExposure(float* MaxExp);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMaximumExposure(
            out float MaxExp);
        //unsigned int WINAPI GetMaximumNumberRingExposureTimes(int* number);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMaximumNumberRingExposureTimes(
            out int number);
        //unsigned int WINAPI GetMCPGain(int* piGain);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMCPGain(
            out int iGain);
        //unsigned int WINAPI GetMCPGainRange(int* iLow, int* iHigh);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMCPGainRange(
            out int Low,
            out int High);
        //unsigned int WINAPI GetMCPGainTable(int iNum, int* piGain, float* pfPhotoepc);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMCPGainTable(
            int Num,
            out int Gain,
            out float Photoepc);
        //unsigned int WINAPI GetMCPVoltage(int* iVoltage);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMCPVoltage(
            out int Voltage);
        //unsigned int WINAPI GetMinimumImageLength(int* MinImageLength);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMinimumImageLength(
            out int MinImageLength);
        //unsigned int WINAPI GetMinimumNumberInSeries(int* number);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMinimumNumberInSeries(
            out int number);
        //unsigned int WINAPI GetMostRecentColorImage16(unsigned long size, int algorithm, WORD* red, WORD* green, WORD* blue);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMostRecentColorImage16(
            UInt32 size,
            int algorithm,
            UInt16[] red,
            UInt16[] green,
            UInt16[] blue);
        //unsigned int WINAPI GetMostRecentImage(at_32* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMostRecentImage(
            Int32[] arr,
            UInt32 size);
        //unsigned int WINAPI GetMostRecentImage16(WORD* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMostRecentImage16(
            UInt16[] arr,
            UInt32 size);
        //unsigned int WINAPI GetMSTimingsData(SYSTEMTIME* TimeOfStart, float* pfDifferences, int inoOfImages);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMSTimingsData(
            ref SYSTEMTIME TimeOfStart,
            out float Differences,
            int noOfImages);
        //unsigned int WINAPI GetMetaDataInfo(SYSTEMTIME* TimeOfStart, float* pfTimeFromStart, unsigned int index);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMetaDataInfo(
            ref SYSTEMTIME TimeOfStart,
            out float TimeFromStart,
            uint index);
        //unsigned int WINAPI GetMSTimingsEnabled(void);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMSTimingsEnabled();
        //unsigned int WINAPI GetNewData(at_32* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNewData(
            Int32[] arr,
            UInt32 size);
        //unsigned int WINAPI GetNewData16(WORD* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNewData16(
            UInt16[] arr,
            UInt32 size);
        //unsigned int WINAPI GetNewData8(unsigned char* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNewData8(
            byte[] arr,
            UInt32 size);
        //unsigned int WINAPI GetNewFloatData(float* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNewFloatData(
            float[] arr,
            UInt32 size);
        //unsigned int WINAPI GetNumberADChannels(int* channels);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberADChannels(
            out int channels);
        //unsigned int WINAPI GetNumberAmp(int* amp);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberAmp(
            out int amp);
        //unsigned int WINAPI GetNumberAvailableImages(at_32* first, at_32* last);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberAvailableImages(
            out Int32 first,
            out Int32 last);
        //unsigned int WINAPI GetNumberDDGExternalOutputs(at_u32* puiCount);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberDDGExternalOutputs(
            out UInt32 count);
        //unsigned int WINAPI GetNumberDevices(int* numDevs);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberDevices(
            out int numDevs);
        //unsigned int WINAPI GetNumberFKVShiftSpeeds(int* number);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberFKVShiftSpeeds(
            out int number);
        //unsigned int WINAPI GetNumberHorizontalSpeeds(int* number);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberHorizontalSpeeds(
            out int number);
        //unsigned int WINAPI GetNumberHSSpeeds(int channel, int typ, int* speeds);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberHSSpeeds(
            int channel,
            int typ,
            out int speeds);
        //unsigned int WINAPI GetNumberMissedExternalTriggers(unsigned int first, unsigned int last, WORD* arr, unsigned int size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberMissedExternalTriggers(
            uint first,
            uint last,
            UInt16[] arr,
            uint size);
        //unsigned int WINAPI GetIRIGData(unsigned char* _uc_irigData, unsigned int _ui_index);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetIRIGData(
            out byte irigData,
            uint index);
        //unsigned int WINAPI GetMetaData(unsigned char* data, unsigned int _ui_index);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetMetaData(
            out byte data, uint index);
        //unsigned int WINAPI GetNumberNewImages(long* first, long* last);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberNewImages(
            out Int32 first,
            out Int32 last);
        //unsigned int WINAPI GetNumberPhotonCountingDivisions(at_u32* noOfDivisions);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberPhotonCountingDivisions(
            out UInt32 noOfDivisions);
        //unsigned int WINAPI GetNumberPreAmpGains(int* noGains);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberPreAmpGains(
            out int noGains);
        //unsigned int WINAPI GetNumberRingExposureTimes(int* ipnumTimes);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberRingExposureTimes(
            out int numTimes);
        //unsigned int WINAPI GetNumberIO(int* iNumber);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberIO(
            out int Number);
        //unsigned int WINAPI GetNumberVerticalSpeeds(int* number);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberVerticalSpeeds(
            out int number);
        //unsigned int WINAPI GetNumberVSAmplitudes(int* number);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberVSAmplitudes(
            out int number);
        //unsigned int WINAPI GetNumberVSSpeeds(int* speeds);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetNumberVSSpeeds(
            out int speeds);
        //unsigned int WINAPI GetOldestImage(at_32* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetOldestImage(
            Int32[] arr,
            UInt32 size);
        //unsigned int WINAPI GetOldestImage16(WORD* arr, unsigned long size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetOldestImage16(
            UInt16[] arr, UInt32 size);
        //unsigned int WINAPI GetPhosphorStatus(int* piFlag);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetPhosphorStatus(
            out int Flag);
        //unsigned int WINAPI GetPhysicalDMAAddress(unsigned long* Address1, unsigned long* Address2);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetPhysicalDMAAddress(
            out UInt32 Address1,
            out UInt32 Address2);
        //unsigned int WINAPI GetPixelSize(float* xSize, float* ySize);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetPixelSize(
            out float xSize,
            out float ySize);
        //unsigned int WINAPI GetPreAmpGain(int index, float* gain);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetPreAmpGain(
            int index,
            out float gain);
        //unsigned int WINAPI GetPreAmpGainText(int index, char* name, int length);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetPreAmpGainText(
            int index,
            StringBuilder name,
            int length);
        //unsigned int WINAPI GetCurrentPreAmpGain(int* index, char* name, int length);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetCurrentPreAmpGain(
            ref int index,
            StringBuilder name,
            int length);
        //unsigned int WINAPI GetDualExposureTimes(float* exposure1, float* exposure2);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetDualExposureTimes(
            out float exposure1,
            out float exposure2);
        //unsigned int WINAPI GetQE(char* sensor, float wavelength, unsigned int mode, float* QE);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetQE(
            out char sensor, 
            float wavelength, 
            uint mode, 
            out float QE);
        //unsigned int WINAPI GetReadOutTime(float* ReadOutTime);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetReadOutTime(
            out float ReadOutTime);
        //unsigned int WINAPI GetRegisterDump(int* mode);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetRegisterDump(
            out int mode);
        //unsigned int WINAPI GetRelativeImageTimes(unsigned int first, unsigned int last, at_u64* arr, unsigned int size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetRelativeImageTimes(
            uint first,
            uint last,
            UInt64[] arr,
            uint size);
        //unsigned int WINAPI GetRingExposureRange(float* fpMin, float* fpMax);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetRingExposureRange(
            out float Min,
            out float Max);
        //unsigned int WINAPI GetSDK3Handle(int* Handle);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetSDK3Handle(
            out int handle);
        //unsigned int WINAPI GetSensitivity(int channel, int horzShift, int amplifier, int pa, float* sensitivity);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetSensitivity(
            int channel,
            int horzShift,
            int amplifier,
            int pa,
            out float sensitivity);
        //unsigned int WINAPI GetShutterMinTimes(int* minclosingtime, int* minopeningtime);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetShutterMinTimes(
            out int minclosingtime,
            out int minopeningtime);
        //unsigned int WINAPI GetSizeOfCircularBuffer(long* index);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetSizeOfCircularBuffer(
            out Int32 index);
        //unsigned int WINAPI GetSlotBusDeviceFunction(DWORD* dwslot, DWORD* dwBus, DWORD* dwDevice, DWORD* dwFunction);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetSlotBusDeviceFunction(
            ref UInt16 slot,
            ref UInt16 bus,
            ref UInt16 device,
            ref UInt16 function);
        //unsigned int WINAPI GetSoftwareVersion(unsigned int* eprom, unsigned int* coffile, unsigned int* vxdrev, unsigned int* vxdver, unsigned int* dllrev, unsigned int* dllver);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetSoftwareVersion(
            out uint eprom,
            out uint coffile,
            out uint vxdrev,
            out uint vxdver,
            out uint dllrev,
            out uint dllver);
        //unsigned int WINAPI GetSpoolProgress(long* index);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetSpoolProgress(
            out Int32 index);
        //unsigned int WINAPI GetStartUpTime(float* time);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetStartUpTime(
            out float time);
        //unsigned int WINAPI GetStatus(int* status);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetStatus(
            out int status);
        //unsigned int WINAPI GetTECStatus(int* piFlag);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetTECStatus(
            out int flag);
        //unsigned int WINAPI GetTemperature(int* temperature);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetTemperature(
            out int temperature);
        //unsigned int WINAPI GetTemperatureF(float* temperature);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetTemperatureF(
            out float temperature);
        //unsigned int WINAPI GetTemperatureRange(int* mintemp, int* maxtemp);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetTemperatureRange(
            out int mintemp,
            out int maxtemp);
        //unsigned int WINAPI GetTemperaturePrecision(int* precision);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetTemperaturePrecision(
            out int precision);
        //unsigned int WINAPI GetTemperatureStatus(float* SensorTemp, float* TargetTemp, float* AmbientTemp, float* CoolerVolts);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetTemperatureStatus(
            out float sensorTemp,
            out float targetTemp,
            out float ambientTemp,
            out float coolerVolts);
        //unsigned int WINAPI GetTotalNumberImagesAcquired(long* index);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetTotalNumberImagesAcquired(
            out Int32 index);
        //unsigned int WINAPI GetIODirection(int index, int* iDirection);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetIODirection(
            int index,
            out int direction);
        //unsigned int WINAPI GetIOLevel(int index, int* iLevel);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetIOLevel(
            int index,
            out int level);
        //unsigned int WINAPI GetUSBDeviceDetails(WORD* VendorID, WORD* ProductID, WORD* FirmwareVersion, WORD* SpecificationNumber);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetUSBDeviceDetails(
            out UInt16 vendorId,
            out UInt16 productId,
            out UInt16 firmwareVersion,
            out UInt16 specificationNumber);
        //unsigned int WINAPI GetVersionInfo(AT_VersionInfoId arr, char* szVersionInfo, at_u32 ui32BufferLen);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetVersionInfo(
            VersionInfoId arr,
            StringBuilder versionInfo,
            UInt32 bufferLen);
        //unsigned int WINAPI GetVerticalSpeed(int index, int* speed);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetVerticalSpeed(
            int index,
            out int speed);
        //unsigned int WINAPI GetVirtualDMAAddress(void** Address1, void** Address2);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetVirtualDMAAddress(
            out IntPtr Address1,
            out IntPtr Address2);
        //unsigned int WINAPI GetVSAmplitudeString(int index, char* text);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetVSAmplitudeString(
            int index,
            StringBuilder text);
        //unsigned int WINAPI GetVSAmplitudeFromString(char* text, int* index);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetVSAmplitudeFromString(
            [MarshalAs(UnmanagedType.LPTStr)] string text,
            out int index);
        //unsigned int WINAPI GetVSAmplitudeValue(int index, int* value);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetVSAmplitudeValue(
            int index,
            out int value);
        //unsigned int WINAPI GetVSSpeed(int index, float* speed);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GetVSSpeed(
            int index,
            out float speed);
        //unsigned int WINAPI GPIBReceive(int id, short address, char* text, int size);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GPIBReceive(
            int id,
            short address,
            StringBuilder text,
            int size);
        //unsigned int WINAPI GPIBSend(int id, short address, char* text);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode GPIBSend(
            int id,
            short address,
            [MarshalAs(UnmanagedType.LPTStr)] string text);
        //unsigned int WINAPI I2CBurstRead(BYTE i2cAddress, long nBytes, BYTE* data);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode I2CBurstRead(
            byte i2cAddress,
            Int32 nBytes,
            byte[] data);
        //unsigned int WINAPI I2CBurstWrite(BYTE i2cAddress, long nBytes, BYTE* data);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode I2CBurstWrite(
            byte i2cAddress,
            Int32 nBytes,
            byte[] data);
        //unsigned int WINAPI I2CRead(BYTE deviceID, BYTE intAddress, BYTE* pdata);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode I2CRead(
            byte deviceId,
            byte intAddress,
            byte[] data);
        //unsigned int WINAPI I2CReset(void);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode I2CReset();
        //unsigned int WINAPI I2CWrite(BYTE deviceID, BYTE intAddress, BYTE data);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode I2CWrite(
            byte deviceId,
            byte intAddress,
            byte data);
        //unsigned int WINAPI IdAndorDll(void);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode IdAndorDll();
        //unsigned int WINAPI InAuxPort(int port, int* state);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode InAuxPort(
            int port,
            out int state);
        //unsigned int WINAPI Initialize(char* dir);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode Initialize(
            [MarshalAs(UnmanagedType.LPTStr)] string dir);
        //unsigned int WINAPI InitializeDevice(char* dir);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode InitializeDevice(
            [MarshalAs(UnmanagedType.LPTStr)] string dir);
        //unsigned int WINAPI IsAmplifierAvailable(int iamp);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode IsAmplifierAvailable(
            int iamp);
        //unsigned int WINAPI IsCoolerOn(int* iCoolerStatus);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode IsCoolerOn(
            out int coolerStatus);
        //unsigned int WINAPI IsCountConvertModeAvailable(int mode);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode IsCountConvertModeAvailable(
            int mode);
        //unsigned int WINAPI IsInternalMechanicalShutter(int* InternalShutter);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode IsInternalMechanicalShutter(
            out int internalShutter);
        //unsigned int WINAPI IsPreAmpGainAvailable(int channel, int amplifier, int index, int pa, int* status);
        //unsigned int WINAPI IsReadoutFlippedByAmplifier(int iAmplifier, int* iFlipped);
        //unsigned int WINAPI IsTriggerModeAvailable(int iTriggerMode);
        //unsigned int WINAPI Merge(const at_32* arr, long nOrder, long nPoint, long nPixel, float* coeff, long fit, long hbin, at_32 * output, float* start, float* step_Renamed);
        //unsigned int WINAPI OutAuxPort(int port, int state);
        //unsigned int WINAPI PrepareAcquisition(void);
        //unsigned int WINAPI SaveAsBmp(const char* path, const char* palette, long ymin, long ymax);
        //unsigned int WINAPI SaveAsCalibratedSif(char* path, int x_data_type, int x_unit, float* x_cal, float rayleighWavelength);
        //unsigned int WINAPI SaveAsCommentedSif(char* path, char* comment);
        //unsigned int WINAPI SaveAsEDF(char* szPath, int iMode);
        //unsigned int WINAPI SaveAsFITS(char* szFileTitle, int typ);
        //unsigned int WINAPI SaveAsRaw(char* szFileTitle, int typ);
        //unsigned int WINAPI SaveAsSif(char* path);
        //unsigned int WINAPI SaveAsSPC(char* path);
        //unsigned int WINAPI SaveAsTiff(char* path, char* palette, int position, int typ);
        //unsigned int WINAPI SaveAsTiffEx(char* path, char* palette, int position, int typ, int mode);
        //unsigned int WINAPI SaveEEPROMToFile(char* cFileName);
        //unsigned int WINAPI SaveToClipBoard(char* palette);
        //unsigned int WINAPI SelectDevice(int devNum);
        [DllImport("ATMCD32d.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern ReturnCode SelectDevice(
            int devNum);
        //unsigned int WINAPI SendSoftwareTrigger(void);
        //unsigned int WINAPI SetAccumulationCycleTime(float time);
        //unsigned int WINAPI SetAcqStatusEvent(HANDLE statusEvent);
        //unsigned int WINAPI SetAcquisitionMode(int mode);
        //unsigned int WINAPI SetSensorPortMode(int mode);
        //unsigned int WINAPI SelectSensorPort(int port);
        //unsigned int WINAPI SetSizeOfCircularBufferMegaBytes(unsigned long sizeMB);
        //unsigned int WINAPI SelectDualSensorPort(int port);
        //unsigned int WINAPI SetAcquisitionType(int typ);
        //unsigned int WINAPI SetADChannel(int channel);
        //unsigned int WINAPI SetAdvancedTriggerModeState(int iState);
        //unsigned int WINAPI SetBackground(at_32* arr, unsigned long size);
        //unsigned int WINAPI SetBaselineClamp(int state);
        //unsigned int WINAPI SetBaselineOffset(int offset);
        //unsigned int WINAPI SetBitsPerPixel(int state);
        //unsigned int WINAPI SetCameraLinkMode(int mode);
        //unsigned int WINAPI SetCameraStatusEnable(DWORD Enable);
        //unsigned int WINAPI SetChargeShifting(unsigned int NumberRows, unsigned int NumberRepeats);
        //unsigned int WINAPI SetComplexImage(int numAreas, int* areas);
        //unsigned int WINAPI SetCoolerMode(int mode);
        //unsigned int WINAPI SetCountConvertMode(int Mode);
        //unsigned int WINAPI SetCountConvertWavelength(float wavelength);
        //unsigned int WINAPI SetCropMode(int active, int cropHeight, int reserved);
        //unsigned int WINAPI SetCurrentCamera(long cameraHandle);
        //unsigned int WINAPI SetCustomTrackHBin(int bin);
        //unsigned int WINAPI SetDataType(int typ);
        //unsigned int WINAPI SetDACOutput(int iOption, int iResolution, int iValue);
        //unsigned int WINAPI SetDACOutputScale(int iScale);
        //unsigned int WINAPI SetDDGAddress(BYTE t0, BYTE t1, BYTE t2, BYTE t3, BYTE address);
        //unsigned int WINAPI SetDDGExternalOutputEnabled(at_u32 uiIndex, at_u32 uiEnabled);
        //unsigned int WINAPI SetDDGExternalOutputPolarity(at_u32 uiIndex, at_u32 uiPolarity);
        //unsigned int WINAPI SetDDGExternalOutputStepEnabled(at_u32 uiIndex, at_u32 uiEnabled);
        //unsigned int WINAPI SetDDGExternalOutputTime(at_u32 uiIndex, at_u64 uiDelay, at_u64 uiWidth);
        //unsigned int WINAPI SetDDGGain(int gain);
        //unsigned int WINAPI SetDDGGateStep(double step_Renamed);
        //unsigned int WINAPI SetDDGGateTime(at_u64 uiDelay, at_u64 uiWidth);
        //unsigned int WINAPI SetDDGInsertionDelay(int state);
        //unsigned int WINAPI SetDDGIntelligate(int state);
        //unsigned int WINAPI SetDDGIOC(int state);
        //unsigned int WINAPI SetDDGIOCFrequency(double frequency);
        //unsigned int WINAPI SetDDGIOCNumber(unsigned long numberPulses);
        //unsigned int WINAPI SetDDGIOCPeriod(at_u64 period);
        //unsigned int WINAPI SetDDGIOCTrigger(at_u32 trigger);
        //unsigned int WINAPI SetDDGOpticalWidthEnabled(at_u32 uiEnabled);

        //// DDG Lite functions
        //unsigned int WINAPI SetDDGLiteGlobalControlByte(unsigned char control);
        //unsigned int WINAPI SetDDGLiteControlByte(AT_DDGLiteChannelId channel, unsigned char control);
        //unsigned int WINAPI SetDDGLiteInitialDelay(AT_DDGLiteChannelId channel, float fDelay);
        //unsigned int WINAPI SetDDGLitePulseWidth(AT_DDGLiteChannelId channel, float fWidth);
        //unsigned int WINAPI SetDDGLiteInterPulseDelay(AT_DDGLiteChannelId channel, float fDelay);
        //unsigned int WINAPI SetDDGLitePulsesPerExposure(AT_DDGLiteChannelId channel, at_u32 ui32Pulses);

        //unsigned int WINAPI SetDDGStepCoefficients(at_u32 mode, double p1, double p2);
        //unsigned int WINAPI SetDDGWidthStepCoefficients(at_u32 mode, double p1, double p2);
        //unsigned int WINAPI SetDDGStepMode(at_u32 mode);
        //unsigned int WINAPI SetDDGWidthStepMode(at_u32 mode);
        //unsigned int WINAPI SetDDGTimes(double t0, double t1, double t2);
        //unsigned int WINAPI SetDDGTriggerMode(int mode);
        //unsigned int WINAPI SetDDGVariableGateStep(int mode, double p1, double p2);
        //unsigned int WINAPI SetDelayGenerator(int board, short address, int typ);
        //unsigned int WINAPI SetDMAParameters(int MaxImagesPerDMA, float SecondsPerDMA);
        //unsigned int WINAPI SetDriverEvent(HANDLE driverEvent);
        //unsigned int WINAPI SetESDEvent(HANDLE esdEvent);
        //unsigned int WINAPI SetEMAdvanced(int state);
        //unsigned int WINAPI SetEMCCDGain(int gain);
        //unsigned int WINAPI SetEMClockCompensation(int EMClockCompensationFlag);
        //unsigned int WINAPI SetEMGainMode(int mode);
        //unsigned int WINAPI SetExposureTime(float time);
        //unsigned int WINAPI SetExternalTriggerTermination(at_u32 uiTermination);
        //unsigned int WINAPI SetFanMode(int mode);
        //unsigned int WINAPI SetFastExtTrigger(int mode);
        //unsigned int WINAPI SetFastKinetics(int exposedRows, int seriesLength, float time, int mode, int hbin, int vbin);
        //unsigned int WINAPI SetFastKineticsEx(int exposedRows, int seriesLength, float time, int mode, int hbin, int vbin, int offset);
        //unsigned int WINAPI SetFastKineticsStorageMode(int mode);
        //unsigned int WINAPI SetFastKineticsTimeScanMode(int rows, int tracks, int mode);
        //unsigned int WINAPI SetFilterMode(int mode);
        //unsigned int WINAPI SetFilterParameters(int width, float sensitivity, int range, float accept, int smooth, int noise);
        //unsigned int WINAPI SetFKVShiftSpeed(int index);
        //unsigned int WINAPI SetFPDP(int state);
        //unsigned int WINAPI SetFrameTransferMode(int mode);
        //unsigned int WINAPI SetFrontEndEvent(HANDLE driverEvent);
        //unsigned int WINAPI SetFullImage(int hbin, int vbin);
        //unsigned int WINAPI SetFVBHBin(int bin);
        //unsigned int WINAPI SetGain(int gain);
        //unsigned int WINAPI SetGate(float delay, float width, float stepRenamed);
        //unsigned int WINAPI SetGateMode(int gatemode);
        //unsigned int WINAPI SetHighCapacity(int state);
        //unsigned int WINAPI SetHorizontalSpeed(int index);
        //unsigned int WINAPI SetHSSpeed(int typ, int index);
        //unsigned int WINAPI SetImage(int hbin, int vbin, int hstart, int hend, int vstart, int vend);
        //unsigned int WINAPI SetImageFlip(int iHFlip, int iVFlip);
        //unsigned int WINAPI SetImageRotate(int iRotate);
        //unsigned int WINAPI SetIsolatedCropMode(int active, int cropheight, int cropwidth, int vbin, int hbin);
        //unsigned int WINAPI SetIsolatedCropModeEx(int active, int cropheight, int cropwidth, int vbin, int hbin, int cropleft, int cropbottom);
        //unsigned int WINAPI SetIsolatedCropModeType(int type);
        //unsigned int WINAPI SetKineticCycleTime(float time);
        //unsigned int WINAPI SetMCPGain(int gain);
        //unsigned int WINAPI SetMCPGating(int gating);
        //unsigned int WINAPI SetMessageWindow(HWND wnd);
        //unsigned int WINAPI SetMetaData(int state);
        //unsigned int WINAPI SetMultiTrack(int number, int height, int offset, int* bottom, int* gap);
        //unsigned int WINAPI SetMultiTrackHBin(int bin);
        //unsigned int WINAPI SetMultiTrackHRange(int iStart, int iEnd);
        //unsigned int WINAPI SetMultiTrackScan(int trackHeight, int numberTracks, int iSIHStart, int iSIHEnd, int trackHBinning, int trackVBinning, int trackGap, int trackOffset, int trackSkip, int numberSubFrames);
        //unsigned int WINAPI SetNextAddress(at_32* data, long lowAdd, long highAdd, long length, long physical);
        //unsigned int WINAPI SetNextAddress16(at_32* data, long lowAdd, long highAdd, long length, long physical);
        //unsigned int WINAPI SetNumberAccumulations(int number);
        //unsigned int WINAPI SetNumberKinetics(int number);
        //unsigned int WINAPI SetNumberPrescans(int iNumber);
        //unsigned int WINAPI SetOutputAmplifier(int typ);
        //unsigned int WINAPI SetOverlapMode(int mode);
        //unsigned int WINAPI SetOverTempEvent(HANDLE tempEvent);
        //unsigned int WINAPI SetPCIMode(int mode, int value);
        //unsigned int WINAPI SetPhotonCounting(int state);
        //unsigned int WINAPI SetPhotonCountingThreshold(long min, long max);
        //unsigned int WINAPI SetPhosphorEvent(HANDLE driverEvent);
        //unsigned int WINAPI SetPhotonCountingDivisions(at_u32 noOfDivisions, at_32* divisions);
        //unsigned int WINAPI SetPixelMode(int bitdepth, int colormode);
        //unsigned int WINAPI SetPreAmpGain(int index);
        //unsigned int WINAPI SetDualExposureTimes(float expTime1, float expTime2);
        //unsigned int WINAPI SetDualExposureMode(int mode);
        //unsigned int WINAPI SetRandomTracks(int numTracks, int* areas);
        //unsigned int WINAPI SetReadMode(int mode);
        //unsigned int WINAPI SetReadoutRegisterPacking(unsigned int mode);
        //unsigned int WINAPI SetRegisterDump(int mode);
        //unsigned int WINAPI SetRingExposureTimes(int numTimes, float* times);
        //unsigned int WINAPI SetSaturationEvent(HANDLE saturationEvent);
        //unsigned int WINAPI SetShutter(int typ, int mode, int closingtime, int openingtime);
        //unsigned int WINAPI SetShutterEx(int typ, int mode, int closingtime, int openingtime, int extmode);
        //unsigned int WINAPI SetShutters(int typ, int mode, int closingtime, int openingtime, int exttype, int extmode, int dummy1, int dummy2);
        //unsigned int WINAPI SetSifComment(char* comment);
        //unsigned int WINAPI SetSingleTrack(int centre, int height);
        //unsigned int WINAPI SetSingleTrackHBin(int bin);
        //unsigned int WINAPI SetSpool(int active, int method, char* path, int framebuffersize);
        //unsigned int WINAPI SetSpoolThreadCount(int count);
        //unsigned int WINAPI SetStorageMode(long mode);
        //unsigned int WINAPI SetTECEvent(HANDLE driverEvent);
        //unsigned int WINAPI SetTemperature(int temperature);
        //unsigned int WINAPI SetTemperatureEvent(HANDLE temperatureEvent);
        //unsigned int WINAPI SetTriggerMode(int mode);
        //unsigned int WINAPI SetTriggerInvert(int mode);
        //unsigned int WINAPI GetTriggerLevelRange(float* minimum, float* maximum);
        //unsigned int WINAPI SetTriggerLevel(float f_level);
        //unsigned int WINAPI SetIODirection(int index, int iDirection);
        //unsigned int WINAPI SetIOLevel(int index, int iLevel);
        //unsigned int WINAPI SetUserEvent(HANDLE userEvent);
        //unsigned int WINAPI SetUSGenomics(long width, long height);
        //unsigned int WINAPI SetVerticalRowBuffer(int rows);
        //unsigned int WINAPI SetVerticalSpeed(int index);
        //unsigned int WINAPI SetVirtualChip(int state);
        //unsigned int WINAPI SetVSAmplitude(int index);
        //unsigned int WINAPI SetVSSpeed(int index);
        //unsigned int WINAPI ShutDown(void);
        //unsigned int WINAPI StartAcquisition(void);
        //unsigned int WINAPI UnMapPhysicalAddress(void);
        //unsigned int WINAPI UpdateDDGTimings(void);
        //unsigned int WINAPI WaitForAcquisition(void);
        //unsigned int WINAPI WaitForAcquisitionByHandle(long cameraHandle);
        //unsigned int WINAPI WaitForAcquisitionByHandleTimeOut(long cameraHandle, int iTimeOutMs);
        //unsigned int WINAPI WaitForAcquisitionTimeOut(int iTimeOutMs);
        //unsigned int WINAPI WhiteBalance(WORD* wRed, WORD* wGreen, WORD* wBlue, float* fRelR, float* fRelB, WhiteBalanceInfo* info);

        //unsigned int WINAPI OA_Initialize(const char* const pcFilename, unsigned int uiFileNameLen);
        //unsigned int WINAPI OA_IsPreSetModeAvailable(const char* const pcModeName);
        //unsigned int WINAPI OA_EnableMode(const char* const pcModeName);
        //unsigned int WINAPI OA_GetModeAcqParams(const char* const pcModeName, char* const pcListOfParams);
        //unsigned int WINAPI OA_GetUserModeNames(char* pcListOfModes);
        //unsigned int WINAPI OA_GetPreSetModeNames(char* pcListOfModes);
        //unsigned int WINAPI OA_GetNumberOfUserModes(unsigned int* const puiNumberOfModes);
        //unsigned int WINAPI OA_GetNumberOfPreSetModes(unsigned int* const puiNumberOfModes);
        //unsigned int WINAPI OA_GetNumberOfAcqParams(const char* const pcModeName, unsigned int* const puiNumberOfParams);
        //unsigned int WINAPI OA_AddMode(char* pcModeName, unsigned int uiModeNameLen, char* pcModeDescription, unsigned int uiModeDescriptionLen);
        //unsigned int WINAPI OA_WriteToFile(const char* const pcFileName, unsigned int uiFileNameLen);
        //unsigned int WINAPI OA_DeleteMode(const char* const pcModeName, unsigned int uiModeNameLen);
        //unsigned int WINAPI OA_SetInt(const char* const pcModeName, const char* pcModeParam, const int iIntValue);
        //unsigned int WINAPI OA_SetFloat(const char* const pcModeName, const char* pcModeParam, const float fFloatValue);
        //unsigned int WINAPI OA_SetString(const char* const pcModeName, const char* pcModeParam, char* pcStringValue, const unsigned int uiStringLen);
        //unsigned int WINAPI OA_GetInt(const char* const pcModeName, const char* const pcModeParam, int* iIntValue);
        //unsigned int WINAPI OA_GetFloat(const char* const pcModeName, const char* const pcModeParam, float* fFloatValue);
        //unsigned int WINAPI OA_GetString(const char* const pcModeName, const char* const pcModeParam, char* pcStringValue, const unsigned int uiStringLen);

        //unsigned int WINAPI Filter_SetMode(unsigned int mode);
        //unsigned int WINAPI Filter_GetMode(unsigned int* mode);
        //unsigned int WINAPI Filter_SetThreshold(float threshold);
        //unsigned int WINAPI Filter_GetThreshold(float* threshold);
        //unsigned int WINAPI Filter_SetDataAveragingMode(int mode);
        //unsigned int WINAPI Filter_GetDataAveragingMode(int* mode);
        //unsigned int WINAPI Filter_SetAveragingFrameCount(int frames);
        //unsigned int WINAPI Filter_GetAveragingFrameCount(int* frames);
        //unsigned int WINAPI Filter_SetAveragingFactor(int averagingFactor);
        //unsigned int WINAPI Filter_GetAveragingFactor(int* averagingFactor);

        //unsigned int WINAPI PostProcessNoiseFilter(at_32* pInputImage, at_32* pOutputImage, int iOutputBufferSize, int iBaseline, int iMode, float fThreshold, int iHeight, int iWidth);
        //unsigned int WINAPI PostProcessCountConvert(at_32* pInputImage, at_32* pOutputImage, int iOutputBufferSize, int iNumImages, int iBaseline, int iMode, int iEmGain, float fQE, float fSensitivity, int iHeight, int iWidth);
        //unsigned int WINAPI PostProcessPhotonCounting(at_32* pInputImage, at_32* pOutputImage, int iOutputBufferSize, int iNumImages, int iNumframes, int iNumberOfThresholds, float* pfThreshold, int iHeight, int iWidth);
        //unsigned int WINAPI PostProcessDataAveraging(at_32* pInputImage, at_32* pOutputImage, int iOutputBufferSize, int iNumImages, int iAveragingFilterMode, int iHeight, int iWidth, int iFrameCount, int iAveragingFactor);

    }
}
