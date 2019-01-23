//
//  ViewController.m
//  Example
//
//  Created by Dragon on 2019/1/15.
//  Copyright © 2019 YinCheng. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  // Do any additional setup after loading the view, typically from a nib.
  
  UIView *view = [[UIView alloc] initWithFrame:CGRectMake(100, 100, 100, 100)];
  view.backgroundColor = [UIColor yellowColor];
  
  [self.view addSubview:view];
}


@end
