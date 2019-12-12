//
//  ASXRouteManager.h
//  UnityBridge
//
//  Created by saeipi on 2019/12/11.
//  Copyright © 2019 saeipi. All rights reserved.
//  负责iOS路由处理

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface ASXRouteManager : NSObject

+ (void)enterBridgeController;
+ (void)showAlertMessage:(NSDictionary *)message;

@end

