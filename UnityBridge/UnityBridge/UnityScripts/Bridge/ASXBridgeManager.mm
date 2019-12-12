//
//  ASXBridgeManager.m
//  UnityBridge
//
//  Created by saeipi on 2019/12/11.
//  Copyright © 2019 saeipi. All rights reserved.
//

#import "ASXBridgeManager.h"
#import "ASXConst.h"
#import "ASXMessageHandler.h"

@implementation ASXBridgeManager

extern "C" void _iOSSendMessage(int type, int subType,const char *msg) {
    NSDictionary *dictionary;
    if (msg != NULL) {
        dictionary = [ASXMessageHandler dictionaryWithJsonString:[NSString stringWithUTF8String:msg]];
    }
    switch (type) {
        case Uniquely_Identified_Type_Dialog:
            [ASXMessageHandler dialogWithSubType:subType msg:dictionary];
            break;
        case Uniquely_Identified_Type_EnterCtrl:
            [ASXMessageHandler enterCtrlWithSubType:subType msg:dictionary];
        break;
        default:
            break;
    }
}

@end
