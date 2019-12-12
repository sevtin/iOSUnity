//
//  ASXBridgeController.m
//  UnityBridge
//
//  Created by saeipi on 2019/12/11.
//  Copyright © 2019 saeipi. All rights reserved.
//

#import "ASXBridgeController.h"
#import "ASXMessageHandler.h"

@interface ASXBridgeController ()

@end

@implementation ASXBridgeController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.view.backgroundColor = [UIColor whiteColor];
    self.title                = @"ASXBridgeController";

    UIButton *backUnityBtn    = [UIButton buttonWithType:UIButtonTypeCustom];
    backUnityBtn.frame        = CGRectMake(0, 0, 120, 40);
    backUnityBtn.center       = self.view.center;
    [self.view addSubview:backUnityBtn];
    [backUnityBtn setTitle:@"返回 Unity" forState:UIControlStateNormal];
    [backUnityBtn setBackgroundColor:[UIColor lightGrayColor]];
    [backUnityBtn addTarget:self action:@selector(onBackUnityClick) forControlEvents:UIControlEventTouchUpInside];
}

- (void)onBackUnityClick {
    NSMutableDictionary *dict = [NSMutableDictionary dictionary];
    dict[@"name"]             = @"saeipi";
    dict[@"age"]              = @(24);
    dict[@"desc"]             = @"saeipi is a good boy";
    
    [ASXMessageHandler sendMessageToObj:@"ASXBridgePanel" method:@"iOSCallback" message:dict];
    [self dismissViewControllerAnimated:true completion:nil];
}

@end
