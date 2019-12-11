//
//  ASXBridgeManager.m
//  UnityBridge
//
//  Created by saeipi on 2019/12/11.
//  Copyright © 2019 saeipi. All rights reserved.
//

#import "ASXBridgeManager.h"
#import "ASXRouteManager.h"

@implementation ASXBridgeManager

extern "C" void _initializeBridge() {
    
}

extern "C" void _enterBridgeController() {
    [ASXRouteManager enterBridgeController];
}

extern "C" void _showDialog(const char *title, const char *msg) {
    [ASXRouteManager showDialog:[NSString stringWithUTF8String:title] message:[NSString stringWithUTF8String:msg]];
}

@end
