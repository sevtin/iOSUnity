//
//  ASXRouteManager.m
//  UnityBridge
//
//  Created by saeipi on 2019/12/11.
//  Copyright © 2019 saeipi. All rights reserved.
//

#import "ASXRouteManager.h"
#import "ASXBridgeController.h"
#import "UnityAppController.h"

@implementation ASXRouteManager

+ (void)enterBridgeController {
    ASXBridgeController *ctrl       = [[ASXBridgeController alloc] init];
    UINavigationController *navCtrl = [[UINavigationController alloc] initWithRootViewController:ctrl];
    //UnityAppController:模拟Unity导出项目中的UnityAppController
    UnityAppController *target      = (UnityAppController*)[UIApplication sharedApplication].delegate;
    [target.rootViewController presentViewController:navCtrl animated:YES completion:nil];
}

+ (void)showDialog:(NSString *)title message:(NSString *)message {
    UIAlertView *alertView = [[UIAlertView alloc] initWithTitle:title message:message delegate:self cancelButtonTitle:@"取消" otherButtonTitles:@"确定", nil];
    [alertView show];
}

@end
