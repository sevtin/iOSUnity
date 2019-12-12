//
//  ASXMessageHandler.h
//  UnityBridge
//
//  Created by saeipi on 2019/12/12.
//  Copyright © 2019 saeipi. All rights reserved.
//  负责消息处理

#import <Foundation/Foundation.h>

@interface ASXMessageHandler : NSObject

+ (void)dialogWithSubType:(int)subType msg:(NSDictionary *)msg;
+ (void)enterCtrlWithSubType:(int)subType msg:(NSDictionary *)msg;

/// 发送消息给Unity
/// @param obj unity中的一个gameobject名称
/// @param method gameobject身上捆绑的脚本中的方法
/// @param message 发送的数据
+ (void)sendMessageToObj:(NSString* )obj method:(NSString* )method message:(NSMutableDictionary *)message;
+ (NSDictionary *)dictionaryWithJsonString:(NSString *)jsonString;
@end

