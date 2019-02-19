using System;
using AVFoundation;
using CoreGraphics;
using CoreLocation;
using Hyphenate.iOS.Lib;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Hyphenate.iOS.UI
{
    // @interface EMAudioPlayerUtil : NSObject
    [BaseType (typeof(NSObject))]
	interface EMAudioPlayerUtil
	{
        // +(BOOL)isPlaying;
        [Static]
        [Export("isPlaying")]
        //[Verify (MethodToProperty)]
        bool IsPlaying ();

		// +(NSString *)playingFilePath;
		[Static]
		[Export ("playingFilePath")]
		//[Verify (MethodToProperty)]
		string PlayingFilePath ();

		// +(void)asyncPlayingWithPath:(NSString *)aFilePath completion:(void (^)(NSError *))completon;
		[Static]
		[Export ("asyncPlayingWithPath:completion:")]
		void AsyncPlayingWithPath_completion (string aFilePath, [NullAllowed] Action<NSError> completon);

		// +(void)stopCurrentPlaying;
		[Static]
		[Export ("stopCurrentPlaying")]
		void StopCurrentPlaying ();
	}

	// @interface EMAudioRecorderUtil : NSObject
	[BaseType (typeof(NSObject))]
	interface EMAudioRecorderUtil
	{
		// +(BOOL)isRecording;
		[Static]
		[Export ("isRecording")]
		//[Verify (MethodToProperty)]
		bool IsRecording ();

		// +(void)asyncStartRecordingWithPreparePath:(NSString *)aFilePath completion:(void (^)(NSError *))completion;
		[Static]
		[Export ("asyncStartRecordingWithPreparePath:completion:")]
		void AsyncStartRecordingWithPreparePath (string aFilePath, [NullAllowed] Action<NSError> completion);

		// +(void)asyncStopRecordingWithCompletion:(void (^)(NSString *))completion;
		[Static]
		[Export ("asyncStopRecordingWithCompletion:")]
		void AsyncStopRecordingWithCompletion ([NullAllowed] Action<NSString> completion);

		// +(void)cancelCurrentRecording;
		[Static]
		[Export ("cancelCurrentRecording")]
		void CancelCurrentRecording ();

		// +(AVAudioRecorder *)recorder;
		[Static]
		[Export ("recorder")]
		//[Verify (MethodToProperty)]
		AVAudioRecorder Recorder ();
	}

    partial interface IEMCDDeviceManagerProximitySensorDelegate {}

	// @protocol EMCDDeviceManagerProximitySensorDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMCDDeviceManagerProximitySensorDelegate
	{
		// @required -(void)proximitySensorChanged:(BOOL)isCloseToUser;
		[Abstract]
		[Export ("proximitySensorChanged:")]
		void ProximitySensorChanged (bool isCloseToUser);
	}

    partial interface IEMCDDeviceManagerDelegate {}

	// @protocol EMCDDeviceManagerDelegate <EMCDDeviceManagerProximitySensorDelegate>
	[Protocol, Model]
    [BaseType (typeof(NSObject))]
	interface EMCDDeviceManagerDelegate : EMCDDeviceManagerProximitySensorDelegate
	{
	}

    // @interface EMCDDeviceManager : NSObject
	[BaseType (typeof(NSObject))]
	interface EMCDDeviceManager
	{
		[Wrap ("WeakDelegate")]
		EMCDDeviceManagerDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<EMCDDeviceManagerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// +(EMCDDeviceManager *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		//[Verify (MethodToProperty)]
		EMCDDeviceManager SharedInstance { get; }
	}

    // @interface Media (EMCDDeviceManager)
	[Category]
	[BaseType (typeof(EMCDDeviceManager))]
	interface EMCDDeviceManager_Media
	{
		// -(void)asyncPlayingWithPath:(NSString *)aFilePath completion:(void (^)(NSError *))completon;
		[Export ("asyncPlayingWithPath:completion:")]
		void AsyncPlayingWithPath (string aFilePath, [NullAllowed] Action<NSError> completon);

		// -(void)stopPlaying;
		[Export ("stopPlaying")]
		void StopPlaying ();

		// -(void)stopPlayingWithChangeCategory:(BOOL)isChange;
		[Export ("stopPlayingWithChangeCategory:")]
		void StopPlayingWithChangeCategory (bool isChange);

		// -(BOOL)isPlaying;
		[Export ("isPlaying")]
		//[Verify (MethodToProperty)]
		bool IsPlaying ();

		// -(void)asyncStartRecordingWithFileName:(NSString *)fileName completion:(void (^)(NSError *))completion;
		[Export ("asyncStartRecordingWithFileName:completion:")]
		void AsyncStartRecordingWithFileName (string fileName, [NullAllowed] Action<NSError> completion);

		// -(void)asyncStopRecordingWithCompletion:(void (^)(NSString *, NSInteger, NSError *))completion;
		[Export ("asyncStopRecordingWithCompletion:")]
		void AsyncStopRecordingWithCompletion ([NullAllowed] Action<NSString, nint, NSError> completion);

		// -(void)cancelCurrentRecording;
		[Export ("cancelCurrentRecording")]
		void CancelCurrentRecording ();

		// -(BOOL)isRecording;
		[Export ("isRecording")]
		//[Verify (MethodToProperty)]
		bool IsRecording ();

		// +(NSString *)dataPath;
		[Static]
		[Export ("dataPath")]
		//[Verify (MethodToProperty)]
		string DataPath { get; }
	}

    // @interface Remind (EMCDDeviceManager)
	[Category]
	[BaseType (typeof(EMCDDeviceManager))]
	interface EMCDDeviceManager_Remind
	{
		// -(SystemSoundID)playNewMessageSound;
		[Export ("playNewMessageSound")]
		//[Verify (MethodToProperty)]
		uint PlayNewMessageSound ();

		// -(void)playVibration;
		[Export ("playVibration")]
		void PlayVibration ();
	}

    // @interface ProximitySensor (EMCDDeviceManager)
	[Category]
	[BaseType (typeof(EMCDDeviceManager))]
	interface EMCDDeviceManager_ProximitySensor
	{
		// @property (readonly, nonatomic) BOOL isSupportProximitySensor;
		[Export ("isSupportProximitySensor")]
		bool IsSupportProximitySensor ();

		// @property (readonly, nonatomic) BOOL isCloseToUser;
		[Export ("isCloseToUser")]
		bool IsCloseToUser ();

		// @property (readonly, nonatomic) BOOL isProximitySensorEnabled;
		[Export ("isProximitySensorEnabled")]
		bool IsProximitySensorEnabled ();

		// -(BOOL)enableProximitySensor;
		[Export ("enableProximitySensor")]
		//[Verify (MethodToProperty)]
		bool EnableProximitySensor ();

		// -(BOOL)disableProximitySensor;
		[Export ("disableProximitySensor")]
		//[Verify (MethodToProperty)]
		bool DisableProximitySensor ();

		// -(void)sensorStateChanged:(NSNotification *)notification;
		[Export ("sensorStateChanged:")]
		void SensorStateChanged ([NullAllowed] NSNotification notification);
	}

    // @interface Microphone (EMCDDeviceManager)
	[Category]
	[BaseType (typeof(EMCDDeviceManager))]
	interface EMCDDeviceManager_Microphone
	{
		// -(BOOL)emCheckMicrophoneAvailability;
		[Export ("emCheckMicrophoneAvailability")]
		//[Verify (MethodToProperty)]
		bool EmCheckMicrophoneAvailability ();

		// -(double)emPeekRecorderVoiceMeter;
		[Export ("emPeekRecorderVoiceMeter")]
		//[Verify (MethodToProperty)]
		double EmPeekRecorderVoiceMeter ();
	}

	// @interface EMVoiceConverter : NSObject
	[BaseType (typeof(NSObject))]
	interface EMVoiceConverter
	{
		// +(int)isMP3File:(NSString *)filePath;
		[Static]
		[Export ("isMP3File:")]
		int IsMP3File (string filePath);

		// +(int)isAMRFile:(NSString *)filePath;
		[Static]
		[Export ("isAMRFile:")]
		int IsAMRFile (string filePath);

		// +(int)amrToWav:(NSString *)_amrPath wavSavePath:(NSString *)_savePath;
		[Static]
		[Export ("amrToWav:wavSavePath:")]
		int AmrToWav (string _amrPath, string _savePath);

		// +(int)wavToAmr:(NSString *)_wavPath amrSavePath:(NSString *)_savePath;
		[Static]
		[Export ("wavToAmr:amrSavePath:")]
		int WavToAmr (string _wavPath, string _savePath);
	}

    partial interface IIModelCell {}

	// @protocol IModelCell <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IModelCell
	{
		// @required @property (nonatomic, strong) id model;
		//[Abstract]
		[Export ("model", ArgumentSemantic.Strong)]
		NSObject Model { get; set; }

		// @required +(NSString *)cellIdentifierWithModel:(id)model;
		[Static]
		[Export ("cellIdentifierWithModel:")]
		string CellIdentifierWithModel ([NullAllowed] NSObject model);

		// @required +(CGFloat)cellHeightWithModel:(id)model;
		[Static]
		[Export ("cellHeightWithModel:")]
		nfloat CellHeightWithModel ([NullAllowed] NSObject model);

		// @optional -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier model:(id)model;
		[Export ("initWithStyle:reuseIdentifier:model:")]
		IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier, [NullAllowed] NSObject model);
	}

    partial interface IIModelChatCell {}

	// @protocol IModelChatCell <NSObject, IModelCell>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IModelChatCell : IModelCell
	{
		// @required @property (nonatomic, strong) id model;
		// [Abstract]
		[Export ("model", ArgumentSemantic.Strong)]
		new NSObject Model { get; set; }

		// @optional -(BOOL)isCustomBubbleView:(id)model;
		[Export ("isCustomBubbleView:")]
		bool IsCustomBubbleView (NSObject model);

		// @optional -(void)setCustomBubbleView:(id)model;
		[Export ("setCustomBubbleView:")]
		void SetCustomBubbleView ([NullAllowed] NSObject model);

		// @optional -(void)setCustomModel:(id)model;
		[Export ("setCustomModel:")]
		void SetCustomModel ([NullAllowed] NSObject model);

		// @optional -(void)updateCustomBubbleViewMargin:(UIEdgeInsets)bubbleMargin model:(id)mode;
		[Export ("updateCustomBubbleViewMargin:model:")]
		void UpdateCustomBubbleViewMargin (UIEdgeInsets bubbleMargin, [NullAllowed] NSObject mode);

		// @optional -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier model:(id)model;
		[Export ("initWithStyle:reuseIdentifier:model:")]
        new IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier, [NullAllowed] NSObject model);
	}

    partial interface IIMessageModel {}

    // @protocol IMessageModel <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IMessageModel
	{
		// @required @property (nonatomic) CGFloat cellHeight;
		[Abstract]
		[Export ("cellHeight")]
		nfloat CellHeight { get; set; }

		// @required @property (readonly, nonatomic, strong) EMMessage * message;
		[Abstract]
		[Export ("message", ArgumentSemantic.Strong)]
		EMMessage Message { get; }

		// @required @property (readonly, nonatomic, strong) NSString * messageId;
		[Abstract]
		[Export ("messageId", ArgumentSemantic.Strong)]
		string MessageId { get; }

		// @required @property (readonly, nonatomic) int messageStatus;
		[Abstract]
		[Export ("messageStatus")]
		int MessageStatus { get; }

		// @required @property (readonly, nonatomic) int bodyType;
		[Abstract]
		[Export ("bodyType")]
		int BodyType { get; }

		// @required @property (nonatomic) BOOL isMessageRead;
		[Abstract]
		[Export ("isMessageRead")]
		bool IsMessageRead { get; set; }

		// @required @property (nonatomic) BOOL isSender;
		[Abstract]
		[Export ("isSender")]
		bool IsSender { get; set; }

		// @required @property (nonatomic, strong) NSString * nickname;
		[Abstract]
		[Export ("nickname", ArgumentSemantic.Strong)]
		string Nickname { get; set; }

		// @required @property (nonatomic, strong) NSString * avatarURLPath;
		[Abstract]
		[Export ("avatarURLPath", ArgumentSemantic.Strong)]
		string AvatarURLPath { get; set; }

		// @required @property (nonatomic, strong) UIImage * avatarImage;
		[Abstract]
		[Export ("avatarImage", ArgumentSemantic.Strong)]
		UIImage AvatarImage { get; set; }

		// @required @property (nonatomic, strong) NSString * text;
		[Abstract]
		[Export ("text", ArgumentSemantic.Strong)]
		string Text { get; set; }

		// @required @property (nonatomic, strong) NSAttributedString * attrBody;
		[Abstract]
		[Export ("attrBody", ArgumentSemantic.Strong)]
		NSAttributedString AttrBody { get; set; }

		// @required @property (nonatomic, strong) NSString * failImageName;
		[Abstract]
		[Export ("failImageName", ArgumentSemantic.Strong)]
		string FailImageName { get; set; }

		// @required @property (nonatomic) CGSize imageSize;
		[Abstract]
		[Export ("imageSize", ArgumentSemantic.Assign)]
		CGSize ImageSize { get; set; }

		// @required @property (nonatomic) CGSize thumbnailImageSize;
		[Abstract]
		[Export ("thumbnailImageSize", ArgumentSemantic.Assign)]
		CGSize ThumbnailImageSize { get; set; }

		// @required @property (nonatomic, strong) UIImage * image;
		[Abstract]
		[Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; set; }

		// @required @property (nonatomic, strong) UIImage * thumbnailImage;
		[Abstract]
		[Export ("thumbnailImage", ArgumentSemantic.Strong)]
		UIImage ThumbnailImage { get; set; }

		// @required @property (nonatomic, strong) NSString * address;
		[Abstract]
		[Export ("address", ArgumentSemantic.Strong)]
		string Address { get; set; }

		// @required @property (nonatomic) double latitude;
		[Abstract]
		[Export ("latitude")]
		double Latitude { get; set; }

		// @required @property (nonatomic) double longitude;
		[Abstract]
		[Export ("longitude")]
		double Longitude { get; set; }

		// @required @property (nonatomic) BOOL isMediaPlaying;
		[Abstract]
		[Export ("isMediaPlaying")]
		bool IsMediaPlaying { get; set; }

		// @required @property (nonatomic) BOOL isMediaPlayed;
		[Abstract]
		[Export ("isMediaPlayed")]
		bool IsMediaPlayed { get; set; }

		// @required @property (nonatomic) CGFloat mediaDuration;
		[Abstract]
		[Export ("mediaDuration")]
		nfloat MediaDuration { get; set; }

		// @required @property (nonatomic, strong) NSString * fileIconName;
		[Abstract]
		[Export ("fileIconName", ArgumentSemantic.Strong)]
		string FileIconName { get; set; }

		// @required @property (nonatomic, strong) NSString * fileName;
		[Abstract]
		[Export ("fileName", ArgumentSemantic.Strong)]
		string FileName { get; set; }

		// @required @property (nonatomic, strong) NSString * fileSizeDes;
		[Abstract]
		[Export ("fileSizeDes", ArgumentSemantic.Strong)]
		string FileSizeDes { get; set; }

		// @required @property (nonatomic) float progress;
		[Abstract]
		[Export ("progress")]
		float Progress { get; set; }

		// @required @property (readonly, nonatomic, strong) NSString * fileLocalPath;
		[Abstract]
		[Export ("fileLocalPath", ArgumentSemantic.Strong)]
		string FileLocalPath { get; }

		// @required @property (nonatomic, strong) NSString * thumbnailFileLocalPath;
		[Abstract]
		[Export ("thumbnailFileLocalPath", ArgumentSemantic.Strong)]
		string ThumbnailFileLocalPath { get; set; }

		// @required @property (nonatomic, strong) NSString * fileURLPath;
		[Abstract]
		[Export ("fileURLPath", ArgumentSemantic.Strong)]
		string FileURLPath { get; set; }

		// @required @property (nonatomic, strong) NSString * thumbnailFileURLPath;
		[Abstract]
		[Export ("thumbnailFileURLPath", ArgumentSemantic.Strong)]
		string ThumbnailFileURLPath { get; set; }

		// @required @property (nonatomic) BOOL isDing;
		[Abstract]
		[Export ("isDing")]
		bool IsDing { get; set; }

		// @required @property (nonatomic) NSInteger dingReadCount;
		[Abstract]
		[Export ("dingReadCount")]
		nint DingReadCount { get; set; }

		// @required -(instancetype)initWithMessage:(EMMessage *)message;
		// [Abstract]
		[Export ("initWithMessage:")]
		IntPtr Constructor ([NullAllowed] EMMessage message);
	}

	[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const CGFloat EaseMessageCellPadding;
		[Field ("EaseMessageCellPadding", "__Internal")]
		nfloat EaseMessageCellPadding { get; }

		// extern NSString *const EaseMessageCellIdentifierSendText;
		[Field ("EaseMessageCellIdentifierSendText", "__Internal")]
		NSString EaseMessageCellIdentifierSendText { get; }

		// extern NSString *const EaseMessageCellIdentifierSendLocation;
		[Field ("EaseMessageCellIdentifierSendLocation", "__Internal")]
		NSString EaseMessageCellIdentifierSendLocation { get; }

		// extern NSString *const EaseMessageCellIdentifierSendVoice;
		[Field ("EaseMessageCellIdentifierSendVoice", "__Internal")]
		NSString EaseMessageCellIdentifierSendVoice { get; }

		// extern NSString *const EaseMessageCellIdentifierSendVideo;
		[Field ("EaseMessageCellIdentifierSendVideo", "__Internal")]
		NSString EaseMessageCellIdentifierSendVideo { get; }

		// extern NSString *const EaseMessageCellIdentifierSendImage;
		[Field ("EaseMessageCellIdentifierSendImage", "__Internal")]
		NSString EaseMessageCellIdentifierSendImage { get; }

		// extern NSString *const EaseMessageCellIdentifierSendFile;
		[Field ("EaseMessageCellIdentifierSendFile", "__Internal")]
		NSString EaseMessageCellIdentifierSendFile { get; }

		// extern NSString *const EaseMessageCellIdentifierRecvText;
		[Field ("EaseMessageCellIdentifierRecvText", "__Internal")]
		NSString EaseMessageCellIdentifierRecvText { get; }

		// extern NSString *const EaseMessageCellIdentifierRecvLocation;
		[Field ("EaseMessageCellIdentifierRecvLocation", "__Internal")]
		NSString EaseMessageCellIdentifierRecvLocation { get; }

		// extern NSString *const EaseMessageCellIdentifierRecvVoice;
		[Field ("EaseMessageCellIdentifierRecvVoice", "__Internal")]
		NSString EaseMessageCellIdentifierRecvVoice { get; }

		// extern NSString *const EaseMessageCellIdentifierRecvVideo;
		[Field ("EaseMessageCellIdentifierRecvVideo", "__Internal")]
		NSString EaseMessageCellIdentifierRecvVideo { get; }

		// extern NSString *const EaseMessageCellIdentifierRecvImage;
		[Field ("EaseMessageCellIdentifierRecvImage", "__Internal")]
		NSString EaseMessageCellIdentifierRecvImage { get; }

		// extern NSString *const EaseMessageCellIdentifierRecvFile;
		[Field ("EaseMessageCellIdentifierRecvFile", "__Internal")]
		NSString EaseMessageCellIdentifierRecvFile { get; }
	}

    // @interface EaseBubbleView : UIView
	[BaseType (typeof(UIView))]
	interface EaseBubbleView
	{
		// @property (nonatomic) BOOL isSender;
		[Export ("isSender")]
		bool IsSender { get; set; }

		// @property (readonly, nonatomic) UIEdgeInsets margin;
		[Export ("margin")]
		UIEdgeInsets Margin { get; }

		// @property (nonatomic, strong) NSMutableArray * marginConstraints;
		[Export ("marginConstraints", ArgumentSemantic.Strong)]
		NSMutableArray MarginConstraints { get; set; }

		// @property (nonatomic, strong) UIImageView * backgroundImageView;
		[Export ("backgroundImageView", ArgumentSemantic.Strong)]
		UIImageView BackgroundImageView { get; set; }

		// @property (nonatomic, strong) UILabel * textLabel;
		[Export ("textLabel", ArgumentSemantic.Strong)]
		UILabel TextLabel { get; set; }

		// @property (nonatomic, strong) UIImageView * imageView;
		[Export ("imageView", ArgumentSemantic.Strong)]
		UIImageView ImageView { get; set; }

		// @property (nonatomic, strong) UIImageView * locationImageView;
		[Export ("locationImageView", ArgumentSemantic.Strong)]
		UIImageView LocationImageView { get; set; }

		// @property (nonatomic, strong) UILabel * locationLabel;
		[Export ("locationLabel", ArgumentSemantic.Strong)]
		UILabel LocationLabel { get; set; }

		// @property (nonatomic, strong) UIImageView * voiceImageView;
		[Export ("voiceImageView", ArgumentSemantic.Strong)]
		UIImageView VoiceImageView { get; set; }

		// @property (nonatomic, strong) UILabel * voiceDurationLabel;
		[Export ("voiceDurationLabel", ArgumentSemantic.Strong)]
		UILabel VoiceDurationLabel { get; set; }

		// @property (nonatomic, strong) UIImageView * isReadView;
		[Export ("isReadView", ArgumentSemantic.Strong)]
		UIImageView IsReadView { get; set; }

		// @property (nonatomic, strong) UIImageView * videoImageView;
		[Export ("videoImageView", ArgumentSemantic.Strong)]
		UIImageView VideoImageView { get; set; }

		// @property (nonatomic, strong) UIImageView * videoTagView;
		[Export ("videoTagView", ArgumentSemantic.Strong)]
		UIImageView VideoTagView { get; set; }

		// @property (nonatomic, strong) UIImageView * fileIconView;
		[Export ("fileIconView", ArgumentSemantic.Strong)]
		UIImageView FileIconView { get; set; }

		// @property (nonatomic, strong) UILabel * fileNameLabel;
		[Export ("fileNameLabel", ArgumentSemantic.Strong)]
		UILabel FileNameLabel { get; set; }

		// @property (nonatomic, strong) UILabel * fileSizeLabel;
		[Export ("fileSizeLabel", ArgumentSemantic.Strong)]
		UILabel FileSizeLabel { get; set; }

		// -(instancetype)initWithMargin:(UIEdgeInsets)margin isSender:(BOOL)isSender;
		[Export ("initWithMargin:isSender:")]
		IntPtr Constructor (UIEdgeInsets margin, bool isSender);
	}

	// [Static]
	//[Verify (ConstantsInterfaceAssociation)]
	// partial interface Constants
	// {
	// 	// extern const CGFloat EaseMessageCellPadding;
	// 	[Field ("EaseMessageCellPadding", "__Internal")]
	// 	nfloat EaseMessageCellPadding { get; }
	// }

    // @interface EaseMessageCell : UITableViewCell <IModelChatCell>
	[BaseType (typeof(UITableViewCell))]
	interface EaseMessageCell : IModelChatCell
	{
		[Wrap ("WeakDelegate")]
		EaseMessageCellDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<EaseMessageCellDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) UIActivityIndicatorView * activity;
		[Export ("activity", ArgumentSemantic.Strong)]
		UIActivityIndicatorView Activity { get; set; }

		// @property (nonatomic, strong) UIImageView * avatarView;
		[Export ("avatarView", ArgumentSemantic.Strong)]
		UIImageView AvatarView { get; set; }

		// @property (nonatomic, strong) UILabel * nameLabel;
		[Export ("nameLabel", ArgumentSemantic.Strong)]
		UILabel NameLabel { get; set; }

		// @property (nonatomic, strong) UIButton * statusButton;
		[Export ("statusButton", ArgumentSemantic.Strong)]
		UIButton StatusButton { get; set; }

		// @property (nonatomic, strong) UILabel * hasRead;
		[Export ("hasRead", ArgumentSemantic.Strong)]
		UILabel HasRead { get; set; }

		// @property (nonatomic, strong) EaseBubbleView * bubbleView;
		[Export ("bubbleView", ArgumentSemantic.Strong)]
		EaseBubbleView BubbleView { get; set; }

		// @property (nonatomic, strong) id<IMessageModel> model;
		[Export ("model", ArgumentSemantic.Strong)]
		new IIMessageModel Model { get; set; }

		// @property (nonatomic) CGFloat statusSize __attribute__((annotate("ui_appearance_selector")));
		[Export ("statusSize")]
		nfloat StatusSize { get; set; }

		// @property (nonatomic) CGFloat activitySize __attribute__((annotate("ui_appearance_selector")));
		[Export ("activitySize")]
		nfloat ActivitySize { get; set; }

		// @property (nonatomic) CGFloat bubbleMaxWidth __attribute__((annotate("ui_appearance_selector")));
		[Export ("bubbleMaxWidth")]
		nfloat BubbleMaxWidth { get; set; }

		// @property (nonatomic) UIEdgeInsets bubbleMargin __attribute__((annotate("ui_appearance_selector")));
		[Export ("bubbleMargin", ArgumentSemantic.Assign)]
		UIEdgeInsets BubbleMargin { get; set; }

		// @property (nonatomic) UIEdgeInsets leftBubbleMargin __attribute__((annotate("ui_appearance_selector")));
		[Export ("leftBubbleMargin", ArgumentSemantic.Assign)]
		UIEdgeInsets LeftBubbleMargin { get; set; }

		// @property (nonatomic) UIEdgeInsets rightBubbleMargin __attribute__((annotate("ui_appearance_selector")));
		[Export ("rightBubbleMargin", ArgumentSemantic.Assign)]
		UIEdgeInsets RightBubbleMargin { get; set; }

		// @property (nonatomic, strong) UIImage * sendBubbleBackgroundImage __attribute__((annotate("ui_appearance_selector")));
		[Export ("sendBubbleBackgroundImage", ArgumentSemantic.Strong)]
		UIImage SendBubbleBackgroundImage { get; set; }

		// @property (nonatomic, strong) UIImage * recvBubbleBackgroundImage __attribute__((annotate("ui_appearance_selector")));
		[Export ("recvBubbleBackgroundImage", ArgumentSemantic.Strong)]
		UIImage RecvBubbleBackgroundImage { get; set; }

		// @property (nonatomic) UIFont * messageTextFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageTextFont", ArgumentSemantic.Assign)]
		UIFont MessageTextFont { get; set; }

		// @property (nonatomic) UIColor * messageTextColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageTextColor", ArgumentSemantic.Assign)]
		UIColor MessageTextColor { get; set; }

		// @property (nonatomic) UIFont * messageLocationFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageLocationFont", ArgumentSemantic.Assign)]
		UIFont MessageLocationFont { get; set; }

		// @property (nonatomic) UIColor * messageLocationColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageLocationColor", ArgumentSemantic.Assign)]
		UIColor MessageLocationColor { get; set; }

		// @property (nonatomic) NSArray * sendMessageVoiceAnimationImages __attribute__((annotate("ui_appearance_selector")));
		[Export ("sendMessageVoiceAnimationImages", ArgumentSemantic.Assign)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] SendMessageVoiceAnimationImages { get; set; }

		// @property (nonatomic) NSArray * recvMessageVoiceAnimationImages __attribute__((annotate("ui_appearance_selector")));
		[Export ("recvMessageVoiceAnimationImages", ArgumentSemantic.Assign)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] RecvMessageVoiceAnimationImages { get; set; }

		// @property (nonatomic) UIColor * messageVoiceDurationColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageVoiceDurationColor", ArgumentSemantic.Assign)]
		UIColor MessageVoiceDurationColor { get; set; }

		// @property (nonatomic) UIFont * messageVoiceDurationFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageVoiceDurationFont", ArgumentSemantic.Assign)]
		UIFont MessageVoiceDurationFont { get; set; }

		// @property (nonatomic) CGFloat voiceCellWidth __attribute__((annotate("ui_appearance_selector")));
		[Export ("voiceCellWidth")]
		nfloat VoiceCellWidth { get; set; }

		// @property (nonatomic) UIFont * messageFileNameFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageFileNameFont", ArgumentSemantic.Assign)]
		UIFont MessageFileNameFont { get; set; }

		// @property (nonatomic) UIColor * messageFileNameColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageFileNameColor", ArgumentSemantic.Assign)]
		UIColor MessageFileNameColor { get; set; }

		// @property (nonatomic) UIFont * messageFileSizeFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageFileSizeFont", ArgumentSemantic.Assign)]
		UIFont MessageFileSizeFont { get; set; }

		// @property (nonatomic) UIColor * messageFileSizeColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageFileSizeColor", ArgumentSemantic.Assign)]
		UIColor MessageFileSizeColor { get; set; }

		// -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier;
		[Export ("initWithStyle:reuseIdentifier:")]
		IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier);

        [Export ("initWithStyle:reuseIdentifier:model:")]
		new IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier, [NullAllowed] NSObject model);

		// +(NSString *)cellIdentifierWithModel:(id<IMessageModel>)model;
		[Static]
		[Export ("cellIdentifierWithModel:")]
		string CellIdentifierWithModel ([NullAllowed] IIMessageModel model);

		// +(CGFloat)cellHeightWithModel:(id<IMessageModel>)model;
		[Static]
		[Export ("cellHeightWithModel:")]
		nfloat CellHeightWithModel ([NullAllowed] IIMessageModel model);
	}

    partial interface IEaseMessageCellDelegate {}

	// @protocol EaseMessageCellDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EaseMessageCellDelegate
	{
		// @optional -(void)messageCellSelected:(id<IMessageModel>)model;
		[Export ("messageCellSelected:")]
		void MessageCellSelected (IIMessageModel model);

		// @optional -(void)statusButtonSelcted:(id<IMessageModel>)model withMessageCell:(EaseMessageCell *)messageCell;
		[Export ("statusButtonSelcted:withMessageCell:")]
		void StatusButtonSelcted (IIMessageModel model, EaseMessageCell messageCell);

		// @optional -(void)avatarViewSelcted:(id<IMessageModel>)model;
		[Export ("avatarViewSelcted:")]
		void AvatarViewSelcted (IIMessageModel model);
	}

	// [Static]
	//[Verify (ConstantsInterfaceAssociation)]
	// partial interface Constants
	// {
	// 	// extern NSString *const EaseMessageCellIdentifierSendText;
	// 	[Field ("EaseMessageCellIdentifierSendText", "__Internal")]
	// 	NSString EaseMessageCellIdentifierSendText { get; }
    //
	// 	// extern NSString *const EaseMessageCellIdentifierSendLocation;
	// 	[Field ("EaseMessageCellIdentifierSendLocation", "__Internal")]
	// 	NSString EaseMessageCellIdentifierSendLocation { get; }
    //
	// 	// extern NSString *const EaseMessageCellIdentifierSendVoice;
	// 	[Field ("EaseMessageCellIdentifierSendVoice", "__Internal")]
	// 	NSString EaseMessageCellIdentifierSendVoice { get; }
    //
	// 	// extern NSString *const EaseMessageCellIdentifierSendVideo;
	// 	[Field ("EaseMessageCellIdentifierSendVideo", "__Internal")]
	// 	NSString EaseMessageCellIdentifierSendVideo { get; }
    //
	// 	// extern NSString *const EaseMessageCellIdentifierSendImage;
	// 	[Field ("EaseMessageCellIdentifierSendImage", "__Internal")]
	// 	NSString EaseMessageCellIdentifierSendImage { get; }
    //
	// 	// extern NSString *const EaseMessageCellIdentifierSendFile;
	// 	[Field ("EaseMessageCellIdentifierSendFile", "__Internal")]
	// 	NSString EaseMessageCellIdentifierSendFile { get; }
	// }

    // @interface EaseBaseMessageCell : EaseMessageCell
	[BaseType (typeof(EaseMessageCell))]
	interface EaseBaseMessageCell
	{
		// @property (nonatomic) CGFloat avatarSize __attribute__((annotate("ui_appearance_selector")));
		[Export ("avatarSize")]
		nfloat AvatarSize { get; set; }

		// @property (nonatomic) CGFloat avatarCornerRadius __attribute__((annotate("ui_appearance_selector")));
		[Export ("avatarCornerRadius")]
		nfloat AvatarCornerRadius { get; set; }

		// @property (nonatomic) UIFont * messageNameFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageNameFont", ArgumentSemantic.Assign)]
		UIFont MessageNameFont { get; set; }

		// @property (nonatomic) UIColor * messageNameColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageNameColor", ArgumentSemantic.Assign)]
		UIColor MessageNameColor { get; set; }

		// @property (nonatomic) CGFloat messageNameHeight __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageNameHeight")]
		nfloat MessageNameHeight { get; set; }

		// @property (nonatomic) BOOL messageNameIsHidden __attribute__((annotate("ui_appearance_selector")));
		[Export ("messageNameIsHidden")]
		bool MessageNameIsHidden { get; set; }

        // -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier;
        [Export ("initWithStyle:reuseIdentifier:")]
        new IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier);

        // -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier model:(id)model;
        [Export ("initWithStyle:reuseIdentifier:model:")]
        new IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier, [NullAllowed] NSObject model);

	}

	// @interface File (EaseBubbleView)
	[Category]
	[BaseType (typeof(EaseBubbleView))]
	interface EaseBubbleView_File
	{
		// -(void)setupFileBubbleView;
		[Export ("setupFileBubbleView")]
		void SetupFileBubbleView ();

		// -(void)updateFileMargin:(UIEdgeInsets)margin;
		[Export ("updateFileMargin:")]
		void UpdateFileMargin (UIEdgeInsets margin);
	}

	// @interface Gif (EaseBubbleView)
	[Category]
	[BaseType (typeof(EaseBubbleView))]
	interface EaseBubbleView_Gif
	{
		// -(void)setupGifBubbleView;
		[Export ("setupGifBubbleView")]
		void SetupGifBubbleView ();

		// -(void)updateGifMargin:(UIEdgeInsets)margin;
		[Export ("updateGifMargin:")]
		void UpdateGifMargin (UIEdgeInsets margin);
	}

	// @interface Image (EaseBubbleView)
	[Category]
	[BaseType (typeof(EaseBubbleView))]
	interface EaseBubbleView_Image
	{
		// -(void)setupImageBubbleView;
		[Export ("setupImageBubbleView")]
		void SetupImageBubbleView ();

		// -(void)updateImageMargin:(UIEdgeInsets)margin;
		[Export ("updateImageMargin:")]
		void UpdateImageMargin (UIEdgeInsets margin);
	}

	// @interface Location (EaseBubbleView)
	[Category]
	[BaseType (typeof(EaseBubbleView))]
	interface EaseBubbleView_Location
	{
		// -(void)setupLocationBubbleView;
		[Export ("setupLocationBubbleView")]
		void SetupLocationBubbleView ();

		// -(void)updateLocationMargin:(UIEdgeInsets)margin;
		[Export ("updateLocationMargin:")]
		void UpdateLocationMargin (UIEdgeInsets margin);
	}

	// @interface Text (EaseBubbleView)
	[Category]
	[BaseType (typeof(EaseBubbleView))]
	interface EaseBubbleView_Text
	{
		// -(void)setupTextBubbleView;
		[Export ("setupTextBubbleView")]
		void SetupTextBubbleView ();

		// -(void)updateTextMargin:(UIEdgeInsets)margin;
		[Export ("updateTextMargin:")]
		void UpdateTextMargin (UIEdgeInsets margin);
	}

	// @interface Video (EaseBubbleView)
	[Category]
	[BaseType (typeof(EaseBubbleView))]
	interface EaseBubbleView_Video
	{
		// -(void)setupVideoBubbleView;
		[Export ("setupVideoBubbleView")]
		void SetupVideoBubbleView ();

		// -(void)updateVideoMargin:(UIEdgeInsets)margin;
		[Export ("updateVideoMargin:")]
		void UpdateVideoMargin (UIEdgeInsets margin);
	}

	// @interface Voice (EaseBubbleView)
	[Category]
	[BaseType (typeof(EaseBubbleView))]
	interface EaseBubbleView_Voice
	{
		// -(void)setupVoiceBubbleView;
		[Export ("setupVoiceBubbleView")]
		void SetupVoiceBubbleView ();

		// -(void)updateVoiceMargin:(UIEdgeInsets)margin;
		[Export ("updateVoiceMargin:")]
		void UpdateVoiceMargin (UIEdgeInsets margin);
	}

    // @interface EaseChatBarMoreView : UIView
	[BaseType (typeof(UIView))]
	interface EaseChatBarMoreView
	{
		[Wrap ("WeakDelegate")]
		EaseChatBarMoreViewDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<EaseChatBarMoreViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic) UIColor * moreViewBackgroundColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("moreViewBackgroundColor", ArgumentSemantic.Assign)]
		UIColor MoreViewBackgroundColor { get; set; }

		// -(instancetype)initWithFrame:(CGRect)frame type:(EMChatToolbarType)type;
		[Export ("initWithFrame:type:")]
		IntPtr Constructor (CGRect frame, EMChatToolbarType type);

		// -(void)insertItemWithImage:(UIImage *)image highlightedImage:(UIImage *)highLightedImage title:(NSString *)title;
		[Export ("insertItemWithImage:highlightedImage:title:")]
		void InsertItemWithImage (UIImage image, UIImage highLightedImage, string title);

		// -(void)updateItemWithImage:(UIImage *)image highlightedImage:(UIImage *)highLightedImage title:(NSString *)title atIndex:(NSInteger)index;
		[Export ("updateItemWithImage:highlightedImage:title:atIndex:")]
		void UpdateItemWithImage (UIImage image, UIImage highLightedImage, string title, nint index);

		// -(void)removeItematIndex:(NSInteger)index;
		[Export ("removeItematIndex:")]
		void RemoveItematIndex (nint index);
	}

    partial interface IEaseChatBarMoreViewDelegate {}

	// @protocol EaseChatBarMoreViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EaseChatBarMoreViewDelegate
	{
		// @optional -(void)moreViewTakePicAction:(EaseChatBarMoreView *)moreView;
		[Export ("moreViewTakePicAction:")]
		void MoreViewTakePicAction (EaseChatBarMoreView moreView);

		// @optional -(void)moreViewPhotoAction:(EaseChatBarMoreView *)moreView;
		[Export ("moreViewPhotoAction:")]
		void MoreViewPhotoAction (EaseChatBarMoreView moreView);

		// @optional -(void)moreViewLocationAction:(EaseChatBarMoreView *)moreView;
		[Export ("moreViewLocationAction:")]
		void MoreViewLocationAction (EaseChatBarMoreView moreView);

		// @optional -(void)moreViewAudioCallAction:(EaseChatBarMoreView *)moreView;
		[Export ("moreViewAudioCallAction:")]
		void MoreViewAudioCallAction (EaseChatBarMoreView moreView);

		// @optional -(void)moreViewVideoCallAction:(EaseChatBarMoreView *)moreView;
		[Export ("moreViewVideoCallAction:")]
		void MoreViewVideoCallAction (EaseChatBarMoreView moreView);

		// @optional -(void)moreViewCommunicationAction:(EaseChatBarMoreView *)moreView;
		[Export ("moreViewCommunicationAction:")]
		void MoreViewCommunicationAction (EaseChatBarMoreView moreView);

		// @optional -(void)moreViewLiveAction:(EaseChatBarMoreView *)moreView;
		[Export ("moreViewLiveAction:")]
		void MoreViewLiveAction (EaseChatBarMoreView moreView);

		// @optional -(void)moreView:(EaseChatBarMoreView *)moreView didItemInMoreViewAtIndex:(NSInteger)index;
		[Export ("moreView:didItemInMoreViewAtIndex:")]
		void MoreView (EaseChatBarMoreView moreView, nint index);
	}

    partial interface IEaseFacialViewDelegate {}

	// @protocol EaseFacialViewDelegate
	[Protocol, Model]
    [BaseType (typeof(NSObject))]
	interface EaseFacialViewDelegate
	{
		// @optional -(void)selectedFacialView:(NSString *)str;
		[Export ("selectedFacialView:")]
		void SelectedFacialView (string str);

		// @optional -(void)deleteSelected:(NSString *)str;
		[Export ("deleteSelected:")]
		void DeleteSelected (string str);

		// @optional -(void)sendFace;
		[Export ("sendFace")]
		void SendFace ();

		// @optional -(void)sendFace:(EaseEmotion *)emotion;
		[Export ("sendFace:")]
		void SendFace (EaseEmotion emotion);
	}

    // @interface EaseFacialView : UIView
	[BaseType (typeof(UIView))]
	interface EaseFacialView
	{
		[Wrap ("WeakDelegate")]
		IEaseFacialViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<EaseFacialViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSArray * faces;
		[Export ("faces", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Faces { get; }

		// -(void)loadFacialView:(NSArray *)emotionManagers size:(CGSize)size;
		[Export ("loadFacialView:size:")]
		//[Verify (StronglyTypedNSArray)]
		void LoadFacialView (NSObject[] emotionManagers, CGSize size);

		// -(void)loadFacialViewWithPage:(NSInteger)page;
		[Export ("loadFacialViewWithPage:")]
		void LoadFacialViewWithPage (nint page);
	}

    partial interface IEMFaceDelegate {}

	// @protocol EMFaceDelegate
	[Protocol, Model]
    [BaseType (typeof(NSObject))]
	interface EMFaceDelegate
	{
		// @required -(void)selectedFacialView:(NSString *)str isDelete:(BOOL)isDelete;
		[Abstract]
		[Export ("selectedFacialView:isDelete:")]
		void SelectedFacialView (string str, bool isDelete);

		// @required -(void)sendFace;
		[Abstract]
		[Export ("sendFace")]
		void SendFace ();

		// @required -(void)sendFaceWithEmotion:(EaseEmotion *)emotion;
		[Abstract]
		[Export ("sendFaceWithEmotion:")]
		void SendFaceWithEmotion (EaseEmotion emotion);
	}

    // @interface EaseFaceView : UIView <EaseFacialViewDelegate>
	[BaseType (typeof(UIView))]
	interface EaseFaceView : IEaseFacialViewDelegate
	{
		[Wrap ("WeakDelegate")]
		EMFaceDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<EMFaceDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(BOOL)stringIsFace:(NSString *)string;
		[Export ("stringIsFace:")]
		bool StringIsFace (string @string);

		// -(void)setEmotionManagers:(NSArray *)emotionManagers;
		[Export ("setEmotionManagers:")]
		//[Verify (StronglyTypedNSArray)]
		void SetEmotionManagers ([NullAllowed] NSObject[] emotionManagers);
	}

    // @interface EaseTextView : UITextView
	[BaseType (typeof(UITextView))]
	interface EaseTextView
	{
		// @property (copy, nonatomic) NSString * placeHolder;
		[Export ("placeHolder")]
		string PlaceHolder { get; set; }

		// @property (nonatomic, strong) UIColor * placeHolderTextColor;
		[Export ("placeHolderTextColor", ArgumentSemantic.Strong)]
		UIColor PlaceHolderTextColor { get; set; }

		// -(NSUInteger)numberOfLinesOfText;
		[Export ("numberOfLinesOfText")]
		//[Verify (MethodToProperty)]
		nuint NumberOfLinesOfText { get; }

		// +(NSUInteger)maxCharactersPerLine;
		[Static]
		[Export ("maxCharactersPerLine")]
		//[Verify (MethodToProperty)]
		nuint MaxCharactersPerLine { get; }

		// +(NSUInteger)numberOfLinesForMessage:(NSString *)text;
		[Static]
		[Export ("numberOfLinesForMessage:")]
		nuint NumberOfLinesForMessage (string text);
	}

    // @interface EaseRecordView : UIView
	[BaseType (typeof(UIView))]
	interface EaseRecordView
	{
		// @property (nonatomic) NSArray * voiceMessageAnimationImages __attribute__((annotate("ui_appearance_selector")));
		[Export ("voiceMessageAnimationImages", ArgumentSemantic.Assign)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] VoiceMessageAnimationImages { get; set; }

		// @property (nonatomic) NSString * upCancelText __attribute__((annotate("ui_appearance_selector")));
		[Export ("upCancelText")]
		string UpCancelText { get; set; }

		// @property (nonatomic) NSString * loosenCancelText __attribute__((annotate("ui_appearance_selector")));
		[Export ("loosenCancelText")]
		string LoosenCancelText { get; set; }

		// -(void)recordButtonTouchDown;
		[Export ("recordButtonTouchDown")]
		void RecordButtonTouchDown ();

		// -(void)recordButtonTouchUpInside;
		[Export ("recordButtonTouchUpInside")]
		void RecordButtonTouchUpInside ();

		// -(void)recordButtonTouchUpOutside;
		[Export ("recordButtonTouchUpOutside")]
		void RecordButtonTouchUpOutside ();

		// -(void)recordButtonDragInside;
		[Export ("recordButtonDragInside")]
		void RecordButtonDragInside ();

		// -(void)recordButtonDragOutside;
		[Export ("recordButtonDragOutside")]
		void RecordButtonDragOutside ();
	}

    // @interface EaseChatToolbarItem : NSObject
	[BaseType (typeof(NSObject))]
	interface EaseChatToolbarItem
	{
		// @property (readonly, nonatomic, strong) UIButton * button;
		[Export ("button", ArgumentSemantic.Strong)]
		UIButton Button { get; }

		// @property (nonatomic, strong) UIView * button2View;
		[Export ("button2View", ArgumentSemantic.Strong)]
		UIView Button2View { get; set; }

		// -(instancetype)initWithButton:(UIButton *)button withView:(UIView *)button2View;
		[Export ("initWithButton:withView:")]
		IntPtr Constructor (UIButton button, UIView button2View);
	}

    // @interface EaseChatToolbar : UIView
	[BaseType (typeof(UIView))]
	interface EaseChatToolbar
	{
		[Wrap ("WeakDelegate")]
		EMChatToolbarDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<EMChatToolbarDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic) UIImage * backgroundImage;
		[Export ("backgroundImage", ArgumentSemantic.Assign)]
		UIImage BackgroundImage { get; set; }

		// @property (readonly, nonatomic) EMChatToolbarType chatBarType;
		[Export ("chatBarType")]
		EMChatToolbarType ChatBarType { get; }

		// @property (readonly, nonatomic) CGFloat inputViewMaxHeight;
		[Export ("inputViewMaxHeight")]
		nfloat InputViewMaxHeight { get; }

		// @property (readonly, nonatomic) CGFloat inputViewMinHeight;
		[Export ("inputViewMinHeight")]
		nfloat InputViewMinHeight { get; }

		// @property (readonly, nonatomic) CGFloat horizontalPadding;
		[Export ("horizontalPadding")]
		nfloat HorizontalPadding { get; }

		// @property (readonly, nonatomic) CGFloat verticalPadding;
		[Export ("verticalPadding")]
		nfloat VerticalPadding { get; }

		// @property (nonatomic, strong) NSArray * inputViewLeftItems;
		[Export ("inputViewLeftItems", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] InputViewLeftItems { get; set; }

		// @property (nonatomic, strong) NSArray * inputViewRightItems;
		[Export ("inputViewRightItems", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] InputViewRightItems { get; set; }

		// @property (nonatomic, strong) EaseTextView * inputTextView;
		[Export ("inputTextView", ArgumentSemantic.Strong)]
		EaseTextView InputTextView { get; set; }

		// @property (nonatomic, strong) UIView * moreView;
		[Export ("moreView", ArgumentSemantic.Strong)]
		UIView MoreView { get; set; }

		// @property (nonatomic, strong) UIView * faceView;
		[Export ("faceView", ArgumentSemantic.Strong)]
		UIView FaceView { get; set; }

		// @property (nonatomic, strong) UIView * recordView;
		[Export ("recordView", ArgumentSemantic.Strong)]
		UIView RecordView { get; set; }

		// -(instancetype)initWithFrame:(CGRect)frame type:(EMChatToolbarType)type;
		[Export ("initWithFrame:type:")]
		IntPtr Constructor (CGRect frame, EMChatToolbarType type);

		// -(instancetype)initWithFrame:(CGRect)frame horizontalPadding:(CGFloat)horizontalPadding verticalPadding:(CGFloat)verticalPadding inputViewMinHeight:(CGFloat)inputViewMinHeight inputViewMaxHeight:(CGFloat)inputViewMaxHeight type:(EMChatToolbarType)type;
		[Export ("initWithFrame:horizontalPadding:verticalPadding:inputViewMinHeight:inputViewMaxHeight:type:")]
		IntPtr Constructor (CGRect frame, nfloat horizontalPadding, nfloat verticalPadding, nfloat inputViewMinHeight, nfloat inputViewMaxHeight, EMChatToolbarType type);

		// +(CGFloat)defaultHeight;
		[Static]
		[Export ("defaultHeight")]
		//[Verify (MethodToProperty)]
		nfloat DefaultHeight { get; }

		// -(void)cancelTouchRecord;
		[Export ("cancelTouchRecord")]
		void CancelTouchRecord ();

		// -(void)willShowBottomView:(UIView *)bottomView;
		[Export ("willShowBottomView:")]
		void WillShowBottomView (UIView bottomView);
	}

    partial interface IEMChatToolbarDelegate {}

	// @protocol EMChatToolbarDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMChatToolbarDelegate
	{
		// @optional -(void)inputTextViewDidBeginEditing:(EaseTextView *)inputTextView;
		[Export ("inputTextViewDidBeginEditing:")]
		void InputTextViewDidBeginEditing (EaseTextView inputTextView);

		// @optional -(void)inputTextViewWillBeginEditing:(EaseTextView *)inputTextView;
		[Export ("inputTextViewWillBeginEditing:")]
		void InputTextViewWillBeginEditing (EaseTextView inputTextView);

		// @optional -(void)didSendText:(NSString *)text;
		[Export ("didSendText:")]
		void DidSendText (string text);

		// @optional -(void)didSendText:(NSString *)text withExt:(NSDictionary *)ext;
		[Export ("didSendText:withExt:")]
		void DidSendText (string text, NSDictionary ext);

		// @optional -(BOOL)didInputAtInLocation:(NSUInteger)location;
		[Export ("didInputAtInLocation:")]
		bool DidInputAtInLocation (nuint location);

		// @optional -(BOOL)didDeleteCharacterFromLocation:(NSUInteger)location;
		[Export ("didDeleteCharacterFromLocation:")]
		bool DidDeleteCharacterFromLocation (nuint location);

		// @optional -(void)didSendFace:(NSString *)faceLocalPath;
		[Export ("didSendFace:")]
		void DidSendFace (string faceLocalPath);

		// @optional -(void)didStartRecordingVoiceAction:(UIView *)recordView;
		[Export ("didStartRecordingVoiceAction:")]
		void DidStartRecordingVoiceAction (UIView recordView);

		// @optional -(void)didCancelRecordingVoiceAction:(UIView *)recordView;
		[Export ("didCancelRecordingVoiceAction:")]
		void DidCancelRecordingVoiceAction (UIView recordView);

		// @optional -(void)didFinishRecoingVoiceAction:(UIView *)recordView;
		[Export ("didFinishRecoingVoiceAction:")]
		void DidFinishRecoingVoiceAction (UIView recordView);

		// @optional -(void)didDragOutsideAction:(UIView *)recordView;
		[Export ("didDragOutsideAction:")]
		void DidDragOutsideAction (UIView recordView);

		// @optional -(void)didDragInsideAction:(UIView *)recordView;
		[Export ("didDragInsideAction:")]
		void DidDragInsideAction (UIView recordView);

		// @required -(void)chatToolbarDidChangeFrameToHeight:(CGFloat)toHeight;
		[Abstract]
		[Export ("chatToolbarDidChangeFrameToHeight:")]
		void ChatToolbarDidChangeFrameToHeight (nfloat toHeight);
	}

	// @interface EaseChineseToPinyin : NSObject
	[BaseType (typeof(NSObject))]
	interface EaseChineseToPinyin
	{
		// +(NSString *)pinyinFromChineseString:(NSString *)string;
		[Static]
		[Export ("pinyinFromChineseString:")]
		string PinyinFromChineseString (string @string);

		// +(char)sortSectionTitle:(NSString *)string;
		[Static]
		[Export ("sortSectionTitle:")]
		sbyte SortSectionTitle (string @string);
	}

    partial interface IIConversationModel {}

	// @protocol IConversationModel <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IConversationModel
	{
		// @required @property (readonly, nonatomic, strong) EMConversation * conversation;
		[Abstract]
		[Export ("conversation", ArgumentSemantic.Strong)]
		EMConversation Conversation { get; }

		// @required @property (nonatomic, strong) NSString * title;
		[Abstract]
		[Export ("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// @required @property (nonatomic, strong) NSString * avatarURLPath;
		[Abstract]
		[Export ("avatarURLPath", ArgumentSemantic.Strong)]
		string AvatarURLPath { get; set; }

		// @required @property (nonatomic, strong) UIImage * avatarImage;
		[Abstract]
		[Export ("avatarImage", ArgumentSemantic.Strong)]
		UIImage AvatarImage { get; set; }

		// @required -(instancetype)initWithConversation:(EMConversation *)conversation;
		// [Abstract]
		[Export ("initWithConversation:")]
		IntPtr Constructor (EMConversation conversation);
	}

    // @interface EaseImageView : UIView
	[BaseType (typeof(UIView))]
	interface EaseImageView
	{
		// @property (nonatomic, strong) UIImageView * imageView;
		[Export ("imageView", ArgumentSemantic.Strong)]
		UIImageView ImageView { get; set; }

		// @property (nonatomic, strong) UIImage * image;
		[Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; set; }

		// @property (nonatomic) NSInteger badge;
		[Export ("badge")]
		nint Badge { get; set; }

		// @property (nonatomic) BOOL showBadge;
		[Export ("showBadge")]
		bool ShowBadge { get; set; }

		// @property (nonatomic) CGFloat imageCornerRadius __attribute__((annotate("ui_appearance_selector")));
		[Export ("imageCornerRadius")]
		nfloat ImageCornerRadius { get; set; }

		// @property (nonatomic) CGFloat badgeSize __attribute__((annotate("ui_appearance_selector")));
		[Export ("badgeSize")]
		nfloat BadgeSize { get; set; }

		// @property (nonatomic) UIFont * badgeFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("badgeFont", ArgumentSemantic.Assign)]
		UIFont BadgeFont { get; set; }

		// @property (nonatomic) UIColor * badgeTextColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("badgeTextColor", ArgumentSemantic.Assign)]
		UIColor BadgeTextColor { get; set; }

		// @property (nonatomic) UIColor * badgeBackgroudColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("badgeBackgroudColor", ArgumentSemantic.Assign)]
		UIColor BadgeBackgroudColor { get; set; }
	}

    // @interface EaseConversationCell : UITableViewCell <IModelCell>
	[BaseType (typeof(UITableViewCell))]
	interface EaseConversationCell : IModelCell
	{
		// @property (nonatomic, strong) EaseImageView * avatarView;
		[Export ("avatarView", ArgumentSemantic.Strong)]
		EaseImageView AvatarView { get; set; }

		// @property (nonatomic, strong) UILabel * detailLabel;
		[Export ("detailLabel", ArgumentSemantic.Strong)]
		UILabel DetailLabel { get; set; }

		// @property (nonatomic, strong) UILabel * timeLabel;
		[Export ("timeLabel", ArgumentSemantic.Strong)]
		UILabel TimeLabel { get; set; }

		// @property (nonatomic, strong) UILabel * titleLabel;
		[Export ("titleLabel", ArgumentSemantic.Strong)]
		UILabel TitleLabel { get; set; }

		// @property (nonatomic, strong) id<IConversationModel> model;
		[Export ("model", ArgumentSemantic.Strong)]
		new IIConversationModel Model { get; set; }

		// @property (nonatomic) BOOL showAvatar;
		[Export ("showAvatar")]
		bool ShowAvatar { get; set; }

		// @property (nonatomic) UIFont * titleLabelFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("titleLabelFont", ArgumentSemantic.Assign)]
		UIFont TitleLabelFont { get; set; }

		// @property (nonatomic) UIColor * titleLabelColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("titleLabelColor", ArgumentSemantic.Assign)]
		UIColor TitleLabelColor { get; set; }

		// @property (nonatomic) UIFont * detailLabelFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("detailLabelFont", ArgumentSemantic.Assign)]
		UIFont DetailLabelFont { get; set; }

		// @property (nonatomic) UIColor * detailLabelColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("detailLabelColor", ArgumentSemantic.Assign)]
		UIColor DetailLabelColor { get; set; }

		// @property (nonatomic) UIFont * timeLabelFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("timeLabelFont", ArgumentSemantic.Assign)]
		UIFont TimeLabelFont { get; set; }

		// @property (nonatomic) UIColor * timeLabelColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("timeLabelColor", ArgumentSemantic.Assign)]
		UIColor TimeLabelColor { get; set; }

        // -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier;
		[Export ("initWithStyle:reuseIdentifier:")]
		IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier);
	}

    // @interface EaseRefreshTableViewController : UIViewController <UITableViewDataSource, UITableViewDelegate>
    [BaseType (typeof(UIViewController))]
	interface EaseRefreshTableViewController : IUITableViewDataSource, IUITableViewDelegate
	{
		// @property (nonatomic, strong) NSArray * rightItems;
		[Export ("rightItems", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] RightItems { get; set; }

		// @property (nonatomic, strong) UIView * defaultFooterView;
		[Export ("defaultFooterView", ArgumentSemantic.Strong)]
		UIView DefaultFooterView { get; set; }

		// @property (nonatomic, strong) UITableView * tableView;
		[Export ("tableView", ArgumentSemantic.Strong)]
		UITableView TableView { get; set; }

		// @property (nonatomic, strong) NSMutableArray * dataArray;
		[Export ("dataArray", ArgumentSemantic.Strong)]
		NSMutableArray DataArray { get; set; }

		// @property (nonatomic, strong) NSMutableDictionary * dataDictionary;
		[Export ("dataDictionary", ArgumentSemantic.Strong)]
		NSMutableDictionary DataDictionary { get; set; }

		// @property (nonatomic) int page;
		[Export ("page")]
		int Page { get; set; }

		// @property (nonatomic) BOOL showRefreshHeader;
		[Export ("showRefreshHeader")]
		bool ShowRefreshHeader { get; set; }

		// @property (nonatomic) BOOL showRefreshFooter;
		[Export ("showRefreshFooter")]
		bool ShowRefreshFooter { get; set; }

		// @property (nonatomic) BOOL showTableBlankView;
		[Export ("showTableBlankView")]
		bool ShowTableBlankView { get; set; }

		// -(instancetype)initWithStyle:(UITableViewStyle)style;
		[Export ("initWithStyle:")]
		IntPtr Constructor (UITableViewStyle style);

		// -(void)tableViewDidTriggerHeaderRefresh;
		[Export ("tableViewDidTriggerHeaderRefresh")]
		void TableViewDidTriggerHeaderRefresh ();

		// -(void)tableViewDidTriggerFooterRefresh;
		[Export ("tableViewDidTriggerFooterRefresh")]
		void TableViewDidTriggerFooterRefresh ();

		// -(void)tableViewDidFinishTriggerHeader:(BOOL)isHeader reload:(BOOL)reload;
		[Export ("tableViewDidFinishTriggerHeader:reload:")]
		void TableViewDidFinishTriggerHeader (bool isHeader, bool reload);
	}

    // @interface EaseConversationModel : NSObject <IConversationModel>
	[BaseType (typeof(NSObject))]
	interface EaseConversationModel : IConversationModel
	{
		// @property (readonly, nonatomic, strong) EMConversation * conversation;
		[Export ("conversation", ArgumentSemantic.Strong)]
		new EMConversation Conversation { get; }

		// @property (nonatomic, strong) NSString * title;
		[Export ("title", ArgumentSemantic.Strong)]
        new string Title { get; set; }

		// @property (nonatomic, strong) NSString * avatarURLPath;
		[Export ("avatarURLPath", ArgumentSemantic.Strong)]
        new string AvatarURLPath { get; set; }

		// @property (nonatomic, strong) UIImage * avatarImage;
		[Export ("avatarImage", ArgumentSemantic.Strong)]
        new UIImage AvatarImage { get; set; }

		// -(instancetype)initWithConversation:(EMConversation *)conversation;
		[Export ("initWithConversation:")]
        new IntPtr Constructor (EMConversation conversation);
	}

    partial interface IEaseConversationListViewControllerDelegate {}

	// @protocol EaseConversationListViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EaseConversationListViewControllerDelegate
	{
		// @required -(void)conversationListViewController:(EaseConversationListViewController *)conversationListViewController didSelectConversationModel:(id<IConversationModel>)conversationModel;
		[Abstract]
		[Export ("conversationListViewController:didSelectConversationModel:")]
		void DidSelectConversationModel (EaseConversationListViewController conversationListViewController, IIConversationModel conversationModel);
	}

    partial interface IEaseConversationListViewControllerDataSource {}

	// @protocol EaseConversationListViewControllerDataSource <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EaseConversationListViewControllerDataSource
	{
		// @required -(id<IConversationModel>)conversationListViewController:(EaseConversationListViewController *)conversationListViewController modelForConversation:(EMConversation *)conversation;
		[Abstract]
		[Export ("conversationListViewController:modelForConversation:")]
		IIConversationModel ConversationListViewController_modelForConversation (EaseConversationListViewController conversationListViewController, EMConversation conversation);

		// @optional -(NSAttributedString *)conversationListViewController:(EaseConversationListViewController *)conversationListViewController latestMessageTitleForConversationModel:(id<IConversationModel>)conversationModel;
		[Export ("conversationListViewController:latestMessageTitleForConversationModel:")]
		NSAttributedString ConversationListViewController_latestMessageTitleForConversationModel (EaseConversationListViewController conversationListViewController, IIConversationModel conversationModel);

		// @optional -(NSString *)conversationListViewController:(EaseConversationListViewController *)conversationListViewController latestMessageTimeForConversationModel:(id<IConversationModel>)conversationModel;
		[Export ("conversationListViewController:latestMessageTimeForConversationModel:")]
		string ConversationListViewController_latestMessageTimeForConversationModel (EaseConversationListViewController conversationListViewController, IIConversationModel conversationModel);
	}

    // @interface EaseConversationListViewController : EaseRefreshTableViewController <EMChatManagerDelegate, EMGroupManagerDelegate>
	[BaseType (typeof(EaseRefreshTableViewController))]
	interface EaseConversationListViewController : IEMChatManagerDelegate, IEMGroupManagerDelegate
	{
		[Wrap ("WeakDelegate")]
		EaseConversationListViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<EaseConversationListViewControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

        [Wrap("WeakDataSource")]
        EaseConversationListViewControllerDataSource DataSource { get; set; }

        // @property (nonatomic, weak) id<EaseConversationListViewControllerDataSource> dataSource;
        [NullAllowed, Export("dataSource", ArgumentSemantic.Weak)]
        NSObject WeakDataSource { get; set; }

		// -(void)tableViewDidTriggerHeaderRefresh;
        [Override]
		[Export ("tableViewDidTriggerHeaderRefresh")]
		void TableViewDidTriggerHeaderRefresh ();

		// -(void)refreshAndSortView;
		[Export ("refreshAndSortView")]
		void RefreshAndSortView ();

		// -(void)deleteCellAction:(NSIndexPath *)aIndexPath;
		[Export ("deleteCellAction:")]
		void DeleteCellAction (NSIndexPath aIndexPath);

        // -(instancetype)initWithStyle:(UITableViewStyle)style;
		[Export ("initWithStyle:")]
		IntPtr Constructor (UITableViewStyle style);
	}

	// @interface EaseConvertToCommonEmoticonsHelper : NSObject
	[BaseType (typeof(NSObject))]
	interface EaseConvertToCommonEmoticonsHelper
	{
		// +(NSString *)convertToCommonEmoticons:(NSString *)text;
		[Static]
		[Export ("convertToCommonEmoticons:")]
		string ConvertToCommonEmoticons (string text);

		// +(NSString *)convertToSystemEmoticons:(NSString *)text;
		[Static]
		[Export ("convertToSystemEmoticons:")]
		string ConvertToSystemEmoticons (string text);
	}

	// @interface EaseCustomMessageCell : EaseBaseMessageCell
	[BaseType (typeof(EaseBaseMessageCell))]
	interface EaseCustomMessageCell
	{
        // -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier;
        [Export ("initWithStyle:reuseIdentifier:")]
        new IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier);

        // -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier model:(id)model;
        [Export ("initWithStyle:reuseIdentifier:model:")]
        new IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier, [NullAllowed] NSObject model);
	}

    // @interface EaseEmoji : NSObject
	[BaseType (typeof(NSObject))]
	interface EaseEmoji
	{
		// +(NSString *)emojiWithCode:(int)code;
		[Static]
		[Export ("emojiWithCode:")]
		string EmojiWithCode (int code);

		// +(NSArray *)allEmoji;
		[Static]
		[Export ("allEmoji")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] AllEmoji { get; }

		// +(BOOL)stringContainsEmoji:(NSString *)string;
		[Static]
		[Export ("stringContainsEmoji:")]
		bool StringContainsEmoji (string @string);
	}

	// @interface EaseEmojiEmoticons : NSObject
	[BaseType (typeof(NSObject))]
	interface EaseEmojiEmoticons
	{
		// +(NSArray *)allEmoticons;
		[Static]
		[Export ("allEmoticons")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] AllEmoticons ();

		// +(NSString *)grinningFace;
		[Static]
		[Export ("grinningFace")]
		//[Verify (MethodToProperty)]
		string GrinningFace ();

		// +(NSString *)grinningFaceWithSmilingEyes;
		[Static]
		[Export ("grinningFaceWithSmilingEyes")]
		//[Verify (MethodToProperty)]
		string GrinningFaceWithSmilingEyes ();

		// +(NSString *)faceWithTearsOfJoy;
		[Static]
		[Export ("faceWithTearsOfJoy")]
		//[Verify (MethodToProperty)]
		string FaceWithTearsOfJoy ();

		// +(NSString *)smilingFaceWithOpenMouth;
		[Static]
		[Export ("smilingFaceWithOpenMouth")]
		//[Verify (MethodToProperty)]
		string SmilingFaceWithOpenMouth ();

		// +(NSString *)smilingFaceWithOpenMouthAndSmilingEyes;
		[Static]
		[Export ("smilingFaceWithOpenMouthAndSmilingEyes")]
		//[Verify (MethodToProperty)]
		string SmilingFaceWithOpenMouthAndSmilingEyes ();

		// +(NSString *)smilingFaceWithOpenMouthAndColdSweat;
		[Static]
		[Export ("smilingFaceWithOpenMouthAndColdSweat")]
		//[Verify (MethodToProperty)]
		string SmilingFaceWithOpenMouthAndColdSweat ();

		// +(NSString *)smilingFaceWithOpenMouthAndTightlyClosedEyes;
		[Static]
		[Export ("smilingFaceWithOpenMouthAndTightlyClosedEyes")]
		//[Verify (MethodToProperty)]
		string SmilingFaceWithOpenMouthAndTightlyClosedEyes ();

		// +(NSString *)smilingFaceWithHalo;
		[Static]
		[Export ("smilingFaceWithHalo")]
		//[Verify (MethodToProperty)]
		string SmilingFaceWithHalo ();

		// +(NSString *)smilingFaceWithHorns;
		[Static]
		[Export ("smilingFaceWithHorns")]
		//[Verify (MethodToProperty)]
		string SmilingFaceWithHorns ();

		// +(NSString *)winkingFace;
		[Static]
		[Export ("winkingFace")]
		//[Verify (MethodToProperty)]
		string WinkingFace ();

		// +(NSString *)smilingFaceWithSmilingEyes;
		[Static]
		[Export ("smilingFaceWithSmilingEyes")]
		//[Verify (MethodToProperty)]
		string SmilingFaceWithSmilingEyes ();

		// +(NSString *)faceSavouringDeliciousFood;
		[Static]
		[Export ("faceSavouringDeliciousFood")]
		//[Verify (MethodToProperty)]
		string FaceSavouringDeliciousFood ();

		// +(NSString *)relievedFace;
		[Static]
		[Export ("relievedFace")]
		//[Verify (MethodToProperty)]
		string RelievedFace ();

		// +(NSString *)smilingFaceWithHeartShapedEyes;
		[Static]
		[Export ("smilingFaceWithHeartShapedEyes")]
		//[Verify (MethodToProperty)]
		string SmilingFaceWithHeartShapedEyes ();

		// +(NSString *)smilingFaceWithSunglasses;
		[Static]
		[Export ("smilingFaceWithSunglasses")]
		//[Verify (MethodToProperty)]
		string SmilingFaceWithSunglasses ();

		// +(NSString *)smirkingFace;
		[Static]
		[Export ("smirkingFace")]
		//[Verify (MethodToProperty)]
		string SmirkingFace ();

		// +(NSString *)neutralFace;
		[Static]
		[Export ("neutralFace")]
		//[Verify (MethodToProperty)]
		string NeutralFace ();

		// +(NSString *)expressionlessFace;
		[Static]
		[Export ("expressionlessFace")]
		//[Verify (MethodToProperty)]
		string ExpressionlessFace ();

		// +(NSString *)unamusedFace;
		[Static]
		[Export ("unamusedFace")]
		//[Verify (MethodToProperty)]
		string UnamusedFace ();

		// +(NSString *)faceWithColdSweat;
		[Static]
		[Export ("faceWithColdSweat")]
		//[Verify (MethodToProperty)]
		string FaceWithColdSweat ();

		// +(NSString *)pensiveFace;
		[Static]
		[Export ("pensiveFace")]
		//[Verify (MethodToProperty)]
		string PensiveFace ();

		// +(NSString *)confusedFace;
		[Static]
		[Export ("confusedFace")]
		//[Verify (MethodToProperty)]
		string ConfusedFace ();

		// +(NSString *)confoundedFace;
		[Static]
		[Export ("confoundedFace")]
		//[Verify (MethodToProperty)]
		string ConfoundedFace ();

		// +(NSString *)kissingFace;
		[Static]
		[Export ("kissingFace")]
		//[Verify (MethodToProperty)]
		string KissingFace ();

		// +(NSString *)faceThrowingAKiss;
		[Static]
		[Export ("faceThrowingAKiss")]
		//[Verify (MethodToProperty)]
		string FaceThrowingAKiss ();

		// +(NSString *)kissingFaceWithSmilingEyes;
		[Static]
		[Export ("kissingFaceWithSmilingEyes")]
		//[Verify (MethodToProperty)]
		string KissingFaceWithSmilingEyes ();

		// +(NSString *)kissingFaceWithClosedEyes;
		[Static]
		[Export ("kissingFaceWithClosedEyes")]
		//[Verify (MethodToProperty)]
		string KissingFaceWithClosedEyes ();

		// +(NSString *)faceWithStuckOutTongue;
		[Static]
		[Export ("faceWithStuckOutTongue")]
		//[Verify (MethodToProperty)]
		string FaceWithStuckOutTongue ();

		// +(NSString *)faceWithStuckOutTongueAndWinkingEye;
		[Static]
		[Export ("faceWithStuckOutTongueAndWinkingEye")]
		//[Verify (MethodToProperty)]
		string FaceWithStuckOutTongueAndWinkingEye ();

		// +(NSString *)faceWithStuckOutTongueAndTightlyClosedEyes;
		[Static]
		[Export ("faceWithStuckOutTongueAndTightlyClosedEyes")]
		//[Verify (MethodToProperty)]
		string FaceWithStuckOutTongueAndTightlyClosedEyes ();

		// +(NSString *)disappointedFace;
		[Static]
		[Export ("disappointedFace")]
		//[Verify (MethodToProperty)]
		string DisappointedFace ();

		// +(NSString *)worriedFace;
		[Static]
		[Export ("worriedFace")]
		//[Verify (MethodToProperty)]
		string WorriedFace ();

		// +(NSString *)angryFace;
		[Static]
		[Export ("angryFace")]
		//[Verify (MethodToProperty)]
		string AngryFace ();

		// +(NSString *)poutingFace;
		[Static]
		[Export ("poutingFace")]
		//[Verify (MethodToProperty)]
		string PoutingFace ();

		// +(NSString *)cryingFace;
		[Static]
		[Export ("cryingFace")]
		//[Verify (MethodToProperty)]
		string CryingFace ();

		// +(NSString *)perseveringFace;
		[Static]
		[Export ("perseveringFace")]
		//[Verify (MethodToProperty)]
		string PerseveringFace ();

		// +(NSString *)faceWithLookOfTriumph;
		[Static]
		[Export ("faceWithLookOfTriumph")]
		//[Verify (MethodToProperty)]
		string FaceWithLookOfTriumph ();

		// +(NSString *)disappointedButRelievedFace;
		[Static]
		[Export ("disappointedButRelievedFace")]
		//[Verify (MethodToProperty)]
		string DisappointedButRelievedFace ();

		// +(NSString *)frowningFaceWithOpenMouth;
		[Static]
		[Export ("frowningFaceWithOpenMouth")]
		//[Verify (MethodToProperty)]
		string FrowningFaceWithOpenMouth ();

		// +(NSString *)anguishedFace;
		[Static]
		[Export ("anguishedFace")]
		//[Verify (MethodToProperty)]
		string AnguishedFace ();

		// +(NSString *)fearfulFace;
		[Static]
		[Export ("fearfulFace")]
		//[Verify (MethodToProperty)]
		string FearfulFace ();

		// +(NSString *)wearyFace;
		[Static]
		[Export ("wearyFace")]
		//[Verify (MethodToProperty)]
		string WearyFace ();

		// +(NSString *)sleepyFace;
		[Static]
		[Export ("sleepyFace")]
		//[Verify (MethodToProperty)]
		string SleepyFace ();

		// +(NSString *)tiredFace;
		[Static]
		[Export ("tiredFace")]
		//[Verify (MethodToProperty)]
		string TiredFace ();

		// +(NSString *)grimacingFace;
		[Static]
		[Export ("grimacingFace")]
		//[Verify (MethodToProperty)]
		string GrimacingFace ();

		// +(NSString *)loudlyCryingFace;
		[Static]
		[Export ("loudlyCryingFace")]
		//[Verify (MethodToProperty)]
		string LoudlyCryingFace ();

		// +(NSString *)faceWithOpenMouth;
		[Static]
		[Export ("faceWithOpenMouth")]
		//[Verify (MethodToProperty)]
		string FaceWithOpenMouth ();

		// +(NSString *)hushedFace;
		[Static]
		[Export ("hushedFace")]
		//[Verify (MethodToProperty)]
		string HushedFace ();

		// +(NSString *)faceWithOpenMouthAndColdSweat;
		[Static]
		[Export ("faceWithOpenMouthAndColdSweat")]
		//[Verify (MethodToProperty)]
		string FaceWithOpenMouthAndColdSweat ();

		// +(NSString *)faceScreamingInFear;
		[Static]
		[Export ("faceScreamingInFear")]
		//[Verify (MethodToProperty)]
		string FaceScreamingInFear ();

		// +(NSString *)astonishedFace;
		[Static]
		[Export ("astonishedFace")]
		//[Verify (MethodToProperty)]
		string AstonishedFace ();

		// +(NSString *)flushedFace;
		[Static]
		[Export ("flushedFace")]
		//[Verify (MethodToProperty)]
		string FlushedFace ();

		// +(NSString *)sleepingFace;
		[Static]
		[Export ("sleepingFace")]
		//[Verify (MethodToProperty)]
		string SleepingFace ();

		// +(NSString *)dizzyFace;
		[Static]
		[Export ("dizzyFace")]
		//[Verify (MethodToProperty)]
		string DizzyFace ();

		// +(NSString *)faceWithoutMouth;
		[Static]
		[Export ("faceWithoutMouth")]
		//[Verify (MethodToProperty)]
		string FaceWithoutMouth ();

		// +(NSString *)faceWithMedicalMask;
		[Static]
		[Export ("faceWithMedicalMask")]
		//[Verify (MethodToProperty)]
		string FaceWithMedicalMask ();

		// +(NSString *)grinningCatFaceWithSmilingEyes;
		[Static]
		[Export ("grinningCatFaceWithSmilingEyes")]
		//[Verify (MethodToProperty)]
		string GrinningCatFaceWithSmilingEyes ();

		// +(NSString *)catFaceWithTearsOfJoy;
		[Static]
		[Export ("catFaceWithTearsOfJoy")]
		//[Verify (MethodToProperty)]
		string CatFaceWithTearsOfJoy ();

		// +(NSString *)smilingCatFaceWithOpenMouth;
		[Static]
		[Export ("smilingCatFaceWithOpenMouth")]
		//[Verify (MethodToProperty)]
		string SmilingCatFaceWithOpenMouth ();

		// +(NSString *)smilingCatFaceWithHeartShapedEyes;
		[Static]
		[Export ("smilingCatFaceWithHeartShapedEyes")]
		//[Verify (MethodToProperty)]
		string SmilingCatFaceWithHeartShapedEyes ();

		// +(NSString *)catFaceWithWrySmile;
		[Static]
		[Export ("catFaceWithWrySmile")]
		//[Verify (MethodToProperty)]
		string CatFaceWithWrySmile ();

		// +(NSString *)kissingCatFaceWithClosedEyes;
		[Static]
		[Export ("kissingCatFaceWithClosedEyes")]
		//[Verify (MethodToProperty)]
		string KissingCatFaceWithClosedEyes ();

		// +(NSString *)poutingCatFace;
		[Static]
		[Export ("poutingCatFace")]
		//[Verify (MethodToProperty)]
		string PoutingCatFace ();

		// +(NSString *)cryingCatFace;
		[Static]
		[Export ("cryingCatFace")]
		//[Verify (MethodToProperty)]
		string CryingCatFace ();

		// +(NSString *)wearyCatFace;
		[Static]
		[Export ("wearyCatFace")]
		//[Verify (MethodToProperty)]
		string WearyCatFace ();

		// +(NSString *)faceWithNoGoodGesture;
		[Static]
		[Export ("faceWithNoGoodGesture")]
		//[Verify (MethodToProperty)]
		string FaceWithNoGoodGesture ();

		// +(NSString *)faceWithOkGesture;
		[Static]
		[Export ("faceWithOkGesture")]
		//[Verify (MethodToProperty)]
		string FaceWithOkGesture ();

		// +(NSString *)personBowingDeeply;
		[Static]
		[Export ("personBowingDeeply")]
		//[Verify (MethodToProperty)]
		string PersonBowingDeeply ();

		// +(NSString *)seeNoEvilMonkey;
		[Static]
		[Export ("seeNoEvilMonkey")]
		//[Verify (MethodToProperty)]
		string SeeNoEvilMonkey ();

		// +(NSString *)hearNoEvilMonkey;
		[Static]
		[Export ("hearNoEvilMonkey")]
		//[Verify (MethodToProperty)]
		string HearNoEvilMonkey ();

		// +(NSString *)speakNoEvilMonkey;
		[Static]
		[Export ("speakNoEvilMonkey")]
		//[Verify (MethodToProperty)]
		string SpeakNoEvilMonkey ();

		// +(NSString *)happyPersonRaisingOneHand;
		[Static]
		[Export ("happyPersonRaisingOneHand")]
		//[Verify (MethodToProperty)]
		string HappyPersonRaisingOneHand ();

		// +(NSString *)personRaisingBothHandsInCelebration;
		[Static]
		[Export ("personRaisingBothHandsInCelebration")]
		//[Verify (MethodToProperty)]
		string PersonRaisingBothHandsInCelebration ();

		// +(NSString *)personFrowning;
		[Static]
		[Export ("personFrowning")]
		//[Verify (MethodToProperty)]
		string PersonFrowning ();

		// +(NSString *)personWithPoutingFace;
		[Static]
		[Export ("personWithPoutingFace")]
		//[Verify (MethodToProperty)]
		string PersonWithPoutingFace ();

		// +(NSString *)personWithFoldedHands;
		[Static]
		[Export ("personWithFoldedHands")]
		//[Verify (MethodToProperty)]
		string PersonWithFoldedHands ();
	}

	// @interface EaseEmotionEscape : NSObject
	[BaseType (typeof(NSObject))]
	interface EaseEmotionEscape
	{
		// +(EaseEmotionEscape *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		//[Verify (MethodToProperty)]
		EaseEmotionEscape SharedInstance { get; }

		// +(NSMutableAttributedString *)attributtedStringFromText:(NSString *)aInputText;
		[Static]
		[Export ("attributtedStringFromText:")]
		NSMutableAttributedString AttributtedStringFromText (string aInputText);

		// +(NSAttributedString *)attStringFromTextForChatting:(NSString *)aInputText;
		[Static]
		[Export ("attStringFromTextForChatting:")]
		NSAttributedString AttStringFromTextForChatting (string aInputText);

		// +(NSAttributedString *)attStringFromTextForInputView:(NSString *)aInputText;
		[Static]
		[Export ("attStringFromTextForInputView:")]
		NSAttributedString AttStringFromTextForInputView (string aInputText);

		// -(NSAttributedString *)attStringFromTextForChatting:(NSString *)aInputText textFont:(UIFont *)font;
		[Export ("attStringFromTextForChatting:textFont:")]
		NSAttributedString AttStringFromTextForChatting (string aInputText, UIFont font);

		// -(NSAttributedString *)attStringFromTextForInputView:(NSString *)aInputText textFont:(UIFont *)font;
		[Export ("attStringFromTextForInputView:textFont:")]
		NSAttributedString AttStringFromTextForInputView (string aInputText, UIFont font);

		// -(void)setEaseEmotionEscapePattern:(NSString *)pattern;
		[Export ("setEaseEmotionEscapePattern:")]
		void SetEaseEmotionEscapePattern (string pattern);

		// -(void)setEaseEmotionEscapeDictionary:(NSDictionary *)dict;
		[Export ("setEaseEmotionEscapeDictionary:")]
		void SetEaseEmotionEscapeDictionary (NSDictionary dict);
	}

	// @interface EMTextAttachment : NSTextAttachment
	[BaseType (typeof(NSTextAttachment))]
	interface EMTextAttachment
	{
		// @property (nonatomic, strong) NSString * imageName;
		[Export ("imageName", ArgumentSemantic.Strong)]
		string ImageName { get; set; }
	}

	// @interface EaseEmotionManager : NSObject
	[BaseType (typeof(NSObject))]
	interface EaseEmotionManager
	{
		// @property (nonatomic, strong) NSArray * emotions;
		[Export ("emotions", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] Emotions { get; set; }

		// @property (assign, nonatomic) NSInteger emotionRow;
		[Export ("emotionRow")]
		nint EmotionRow { get; set; }

		// @property (assign, nonatomic) NSInteger emotionCol;
		[Export ("emotionCol")]
		nint EmotionCol { get; set; }

		// @property (assign, nonatomic) EMEmotionType emotionType;
		[Export ("emotionType", ArgumentSemantic.Assign)]
		EMEmotionType EmotionType { get; set; }

		// @property (nonatomic, strong) UIImage * tagImage;
		[Export ("tagImage", ArgumentSemantic.Strong)]
		UIImage TagImage { get; set; }

		// -(id)initWithType:(EMEmotionType)Type emotionRow:(NSInteger)emotionRow emotionCol:(NSInteger)emotionCol emotions:(NSArray *)emotions;
		[Export ("initWithType:emotionRow:emotionCol:emotions:")]
		//[Verify (StronglyTypedNSArray)]
		IntPtr Constructor (EMEmotionType Type, nint emotionRow, nint emotionCol, NSObject[] emotions);

		// -(id)initWithType:(EMEmotionType)Type emotionRow:(NSInteger)emotionRow emotionCol:(NSInteger)emotionCol emotions:(NSArray *)emotions tagImage:(UIImage *)tagImage;
		[Export ("initWithType:emotionRow:emotionCol:emotions:tagImage:")]
		//[Verify (StronglyTypedNSArray)]
		IntPtr Constructor (EMEmotionType Type, nint emotionRow, nint emotionCol, NSObject[] emotions, UIImage tagImage);
	}

	// @interface EaseEmotion : NSObject
	[BaseType (typeof(NSObject))]
	interface EaseEmotion
	{
		// @property (assign, nonatomic) EMEmotionType emotionType;
		[Export ("emotionType", ArgumentSemantic.Assign)]
		EMEmotionType EmotionType { get; set; }

		// @property (copy, nonatomic) NSString * emotionTitle;
		[Export ("emotionTitle")]
		string EmotionTitle { get; set; }

		// @property (copy, nonatomic) NSString * emotionId;
		[Export ("emotionId")]
		string EmotionId { get; set; }

		// @property (copy, nonatomic) NSString * emotionThumbnail;
		[Export ("emotionThumbnail")]
		string EmotionThumbnail { get; set; }

		// @property (copy, nonatomic) NSString * emotionOriginal;
		[Export ("emotionOriginal")]
		string EmotionOriginal { get; set; }

		// @property (copy, nonatomic) NSString * emotionOriginalURL;
		[Export ("emotionOriginalURL")]
		string EmotionOriginalURL { get; set; }

		// -(id)initWithName:(NSString *)emotionTitle emotionId:(NSString *)emotionId emotionThumbnail:(NSString *)emotionThumbnail emotionOriginal:(NSString *)emotionOriginal emotionOriginalURL:(NSString *)emotionOriginalURL emotionType:(EMEmotionType)emotionType;
		[Export ("initWithName:emotionId:emotionThumbnail:emotionOriginal:emotionOriginalURL:emotionType:")]
		IntPtr Constructor (string emotionTitle, string emotionId, string emotionThumbnail, string emotionOriginal, string emotionOriginalURL, EMEmotionType emotionType);
	}

	// @interface EaseViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface EaseViewController
	{
		// @property (nonatomic, strong) NSArray * rightItems;
		[Export ("rightItems", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] RightItems { get; set; }

		// @property (nonatomic) BOOL endEditingWhenTap;
		[Export ("endEditingWhenTap")]
		bool EndEditingWhenTap { get; set; }
	}

    partial interface IEMLocationViewDelegate {}

	// @protocol EMLocationViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMLocationViewDelegate
	{
		// @required -(void)sendLocationLatitude:(double)latitude longitude:(double)longitude andAddress:(NSString *)address;
		[Abstract]
		[Export ("sendLocationLatitude:longitude:andAddress:")]
		void Longitude (double latitude, double longitude, string address);
	}

	// @interface EaseLocationViewController : EaseViewController
	[BaseType (typeof(EaseViewController))]
	interface EaseLocationViewController
	{
		[Wrap ("WeakDelegate")]
		EMLocationViewDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<EMLocationViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype)initWithLocation:(CLLocationCoordinate2D)locationCoordinate;
		[Export ("initWithLocation:")]
		IntPtr Constructor (CLLocationCoordinate2D locationCoordinate);
	}

	// @interface EaseMessageModel : NSObject <IMessageModel>
	[BaseType (typeof(NSObject))]
	interface EaseMessageModel : IMessageModel
	{
		// @property (nonatomic) CGFloat cellHeight;
		[Export ("cellHeight")]
		new nfloat CellHeight { get; set; }

		// @property (readonly, nonatomic, strong) EMMessage * message;
		[Export ("message", ArgumentSemantic.Strong)]
        new EMMessage Message { get; }

		// @property (readonly, nonatomic, strong) EMMessageBody * firstMessageBody;
		[Export ("firstMessageBody", ArgumentSemantic.Strong)]
		EMMessageBody FirstMessageBody { get; }

		// @property (readonly, nonatomic, strong) NSString * messageId;
		[Export ("messageId", ArgumentSemantic.Strong)]
        new string MessageId { get; }

		// @property (readonly, nonatomic) int bodyType;
		[Export ("bodyType")]
        new int BodyType { get; }

		// @property (readonly, nonatomic) int messageStatus;
		[Export ("messageStatus")]
        new int MessageStatus { get; }

		// @property (readonly, nonatomic) int messageType;
		[Export ("messageType")]
		int MessageType { get; }

		// @property (nonatomic) BOOL isMessageRead;
		[Export ("isMessageRead")]
        new bool IsMessageRead { get; set; }

		// @property (nonatomic) BOOL isSender;
		[Export ("isSender")]
        new bool IsSender { get; set; }

		// @property (nonatomic, strong) NSString * nickname;
		[Export ("nickname", ArgumentSemantic.Strong)]
        new string Nickname { get; set; }

		// @property (nonatomic, strong) NSString * avatarURLPath;
		[Export ("avatarURLPath", ArgumentSemantic.Strong)]
		new string AvatarURLPath { get; set; }

		// @property (nonatomic, strong) UIImage * avatarImage;
		[Export ("avatarImage", ArgumentSemantic.Strong)]
		new UIImage AvatarImage { get; set; }

		// @property (nonatomic, strong) NSString * text;
		[Export ("text", ArgumentSemantic.Strong)]
		new string Text { get; set; }

		// @property (nonatomic, strong) NSAttributedString * attrBody;
		[Export ("attrBody", ArgumentSemantic.Strong)]
		new NSAttributedString AttrBody { get; set; }

		// @property (nonatomic, strong) NSString * address;
		[Export ("address", ArgumentSemantic.Strong)]
		new string Address { get; set; }

		// @property (nonatomic) double latitude;
		[Export ("latitude")]
		new double Latitude { get; set; }

		// @property (nonatomic) double longitude;
		[Export ("longitude")]
		new double Longitude { get; set; }

		// @property (nonatomic, strong) NSString * failImageName;
		[Export ("failImageName", ArgumentSemantic.Strong)]
		new string FailImageName { get; set; }

		// @property (nonatomic) CGSize imageSize;
		[Export ("imageSize", ArgumentSemantic.Assign)]
		new CGSize ImageSize { get; set; }

		// @property (nonatomic) CGSize thumbnailImageSize;
		[Export ("thumbnailImageSize", ArgumentSemantic.Assign)]
		new CGSize ThumbnailImageSize { get; set; }

		// @property (nonatomic, strong) UIImage * image;
		[Export ("image", ArgumentSemantic.Strong)]
		new UIImage Image { get; set; }

		// @property (nonatomic, strong) UIImage * thumbnailImage;
		[Export ("thumbnailImage", ArgumentSemantic.Strong)]
		new UIImage ThumbnailImage { get; set; }

		// @property (nonatomic) BOOL isMediaPlaying;
		[Export ("isMediaPlaying")]
		new bool IsMediaPlaying { get; set; }

		// @property (nonatomic) BOOL isMediaPlayed;
		[Export ("isMediaPlayed")]
		new bool IsMediaPlayed { get; set; }

		// @property (nonatomic) CGFloat mediaDuration;
		[Export ("mediaDuration")]
		new nfloat MediaDuration { get; set; }

		// @property (nonatomic, strong) NSString * fileIconName;
		[Export ("fileIconName", ArgumentSemantic.Strong)]
		new string FileIconName { get; set; }

		// @property (nonatomic, strong) NSString * fileName;
		[Export ("fileName", ArgumentSemantic.Strong)]
		new string FileName { get; set; }

		// @property (nonatomic, strong) NSString * fileSizeDes;
		[Export ("fileSizeDes", ArgumentSemantic.Strong)]
		new string FileSizeDes { get; set; }

		// @property (nonatomic) CGFloat fileSize;
		[Export ("fileSize")]
		nfloat FileSize { get; set; }

		// @property (nonatomic) float progress;
		[Export ("progress")]
		new float Progress { get; set; }

		// @property (readonly, nonatomic, strong) NSString * fileLocalPath;
		[Export ("fileLocalPath", ArgumentSemantic.Strong)]
		new string FileLocalPath { get; }

		// @property (nonatomic, strong) NSString * thumbnailFileLocalPath;
		[Export ("thumbnailFileLocalPath", ArgumentSemantic.Strong)]
		new string ThumbnailFileLocalPath { get; set; }

		// @property (nonatomic, strong) NSString * fileURLPath;
		[Export ("fileURLPath", ArgumentSemantic.Strong)]
		new string FileURLPath { get; set; }

		// @property (nonatomic, strong) NSString * thumbnailFileURLPath;
		[Export ("thumbnailFileURLPath", ArgumentSemantic.Strong)]
		new string ThumbnailFileURLPath { get; set; }

		// @property (nonatomic) BOOL isDing;
		[Export ("isDing")]
		new bool IsDing { get; set; }

		// @property (nonatomic) NSInteger dingReadCount;
		[Export ("dingReadCount")]
		new nint DingReadCount { get; set; }

		// -(instancetype)initWithMessage:(EMMessage *)message;
		[Export ("initWithMessage:")]
		new IntPtr Constructor (EMMessage message);
	}

	// typedef void (^FinishBlock)(BOOL);
	delegate void FinishBlock (bool arg0);

	// typedef void (^PlayBlock)(BOOL, EaseMessageModel *);
	delegate void PlayBlock (bool arg0, EaseMessageModel arg1);

	// @interface EaseMessageReadManager : NSObject
	[BaseType (typeof(NSObject))]
	interface EaseMessageReadManager
	{
		// @property (nonatomic, strong) MWPhotoBrowser * photoBrowser;
		[Export ("photoBrowser", ArgumentSemantic.Strong)]
        Ricardo.LibMWPhotoBrowser.iOS.MWPhotoBrowser PhotoBrowser { get; set; }

		// @property (nonatomic, strong) FinishBlock finishBlock;
		[Export ("finishBlock", ArgumentSemantic.Strong)]
		FinishBlock FinishBlock { get; set; }

		// @property (nonatomic, strong) EaseMessageModel * audioMessageModel;
		[Export ("audioMessageModel", ArgumentSemantic.Strong)]
		EaseMessageModel AudioMessageModel { get; set; }

		// +(id)defaultManager;
		[Static]
		[Export ("defaultManager")]
		//[Verify (MethodToProperty)]
		NSObject DefaultManager { get; }

		// -(void)showBrowserWithImages:(NSArray *)imageArray;
		[Export ("showBrowserWithImages:")]
		//[Verify (StronglyTypedNSArray)]
		void ShowBrowserWithImages (NSObject[] imageArray);

		// -(BOOL)prepareMessageAudioModel:(EaseMessageModel *)messageModel updateViewCompletion:(void (^)(EaseMessageModel *, EaseMessageModel *))updateCompletion;
		[Export ("prepareMessageAudioModel:updateViewCompletion:")]
		bool PrepareMessageAudioModel (EaseMessageModel messageModel, [NullAllowed] Action<EaseMessageModel, EaseMessageModel> updateCompletion);

		// -(EaseMessageModel *)stopMessageAudioModel;
		[Export ("stopMessageAudioModel")]
		//[Verify (MethodToProperty)]
		EaseMessageModel StopMessageAudioModel { get; }
	}

	// @interface EaseMessageTimeCell : UITableViewCell
	[BaseType (typeof(UITableViewCell))]
	interface EaseMessageTimeCell
	{
		// @property (nonatomic, strong) NSString * title;
		[Export ("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// @property (nonatomic) UIFont * titleLabelFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("titleLabelFont", ArgumentSemantic.Assign)]
		UIFont TitleLabelFont { get; set; }

		// @property (nonatomic) UIColor * titleLabelColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("titleLabelColor", ArgumentSemantic.Assign)]
		UIColor TitleLabelColor { get; set; }

		// +(NSString *)cellIdentifier;
		[Static]
		[Export ("cellIdentifier")]
		//[Verify (MethodToProperty)]
		string CellIdentifier { get; }

        // -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier;
		[Export ("initWithStyle:reuseIdentifier:")]
		IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier);
	}

	// @interface HUD (UIViewController)
	[Category]
	[BaseType (typeof(UIViewController))]
	interface UIViewController_HUD
	{
		// -(void)showHudInView:(UIView *)view hint:(NSString *)hint;
		[Export ("showHudInView:hint:")]
		void ShowHudInView (UIView view, string hint);

		// -(void)hideHud;
		[Export ("hideHud")]
		void HideHud ();

		// -(void)showHint:(NSString *)hint;
		[Export ("showHint:")]
		void ShowHint (string hint);

		// -(void)showHint:(NSString *)hint yOffset:(float)yOffset;
		[Export ("showHint:yOffset:")]
		void ShowHint (string hint, float yOffset);
	}

	// @interface EaseSDKHelper : NSObject <EMClientDelegate>
	[BaseType (typeof(NSObject))]
	interface EaseSDKHelper : IEMClientDelegate
	{
		// @property (nonatomic) BOOL isShowingimagePicker;
		[Export ("isShowingimagePicker")]
		bool IsShowingimagePicker { get; set; }

		// @property (nonatomic) BOOL isLite;
		[Export ("isLite")]
		bool IsLite { get; set; }

		// +(instancetype)shareHelper;
		[Static]
		[Export ("shareHelper")]
		EaseSDKHelper ShareHelper ();

		// -(void)hyphenateApplication:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions appkey:(NSString *)appkey apnsCertName:(NSString *)apnsCertName otherConfig:(NSDictionary *)otherConfig;
		[Export ("hyphenateApplication:didFinishLaunchingWithOptions:appkey:apnsCertName:otherConfig:")]
		void HyphenateApplication ([NullAllowed] UIApplication application, [NullAllowed] NSDictionary launchOptions, string appkey, string apnsCertName, [NullAllowed] NSDictionary otherConfig);

		// -(void)hyphenateApplication:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo;
		[Export ("hyphenateApplication:didReceiveRemoteNotification:")]
		void HyphenateApplication ([NullAllowed] UIApplication application, [NullAllowed] NSDictionary userInfo);

		// +(EMMessage *)getTextMessage:(NSString *)text to:(NSString *)to messageType:(int)messageType messageExt:(NSDictionary *)messageExt;
		[Static]
		[Export ("getTextMessage:to:messageType:messageExt:")]
		EMMessage GetTextMessage (string text, string to, int messageType, [NullAllowed] NSDictionary messageExt);

		// +(EMMessage *)getCmdMessage:(NSString *)action to:(NSString *)to messageType:(int)messageType messageExt:(NSDictionary *)messageExt cmdParams:(NSArray *)params;
		[Static]
		[Export ("getCmdMessage:to:messageType:messageExt:cmdParams:")]
		//[Verify (StronglyTypedNSArray)]
		EMMessage GetCmdMessage (string action, string to, int messageType, [NullAllowed] NSDictionary messageExt, [NullAllowed] NSObject[] @params);

		// +(EMMessage *)getLocationMessageWithLatitude:(double)latitude longitude:(double)longitude address:(NSString *)address to:(NSString *)to messageType:(int)messageType messageExt:(NSDictionary *)messageExt;
		[Static]
		[Export ("getLocationMessageWithLatitude:longitude:address:to:messageType:messageExt:")]
		EMMessage GetLocationMessageWithLatitude (double latitude, double longitude, string address, string to, int messageType, [NullAllowed] NSDictionary messageExt);

		// +(EMMessage *)getImageMessageWithImageData:(NSData *)imageData to:(NSString *)to messageType:(int)messageType messageExt:(NSDictionary *)messageExt;
		[Static]
		[Export ("getImageMessageWithImageData:to:messageType:messageExt:")]
		EMMessage GetImageMessageWithImageData (NSData imageData, string to, int messageType, [NullAllowed] NSDictionary messageExt);

		// +(EMMessage *)getImageMessageWithImage:(UIImage *)image to:(NSString *)to messageType:(int)messageType messageExt:(NSDictionary *)messageExt;
		[Static]
		[Export ("getImageMessageWithImage:to:messageType:messageExt:")]
		EMMessage GetImageMessageWithImage (UIImage image, string to, int messageType, [NullAllowed] NSDictionary messageExt);

		// +(EMMessage *)getVoiceMessageWithLocalPath:(NSString *)localPath duration:(NSInteger)duration to:(NSString *)to messageType:(int)messageType messageExt:(NSDictionary *)messageExt;
		[Static]
		[Export ("getVoiceMessageWithLocalPath:duration:to:messageType:messageExt:")]
		EMMessage GetVoiceMessageWithLocalPath (string localPath, nint duration, string to, int messageType, [NullAllowed] NSDictionary messageExt);

		// +(EMMessage *)getVideoMessageWithURL:(NSURL *)url to:(NSString *)to messageType:(int)messageType messageExt:(NSDictionary *)messageExt;
		[Static]
		[Export ("getVideoMessageWithURL:to:messageType:messageExt:")]
		EMMessage GetVideoMessageWithURL (NSUrl url, string to, int messageType, [NullAllowed] NSDictionary messageExt);
	}

	// @interface EaseAtTarget : NSObject
	[BaseType (typeof(NSObject))]
	interface EaseAtTarget
	{
		// @property (copy, nonatomic) NSString * userId;
		[Export ("userId")]
		string UserId { get; set; }

		// @property (copy, nonatomic) NSString * nickname;
		[Export ("nickname")]
		string Nickname { get; set; }

		// -(instancetype)initWithUserId:(NSString *)userId andNickname:(NSString *)nickname;
		[Export ("initWithUserId:andNickname:")]
		IntPtr Constructor (string userId, string nickname);
	}

	// typedef void (^EaseSelectAtTargetCallback)(EaseAtTarget *);
	delegate void EaseSelectAtTargetCallback (EaseAtTarget arg0);

    partial interface IEaseMessageViewControllerDelegate {}

	// @protocol EaseMessageViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EaseMessageViewControllerDelegate
	{
		// @optional -(UITableViewCell *)messageViewController:(UITableView *)tableView cellForMessageModel:(id<IMessageModel>)messageModel;
		[Export ("messageViewController:cellForMessageModel:")]
		UITableViewCell MessageViewController_cellForMessageModel (UITableView tableView, IIMessageModel messageModel);

		// @optional -(CGFloat)messageViewController:(EaseMessageViewController *)viewController heightForMessageModel:(id<IMessageModel>)messageModel withCellWidth:(CGFloat)cellWidth;
		[Export ("messageViewController:heightForMessageModel:withCellWidth:")]
		nfloat MessageViewController_heightForMessageModel_withCellWidth (EaseMessageViewController viewController, IIMessageModel messageModel, nfloat cellWidth);

		// @optional -(void)messageViewController:(EaseMessageViewController *)viewController didReceiveHasReadAckForModel:(id<IMessageModel>)messageModel;
		[Export ("messageViewController:didReceiveHasReadAckForModel:")]
		void MessageViewController_didReceiveHasReadAckForModel (EaseMessageViewController viewController, IIMessageModel messageModel);

		// @optional -(BOOL)messageViewController:(EaseMessageViewController *)viewController didSelectMessageModel:(id<IMessageModel>)messageModel;
		[Export ("messageViewController:didSelectMessageModel:")]
		bool MessageViewController_didSelectMessageModel (EaseMessageViewController viewController, IIMessageModel messageModel);

		// @optional -(void)messageViewController:(EaseMessageViewController *)viewController didSelectAvatarMessageModel:(id<IMessageModel>)messageModel;
		[Export ("messageViewController:didSelectAvatarMessageModel:")]
		void MessageViewController_didSelectAvatarMessageModel (EaseMessageViewController viewController, IIMessageModel messageModel);

		// @optional -(void)messageViewController:(EaseMessageViewController *)viewController didSelectCallMessageModel:(id<IMessageModel>)messageModel;
		[Export ("messageViewController:didSelectCallMessageModel:")]
		void MessageViewController_didSelectCallMessageModel (EaseMessageViewController viewController, IIMessageModel messageModel);

		// @optional -(void)messageViewController:(EaseMessageViewController *)viewController didSelectMoreView:(EaseChatBarMoreView *)moreView AtIndex:(NSInteger)index;
		[Export ("messageViewController:didSelectMoreView:AtIndex:")]
		void MessageViewController_didSelectMoreView_AtIndex (EaseMessageViewController viewController, EaseChatBarMoreView moreView, nint index);

		// @optional -(void)messageViewController:(EaseMessageViewController *)viewController didSelectRecordView:(UIView *)recordView withEvenType:(EaseRecordViewType)type;
		[Export ("messageViewController:didSelectRecordView:withEvenType:")]
		void MessageViewController_didSelectRecordView_withEvenType (EaseMessageViewController viewController, UIView recordView, EaseRecordViewType type);

		// @optional -(void)messageViewController:(EaseMessageViewController *)viewController selectAtTarget:(EaseSelectAtTargetCallback)selectedCallback;
		[Export ("messageViewController:selectAtTarget:")]
		void MessageViewController_selectAtTarget (EaseMessageViewController viewController, EaseSelectAtTargetCallback selectedCallback);
	}

    partial interface IEaseMessageViewControllerDataSource {}

	// @protocol EaseMessageViewControllerDataSource <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EaseMessageViewControllerDataSource
	{
		// @optional -(id)messageViewController:(EaseMessageViewController *)viewController progressDelegateForMessageBodyType:(int)messageBodyType;
		[Export ("messageViewController:progressDelegateForMessageBodyType:")]
		NSObject MessageViewController_progressDelegateForMessageBodyType (EaseMessageViewController viewController, int messageBodyType);

		// @optional -(void)messageViewController:(EaseMessageViewController *)viewController updateProgress:(float)progress messageModel:(id<IMessageModel>)messageModel messageBody:(EMMessageBody *)messageBody;
		[Export ("messageViewController:updateProgress:messageModel:messageBody:")]
		void MessageViewController_updateProgress_messageModel_messageBody (EaseMessageViewController viewController, float progress, IIMessageModel messageModel, EMMessageBody messageBody);

		// @optional -(NSString *)messageViewController:(EaseMessageViewController *)viewController stringForDate:(NSDate *)date;
		[Export ("messageViewController:stringForDate:")]
		string MessageViewController_stringForDate (EaseMessageViewController viewController, NSDate date);

		// @optional -(id<IMessageModel>)messageViewController:(EaseMessageViewController *)viewController modelForMessage:(EMMessage *)message;
		[Export ("messageViewController:modelForMessage:")]
		IIMessageModel MessageViewController_modelForMessage (EaseMessageViewController viewController, EMMessage message);

		// @optional -(BOOL)messageViewController:(EaseMessageViewController *)viewController canLongPressRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("messageViewController:canLongPressRowAtIndexPath:")]
		bool MessageViewController_canLongPressRowAtIndexPath (EaseMessageViewController viewController, NSIndexPath indexPath);

		// @optional -(BOOL)messageViewController:(EaseMessageViewController *)viewController didLongPressRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("messageViewController:didLongPressRowAtIndexPath:")]
		bool MessageViewController_didLongPressRowAtIndexPath (EaseMessageViewController viewController, NSIndexPath indexPath);

		// @optional -(BOOL)messageViewControllerShouldMarkMessagesAsRead:(EaseMessageViewController *)viewController;
		[Export ("messageViewControllerShouldMarkMessagesAsRead:")]
		bool MessageViewControllerShouldMarkMessagesAsRead (EaseMessageViewController viewController);

		// @optional -(BOOL)messageViewController:(EaseMessageViewController *)viewController shouldSendHasReadAckForMessage:(EMMessage *)message read:(BOOL)read;
		[Export ("messageViewController:shouldSendHasReadAckForMessage:read:")]
		bool MessageViewController_shouldSendHasReadAckForMessage (EaseMessageViewController viewController, EMMessage message, bool read);

		// @optional -(BOOL)isEmotionMessageFormessageViewController:(EaseMessageViewController *)viewController messageModel:(id<IMessageModel>)messageModel;
		[Export ("isEmotionMessageFormessageViewController:messageModel:")]
		bool IsEmotionMessageFormessageViewController_messageModel (EaseMessageViewController viewController, IIMessageModel messageModel);

		// @optional -(EaseEmotion *)emotionURLFormessageViewController:(EaseMessageViewController *)viewController messageModel:(id<IMessageModel>)messageModel;
		[Export ("emotionURLFormessageViewController:messageModel:")]
		EaseEmotion EmotionURLFormessageViewController_messageModel (EaseMessageViewController viewController, IIMessageModel messageModel);

		// @optional -(NSArray *)emotionFormessageViewController:(EaseMessageViewController *)viewController;
		[Export ("emotionFormessageViewController:")]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] EmotionFormessageViewController (EaseMessageViewController viewController);

		// @optional -(NSDictionary *)emotionExtFormessageViewController:(EaseMessageViewController *)viewController easeEmotion:(EaseEmotion *)easeEmotion;
		[Export ("emotionExtFormessageViewController:easeEmotion:")]
		NSDictionary EmotionExtFormessageViewController_easeEmotion (EaseMessageViewController viewController, EaseEmotion easeEmotion);

		// @optional -(void)messageViewControllerMarkAllMessagesAsRead:(EaseMessageViewController *)viewController;
		[Export ("messageViewControllerMarkAllMessagesAsRead:")]
		void MessageViewControllerMarkAllMessagesAsRead (EaseMessageViewController viewController);
	}

    // @interface EaseMessageViewController : EaseRefreshTableViewController <UINavigationControllerDelegate, UIImagePickerControllerDelegate, EMChatManagerDelegate, EMCDDeviceManagerDelegate, EMChatToolbarDelegate, EaseChatBarMoreViewDelegate, EMLocationViewDelegate, EMChatroomManagerDelegate, EaseMessageCellDelegate>
	[BaseType (typeof(EaseRefreshTableViewController))]
	interface EaseMessageViewController : IUINavigationControllerDelegate, IUIImagePickerControllerDelegate, IEMChatManagerDelegate, IEMCDDeviceManagerDelegate, IEMChatToolbarDelegate, IEaseChatBarMoreViewDelegate, IEMLocationViewDelegate, IEMChatroomManagerDelegate, IEaseMessageCellDelegate
	{
		[Wrap ("WeakDelegate")]
		EaseMessageViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<EaseMessageViewControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

        [Wrap("WeakDataSource")]
        EaseMessageViewControllerDataSource DataSource { get; set; }

        // @property (nonatomic, weak) id<EaseMessageViewControllerDataSource> dataSource;
        [NullAllowed, Export("dataSource", ArgumentSemantic.Weak)]
        NSObject WeakDataSource { get; set; }

		// @property (nonatomic, strong) EMConversation * conversation;
		[Export ("conversation", ArgumentSemantic.Strong)]
		EMConversation Conversation { get; set; }

		// @property (nonatomic) NSTimeInterval messageTimeIntervalTag;
		[Export ("messageTimeIntervalTag")]
		double MessageTimeIntervalTag { get; set; }

		// @property (nonatomic) BOOL deleteConversationIfNull;
		[Export ("deleteConversationIfNull")]
		bool DeleteConversationIfNull { get; set; }

		// @property (nonatomic) BOOL scrollToBottomWhenAppear;
		[Export ("scrollToBottomWhenAppear")]
		bool ScrollToBottomWhenAppear { get; set; }

		// @property (nonatomic) BOOL isViewDidAppear;
		[Export ("isViewDidAppear")]
		bool IsViewDidAppear { get; set; }

		// @property (nonatomic) NSInteger messageCountOfPage;
		[Export ("messageCountOfPage")]
		nint MessageCountOfPage { get; set; }

		// @property (nonatomic) CGFloat timeCellHeight;
		[Export ("timeCellHeight")]
		nfloat TimeCellHeight { get; set; }

		// @property (nonatomic, strong) NSMutableArray * messsagesSource;
		[Export ("messsagesSource", ArgumentSemantic.Strong)]
		NSMutableArray MesssagesSource { get; set; }

		// @property (nonatomic, strong) UIView * chatToolbar;
		[Export ("chatToolbar", ArgumentSemantic.Strong)]
		UIView ChatToolbar { get; set; }

		// @property (nonatomic, strong) EaseChatBarMoreView * chatBarMoreView;
		[Export ("chatBarMoreView", ArgumentSemantic.Strong)]
		EaseChatBarMoreView ChatBarMoreView { get; set; }

		// @property (nonatomic, strong) EaseFaceView * faceView;
		[Export ("faceView", ArgumentSemantic.Strong)]
		EaseFaceView FaceView { get; set; }

		// @property (nonatomic, strong) EaseRecordView * recordView;
		[Export ("recordView", ArgumentSemantic.Strong)]
		EaseRecordView RecordView { get; set; }

		// @property (nonatomic, strong) UIMenuController * menuController;
		[Export ("menuController", ArgumentSemantic.Strong)]
		UIMenuController MenuController { get; set; }

		// @property (nonatomic, strong) NSIndexPath * menuIndexPath;
		[Export ("menuIndexPath", ArgumentSemantic.Strong)]
		NSIndexPath MenuIndexPath { get; set; }

		// @property (nonatomic, strong) UIImagePickerController * imagePicker;
		[Export ("imagePicker", ArgumentSemantic.Strong)]
		UIImagePickerController ImagePicker { get; set; }

		// @property (nonatomic) BOOL isJoinedChatroom;
		[Export ("isJoinedChatroom")]
		bool IsJoinedChatroom { get; set; }

		// -(instancetype)initWithConversationChatter:(NSString *)conversationChatter conversationType:(int)conversationType;
		[Export ("initWithConversationChatter:conversationType:")]
		IntPtr Constructor (string conversationChatter, int conversationType);

        // -(instancetype)initWithStyle:(UITableViewStyle)style;
        [Export ("initWithStyle:")]
        IntPtr Constructor (UITableViewStyle style);

        // -(void)tableViewDidTriggerHeaderRefresh;
        [Override]
        [Export ("tableViewDidTriggerHeaderRefresh")]
		void TableViewDidTriggerHeaderRefresh ();

		// -(void)sendTextMessage:(NSString *)text;
		[Export ("sendTextMessage:")]
		void SendTextMessage (string text);

		// -(void)sendTextMessage:(NSString *)text withExt:(NSDictionary *)ext;
		[Export ("sendTextMessage:withExt:")]
		void SendTextMessage (string text, [NullAllowed] NSDictionary ext);

		// -(void)sendImageMessage:(UIImage *)image;
		[Export ("sendImageMessage:")]
		void SendImageMessage (UIImage image);

		// -(void)sendLocationMessageLatitude:(double)latitude longitude:(double)longitude andAddress:(NSString *)address;
		[Export ("sendLocationMessageLatitude:longitude:andAddress:")]
		void SendLocationMessageLatitude (double latitude, double longitude, string address);

		// -(void)sendVoiceMessageWithLocalPath:(NSString *)localPath duration:(NSInteger)duration;
		[Export ("sendVoiceMessageWithLocalPath:duration:")]
		void SendVoiceMessageWithLocalPath (string localPath, nint duration);

		// -(void)sendVideoMessageWithURL:(NSURL *)url;
		[Export ("sendVideoMessageWithURL:")]
		void SendVideoMessageWithURL (NSUrl url);

		// -(void)sendFileMessageWith:(EMMessage *)message;
		[Export ("sendFileMessageWith:")]
		void SendFileMessageWith (EMMessage message);

		// -(void)sendMessage:(EMMessage *)message isNeedUploadFile:(BOOL)isUploadFile;
		[Export ("sendMessage:isNeedUploadFile:")]
		void SendMessage (EMMessage message, bool isUploadFile);

		// -(void)addMessageToDataSource:(EMMessage *)message progress:(id)progress;
		[Export ("addMessageToDataSource:progress:")]
		void AddMessageToDataSource (EMMessage message, NSObject progress);

		// -(void)showMenuViewController:(UIView *)showInView andIndexPath:(NSIndexPath *)indexPath messageType:(int)messageType;
		[Export ("showMenuViewController:andIndexPath:messageType:")]
		void ShowMenuViewController (UIView showInView, NSIndexPath indexPath, int messageType);

		// -(BOOL)shouldSendHasReadAckForMessage:(EMMessage *)message read:(BOOL)read;
		[Export ("shouldSendHasReadAckForMessage:read:")]
		bool ShouldSendHasReadAckForMessage (EMMessage message, bool read);
	}

    partial interface IIUserModel {}

	// @protocol IUserModel <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IUserModel
	{
		// @required @property (readonly, nonatomic, strong) NSString * buddy;
		[Abstract]
		[Export ("buddy", ArgumentSemantic.Strong)]
		string Buddy { get; }

		// @required @property (nonatomic, strong) NSString * nickname;
		[Abstract]
		[Export ("nickname", ArgumentSemantic.Strong)]
		string Nickname { get; set; }

		// @required @property (nonatomic, strong) NSString * avatarURLPath;
		[Abstract]
		[Export ("avatarURLPath", ArgumentSemantic.Strong)]
		string AvatarURLPath { get; set; }

		// @required @property (nonatomic, strong) UIImage * avatarImage;
		[Abstract]
		[Export ("avatarImage", ArgumentSemantic.Strong)]
		UIImage AvatarImage { get; set; }

		// @required -(instancetype)initWithBuddy:(NSString *)buddy;
		// [Abstract]
		[Export ("initWithBuddy:")]
		IntPtr Constructor (string buddy);
	}

    // @interface EaseUserModel : NSObject <IUserModel>
	[BaseType (typeof(NSObject))]
	interface EaseUserModel : IUserModel
	{
		// @property (readonly, nonatomic, strong) NSString * buddy;
		[Export ("buddy", ArgumentSemantic.Strong)]
		new string Buddy { get; }

		// @property (nonatomic, strong) NSString * nickname;
		[Export ("nickname", ArgumentSemantic.Strong)]
		new string Nickname { get; set; }

		// @property (nonatomic, strong) NSString * avatarURLPath;
		[Export ("avatarURLPath", ArgumentSemantic.Strong)]
		new string AvatarURLPath { get; set; }

		// @property (nonatomic, strong) UIImage * avatarImage;
		[Export ("avatarImage", ArgumentSemantic.Strong)]
		new UIImage AvatarImage { get; set; }

		// -(instancetype)initWithBuddy:(NSString *)buddy;
		[Export ("initWithBuddy:")]
		new IntPtr Constructor (string buddy);
	}

    // @interface EaseUserCell : UITableViewCell <IModelCell>
	[BaseType (typeof(UITableViewCell))]
	interface EaseUserCell : IModelCell
	{
		[Wrap ("WeakDelegate")]
		EaseUserCellDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<EaseUserCellDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) EaseImageView * avatarView;
		[Export ("avatarView", ArgumentSemantic.Strong)]
		EaseImageView AvatarView { get; set; }

		// @property (nonatomic, strong) UILabel * titleLabel;
		[Export ("titleLabel", ArgumentSemantic.Strong)]
		UILabel TitleLabel { get; set; }

		// @property (nonatomic, strong) id<IUserModel> model;
		[Export ("model", ArgumentSemantic.Strong)]
		new IIUserModel Model { get; set; }

		// @property (nonatomic) BOOL showAvatar;
		[Export ("showAvatar")]
		bool ShowAvatar { get; set; }

		// @property (nonatomic, strong) NSIndexPath * indexPath;
		[Export ("indexPath", ArgumentSemantic.Strong)]
		NSIndexPath IndexPath { get; set; }

		// @property (nonatomic) UIFont * titleLabelFont __attribute__((annotate("ui_appearance_selector")));
		[Export ("titleLabelFont", ArgumentSemantic.Assign)]
		UIFont TitleLabelFont { get; set; }

		// @property (nonatomic) UIColor * titleLabelColor __attribute__((annotate("ui_appearance_selector")));
		[Export ("titleLabelColor", ArgumentSemantic.Assign)]
		UIColor TitleLabelColor { get; set; }

        // -(instancetype)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier;
		[Export ("initWithStyle:reuseIdentifier:")]
		IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier);
	}

    partial interface IEaseUserCellDelegate {}

	// @protocol EaseUserCellDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EaseUserCellDelegate
	{
		// @required -(void)cellLongPressAtIndexPath:(NSIndexPath *)indexPath;
		[Abstract]
		[Export ("cellLongPressAtIndexPath:")]
		void CellLongPressAtIndexPath (NSIndexPath indexPath);
	}

    partial interface IEMUserListViewControllerDelegate {}

	// @protocol EMUserListViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMUserListViewControllerDelegate
	{
		// @required -(void)userListViewController:(EaseUsersListViewController *)userListViewController didSelectUserModel:(id<IUserModel>)userModel;
		[Abstract]
		[Export ("userListViewController:didSelectUserModel:")]
		void DidSelectUserModel (EaseUsersListViewController userListViewController, IIUserModel userModel);

		// @optional -(void)userListViewController:(EaseUsersListViewController *)userListViewController didDeleteUserModel:(id<IUserModel>)userModel;
		[Export ("userListViewController:didDeleteUserModel:")]
		void DidDeleteUserModel (EaseUsersListViewController userListViewController, IIUserModel userModel);
	}

    partial interface IEMUserListViewControllerDataSource {}

	// @protocol EMUserListViewControllerDataSource <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface EMUserListViewControllerDataSource
	{
		// @optional -(NSInteger)numberOfRowInUserListViewController:(EaseUsersListViewController *)userListViewController;
		[Export ("numberOfRowInUserListViewController:")]
		nint NumberOfRowInUserListViewController (EaseUsersListViewController userListViewController);

		// @optional -(id<IUserModel>)userListViewController:(EaseUsersListViewController *)userListViewController modelForBuddy:(NSString *)buddy;
		[Export ("userListViewController:modelForBuddy:")]
		IIUserModel UserListViewController (EaseUsersListViewController userListViewController, string buddy);

		// @optional -(id<IUserModel>)userListViewController:(EaseUsersListViewController *)userListViewController userModelForIndexPath:(NSIndexPath *)indexPath;
		[Export ("userListViewController:userModelForIndexPath:")]
		IIUserModel UserListViewController (EaseUsersListViewController userListViewController, NSIndexPath indexPath);
	}

	// @interface EaseUsersListViewController : EaseRefreshTableViewController
	[BaseType (typeof(EaseRefreshTableViewController))]
	interface EaseUsersListViewController
	{
		[Wrap ("WeakDelegate")]
		EMUserListViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<EMUserListViewControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

        [Wrap("WeakDataSource")]
        EMUserListViewControllerDataSource DataSource { get; set; }

        // @property (nonatomic, weak) id<EMUserListViewControllerDataSource> dataSource;
        [NullAllowed, Export("dataSource", ArgumentSemantic.Weak)]
        NSObject WeakDataSource { get; set; }

		// @property (nonatomic) BOOL showSearchBar;
		[Export ("showSearchBar")]
		bool ShowSearchBar { get; set; }

		// -(void)tableViewDidTriggerHeaderRefresh;
        [Override]
		[Export ("tableViewDidTriggerHeaderRefresh")]
		void TableViewDidTriggerHeaderRefresh ();

        // -(instancetype)initWithStyle:(UITableViewStyle)style;
		[Export ("initWithStyle:")]
		IntPtr Constructor (UITableViewStyle style);
	}

    // @interface Category (NSDate)
	[Category]
	[BaseType (typeof(NSDate))]
	interface NSDate_Category
	{
		// -(NSString *)timeIntervalDescription;
		[Export ("timeIntervalDescription")]
		//[Verify (MethodToProperty)]
		string TimeIntervalDescription ();

		// -(NSString *)minuteDescription;
		[Export ("minuteDescription")]
		//[Verify (MethodToProperty)]
		string MinuteDescription ();

		// -(NSString *)formattedTime;
		[Export ("formattedTime")]
		//[Verify (MethodToProperty)]
		string FormattedTime ();

		// -(NSString *)formattedDateDescription;
		[Export ("formattedDateDescription")]
		//[Verify (MethodToProperty)]
		string FormattedDateDescription ();

		// -(double)timeIntervalSince1970InMilliSecond;
		[Export ("timeIntervalSince1970InMilliSecond")]
		//[Verify (MethodToProperty)]
		double TimeIntervalSince1970InMilliSecond ();

		// +(NSDate *)dateWithTimeIntervalInMilliSecondSince1970:(double)timeIntervalInMilliSecond;
		[Static]
		[Export ("dateWithTimeIntervalInMilliSecondSince1970:")]
		NSDate DateWithTimeIntervalInMilliSecondSince1970 (double timeIntervalInMilliSecond);

		// +(NSString *)formattedTimeFromTimeInterval:(long long)time;
		[Static]
		[Export ("formattedTimeFromTimeInterval:")]
		string FormattedTimeFromTimeInterval (long time);

		// +(NSDate *)dateTomorrow;
		[Static]
		[Export ("dateTomorrow")]
		//[Verify (MethodToProperty)]
		NSDate DateTomorrow ();

		// +(NSDate *)dateYesterday;
		[Static]
		[Export ("dateYesterday")]
		//[Verify (MethodToProperty)]
		NSDate DateYesterday ();

		// +(NSDate *)dateWithDaysFromNow:(NSInteger)days;
		[Static]
		[Export ("dateWithDaysFromNow:")]
		NSDate DateWithDaysFromNow (nint days);

		// +(NSDate *)dateWithDaysBeforeNow:(NSInteger)days;
		[Static]
		[Export ("dateWithDaysBeforeNow:")]
		NSDate DateWithDaysBeforeNow (nint days);

		// +(NSDate *)dateWithHoursFromNow:(NSInteger)dHours;
		[Static]
		[Export ("dateWithHoursFromNow:")]
		NSDate DateWithHoursFromNow (nint dHours);

		// +(NSDate *)dateWithHoursBeforeNow:(NSInteger)dHours;
		[Static]
		[Export ("dateWithHoursBeforeNow:")]
		NSDate DateWithHoursBeforeNow (nint dHours);

		// +(NSDate *)dateWithMinutesFromNow:(NSInteger)dMinutes;
		[Static]
		[Export ("dateWithMinutesFromNow:")]
		NSDate DateWithMinutesFromNow (nint dMinutes);

		// +(NSDate *)dateWithMinutesBeforeNow:(NSInteger)dMinutes;
		[Static]
		[Export ("dateWithMinutesBeforeNow:")]
		NSDate DateWithMinutesBeforeNow (nint dMinutes);

		// -(BOOL)isEqualToDateIgnoringTime:(NSDate *)aDate;
		[Export ("isEqualToDateIgnoringTime:")]
		bool IsEqualToDateIgnoringTime (NSDate aDate);

		// -(BOOL)isToday;
		[Export ("isToday")]
		//[Verify (MethodToProperty)]
		bool IsToday ();

		// -(BOOL)isTomorrow;
		[Export ("isTomorrow")]
		//[Verify (MethodToProperty)]
		bool IsTomorrow ();

		// -(BOOL)isYesterday;
		[Export ("isYesterday")]
		//[Verify (MethodToProperty)]
		bool IsYesterday ();

		// -(BOOL)isSameWeekAsDate:(NSDate *)aDate;
		[Export ("isSameWeekAsDate:")]
		bool IsSameWeekAsDate (NSDate aDate);

		// -(BOOL)isThisWeek;
		[Export ("isThisWeek")]
		//[Verify (MethodToProperty)]
		bool IsThisWeek ();

		// -(BOOL)isNextWeek;
		[Export ("isNextWeek")]
		//[Verify (MethodToProperty)]
		bool IsNextWeek ();

		// -(BOOL)isLastWeek;
		[Export ("isLastWeek")]
		//[Verify (MethodToProperty)]
		bool IsLastWeek ();

		// -(BOOL)isSameMonthAsDate:(NSDate *)aDate;
		[Export ("isSameMonthAsDate:")]
		bool IsSameMonthAsDate (NSDate aDate);

		// -(BOOL)isThisMonth;
		[Export ("isThisMonth")]
		//[Verify (MethodToProperty)]
		bool IsThisMonth ();

		// -(BOOL)isSameYearAsDate:(NSDate *)aDate;
		[Export ("isSameYearAsDate:")]
		bool IsSameYearAsDate (NSDate aDate);

		// -(BOOL)isThisYear;
		[Export ("isThisYear")]
		//[Verify (MethodToProperty)]
		bool IsThisYear ();

		// -(BOOL)isNextYear;
		[Export ("isNextYear")]
		//[Verify (MethodToProperty)]
		bool IsNextYear ();

		// -(BOOL)isLastYear;
		[Export ("isLastYear")]
		//[Verify (MethodToProperty)]
		bool IsLastYear ();

		// -(BOOL)isEarlierThanDate:(NSDate *)aDate;
		[Export ("isEarlierThanDate:")]
		bool IsEarlierThanDate (NSDate aDate);

		// -(BOOL)isLaterThanDate:(NSDate *)aDate;
		[Export ("isLaterThanDate:")]
		bool IsLaterThanDate (NSDate aDate);

		// -(BOOL)isInFuture;
		[Export ("isInFuture")]
		//[Verify (MethodToProperty)]
		bool IsInFuture ();

		// -(BOOL)isInPast;
		[Export ("isInPast")]
		//[Verify (MethodToProperty)]
		bool IsInPast ();

		// -(BOOL)isTypicallyWorkday;
		[Export ("isTypicallyWorkday")]
		//[Verify (MethodToProperty)]
		bool IsTypicallyWorkday ();

		// -(BOOL)isTypicallyWeekend;
		[Export ("isTypicallyWeekend")]
		//[Verify (MethodToProperty)]
		bool IsTypicallyWeekend ();

		// -(NSDate *)dateByAddingDays:(NSInteger)dDays;
		[Export ("dateByAddingDays:")]
		NSDate DateByAddingDays (nint dDays);

		// -(NSDate *)dateBySubtractingDays:(NSInteger)dDays;
		[Export ("dateBySubtractingDays:")]
		NSDate DateBySubtractingDays (nint dDays);

		// -(NSDate *)dateByAddingHours:(NSInteger)dHours;
		[Export ("dateByAddingHours:")]
		NSDate DateByAddingHours (nint dHours);

		// -(NSDate *)dateBySubtractingHours:(NSInteger)dHours;
		[Export ("dateBySubtractingHours:")]
		NSDate DateBySubtractingHours (nint dHours);

		// -(NSDate *)dateByAddingMinutes:(NSInteger)dMinutes;
		[Export ("dateByAddingMinutes:")]
		NSDate DateByAddingMinutes (nint dMinutes);

		// -(NSDate *)dateBySubtractingMinutes:(NSInteger)dMinutes;
		[Export ("dateBySubtractingMinutes:")]
		NSDate DateBySubtractingMinutes (nint dMinutes);

		// -(NSDate *)dateAtStartOfDay;
		[Export ("dateAtStartOfDay")]
		//[Verify (MethodToProperty)]
		NSDate DateAtStartOfDay ();

		// -(NSInteger)minutesAfterDate:(NSDate *)aDate;
		[Export ("minutesAfterDate:")]
		nint MinutesAfterDate (NSDate aDate);

		// -(NSInteger)minutesBeforeDate:(NSDate *)aDate;
		[Export ("minutesBeforeDate:")]
		nint MinutesBeforeDate (NSDate aDate);

		// -(NSInteger)hoursAfterDate:(NSDate *)aDate;
		[Export ("hoursAfterDate:")]
		nint HoursAfterDate (NSDate aDate);

		// -(NSInteger)hoursBeforeDate:(NSDate *)aDate;
		[Export ("hoursBeforeDate:")]
		nint HoursBeforeDate (NSDate aDate);

		// -(NSInteger)daysAfterDate:(NSDate *)aDate;
		[Export ("daysAfterDate:")]
		nint DaysAfterDate (NSDate aDate);

		// -(NSInteger)daysBeforeDate:(NSDate *)aDate;
		[Export ("daysBeforeDate:")]
		nint DaysBeforeDate (NSDate aDate);

		// -(NSInteger)distanceInDaysToDate:(NSDate *)anotherDate;
		[Export ("distanceInDaysToDate:")]
		nint DistanceInDaysToDate (NSDate anotherDate);

		// @property (readonly) NSInteger nearestHour;
		[Export ("nearestHour")]
		nint NearestHour ();

		// @property (readonly) NSInteger hour;
		[Export ("hour")]
		nint Hour ();

		// @property (readonly) NSInteger minute;
		[Export ("minute")]
		nint Minute ();

		// @property (readonly) NSInteger seconds;
		[Export ("seconds")]
		nint Seconds ();

		// @property (readonly) NSInteger day;
		[Export ("day")]
		nint Day ();

		// @property (readonly) NSInteger month;
		[Export ("month")]
		nint Month ();

		// @property (readonly) NSInteger week;
		[Export ("week")]
		nint Week ();

		// @property (readonly) NSInteger weekday;
		[Export ("weekday")]
		nint Weekday ();

		// @property (readonly) NSInteger nthWeekday;
		[Export ("nthWeekday")]
		nint NthWeekday ();

		// @property (readonly) NSInteger year;
		[Export ("year")]
		nint Year ();
	}

	// @interface Valid (NSString)
	[Category]
	[BaseType (typeof(NSString))]
	interface NSString_Valid
	{
		// -(BOOL)isChinese;
		[Export ("isChinese")]
		//[Verify (MethodToProperty)]
		bool IsChinese ();
	}

	// @interface DismissKeyboard (UIViewController)
	[Category]
	[BaseType (typeof(UIViewController))]
	interface UIViewController_DismissKeyboard
	{
		// -(void)setupForDismissKeyboard;
		[Export ("setupForDismissKeyboard")]
		void SetupForDismissKeyboard ();
	}

	// // @interface EaseUI : NSObject
	// [BaseType (typeof(NSObject))]
	// interface EaseUI
	// {
	// }

	// @interface Category (NSDateFormatter)
	[Category]
	[BaseType (typeof(NSDateFormatter))]
	interface NSDateFormatter_Category
	{
		// +(id)dateFormatter;
		[Static]
		[Export ("dateFormatter")]
		//[Verify (MethodToProperty)]
		NSObject DateFormatter { get; }

		// +(id)dateFormatterWithFormat:(NSString *)dateFormat;
		[Static]
		[Export ("dateFormatterWithFormat:")]
		NSObject DateFormatterWithFormat (string dateFormat);

		// +(id)defaultDateFormatter;
		[Static]
		[Export ("defaultDateFormatter")]
		//[Verify (MethodToProperty)]
		NSObject DefaultDateFormatter { get; }
	}
}
