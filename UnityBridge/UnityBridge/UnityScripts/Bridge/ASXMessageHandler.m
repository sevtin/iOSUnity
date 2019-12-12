//
//  ASXMessageHandler.m
//  UnityBridge
//
//  Created by saeipi on 2019/12/12.
//  Copyright © 2019 saeipi. All rights reserved.
//

#import "ASXMessageHandler.h"
#import "ASXConst.h"
#import "ASXRouteManager.h"
//模拟UnitySendMessage
#include "UnityInterface.h"

@implementation ASXMessageHandler

+ (void)dialogWithSubType:(int)subType msg:(NSDictionary *)msg {
    switch (subType) {
        case Uniquely_Identified_Type_Dialog_Nomarl:
            [ASXRouteManager showAlertMessage:msg];
            break;
            
        default:
            break;
    }
}

+ (void)enterCtrlWithSubType:(int)subType msg:(NSDictionary *)msg {
    switch (subType) {
        case Uniquely_Identified_Type_EnterCtrl_Bridge:
            [ASXRouteManager enterBridgeController];
            break;
            
        default:
            break;
    }
}

+ (void)sendMessageToObj:(NSString* )obj method:(NSString* )method message:(NSMutableDictionary *)message {
    UnitySendMessage([obj UTF8String], [method UTF8String], [[ASXMessageHandler stringWithJSONObject:message] UTF8String]);
}

+ (NSString*)stringWithJSONObject:(NSDictionary *)dict {
    NSError *parseError = nil;
    NSData *jsonData    = [NSJSONSerialization dataWithJSONObject:dict options:NSJSONWritingPrettyPrinted error:&parseError];
    return [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
}

+ (NSDictionary *)dictionaryWithJsonString:(NSString *)jsonString {
    if (jsonString == nil) {
        return nil;
    }
    NSData *jsonData   = [jsonString dataUsingEncoding:NSUTF8StringEncoding];
    NSError *error;
    NSDictionary *dict = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingMutableContainers error:&error];
    if(error) {
        return nil;
    }
    return dict;
}

@end
