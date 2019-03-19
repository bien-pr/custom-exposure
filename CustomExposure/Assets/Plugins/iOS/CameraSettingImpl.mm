#import "CameraSettingImpl.h"

AVCaptureDevice *device;

extern "C" {

	void _initDevice()
	{
		NSArray *devices = [AVCaptureDevice devices];
   
        for (AVCaptureDevice *d in devices) {
            if (d.position == AVCaptureDevicePositionBack) {
                NSLog(@"init camera!");
                device = d;
            }
        }
	}

	void _AVCaptureExposureModeLocked()
	{
		if(device==nil)
		{
			_initDevice();
		}

        if([device lockForConfiguration:nil]) {
            NSLog(@"AVCaptureExposureModeLocked");
            [device setExposureMode:AVCaptureExposureModeLocked];
            [device unlockForConfiguration];
        }
	}

	void _AVCaptureExposureModeAutoExpose()
	{
		if(device==nil)
		{
			_initDevice();
		}
		
        if([device lockForConfiguration:nil]) {
            NSLog(@"AVCaptureExposureModeAutoExpose");
            [device setExposureMode:AVCaptureExposureModeAutoExpose];
            [device unlockForConfiguration];
        }
	}

	void _AVCaptureExposureModeContinuousAutoExposure()
	{
		if(device==nil)
		{
			_initDevice();
		}
		
        if([device lockForConfiguration:nil]) {
            NSLog(@"_AVCaptureExposureModeContinuousAutoExposure");
            [device setExposureMode:AVCaptureExposureModeContinuousAutoExposure];
            [device unlockForConfiguration];
        }
	}

	void _AVCaptureExposureModeCustom(float duration, float scale, float newISO)
	{
		if(device==nil)
		{
			_initDevice();
		}
        if([device lockForConfiguration:nil]) {
            try {
                NSLog(@"_AVCaptureExposureModeCustom - duration: %f , scale: %f , iso : %f", duration, scale, newISO);
                CMTime exposureDuration = CMTimeMakeWithSeconds(duration/scale, NSEC_PER_SEC);
                [device setExposureModeCustomWithDuration:exposureDuration ISO:newISO completionHandler:^(CMTime syncTime) {}];
            }
            catch (NSException *exception) {
                NSLog(@"%@", exception.reason);
            }
            
            [device unlockForConfiguration];
        }
	}
}
