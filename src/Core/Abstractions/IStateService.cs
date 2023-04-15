﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bit.Core.Enums;
using Bit.Core.Models.Data;
using Bit.Core.Models.Domain;
using Bit.Core.Models.Response;
using Bit.Core.Models.View;

namespace Bit.Core.Abstractions
{
    public interface IStateService
    {
        List<AccountView> AccountViews { get; }
        Task<string> GetActiveUserIdAsync();
        Task<string> GetActiveUserEmailAsync();
        Task<T> GetActiveUserCustomDataAsync<T>(Func<Account, T> dataMapper);
        Task<bool> IsActiveAccountAsync(string userId = null);
        Task SetActiveUserAsync(string userId);
        Task CheckExtensionActiveUserAndSwitchIfNeededAsync();
        Task<bool> IsAuthenticatedAsync(string userId = null);
        Task<string> GetUserIdAsync(string email);
        Task RefreshAccountViewsAsync(bool allowAddAccountRow);
        Task AddAccountAsync(Account account);
        Task LogoutAccountAsync(string userId, bool userInitiated);
        Task<EnvironmentUrlData> GetPreAuthEnvironmentUrlsAsync();
        Task SetPreAuthEnvironmentUrlsAsync(EnvironmentUrlData value);
        Task<EnvironmentUrlData> GetEnvironmentUrlsAsync(string userId = null);
        Task<bool?> GetBiometricUnlockAsync(string userId = null);
        Task SetBiometricUnlockAsync(bool? value, string userId = null);
        Task<bool> GetBiometricLockedAsync(string userId = null);
        Task SetBiometricLockedAsync(bool value, string userId = null);
        Task<bool> CanAccessPremiumAsync(string userId = null);
        Task SetPersonalPremiumAsync(bool value, string userId = null);
        Task<string> GetProtectedPinAsync(string userId = null);
        Task SetProtectedPinAsync(string value, string userId = null);
        Task<string> GetPinProtectedAsync(string userId = null);
        Task SetPinProtectedAsync(string value, string userId = null);
        Task<EncString> GetPinProtectedKeyAsync(string userId = null);
        Task SetPinProtectedKeyAsync(EncString value, string userId = null);
        Task SetKdfConfigurationAsync(KdfConfig config, string userId = null);
        Task<string> GetKeyEncryptedAsync(string userId = null);
        Task SetKeyEncryptedAsync(string value, string userId = null);
        Task<SymmetricCryptoKey> GetKeyDecryptedAsync(string userId = null);
        Task SetKeyDecryptedAsync(SymmetricCryptoKey value, string userId = null);
        Task<string> GetKeyHashAsync(string userId = null);
        Task SetKeyHashAsync(string value, string userId = null);
        Task<string> GetEncKeyEncryptedAsync(string userId = null);
        Task SetEncKeyEncryptedAsync(string value, string userId = null);
        Task<Dictionary<string, string>> GetOrgKeysEncryptedAsync(string userId = null);
        Task SetOrgKeysEncryptedAsync(Dictionary<string, string> value, string userId = null);
        Task<string> GetPrivateKeyEncryptedAsync(string userId = null);
        Task SetPrivateKeyEncryptedAsync(string value, string userId = null);
        Task<List<string>> GetAutofillBlacklistedUrisAsync(string userId = null);
        Task SetAutofillBlacklistedUrisAsync(List<string> value, string userId = null);
        Task<bool?> GetAutofillTileAddedAsync();
        Task SetAutofillTileAddedAsync(bool? value);
        Task<string> GetEmailAsync(string userId = null);
        Task<string> GetNameAsync(string userId = null);
        Task SetNameAsync(string value, string userId = null);
        Task<string> GetOrgIdentifierAsync(string userId = null);
        Task<long?> GetLastActiveTimeAsync(string userId = null);
        Task SetLastActiveTimeAsync(long? value, string userId = null);
        Task<int?> GetVaultTimeoutAsync(string userId = null);
        Task SetVaultTimeoutAsync(int? value, string userId = null);
        Task<VaultTimeoutAction?> GetVaultTimeoutActionAsync(string userId = null);
        Task SetVaultTimeoutActionAsync(VaultTimeoutAction? value, string userId = null);
        Task<DateTime?> GetLastFileCacheClearAsync();
        Task SetLastFileCacheClearAsync(DateTime? value);
        Task<PreviousPageInfo> GetPreviousPageInfoAsync(string userId = null);
        Task SetPreviousPageInfoAsync(PreviousPageInfo value, string userId = null);
        Task<int> GetInvalidUnlockAttemptsAsync(string userId = null);
        Task SetInvalidUnlockAttemptsAsync(int? value, string userId = null);
        Task<string> GetLastBuildAsync();
        Task SetLastBuildAsync(string value);
        Task<bool?> GetDisableFaviconAsync(string userId = null);
        Task SetDisableFaviconAsync(bool? value, string userId = null);
        Task<bool?> GetDisableAutoTotpCopyAsync(string userId = null);
        Task SetDisableAutoTotpCopyAsync(bool? value, string userId = null);
        Task<bool?> GetInlineAutofillEnabledAsync(string userId = null);
        Task SetInlineAutofillEnabledAsync(bool? value, string userId = null);
        Task<bool?> GetAutofillDisableSavePromptAsync(string userId = null);
        Task SetAutofillDisableSavePromptAsync(bool? value, string userId = null);
        Task<Dictionary<string, Dictionary<string, object>>> GetLocalDataAsync(string userId = null);
        Task SetLocalDataAsync(Dictionary<string, Dictionary<string, object>> value, string userId = null);
        Task<Dictionary<string, CipherData>> GetEncryptedCiphersAsync(string userId = null);
        Task SetEncryptedCiphersAsync(Dictionary<string, CipherData> value, string userId = null);
        Task<int?> GetDefaultUriMatchAsync(string userId = null);
        Task SetDefaultUriMatchAsync(int? value, string userId = null);
        Task<HashSet<string>> GetNeverDomainsAsync(string userId = null);
        Task SetNeverDomainsAsync(HashSet<string> value, string userId = null);
        Task<int?> GetClearClipboardAsync(string userId = null);
        Task SetClearClipboardAsync(int? value, string userId = null);
        Task<Dictionary<string, CollectionData>> GetEncryptedCollectionsAsync(string userId = null);
        Task SetEncryptedCollectionsAsync(Dictionary<string, CollectionData> value, string userId = null);
        Task<bool> GetPasswordRepromptAutofillAsync(string userId = null);
        Task SetPasswordRepromptAutofillAsync(bool? value, string userId = null);
        Task<bool> GetPasswordVerifiedAutofillAsync(string userId = null);
        Task SetPasswordVerifiedAutofillAsync(bool? value, string userId = null);
        Task<DateTime?> GetLastSyncAsync(string userId = null);
        Task SetLastSyncAsync(DateTime? value, string userId = null);
        Task<string> GetSecurityStampAsync(string userId = null);
        Task SetSecurityStampAsync(string value, string userId = null);
        Task<bool> GetEmailVerifiedAsync(string userId = null);
        Task SetEmailVerifiedAsync(bool? value, string userId = null);
        Task<bool> GetSyncOnRefreshAsync(string userId = null);
        Task SetSyncOnRefreshAsync(bool? value, string userId = null);
        Task<string> GetRememberedEmailAsync();
        Task SetRememberedEmailAsync(string value);
        Task<string> GetRememberedOrgIdentifierAsync();
        Task SetRememberedOrgIdentifierAsync(string value);
        Task<string> GetThemeAsync(string userId = null);
        Task SetThemeAsync(string value, string userId = null);
        Task<string> GetAutoDarkThemeAsync(string userId = null);
        Task SetAutoDarkThemeAsync(string value, string userId = null);
        Task<bool?> GetAddSitePromptShownAsync(string userId = null);
        Task SetAddSitePromptShownAsync(bool? value, string userId = null);
        Task<bool?> GetPushInitialPromptShownAsync();
        Task SetPushInitialPromptShownAsync(bool? value);
        Task<DateTime?> GetPushLastRegistrationDateAsync(string userId = null);
        Task SetPushLastRegistrationDateAsync(DateTime? value, string userId = null);
        Task<string> GetPushInstallationRegistrationErrorAsync();
        Task SetPushInstallationRegistrationErrorAsync(string value);
        Task<string> GetPushCurrentTokenAsync(string userId = null);
        Task SetPushCurrentTokenAsync(string value, string userId = null);
        Task<List<EventData>> GetEventCollectionAsync();
        Task SetEventCollectionAsync(List<EventData> value);
        Task<Dictionary<string, FolderData>> GetEncryptedFoldersAsync(string userId = null);
        Task SetEncryptedFoldersAsync(Dictionary<string, FolderData> value, string userId = null);
        Task<Dictionary<string, PolicyData>> GetEncryptedPoliciesAsync(string userId = null);
        Task SetEncryptedPoliciesAsync(Dictionary<string, PolicyData> value, string userId = null);
        Task<string> GetPushRegisteredTokenAsync();
        Task SetPushRegisteredTokenAsync(string value);
        Task<bool> GetUsesKeyConnectorAsync(string userId = null);
        Task SetUsesKeyConnectorAsync(bool? value, string userId = null);
        Task<Dictionary<string, OrganizationData>> GetOrganizationsAsync(string userId = null);
        Task SetOrganizationsAsync(Dictionary<string, OrganizationData> organizations, string userId = null);
        Task<PasswordGenerationOptions> GetPasswordGenerationOptionsAsync(string userId = null);
        Task SetPasswordGenerationOptionsAsync(PasswordGenerationOptions value, string userId = null);
        Task<List<GeneratedPasswordHistory>> GetEncryptedPasswordGenerationHistory(string userId = null);
        Task SetEncryptedPasswordGenerationHistoryAsync(List<GeneratedPasswordHistory> value, string userId = null);
        Task<Dictionary<string, SendData>> GetEncryptedSendsAsync(string userId = null);
        Task SetEncryptedSendsAsync(Dictionary<string, SendData> value, string userId = null);
        Task<Dictionary<string, object>> GetSettingsAsync(string userId = null);
        Task SetSettingsAsync(Dictionary<string, object> value, string userId = null);
        Task<string> GetAccessTokenAsync(string userId = null);
        Task SetAccessTokenAsync(string value, bool skipTokenStorage, string userId = null);
        Task<string> GetRefreshTokenAsync(string userId = null);
        Task SetRefreshTokenAsync(string value, bool skipTokenStorage, string userId = null);
        Task<string> GetTwoFactorTokenAsync(string email = null);
        Task SetTwoFactorTokenAsync(string value, string email = null);
        Task<bool> GetScreenCaptureAllowedAsync(string userId = null);
        Task SetScreenCaptureAllowedAsync(bool value, string userId = null);
        Task SaveExtensionActiveUserIdToStorageAsync(string userId);
        Task<bool> GetApprovePasswordlessLoginsAsync(string userId = null);
        Task SetApprovePasswordlessLoginsAsync(bool? value, string userId = null);
        Task<PasswordlessRequestNotification> GetPasswordlessLoginNotificationAsync();
        Task SetPasswordlessLoginNotificationAsync(PasswordlessRequestNotification value);
        Task<UsernameGenerationOptions> GetUsernameGenerationOptionsAsync(string userId = null);
        Task SetUsernameGenerationOptionsAsync(UsernameGenerationOptions value, string userId = null);
        Task<bool> GetShouldConnectToWatchAsync(string userId = null);
        Task SetShouldConnectToWatchAsync(bool shouldConnect, string userId = null);
        Task<bool> GetLastUserShouldConnectToWatchAsync();
        Task SetAvatarColorAsync(string value, string userId = null);
        Task<string> GetAvatarColorAsync(string userId = null);
        Task<int?> GetAutoTyperProviderAsync(string userId = null);
        Task SetAutoTyperProvider(int? value, string userId = null);
        Task<int?> GetAutoTyperLayoutAsync(string userId = null);
        Task SetAutoTyperLayoutAsync(int? value, string userId = null);
    }
}
