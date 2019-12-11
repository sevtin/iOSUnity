//
//  ASXBridgeController.m
//  UnityBridge
//
//  Created by saeipi on 2019/12/11.
//  Copyright © 2019 saeipi. All rights reserved.
//

#import "ASXBridgeController.h"
//模拟UnitySendMessage
#include "UnityInterface.h"

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
    UnitySendMessage("ASXBridgePanel", "iOSCallback", "{\"name\":\"Jack\",\"icon\":\"lufy.png\"}");
    [self dismissViewControllerAnimated:true completion:nil];
}

@end
